
SELECT DISTINCT sqRanked.DeptName AS [Department Name],
		sqRanked.CatName AS [Category Name],
		--sqRanked.Rank,
		--COUNT(*) AS Count,
		--sqTotal.TotalReports,
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
GROUP BY sqRanked.DeptName, sqRanked.CatName,sqRanked.Rank, sqTotal.TotalReports
ORDER BY [Department Name], [Category Name], Percentage