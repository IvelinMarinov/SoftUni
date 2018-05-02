--01. Find Names of All Employees by First Name
USE SoftUni

SELECT FirstName, LastName 
FROM Employees
WHERE FirstName LIKE 'sa%'

--02. Find Names of All Employees by Last Name
SELECT FirstName, LastName 
FROM Employees
WHERE LastName LIKE '%ei%'

--03. Find First Names of All Employess
SELECT FirstName 
FROM Employees
WHERE (DepartmentID = 3 
OR DepartmentID = 10) 
AND DATEPART(YYYY, HireDate) BETWEEN 1995 AND 2005

--04. Find All Employees Except Engineers
SELECT FirstName, LastName 
FROM Employees
WHERE JobTitle NOT LIKE '%engineer%'

--05. Find Towns with Name Length
SELECT Name FROM Towns
WHERE DATALENGTH([Name]) = 5 
OR DATALENGTH([Name]) = 6
ORDER BY Name ASC

--06. Find Towns Starting With
SELECT TownID, [Name] 
FROM Towns
WHERE SUBSTRING([Name], 1, 1) IN ('m', 'k', 'b', 'e')
ORDER BY [Name] ASC
 
--07. Find Towns Not Starting With
SELECT TownID, [Name] 
FROM Towns
WHERE SUBSTRING([Name], 1, 1) NOT IN ('r', 'b', 'd')
ORDER BY [Name] ASC

--08. Create View Employees Hired After
GO
CREATE VIEW v_EmployeesHiredAfter2000 AS
SELECT FirstName, LastName FROM Employees
WHERE DATEPART(YYYY, HireDate) > 2000
GO

SELECT * FROM v_EmployeesHiredAfter2000

--09. Length of Last Name
SELECT FirstName, LastName 
FROM Employees
WHERE LEN(LastName) = 5

--10. Countries Holding 'A'
USE Geography

SELECT CountryName AS [Country Name], IsoCode AS [ISO Code] 
FROM Countries
WHERE DATALENGTH(CountryName) - DATALENGTH(REPLACE(CountryName, 'a', '')) >= 3
ORDER BY IsoCode ASC

--11. Mix of Peak and River Names
SELECT * FROM Peaks

SELECT Peaks.PeakName, 
	   Rivers.RiverName, 
	   LOWER(CONCAT(SUBSTRING(PeakName, 1, LEN(PeakName) - 1), RiverName)) AS [Mix]
FROM Peaks 
CROSS JOIN Rivers
WHERE RIGHT(PeakName, 1) = LEFT(RiverName, 1)
ORDER BY Mix 

--12. Games From 2011 and 2012 Year
USE Diablo

SELECT TOP(50) [Name], FORMAT(Start, 'yyyy-MM-dd') AS [Start] 
FROM Games
WHERE DATEPART(YYYY, Start) = 2011 
OR DATEPART(YYYY, Start) = 2012
ORDER BY [Start] ASC

--13. User Email Providers
  SELECT Username, SUBSTRING(Email, CHARINDEX('@', Email) + 1, LEN(Email) - CHARINDEX('@', Email)) 
      AS [Email Provider] FROM Users
ORDER BY [Email Provider] ASC, Username ASC

--14. Get Users with IPAddress Like Pattern
SELECT Username, IpAddress AS [IP Address] 
FROM Users
WHERE SUBSTRING(IpAddress, 4, 2) = '.1'
AND SUBSTRING(IpAddress, LEN(IpAddress) - 3, 1) = '.'
ORDER BY Username ASC

--15. Show All Games with Duration
USE Diablo

SELECT [Name] AS [Game],
  CASE 
  WHEN DATEPART(HH, Start) < 12
  THEN 'Morning' 
  WHEN DATEPART(HH, Start) < 18
  THEN 'Afternoon' 
  ELSE 'Evening' 
   END
    AS [Part of the Day],
  CASE
  WHEN Duration <= 3
  THEN 'Extra Short'
  WHEN Duration <= 6
  THEN 'Short'
  WHEN Duration > 6
  THEN 'Long'
  ELSE 'Extra Long'
   END
    AS [Duration] FROM Games
ORDER BY Name ASC, Duration ASC, [Part of the Day] ASC

--16. Orders
USE Orders
SELECT * FROM Orders

SELECT ProductName, OrderDate, 
	   DATEADD(DD, 3, Orderdate) AS [Pay Due],
	   DATEADD(mm, 1, Orderdate) AS [Deliver Due]
	   FROM dbo.Orders

--17. People Table
CREATE TABLE People 
(
	Id INT NOT NULL IDENTITY PRIMARY KEY,
	[Name] NVARCHAR(50) NOT NULL,
	Birthdate DATETIME NOT NULL
)

USE Orders

INSERT INTO People VALUES
('Victor', '2000-12-07 00:00:00.000'),
('Steven', '1992-09-10 00:00:00.000'),
('Stephen', '1910-09-19 00:00:00.000'),
('John', '2010-01-06 00:00:00.000'),
('Με', '1986-07-25 00:00:00.000')

SELECT [Name], 
		DATEDIFF(YEAR, Birthdate, GETDATE()) AS [Age in Years],
		DATEDIFF(MONTH, Birthdate, GETDATE()) AS [Age in Months],
		DATEDIFF(DAY, Birthdate, GETDATE()) AS [Age in Days],
		DATEDIFF(MINUTE, Birthdate, GETDATE()) AS [Age in Minutes]
		FROM People

SELECT * FROM People