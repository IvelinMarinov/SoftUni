WITH cte2
AS
(
	SELECT c.Name AS [CategoryName],
				   s.Label,
				   COUNT(s.Id) AS Count,
				   DENSE_RANK() OVER(PARTITION BY c.Name ORDER BY COUNT(s.Label) DESC) AS Rank
			FROM Categories AS c
			INNER JOIN Reports AS r ON c.Id = r.CategoryId
			INNER JOIN Status AS s ON r.StatusId = s.Id
			WHERE s.Label IN ('waiting', 'in progress')
			GROUP BY c.Name, s.Label, s.Id
)

SELECT * FROM cte2 WHERE Rank = 1

SELECT c.Name AS [Category Name],
	   COUNT(r.Id) AS [Reports Number],
	   CASE
	   WHEN cte.Count / CAST(COUNT(r.Id) AS DECIMAL(8,2)) = 0.5 THEN 'equal'
	   ELSE cte.Label 
	   END AS [Main Status], 
	   cte.Count,
	   cte.Label
FROM Categories AS c
INNER JOIN Reports AS r ON c.Id = r.CategoryId
INNER JOIN Status AS s ON r.StatusId = s.Id
INNER JOIN (SELECT * FROM cte2 WHERE Rank = 1) AS cte
ON c.Name = cte.CategoryName
WHERE s.Label IN ('waiting', 'in progress') AND cte.Rank = 1
GROUP BY  c.Name, cte.Count, cte.Label
ORDER BY [Category Name], [Reports Number], [Main Status]

--INSERT INTO Reports(CategoryId, StatusId, OpenDate, CloseDate, Description, UserId, EmployeeId) VALUES 
--(1, 1, GETDATE(), NULL, 'test', 1, 1 )

--SELECT * FROM Categories
--SELECT * FROM Status

--SELECT * FROM Reports 
--WHERE CategoryId = 1 AND StatusId IN (1,2)





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