--01. DDL
--CREATE DATABASE Bakery
--USE Bakery
CREATE TABLE Countries
(
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(50) UNIQUE
)

CREATE TABLE Distributors
(
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(25) UNIQUE,
	AddressText NVARCHAR(30),
	Summary NVARCHAR(200),
	CountryId INT FOREIGN KEY REFERENCES Countries(Id)
)

CREATE TABLE Ingredients
(
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(30),
	Description NVARCHAR(200),
	OriginCountryId INT FOREIGN KEY REFERENCES Countries(Id),
	DistributorId INT FOREIGN KEY REFERENCES Distributors(Id),
)

CREATE TABLE Products
(
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(25) UNIQUE,
	Description NVARCHAR(250),
	Recipe NVARCHAR(MAX),
	Price MONEY CHECK(Price > 0)
)

CREATE TABLE ProductsIngredients
(
	ProductId INT FOREIGN KEY REFERENCES Products(Id),
	IngredientId INT FOREIGN KEY REFERENCES Ingredients(Id) 
	CONSTRAINT PK_ProductsIngredients PRIMARY KEY(ProductId, IngredientId)
)

CREATE TABLE Customers
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(25),
	LastName NVARCHAR(25),
	Gender CHAR(1) CHECK(Gender IN ('M', 'F')),
	Age INT,
	PhoneNumber CHAR(10),
	CountryId INT FOREIGN KEY REFERENCES Countries(Id)
)

CREATE TABLE Feedbacks
(
	Id INT PRIMARY KEY IDENTITY,
	Description NVARCHAR(255),
	Rate DECIMAL(4,2) CHECK(Rate > 0 AND Rate < 10),
	ProductId INT FOREIGN KEY REFERENCES Products(Id),
	CustomerId INT FOREIGN KEY REFERENCES Customers(Id)
)

--02. Insert
INSERT INTO Distributors(Name, AddressText, Summary, CountryId) VALUES
('Deloitte & Touche', '6 Arch St #9757', 'Customizable neutral traveling', 2),
('Congress Title', '58 Hancock St',	'Customer loyalty', 13),
('Kitchen People', '3 E 31st St #77', 'Triple-buffered stable delivery', 1),
('General Color Co Inc', '6185 Bohn St #72', 'Focus group', 21),
('Beck Corporation	', '21 E 64th Ave',	'Quality-focused 4th generation hardware', 23)

INSERT INTO Customers(FirstName, LastName, Age, Gender, PhoneNumber, CountryId) VALUES
('Francoise', 'Rautenstrauch',	15, 'M', '0195698399',	5  ),
('Kendra', 'Loud',	22, 'F', '0063631526',	11 ),
('Lourdes', 'Bauswell',	50, 'M', '0139037043',	8  ),
('Hannah', 'Edmison',	18, 'F', '0043343686',	1  ),
('Tom', 'Loeza', 31, 'M', '0144876096',	23 ),
('Queenie', 'Kramarczyk', 30, 'F', '0064215793',	29 ),
('Hiu', 'Portaro',	25, 'M', '0068277755',	16 ),
('Josefa', 'Opitz',	43, 'F', '0197887645',	17 )

--03. Update
UPDATE Ingredients
SET DistributorId = 35
WHERE Name IN ('Bay Leaf', 'Paprika', 'Poppy')

UPDATE Ingredients
SET OriginCountryId = 14
WHERE OriginCountryId = 8

--04. Delete
DELETE FROM Feedbacks
WHERE CustomerId = 14 OR ProductId = 5

--05. Products By Price
SELECT Name, 
	   Price, 
	   Description 
FROM Products
ORDER BY Price DESC, Name ASC

--06. Ingredients
SELECT Name,
	   Description,
	   OriginCountryId
FROM Ingredients
WHERE OriginCountryId IN (1, 10, 20)
ORDER BY Id ASC

--07. Ingredients from Bulgaria and Greece
SELECT TOP 15 i.Name,
			  i.Description,
			  c.Name
FROM Ingredients AS i
LEFT JOIN Countries AS c ON i.OriginCountryId = c.Id
WHERE c.Name IN ('Bulgaria', 'Greece')
ORDER BY i.Name ASC, c.Name ASC

--08. Best Rated Products
SELECT TOP 10 p.Name, 
			  p.Description,
			  AVG(f.Rate) AS AverageRate,
			  COUNT(f.Id) AS FeedbacksAmount
FROM Products AS p
LEFT JOIN Feedbacks AS f ON p.Id = f.ProductId
GROUP BY p.Name, p.Description
ORDER BY AverageRate DESC, FeedbacksAmount DESC

--09. Negative Feedback
SELECT f.ProductId,
	   f.Rate,
	   f.Description,
	   f.CustomerId,
	   c.Age,
	   c.Gender
FROM Feedbacks AS f
LEFT JOIN Customers AS c ON f.CustomerId = c.Id
WHERE f.Rate < 5.0
ORDER BY f.ProductId DESC, f.Rate ASC

--10. Customers without Feedback
SELECT CONCAT(c.FirstName, ' ', c.LastName) AS CustomerName,
	   c.PhoneNumber,
	   c.Gender
FROM Customers AS c
LEFT JOIN Feedbacks AS f ON c.Id = f.CustomerId
WHERE f.CustomerId IS NULL
ORDER BY c.Id ASC

--11. Honorable Mentions
SELECT f.ProductId,
	   CONCAT(c.FirstName, ' ', c.LastName) AS CustomerName,
	   f.Description AS FeedbackDescription
FROM Feedbacks AS f
LEFT JOIN Customers AS c ON f.CustomerId = c.Id
WHERE f.CustomerId IN (SELECT c.Id
					   FROM Customers AS c
					   LEFT JOIN Feedbacks AS f ON c.Id = f.CustomerId
					   GROUP BY c.Id
					   HAVING COUNT(f.Id) >= 3)
ORDER BY f.ProductId ASC, CustomerName ASC, f.Id ASC

--12. Customers by Criteria
SELECT FirstName,
	   Age,
	   PhoneNumber
FROM Customers
WHERE (Age >= 21 AND FirstName LIKE '%an%') 
OR (PhoneNumber LIKE '%38' AND CountryId <> (SELECT Id FROM Countries
											 WHERE Name = 'Greece'))
ORDER BY FirstName ASC, Age DESC

--13. Middle Range Distributors
WITH cte
AS
(
	SELECT p.Id, 
		   AVG(f.Rate) AS AverageRate
	FROM Products AS p
	INNER JOIN Feedbacks AS f ON p.Id = f.ProductId
	GROUP BY p.Id
	HAVING AVG(f.Rate) BETWEEN 5 AND 8
)

SELECT d.Name AS DistributorName,
	   i.Name AS IngredientName,
	   p.Name AS ProductName,
	   cte.AverageRate
FROM Products AS p
INNER JOIN ProductsIngredients AS pi ON p.Id = pi.ProductId
INNER JOIN Ingredients AS i ON pi.IngredientId = i.Id
INNER JOIN Distributors AS d ON i.DistributorId = d.Id
LEFT JOIN cte ON p.Id = cte.Id
WHERE p.Id IN (SELECT p.Id
			   FROM Products AS p
			   INNER JOIN Feedbacks AS f ON p.Id = f.ProductId
			   GROUP BY p.Id
			   HAVING AVG(f.Rate) BETWEEN 5 AND 8)
ORDER BY d.Name ASC, i.Name ASC, p.Name ASC

--14. The Most Positive Country
SELECT TOP 1 WITH TIES
	   cnt.Name AS CountryName,
	   AVG(f.Rate) AS FeedbackRate
FROM Countries AS cnt
INNER JOIN Customers AS cust ON cnt.Id = cust.CountryId
INNER JOIN Feedbacks AS f ON f.CustomerId = cust.Id
GROUP BY cnt.Name
ORDER BY FeedbackRate DESC

--15. Country Representative
WITH cte
AS
(
	SELECT c.Name AS  CountryName,
		   d.Name AS DisributorName,
		   COUNT(i.Id) AS IngredientsCount,
		   DENSE_RANK() OVER (PARTITION BY c.Name ORDER BY COUNT(i.Id) DESC) AS Rank	    
	FROM Countries AS c
	LEFT JOIN Distributors AS d ON c.Id = d.CountryId
	LEFT JOIN Ingredients AS i ON d.Id = i.DistributorId
	GROUP BY c.Name, d.Name
)

SELECT CountryName, DisributorName FROM cte
WHERE Rank = 1
ORDER BY CountryName ASC, DisributorName ASC

--16. Customers With Countries
GO
CREATE VIEW v_UserWithCountries AS
SELECT CONCAT(cust.FirstName, ' ', cust.LastName) AS CustomerName,
	   cust.Age,
	   cust.Gender,
	   cnt.Name AS CountryName
FROM Customers AS cust
INNER JOIN Countries AS cnt ON cust. CountryId = cnt.Id
GO

SELECT TOP 5 *
  FROM v_UserWithCountries
 ORDER BY Age

 --17. Feedback by Product Name
GO
CREATE FUNCTION udf_GetRating(@Name NVARCHAR(50))
RETURNS NVARCHAR(50)
BEGIN
	DECLARE @Rating DECIMAL(4,2) = (SELECT AVG(f.Rate) FROM Products AS p
									LEFT JOIN Feedbacks AS f ON p.Id = f.ProductId
									WHERE p.Name = @Name
									GROUP BY p.Name)	
	DECLARE @Result NVARCHAR(50)

	IF @Rating IS NULL
	BEGIN
		SET @Result = 'No rating'
	END

	IF @Rating < 5
	BEGIN
		SET @Result = 'Bad'
	END

	ELSE IF @Rating BETWEEN 5 AND 8
	BEGIN
		SET @Result = 'Average'
	END

	ELSE IF @Rating > 8
	BEGIN
		SET @Result = 'Good'
	END

	RETURN @Result
END

SELECT TOP 5 Id, Name, dbo.udf_GetRating(Name)
  FROM Products
 ORDER BY Id

--18. Send Feedback
GO
CREATE OR ALTER PROCEDURE usp_SendFeedback(@CustomerId INT, @ProductId INT, @Rate DECIMAL(4,2), @Description NVARCHAR(255))
AS
BEGIN
	DECLARE @CommentsCount INT = (SELECT TOP 1 COALESCE(COUNT(*), 0) FROM Feedbacks
								  WHERE CustomerId = @CustomerId 
								  AND ProductId = @ProductId)

	IF @CommentsCount >= 3
	BEGIN
		RAISERROR('You are limited to only 3 feedbacks per product!', 16, 1)		
		RETURN
	END	

	INSERT INTO Feedbacks(ProductId, CustomerId, Rate, Description) VALUES
	(@ProductId, @CustomerId, @Rate, @Description)	
END

EXEC usp_SendFeedback 3, 15, 7.50, 'Average experience';
SELECT COUNT(*) FROM Feedbacks WHERE CustomerId = 3 AND ProductId = 15;

--19. Delete Products
GO
CREATE TRIGGER tr_DeleteProduct ON Products INSTEAD OF DELETE
AS
BEGIN
	DECLARE @ProductID INT = (SELECT Id FROM deleted)

	DELETE FROM ProductsIngredients
	WHERE ProductId = @ProductID

	DELETE FROM Feedbacks
	WHERE ProductId = @ProductID

	DELETE FROM Products
	WHERE Id = @ProductID
END

--20. Products by One Distributor


SELECT p.Name AS ProductName,
	   sq.ProductAverageRate,
	   d.Name AS DistributorName,
	   c.Name AS DistributorCountry
FROM Products AS p
LEFT JOIN (SELECT ProductId AS ProductId, 
				   AVG(Rate) AS ProductAverageRate
			FROM Feedbacks
			GROUP BY ProductId) AS sq ON p.Id = sq.ProductId
LEFT JOIN Feedbacks AS f ON p.Id = f.Rate
LEFT JOIN ProductsIngredients AS pi ON p.Id = pi.ProductId
LEFT JOIN Ingredients AS i ON pi.IngredientId = i.Id
LEFT JOIN Distributors AS d ON i.DistributorId = d.Id
LEFT JOIN Countries AS c ON d.CountryId = c.Id
WHERE p.Id IN  (SELECT p.Id FROM Products AS p
			   INNER JOIN ProductsIngredients AS pi ON p.Id = pi.ProductId
			   INNER JOIN Ingredients AS i ON pi.IngredientId = i.Id
			   GROUP BY p.Id
			   HAVING MIN(i.DistributorId) = MAX(i.DistributorId))
ORDER BY p.Id ASC

SELECT * FROM Products