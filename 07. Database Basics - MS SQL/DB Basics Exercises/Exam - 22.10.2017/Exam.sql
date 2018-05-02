--CREATE DATABASE ReportService
--USE ReportService

--01. DDL
CREATE TABLE Users
(
	Id INT PRIMARY KEY IDENTITY,
	Username NVARCHAR(30) UNIQUE NOT NULL,
	Password NVARCHAR(50) NOT NULL,
	Name NVARCHAR(50),
	Gender CHAR(1) CHECK(Gender IN ('M', 'F')),
	BirthDate DATETIME,
	Age INT,
	Email NVARCHAR(50) NOT NULL
)

CREATE TABLE Departments
(
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(50) NOT NULL
)

CREATE TABLE Employees
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(25),
	LastName NVARCHAR(25),
	Gender CHAR(1) CHECK(Gender IN ('M', 'F')),
	BirthDate DATETIME,
	Age INT,
	DepartmentId INT NOT NULL FOREIGN KEY REFERENCES Departments(Id)
)

CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY,
	Name VARCHAR(50) NOT NULL,  --NVARCHAR?
	DepartmentId INT FOREIGN KEY REFERENCES Departments(Id)
)

CREATE TABLE Status
(
	Id INT PRIMARY KEY IDENTITY,
	Label VARCHAR(30) NOT NULL,  --NVARCHAR?	
)

CREATE TABLE Reports
(
	Id INT PRIMARY KEY IDENTITY,
	CategoryId INT NOT NULL FOREIGN KEY REFERENCES Categories(Id),
	StatusId INT NOT NULL FOREIGN KEY REFERENCES Status(Id),
	OpenDate DATETIME NOT NULL,
	CloseDate DATETIME,
	Description VARCHAR(200),  --NVARCHAR?
	UserId INT NOT NULL FOREIGN KEY REFERENCES Users(Id),
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id)
)

--02. Insert
INSERT INTO Employees(FirstName, LastName, Gender, Birthdate, DepartmentId) VALUES
('Marlo', 'O’Malley', 'M', '9/21/1958', 1),
('Niki', 'Stanaghan', 'F', '11/26/1969', 4),
('Ayrton', 'Senna', 'M', '03/21/1960 ', 9),
('Ronnie', 'Peterson', 'M', '02/14/1944', 9),
('Giovanna', 'Amati', 'F', '07/20/1959', 5)

INSERT INTO Reports(CategoryId, StatusId, OpenDate, CloseDate, Description, UserId, EmployeeId) VALUES
(1, 1, '04/13/2017', NULL, 'Stuck Road on Str.133', 6, 2),
(6, 3, '09/05/2015', '12/06/2015', 'Charity trail running', 3, 5),
(14, 2, '09/07/2015', NULL, 'Falling bricks on Str.58', 5, 2),
(4, 3, '07/03/2017', '07/06/2017', 'Cut off streetlight on Str.11', 1, 1)

--03. Update
SELECT * FROM Reports
SELECT * FROM Categories
SELECT * FROM Status

UPDATE Reports
SET StatusId = 2
WHERE StatusId = 1 AND CategoryId = 4

--04. Delete
DELETE FROM Reports
WHERE StatusId = 4

--05. Users by Age
SELECT Username,
	   Age
FROM Users
ORDER BY Age ASC, Username DESC

--06. Unassigned Reports
SELECT Description,
	   OpenDate
FROM Reports
WHERE EmployeeId IS NULL
ORDER BY OpenDate ASC, Description ASC

--07. Employees & Reports
SELECT e.FirstName,
	   e.LastName,
	   r.Description,
	   FORMAT(r.OpenDate, 'yyyy-MM-dd') AS OpenDate
FROM Employees AS e
INNER JOIN Reports AS r ON e.Id = r.EmployeeId
ORDER BY e.Id ASC, r.OpenDate ASC, r.Id ASC

--08. Most Reported Category
SELECT c.Name AS CategoryName,
	   COUNT(r.Id) AS ReportsNumber
FROM Reports AS r
LEFT JOIN Categories AS c ON r.CategoryId = c.Id
GROUP BY c.Name
ORDER BY ReportsNumber DESC, CategoryName ASC

--09. Employees in Category
SELECT c.Name AS CategoryName,
	   COUNT(e.Id) AS [Employees Number]  
FROM Categories AS c
LEFT JOIN Departments AS d ON c.DepartmentId = d.Id
LEFT JOIN Employees AS e ON d.Id = e.DepartmentId
GROUP BY c.Name
ORDER BY c.Name ASC

--10. Users per Employee
SELECT CONCAT(e.FirstName, ' ', e.LastName) AS Name,
	   COUNT(r.EmployeeId) AS [Users Number]
FROM Employees AS e
LEFT JOIN Reports AS r ON e.Id = r.EmployeeId
GROUP BY CONCAT(e.FirstName, ' ', e.LastName)
ORDER BY [Users Number] DESC, Name ASC

--11. Emergency Patrol
SELECT r.OpenDate, 
	   r.Description,
	   u.Email
FROM Reports AS r
INNER JOIN Users AS u ON r.UserId = u.Id
INNER JOIN Categories AS c ON r.CategoryId = c.Id
INNER JOIN Departments AS d ON c.DepartmentId = d.Id
WHERE r.CloseDate IS NULL 
AND LEN(r.Description) > 20 AND r.Description LIKE '%str%'
AND d.Name IN ('Infrastructure', 'Emergency', 'Roads Maintenance')
ORDER BY r.OpenDate ASC, u.Email ASC, u.Id ASC

--12. Birthday Report
SELECT DISTINCT c.Name AS [Category Name]
FROM Users AS u
LEFT JOIN Reports AS r ON u.Id = r.UserId
LEFT JOIN Categories AS c ON r.CategoryId = c.Id
WHERE DATEPART(MONTH, r.OpenDate) = DATEPART(MONTH, u.BirthDate)
AND DATEPART(DAY, r.OpenDate) = DATEPART(DAY, u.BirthDate)
ORDER BY [Category Name] ASC

--13. Numbers Coincidence
SELECT DISTINCT u.Username
FROM Users AS u
LEFT JOIN Reports AS r ON u.Id = r.UserId
WHERE LEFT(u.Username, 1) = CAST(r.CategoryId AS VARCHAR(MAX))
OR RIGHT(u.Username, 1) = CAST(r.CategoryId AS VARCHAR(MAX))
ORDER BY u.Username ASC

--14. Open/Closed Statistics
SELECT CONCAT(e.FirstName, ' ', e.LastName) AS Name,
	   --sqOpened.OpenedCount,
	   --sqClosed.ClosedCount,
	   CONCAT(COALESCE(sqClosed.ClosedCount, 0), '/', COALESCE(sqOpened.OpenedCount, 0)) AS [Closed Open Reports]	  
FROM Employees AS e
LEFT JOIN (SELECT e.Id AS EmplId,
		   	   COUNT(r.Id) AS OpenedCount
		   FROM Employees AS e
		   LEFT JOIN Reports AS r ON e.Id = r.EmployeeId
		   WHERE DATEPART(YEAR, r.OpenDate) = 2016
		   GROUP BY e.Id) AS sqOpened
ON e.Id = sqOpened.EmplId
LEFT JOIN (SELECT e.Id AS EmplId,
		   	   COUNT(r.Id) AS ClosedCount
		   FROM Employees AS e
		   LEFT JOIN Reports AS r ON e.Id = r.EmployeeId
		   WHERE DATEPART(YEAR, r.CloseDate) = 2016
		   GROUP BY e.Id) AS sqClosed
ON e.Id = sqClosed.EmplId
WHERE sqOpened.OpenedCount >= 1 OR sqClosed.ClosedCount >= 1
ORDER BY Name ASC, e.Id ASC

--15. Average Closing Time
SELECT d.Name,
	   COALESCE(CAST(AVG(DATEDIFF(DAY, r.OpenDate, r.CloseDate)) AS VARCHAR(MAX)), 'no info') AS [Average Duration]
FROM Departments AS d
INNER JOIN Categories AS c ON d.Id = c.DepartmentId
INNER JOIN Reports AS r ON c.Id = r.CategoryId
GROUP BY d.Name
ORDER by d.Name ASC

--16. Favorite Categories
SELECT DISTINCT sqRanked.DeptName AS [Department Name],
		sqRanked.CatName AS [Category Name],
		CAST(ROUND(COUNT(*) / CAST(sqTotal.TotalReports AS DECIMAL(8,2)) * 100, 0) AS INT) AS Percentage
FROM Departments AS d
LEFT JOIN (SELECT d.Name AS DeptName,
				  c.Name AS CatName,
				  DENSE_RANK() OVER(PARTITION BY d.Name ORDER BY c.Name ASC) AS Rank
		  FROM Departments AS d
		  INNER JOIN Categories AS c on d.Id = c.DepartmentId
		  INNER JOIN Reports AS r on c.Id = r.CategoryId
		  WHERE r.UserId IS NOT NULL) AS sqRanked
ON d.Name = sqRanked.DeptName
INNER JOIN (SELECT d.Name,
				   COUNT(r.Id) AS TotalReports
			FROM Departments AS d
			INNER JOIN Categories AS c on d.Id = c.DepartmentId
			INNER JOIN Reports AS r on c.Id = r.CategoryId 
			GROUP BY d.Name) AS sqTotal
ON d.Name = sqTotal.Name
GROUP BY sqRanked.DeptName, sqRanked.CatName, sqTotal.TotalReports
ORDER BY [Department Name], [Category Name], Percentage

--17. Employee's Load
GO
CREATE FUNCTION udf_GetReportsCount(@employeeId INT, @statusId INT)
RETURNS INT
BEGIN
	DECLARE @result INT = (SELECT COUNT(*) FROM Reports
					   WHERE EmployeeId = @employeeId
					   AND StatusId = @statusId)

	RETURN @result
END

SELECT Id, FirstName, Lastname, dbo.udf_GetReportsCount(Id, 2) AS ReportsCount
FROM Employees
ORDER BY Id

--18. Assign Employee
GO
CREATE PROCEDURE usp_AssignEmployeeToReport(@employeeId INT, @reportId INT) 
AS
BEGIN
	DECLARE @employeesDeptId INT = (SELECT DepartmentId 
							        FROM Employees
							        WHERE Id = @employeeId)

	DECLARE @reportsDeptId INT = (SELECT c.DepartmentId
							      FROM Reports AS r
								  LEFT JOIN Categories AS c ON r.CategoryId = c.Id
							      WHERE r.Id = @reportId)

	IF @employeesDeptId <> @reportsDeptId
	BEGIN
		RAISERROR('Employee doesn''t belong to the appropriate department!', 16, 1)
		RETURN
	END

	UPDATE Reports
	SET EmployeeId = @employeeId
	WHERE Id = @reportId
END

EXEC usp_AssignEmployeeToReport 17, 2;
SELECT EmployeeId FROM Reports WHERE id = 2

--19. Close Reports
GO
CREATE TRIGGER tr_ChangeStatusOfCompletedReport ON Reports AFTER UPDATE
AS 
BEGIN
	IF (SELECT TOP 1 CloseDate FROM deleted) IS NULL AND (SELECT TOP 1 CloseDate FROM inserted) IS NOT NULL
	BEGIN
		UPDATE Reports
		SET StatusId = 3
		WHERE Id = (SELECT TOP 1 Id FROM inserted)
	END
END

UPDATE Reports
SET CloseDate = GETDATE()
WHERE EmployeeId = 5;

SELECT * FROM Reports
SELECT * FROM Status

--20. Categories Revision
SELECT c.Name AS [Category Name],
	   COUNT(r.Id) AS [Reports Number],
	   CASE
	   WHEN sq.Count / CAST(COUNT(r.Id) AS DECIMAL(8,2)) = 0.5 THEN 'equal'
	   ELSE sq.Label 
	   END AS [Main Status]
FROM Categories AS c
INNER JOIN Reports AS r ON c.Id = r.CategoryId
INNER JOIN Status AS s ON r.StatusId = s.Id
INNER JOIN (SELECT c.Name AS [CategoryName],
				   s.Label,
				   COUNT(s.Id) AS Count,
				   DENSE_RANK() OVER(PARTITION BY c.Name ORDER BY COUNT(s.Label) DESC) AS Rank
			FROM Categories AS c
			INNER JOIN Reports AS r ON c.Id = r.CategoryId
			INNER JOIN Status AS s ON r.StatusId = s.Id
			WHERE s.Label IN ('waiting', 'in progress')
			GROUP BY c.Name, s.Label) AS sq
ON c.Name = sq.CategoryName
WHERE s.Label IN ('waiting', 'in progress') AND sq.Rank = 1
GROUP BY  c.Name, sq.Count, sq.Label
ORDER BY [Category Name], [Reports Number], [Main Status]