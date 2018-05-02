--01. Create Table Logs
USE Bank

CREATE TABLE Logs
(
	LogId INT NOT NULL IDENTITY PRIMARY KEY,
	AccountId INT NOT NULL FOREIGN KEY REFERENCES Accounts(Id),
	OldSum DECIMAL(15,2) NOT NULL,
	NewSum DECIMAL(15,2) NOT NULL
)

ALTER TABLE Logs
DROP COLUMN Amount
GO

CREATE OR ALTER TRIGGER tr_BalanceChangeLog ON Accounts FOR UPDATE
AS 
BEGIN TRANSACTION
	INSERT INTO Logs (AccountId, OldSum, NewSum)
	SELECT d.Id, 
		   d.Balance, 
		   i.Balance
	FROM deleted AS d
	LEFT JOIN inserted as i
	ON d.Id = i.Id

UPDATE Accounts
SET Balance += 50
WHERE Id = 1
COMMIT

--02. Create Table Emails
DROP TABLE NotificationEmails

CREATE TABLE NotificationEmails
(
	Id INT NOT NULL PRIMARY KEY IDENTITY, 
	Recipient INT NOT NULL, 
	[Subject] VARCHAR(100) NOT NULL, 
	Body VARCHAR(500) NOT NULL
)
GO

CREATE OR ALTER TRIGGER tr_SendNotificationEmail ON Logs FOR INSERT
AS
BEGIN TRANSACTION
	INSERT INTO NotificationEmails (Recipient, Subject, Body)
	SELECT TOP 1 AccountId, 
		   'Balance change for account: ' + CAST(AccountId AS VARCHAR(10)),
		   'On ' + CONVERT(VARCHAR(20), GETDATE(), 100) + ' your balance was changed from ' + CAST(OldSum AS VARCHAR(10)) + ' to ' + CAST(NewSum AS VARCHAR(10))
	  FROM Logs
	  ORDER BY LogId DESC
COMMIT
GO

--03. Deposit Money
CREATE OR ALTER PROCEDURE usp_DepositMoney (@AccountId INT, @MoneyAmount DECIMAL(15,4)) 
AS
	BEGIN TRANSACTION
	IF (@MoneyAmount < 0)
	BEGIN
		RAISERROR('Cannot deposit negative amont', 15, 1)
		RETURN
	END
	UPDATE Accounts
	SET Balance += @MoneyAmount
	WHERE Id = @AccountId
	COMMIT

EXEC dbo.usp_DepositMoney 1, 50
GO

--04. Withdraw Money Procedure
CREATE OR ALTER PROCEDURE usp_WithdrawMoney(@AccountId INT, @MoneyAmount DECIMAL(15,4)) 
AS
BEGIN TRANSACTION
	IF (@MoneyAmount < 0)
	BEGIN
		RAISERROR('Cannot withdraw negative amont', 15, 1)
		RETURN
	END
	DECLARE @CurrentBalance INT = (SELECT Balance FROM Accounts 
								   WHERE Id = @AccountId)
	IF (@CurrentBalance - @MoneyAmount < 0)
	BEGIN
		RAISERROR('Insuficient Funds', 15, 1)
		RETURN
	END
	UPDATE Accounts
	SET Balance -= @MoneyAmount
	WHERE Id = @AccountId
COMMIT

EXEC dbo.usp_WithdrawMoney 1, 500
GO

--05. Money Transfer
CREATE OR ALTER PROCEDURE usp_TransferMoney(@SenderId INT, @ReceiverId INT, @Amount DECIMAL(15,4)) 
AS
BEGIN TRANSACTION 
EXEC dbo.usp_WithdrawMoney @SenderId, @Amount
EXEC dbo.usp_DepositMoney @ReceiverId, @Amount
COMMIT

EXEC dbo.usp_TransferMoney 1, 2, 50
GO

--06. Trigger
--1)
CREATE TRIGGER tr_UsersItemsLevelLimit ON UserGameItems INSTEAD OF INSERT
AS
BEGIN TRANSACTION

DECLARE @UserLevel INT = (SELECT ug.Level FROM UsersGames AS ug
					  INNER JOIN inserted AS ins ON ug.Id = ins.UserGameId)

DECLARE @ItemMinLevel INT = (SELECT i.Id FROM Items as i
						 INNER JOIN inserted AS ins on i.Id = ins.ItemId)

IF (@UserLevel < @ItemMinLevel)
BEGIN
	RAISERROR('Cannot purchase item with level, higher than user level', 16, 1)
	ROLLBACK
END

ELSE
BEGIN
	INSERT INTO UserGameItems(ItemId, UserGameId)
	SELECT ItemId, UserGameId FROM inserted
END
COMMIT

SELECT * FROM Items
SELECT * FROM UsersGames
SELECT * FROM UserGameItems

--2)
UPDATE UsersGames 
SET Cash += 50000
FROM UsersGames AS ug
LEFT JOIN Users AS u
ON ug.UserId = u.Id
LEFT JOIN Games AS g
ON ug.GameId = g.Id
WHERE u.Username IN ('baleremuda', 'loosenoise', 'inguinalself', 'buildingdeltoid', 'monoxidecos' )
AND g.Name = 'Bali'

--3)

--07. *Massive Shopping
DROP TRIGGER IF EXISTS  dbo.tr_UsersItemsLevelLimit

BEGIN TRANSACTION

DECLARE @StamatsGameId INT = (SELECT ug.Id FROM Users AS u
						      LEFT JOIN UsersGames AS ug ON u.Id = ug.UserId
						      LEFT JOIN Games AS g ON ug.GameId = g.Id
						      WHERE u.Username = 'Stamat' AND g.Name = 'Safflower')

DECLARE @StamatsCash DECIMAL(15,4) = (SELECT Cash FROM UsersGames 
									  WHERE Id = 110)

DECLARE @Sum DECIMAL(15,4) = (SELECT SUM(i.Price)
					          FROM Items AS i
						      WHERE MinLevel BETWEEN 11 AND 12)

IF (@StamatsCash < @Sum)
BEGIN
   ROLLBACK
END
ELSE 
BEGIN
	UPDATE UsersGames
	   SET Cash -= @Sum
	 WHERE Id = @StamatsGameId

INSERT INTO UserGameItems (UserGameId, ItemId)
	 SELECT @StamatsGameId, Id 
	   FROM Items 
	  WHERE MinLevel BETWEEN 11 AND 12
	 COMMIT
END

BEGIN TRANSACTION

DECLARE @Sum2 DECIMAL = (SELECT SUM(i.Price)
						   FROM Items i
						  WHERE MinLevel BETWEEN 19 AND 21)

IF @StamatsCash < @Sum2
BEGIN
	ROLLBACK
END
ELSE 
BEGIN
	UPDATE UsersGames
	   SET Cash -= @sum2
	 WHERE Id = @StamatsGameId

INSERT INTO UserGameItems (UserGameId, ItemId)
     SELECT @StamatsGameId, Id 
	   FROM Items 
	  WHERE MinLevel BETWEEN 19 AND 21
	 COMMIT
END

SELECT i.Name AS [Item Name] 
  FROM UserGameItems ugi
  JOIN Items i ON ugi.ItemId = i.Id
WHERE ugi.UserGameId = @StamatsGameId

--08. Employees with Three Projects
USE SoftUni
GO

CREATE OR ALTER PROCEDURE usp_AssignProject(@emloyeeId INT, @projectID INT) 
AS
BEGIN TRANSACTION
	DECLARE @ProjectsCount INT
	SET @ProjectsCount = (SELECT COUNT(ProjectID) AS ProjectsCount
						  FROM EmployeesProjects
						  GROUP BY EmployeeID
						  HAVING EmployeeID = @emloyeeId)
	IF(@ProjectsCount >= 3)
	BEGIN
		RAISERROR('The employee has too many projects!', 16, 1)
		ROLLBACK
		RETURN
	END

	INSERT INTO EmployeesProjects(EmployeeID, ProjectID)
	VALUES (@emloyeeId, @projectID)
COMMIT

EXEC dbo.usp_AssignProject 1, 5

--09. Delete Employees
DROP TABLE Deleted_Employees

CREATE TABLE Deleted_Employees
(
	EmployeeId INT NOT NULL PRIMARY KEY IDENTITY, 
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	MiddleName VARCHAR(50) NOT NULL,
	JobTitle VARCHAR(50) NOT NULL,
	DepartmentID INT NOT NULL,
	Salary DECIMAL(15,4) NOT NULL
) 
GO

CREATE OR ALTER TRIGGER tr_MoveFiredEmployees ON Employees FOR DELETE
AS
BEGIN TRANSACTION
	INSERT INTO Deleted_Employees(FirstName, LastName, MiddleName, JobTitle, DepartmentId, Salary)
	(SELECT 
			d.FirstName,
			d.LastName,
			d.MiddleName,
			d.JobTitle,
			d.DepartmentID,
			d.Salary
	 FROM deleted AS d)
COMMIT

DELETE FROM Employees
WHERE EmployeeID = 8

SELECT * FROM Deleted_Employees
SELECT * FROM Employees