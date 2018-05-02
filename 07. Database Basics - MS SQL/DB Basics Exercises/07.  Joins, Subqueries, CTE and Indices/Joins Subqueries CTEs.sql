USE SoftUni

--01. Employee Address
SELECT TOP (5) e.EmployeeID, 
			   e.JobTitle, 
			   e.AddressID, 
			   a.AddressText 
		  FROM Employees AS e
    INNER JOIN Addresses AS a
			ON e.AddressID = a.AddressID
	  ORDER BY e.AddressID ASC

--02. Addresses with Towns
SELECT TOP (50) e.FirstName, 
				e.LastName, 
				t.[Name] AS Town, 
				a.AddressText
		   FROM Employees AS e
	 INNER JOIN Addresses AS a
			 ON e.AddressID = a.AddressID
	 INNER JOIN Towns AS t
			 ON a.TownID = t.TownID
	   ORDER BY e.FirstName ASC, e.LastName ASC

--03. Sales Employees
    SELECT e.EmployeeID, 
	       e.FirstName, 
		   e.LastName, 
	       d.[Name]  
      FROM Employees AS e
INNER JOIN Departments AS d
		ON e.DepartmentID = d.DepartmentID
	 WHERE d.[Name] = 'Sales'
  ORDER BY e.EmployeeID ASC

--04. Employee Departments
SELECT TOP (5) e.EmployeeID, 
			   e.FirstName, 
			   e.Salary, 
			   d.[Name] AS DepartmentName
		  FROM Employees AS e
	INNER JOIN Departments AS d
			ON e.DepartmentID = d.DepartmentID
		 WHERE e.Salary > 15000
	  ORDER BY e.DepartmentID ASC

--05. Employees Without Projects
 SELECT TOP (3) e.EmployeeID, 
			    e.FirstName
		   FROM Employees AS e
LEFT OUTER JOIN EmployeesProjects AS ep
			 ON e.EmployeeID = ep.EmployeeID
LEFT OUTER JOIN Projects AS p
			 ON ep.ProjectID = p.ProjectID
		  WHERE p.ProjectID IS NULL
	   ORDER BY e.EmployeeID ASC

--06. Employees Hired After
    SELECT e.FirstName, 
		   e.LastName, 
	       e.HireDate, 
	       d.[Name] AS DeptName
	  FROM Employees AS e
INNER JOIN Departments AS d
		ON e.DepartmentID = d.DepartmentID
	 WHERE e.HireDate > '1999-01-01' AND d.[Name] IN ('Sales', 'Finance')
  ORDER BY e.HireDate

--07. Employees With Project
SELECT TOP (5) e.EmployeeID, 
			   e.FirstName, 
			   p.[Name] AS ProjectName
		  FROM Employees AS e
	INNER JOIN EmployeesProjects AS ep
			ON e.EmployeeID = ep.EmployeeID
	INNER JOIN Projects AS p
			ON ep.ProjectID = p.ProjectID
		 WHERE p.StartDate > '2002-08-13' AND p.EndDate IS NULL
	  ORDER BY e.EmployeeID ASC

--08. Employee 24
   SELECT  e.EmployeeID, 
		   e.FirstName, 
		   CASE 
		   WHEN p.StartDate > '2005-01-01' THEN NULL
		   ELSE p.[Name]
		   END AS ProjectName
	  FROM Employees AS e
INNER JOIN EmployeesProjects AS ep
		ON e.EmployeeID = ep.EmployeeID
INNER JOIN Projects AS p
		ON ep.ProjectID = p.ProjectID
	WHERE e.EmployeeID = 24

--09. Employee Manager
    SELECT e.EmployeeID, 
		   e.FirstName, 
		   e.ManagerID, 
		   m.FirstName AS [ManagerName] 
	  FROM Employees AS e
INNER JOIN Employees AS m
		ON e.ManagerID = m.EmployeeID
	 WHERE e.ManagerID IN (3, 7)
  ORDER BY e.EmployeeID ASC

--10. Employees Summary
SELECT TOP (50) e.EmployeeID, 
				e.FirstName + ' ' + e.LastName AS [EmployeeName],
				m.FirstName + ' ' + m.LastName AS [ManagerName],
				d.Name AS [DepartmentName]
		   FROM Employees AS e
	 INNER JOIN Employees AS m
			 ON e.ManagerID = m.EmployeeID
	 INNER JOIN Departments AS d
			 ON e.DepartmentID = d.DepartmentID
	   ORDER BY e.EmployeeID

--11. Min Average Salary
SELECT MIN(AverageSalaryPerDepartment) AS MinAverageSalary
FROM
(
  SELECT AVG(e.Salary) AS AverageSalaryPerDepartment
    FROM Employees AS e
GROUP BY e.DepartmentID
) AS SubQuery

--12. Highest Peaks in Bulgaria
USE Geography

    SELECT c.CountryCode,
	       m.MountainRange,
	       p.PeakName,
	       p.Elevation
      FROM Countries AS c
INNER JOIN MountainsCountries AS mc
		ON c.CountryCode = mc.CountryCode
INNER JOIN Mountains AS m
		ON mc.MountainId = m.Id
INNER JOIN Peaks AS p
		ON p.MountainId = m.Id
	 WHERE c.CountryCode = 'BG' AND p.Elevation > 2835
  ORDER BY p.Elevation DESC

--13. Count Mountain Ranges
  SELECT mc.CountryCode, 
	     COUNT(mc.MountainId) AS [MountainRanges]
    FROM MountainsCountries AS mc
GROUP BY mc.CountryCode
  HAVING mc.CountryCode IN ('BG', 'RU', 'US')

--14. Countries With or Without Rivers
 SELECT TOP (5) c.CountryName,
			    r.RiverName
		   FROM Countries AS c
LEFT OUTER JOIN CountriesRivers AS cr
			 ON c.CountryCode = cr.CountryCode
LEFT OUTER JOIN Rivers AS r
			 ON cr.RiverId = r.Id
		  WHERE c.ContinentCode = 'AF'
	   ORDER BY c.CountryName ASC

--15. *Continents and Currencies
WITH CTE_CurrencyUsagePerContinent(ContinentCode, CurrencyCode, CurrencyUsage, Rank)
AS
(
    SELECT ContinentCode, 
		   CurrencyCode, 
		   COUNT(CurrencyCode) AS [CurrencyUsage],
		   DENSE_RANK() OVER (PARTITION BY ContinentCode ORDER BY COUNT(CurrencyCode) DESC) AS Rank
	  FROM Countries
  GROUP BY ContinentCode, CurrencyCode
	HAVING COUNT(CurrencyCode) > 1
)

  SELECT ContinentCode, CurrencyCode, CurrencyUsage
    FROM CTE_CurrencyUsagePerContinent
   WHERE Rank = 1
ORDER BY ContinentCode ASC

--16. Countries Without any Mountains
SELECT COUNT(*) AS [CountryCode]
FROM
(
	SELECT c.ContinentCode FROM Countries AS c
	LEFT OUTER JOIN MountainsCountries AS mc
	ON c.CountryCode = mc.CountryCode
	LEFT OUTER JOIN Mountains AS m
	ON mc.MountainId = m.Id
	WHERE m.Id IS NULL
) AS [ResultSet]

--17. Highest Peak and Longest River by Country
SELECT TOP (5) * FROM
(
       SELECT c.CountryName, 
		      MAX(p.Elevation) AS [HighestPeakElevation],
		      MAX(r.Length)  AS [LongestRiverLength]
	     FROM Countries AS c
	LEFT JOIN MountainsCountries AS mc
		   ON c.CountryCode = mc.CountryCode
	LEFT JOIN Mountains AS m
		   ON mc.MountainId = m.Id 
	LEFT JOIN Peaks AS p
		  ON m.Id = p.MountainId
	LEFT JOIN CountriesRivers AS cr
		   ON c.CountryCode = cr.CountryCode
	LEFT JOIN Rivers AS r
		   ON cr.RiverId = r.Id
	 GROUP BY c.CountryName
) AS Subquery
ORDER BY HighestPeakElevation DESC, LongestRiverLength DESC, CountryName ASC

--18. *Highest Peak Name and Elevation by Country
 SELECT TOP (5) c.CountryName,
			    COALESCE(p.Peakname, '(no highest peak)') AS [Highest Peak Name], 
			    COALESCE(MAX(p.Elevation), 0) AS [Highest Peak Elevation], 
			    COALESCE(m.MountainRange, '(no mountain)') AS [Mountain]
		   FROM Countries AS c
LEFT OUTER JOIN MountainsCountries AS mc
			 ON c.CountryCode = mc.CountryCode
LEFT OUTER JOIN Mountains AS m
			 ON mc.MountainId = m.Id
LEFT OUTER JOIN Peaks AS p
			 ON m.Id = p.MountainId
	   GROUP BY c.CountryName, p.PeakName, p.Elevation, m.MountainRange
	   ORDER BY c.CountryName, p.PeakName