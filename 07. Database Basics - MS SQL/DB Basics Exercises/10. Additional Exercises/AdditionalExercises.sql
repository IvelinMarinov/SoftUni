USE Diablo

--01. Number of Users for Email Provider
SELECT * FROM (SELECT SUBSTRING(Email, CHARINDEX('@', Email) + 1, LEN(Email) - CHARINDEX('@', Email)) AS [Email Provider], 
					  COUNT(*) AS [Number Of Users] 
				 FROM Users
		     GROUP BY SUBSTRING(Email, CHARINDEX('@', Email) + 1, LEN(Email) - CHARINDEX('@', Email)) ) AS SubQuery
ORDER BY [Number Of Users] DESC, [Email Provider] ASC

--02. All Users in Games
SELECT g.Name, gt.Name, u.Username, ug.Level, ug.Cash, c.Name
FROM GameTypes AS gt
INNER JOIN Games AS g ON gt.Id = g.GameTypeId
INNER JOIN UsersGames AS ug ON g.Id = ug.GameId
INNER JOIN Users AS u ON ug.UserId = u.Id
INNER JOIN Characters AS c ON ug.CharacterId = c.Id
ORDER BY ug.Level DESC, u.Username ASC, g.Name ASC

--03. Users in Games with Their Items
SELECT * FROM
	(SELECT  u.Username AS [Username], 
			 g.Name AS [Game], 
			 COUNT(i.Name) AS [Items Count], 
			 SUM(i.Price) AS [Items Price]
	FROM Users AS u
	LEFT JOIN UsersGames AS ug ON u.Id = ug.UserId
	LEFT JOIN Games AS g ON ug.GameId = g.Id
	LEFT JOIN UserGameItems AS ugi ON ug.Id = ugi.UserGameId
	LEFT JOIN Items as i ON ugi.ItemId = i.Id
	GROUP BY u.Username, g.Name) AS SubQuery
WHERE [Items Count] >= 10
ORDER BY [Items Count] DESC, [Items Price] DESC, Username ASC

--04. * User in Games with Their Statistics


--05. All Items with Greater than Average Statistics
   SELECT i.Name, 
	      i.Price, 
	      i.MinLevel, 
	      s.Strength, 
	      s.Defence, 
	      s.Speed, 
	      s.Luck, 
	      s.Mind
     FROM Items AS i
INNER JOIN [Statistics] AS s 
       ON i.StatisticId = s.Id
	WHERE s.Mind > (SELECT AVG(Mind) FROM [Statistics]) 
	  AND s.Luck > (SELECT AVG(Luck) FROM [Statistics])
	  AND s.Speed > (SELECT AVG(Speed) FROM [Statistics])
 ORDER BY i.Name ASC

--06. Display All Items about Forbidden Game Type
   SELECT i.Name AS [Item], 
	      i.Price AS [Price], 
	      i.MinLevel AS [MinLevel], 
	      gt.Name AS [Forbidden Game Type] 
     FROM Items AS i
LEFT JOIN GameTypeForbiddenItems AS gtfi 
       ON i.Id = gtfi.ItemId
LEFT JOIN GameTypes AS gt 
       ON gtfi.GameTypeId = gt.Id
 ORDER BY gt.Name DESC, i.Name ASC

--07. Buy Items for User in Game
BEGIN TRANSACTION
DECLARE @AlexsGameId INT = (SELECT ug.GameId FROM Users AS u
						    LEFT JOIN UsersGames AS ug
						    ON u.Id = ug.UserId
						    LEFT JOIN Games AS g
						    ON ug.GameId = g.Id
						    WHERE Username = 'Alex'
						    AND g.Name = 'Edinburgh');

WITH CTE_Items(Id, Name, Price)
AS
(
	SELECT Id, Name, Price FROM Items
	WHERE Name IN ('Blackguard', 'Bottomless Potion of Amplification', 'Eye of Etlich (Diablo III)', 
	'Gem of Efficacious Toxin', 'Golden Gorget of Leoric', 'Hellfire Amulet')
)

INSERT INTO UserGameItems(ItemId, UserGameId)
SELECT Id, @AlexsGameId FROM CTE_Items

DECLARE @Sum DECIMAL(15,2) = (SELECT SUM(Price) FROM Items
	WHERE Name IN ('Blackguard', 'Bottomless Potion of Amplification', 'Eye of Etlich (Diablo III)', 
	'Gem of Efficacious Toxin', 'Golden Gorget of Leoric', 'Hellfire Amulet'))

UPDATE UsersGames
SET Cash -= @Sum
WHERE Id = @AlexsGameId

--IF ((SELECT Cash FROM UsersGames WHERE Id = @AlexsGameId) < 0)
--BEGIN
--	RAISERROR('Insufficient Funds', 16, 1)
--	ROLLBACK
--END

--ELSE
--BEGIN
--	COMMIT
--END

SELECT u.Username, 
	   g.Name, 
	   ug.Cash, 
	   i.Name AS [Item Name]
FROM Users AS u
LEFT JOIN UsersGames AS ug
ON u.Id = ug.UserId
LEFT JOIN Games AS g
ON ug.GameId = g.Id
LEFT JOIN UserGameItems AS ugi
ON ug.GameId = ugi.UserGameId
LEFT JOIN Items AS i
ON ugi.ItemId = i.Id
WHERE g.Name = 'Edinburgh'
AND u.Username = 'Alex'
ORDER BY i.Name ASC

--08. Peaks and Mountains
USE Geography

   SELECT p.PeakName, 
	      m.MountainRange, 
	      p.Elevation 
     FROM Peaks AS p
LEFT JOIN Mountains AS m
	   ON p.MountainId = m.Id
 ORDER BY p.Elevation DESC, p.PeakName ASC

--09. Peaks with Mountain, Country and Continent
    SELECT p.PeakName, 
	       m.MountainRange AS [Mountain],
	 	   cr.CountryName,
	   	   cn.ContinentName
      FROM Peaks AS p
INNER JOIN Mountains AS m
	    ON p.MountainId = m.Id
INNER JOIN MountainsCountries AS mc
	    ON m.Id = mc.MountainId
INNER JOIN Countries AS cr
	    ON mc.CountryCode = cr.CountryCode
INNER JOIN Continents AS cn
	    ON cr.ContinentCode = cn.ContinentCode
  ORDER BY p.PeakName ASC, cr.CountryName ASC

--10. Rivers by Country
   SELECT ctr.CountryName, 
	      cnt.ContinentName, 
	      COALESCE(COUNT(r.RiverName), 0) AS [RiversCount], 
	      COALESCE(SUM(r.[Length]), 0) AS [TotalLength]
     FROM Countries AS ctr
LEFT JOIN Continents AS cnt
	   ON ctr.ContinentCode = cnt.ContinentCode
LEFT JOIN CountriesRivers AS cr
	   ON ctr.CountryCode = cr.CountryCode
LEFT JOIN Rivers AS r
	   ON cr.RiverId = r.Id
 GROUP BY ctr.CountryName, cnt.ContinentName
 ORDER BY COUNT(r.RiverName) DESC, SUM(r.[Length]) DESC, ctr.CountryName ASC

--11. Count of Countries by Currency
   SELECT curr.CurrencyCode, 
	      curr.Description, 
	      COUNT(ctr.CountryName) AS [NumberOfCountries]
     FROM Currencies AS curr
LEFT JOIN Countries AS ctr
	   ON ctr.CurrencyCode = curr.CurrencyCode
 GROUP BY curr.CurrencyCode, curr.Description
 ORDER BY [NumberOfCountries] DESC, curr.Description ASC

--12. Population and Area by Continent
   SELECT cnt.ContinentName, 
          SUM(CAST(ctr.AreaInSqKm AS BIGINT)) AS [CountriesArea], 
		  SUM(CAST(ctr.Population AS BIGINT)) AS [CountriesPopulation]
	 FROM Continents AS cnt
LEFT JOIN Countries AS ctr
       ON cnt.ContinentCode = ctr.ContinentCode
 GROUP BY cnt.ContinentName
 ORDER BY CountriesPopulation DESC

 --13. Monasteries by Country

 --1. Create
CREATE TABLE Monasteries
(
	Id INT NOT NULL PRIMARY KEY IDENTITY,
	[Name] VARCHAR(100) NOT NULL,
	CountryCode CHAR(2) NOT NULL FOREIGN KEY REFERENCES Countries(CountryCode)
)

--2. Insert
INSERT INTO Monasteries(Name, CountryCode) VALUES
('Rila Monastery “St. Ivan of Rila”', 'BG'), 
('Bachkovo Monastery “Virgin Mary”', 'BG'),
('Troyan Monastery “Holy Mother''s Assumption”', 'BG'),
('Kopan Monastery', 'NP'),
('Thrangu Tashi Yangtse Monastery', 'NP'),
('Shechen Tennyi Dargyeling Monastery', 'NP'),
('Benchen Monastery', 'NP'),
('Southern Shaolin Monastery', 'CN'),
('Dabei Monastery', 'CN'),
('Wa Sau Toi', 'CN'),
('Lhunshigyia Monastery', 'CN'),
('Rakya Monastery', 'CN'),
('Monasteries of Meteora', 'GR'),
('The Holy Monastery of Stavronikita', 'GR'),
('Taung Kalat Monastery', 'MM'),
('Pa-Auk Forest Monastery', 'MM'),
('Taktsang Palphug Monastery', 'BT'),
('S?mela Monastery', 'TR')

--3. Add IsDeleted column and default value
ALTER TABLE Countries
ADD IsDeleted BIT DEFAULT 0

--4. Delete Countries with more than 3 rivers
UPDATE Countries
SET IsDeleted = 1
FROM Countries AS c2
INNER JOIN (SELECT c.CountryCode, 
				   COUNT(r.Id) AS RiversCount
			FROM Countries AS c
			LEFT JOIN CountriesRivers AS cr
			ON c.CountryCode = cr.CountryCode
			LEFT JOIN Rivers AS r
			ON cr.RiverId = r.Id
			GROUP BY c.CountryCode
			HAVING COUNT(r.Id) > 3) AS sq
ON c2.CountryCode = sq.CountryCode

--5. Select countries and monasteries
    SELECT m.Name AS [Monastery], 
	       c.CountryName AS [Country]
      FROM Countries AS c
INNER JOIN Monasteries AS m
		ON c.CountryCode = m.CountryCode
	 WHERE c.IsDeleted = 0
  ORDER BY m.Name ASC

--14. Monasteries by Continents and Countries

--1. Rename Myanmar to Burma
UPDATE Countries
SET CountryName = 'Burma'
WHERE CountryName = 'Myanmar'

--2. Insert monastery
INSERT INTO Monasteries(Name, CountryCode) VALUES
('Hanga Abbey',  (SELECT CountryCode FROM Countries
WHERE CountryName = 'Tanzania'))

--3. Insert another monastery
INSERT INTO Monasteries(Name, CountryCode) VALUES
('Myin-Tin-Daik',  (SELECT CountryCode FROM Countries
WHERE CountryName = 'Myanmar'))

--4. Select 
SELECT cnt.ContinentName, 
	   ctr.CountryName, 
	   COUNT(m.Name) AS [MonasteriesCount]
FROM Countries AS ctr
LEFT JOIN Continents AS cnt
ON ctr.ContinentCode = cnt.ContinentCode
LEFT JOIN Monasteries AS m
ON ctr.CountryCode = m.CountryCode
WHERE ctr.IsDeleted = 0
GROUP BY cnt.ContinentName, ctr.CountryName
ORDER BY MonasteriesCount DESC, ctr.CountryName ASC