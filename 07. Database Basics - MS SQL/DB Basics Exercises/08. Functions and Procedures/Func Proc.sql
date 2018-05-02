USE SoftUni
GO

--01. Employees with Salary Above 35000
CREATE PROCEDURE usp_GetEmployeesSalaryAbove35000 
AS
SELECT FirstName, LastName FROM Employees
WHERE Salary > 35000
GO

EXEC dbo.usp_GetEmployeesSalaryAbove35000
GO

--02. Employees with Salary Above Number
CREATE PROCEDURE usp_GetEmployeesSalaryAboveNumber (@SalaryLimit DECIMAL(18,4)) 
AS
SELECT FirstName, LastName FROM Employees
WHERE Salary >= @SalaryLimit
GO

EXEC dbo.usp_GetEmployeesSalaryAboveNumber 50000
GO

--03. Town Names Starting With
CREATE PROCEDURE usp_GetTownsStartingWith (@TownNameBeginning NVARCHAR(10))
AS
SELECT [Name] AS [Town] 
  FROM Towns
 WHERE [Name] LIKE (@TownNameBeginning + '%')
GO

EXEC dbo.usp_GetTownsStartingWith b
GO

--04. Employees from Town
CREATE PROCEDURE usp_GetEmployeesFromTown (@TownName NVARCHAR(10))
AS
   SELECT e.FirstName AS [First Name], 
		  e.LastName AS [Last Name]
     FROM Employees AS e
LEFT JOIN Addresses AS a
		ON a.AddressID = e.AddressID
LEFT JOIN Towns AS t
		ON a.TownID = t.TownID
	 WHERE t.[Name] = @TownName
GO

EXEC dbo.usp_GetEmployeesFromTown Sofia
GO

--05. Salary Level Function
CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4)) 
RETURNS NVARCHAR(10)
AS
BEGIN
	DECLARE @SalaryLevel NVARCHAR(10)
	IF (@salary < 30000)
	BEGIN
		SET @SalaryLevel = 'Low'
	END
	ELSE IF (@salary >= 30000 AND @salary <= 50000)
	BEGIN
		SET @SalaryLevel = 'Average'
	END
	ELSE 
	BEGIN
		SET @SalaryLevel = 'High'
	END

	RETURN @SalaryLevel
END
GO

SELECT Salary,
	   dbo.ufn_GetSalaryLevel(Salary) AS [Salary Level]
 FROM Employees
GO

--06. Employees by Salary Level
CREATE PROCEDURE usp_EmployeesBySalaryLevel(@SalaryLevel NVARCHAR(10))
AS
SELECT FirstName AS [First Name],
	   LastName AS [Last Name]
 FROM Employees
 WHERE dbo.ufn_GetSalaryLevel(Salary) = @SalaryLevel 
GO

EXEC dbo.usp_EmployeesBySalaryLevel high
GO

--07. Define Function
CREATE FUNCTION ufn_IsWordComprised(@setOfLetters NVARCHAR(200), @word NVARCHAR(200))
RETURNS BIT
AS
BEGIN
	DECLARE @result BIT = 1
	DECLARE @i INT = 1
	DECLARE @currentSymbol CHAR

	WHILE @i <= LEN(@word) 
	BEGIN
		SET @currentSymbol = RIGHT(LEFT(@word, @i), 1)
		IF (CHARINDEX(@currentSymbol, @setOfLetters, 1) < 1)
		BEGIN
			SET @result = 0
		END

		SET @i += 1		
	END
	
	RETURN @result
END
GO

SELECT dbo.ufn_IsWordComprised('ppppp', 'ppg')

--08. Delete Employees and Departments
BACKUP DATABASE SoftUni 
TO DISK = 'D:\_Projects\SoftUni\07. Database Basics - MS SQL\SoftUni.bak'
GO

CREATE OR ALTER PROCEDURE usp_DeleteEmployeesFromDepartment (@departmentId INT)
AS

SELECT 0
	ALTER TABLE Departments
	ALTER COLUMN ManagerID INT NULL

	--ALTER TABLE EmployeesProjects
	--DROP CONSTRAINT PK_EmployeesProjects

	ALTER TABLE EmployeesProjects
	DROP CONSTRAINT IF EXISTS FK_EmployeesProjects_Employees

	ALTER TABLE EmployeesProjects
	DROP CONSTRAINT IF EXISTS FK_Employees_Departments
	
	ALTER TABLE EmployeesProjects
	ALTER COLUMN EmployeeID INT NULL
		
	DELETE FROM Employees
	WHERE DepartmentID = @departmentId

	DELETE FROM Departments
	WHERE DepartmentID = @departmentId

	SELECT COUNT(*) FROM Employees
	WHERE DepartmentID = @departmentId
GO

EXEC dbo.usp_DeleteEmployeesFromDepartment 7

USE master
RESTORE DATABASE SoftUni
FROM DISK = 'D:\_Projects\SoftUni\07. Database Basics - MS SQL\SoftUni.bak'

SELECT * FROM Employees
SELECT * FROM Departments
SELECT * FROM EmployeesProjects

--09. Find Full Name
USE Bank
GO

CREATE PROCEDURE usp_GetHoldersFullName
AS
	SELECT FirstName + ' ' + LastName AS [Full Name]
	 FROM AccountHolders

EXEC dbo.usp_GetHoldersFullName
GO

--10. People with Balance Higher Than
CREATE PROCEDURE usp_GetHoldersWithBalanceHigherThan (@amount DECIMAL(15,2))
AS
    SELECT ah.FirstName AS [First Name],
		   ah.LastName AS [Last Name]
	  FROM AccountHolders AS ah
 LEFT JOIN Accounts AS a
   	    ON ah.Id = a.AccountHolderId
  GROUP BY ah.FirstName, ah.LastName
    HAVING SUM(a.Balance) > @amount
GO

EXEC dbo.usp_GetHoldersWithBalanceHigherThan 1000
GO

--11. Future Value Function
CREATE FUNCTION ufn_CalculateFutureValue (@sum MONEY, @yearlyInterestRate FLOAT, @numOfYears INT)
RETURNS DECIMAL(15,4)
BEGIN
	DECLARE @result DECIMAL(15,4)
	SET @result = @sum * (POWER((1 + @yearlyInterestRate), @numOfYears))
	RETURN @result
END
GO

SELECT dbo.ufn_CalculateFutureValue(123.12, 0.1, 5)
GO

--12. Calculating Interest
CREATE PROCEDURE usp_CalculateFutureValueForAccount(@accountID INT, @rate DECIMAL(15,4))
AS
   SELECT a.Id AS [Account Id],
	      ah.FirstName AS [First Name] ,
	      ah.LastName AS [Last Name] ,
   	      a.Balance AS [Current Balance],
	      dbo.ufn_CalculateFutureValue(a.Balance, @rate, 5) AS [Balance in 5 years]
     FROM AccountHolders AS ah
LEFT JOIN Accounts as a
	   ON ah.Id = a.AccountHolderId
	WHERE a.Id = @accountID

EXEC dbo.usp_CalculateFutureValueForAccount 1, 0.1
GO

--13. *Cash in User Games Odd Rows
CREATE FUNCTION ufn_CashInUsersGames (@gameName NVARCHAR(100))
RETURNS TABLE 
	RETURN 
	(SELECT SUM(Cash) AS SumCash
	FROM (   
		SELECT g.Name, 
		       ug.Cash,
			   ROW_NUMBER() OVER(ORDER BY ug.Cash DESC) AS RowNum
		FROM Games AS g
		LEFT JOIN UsersGames AS ug
		ON g.Id = ug.GameId
		WHERE Name = @gameName) AS CashList
		--WHERE g.Name = 'Love in a mist') AS a
	WHERE RowNum % 2 = 1)
GO

SELECT * FROM dbo.ufn_CashInUsersGames ('Lily Stargazer')