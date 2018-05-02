--Section 1: DDL
--CREATE DATABASE AMS
--USE AMS

CREATE TABLE Towns (
	TownID INT,
	TownName VARCHAR(30) NOT NULL,
	CONSTRAINT PK_Towns PRIMARY KEY(TownID)
)

CREATE TABLE Airports (
	AirportID INT,
	AirportName VARCHAR(50) NOT NULL,
	TownID INT NOT NULL,
	CONSTRAINT PK_Airports PRIMARY KEY(AirportID),
	CONSTRAINT FK_Airports_Towns FOREIGN KEY(TownID) REFERENCES Towns(TownID)
)

CREATE TABLE Airlines (
	AirlineID INT,
	AirlineName VARCHAR(30) NOT NULL,
	Nationality VARCHAR(30) NOT NULL,
	Rating INT DEFAULT(0),
	CONSTRAINT PK_Airlines PRIMARY KEY(AirlineID)
)

CREATE TABLE Customers (
	CustomerID INT,
	FirstName VARCHAR(20) NOT NULL,
	LastName VARCHAR(20) NOT NULL,
	DateOfBirth DATE NOT NULL,
	Gender VARCHAR(1) NOT NULL CHECK (Gender='M' OR Gender='F'),
	HomeTownID INT NOT NULL,
	CONSTRAINT PK_Customers PRIMARY KEY(CustomerID),
	CONSTRAINT FK_Customers_Towns FOREIGN KEY(HomeTownID) REFERENCES Towns(TownID)
)

CREATE TABLE Flights (
	FlightID INT,
	DepartureTime DATETIME NOT NULL,
	ArrivalTime DATETIME NOT NULL,
	Status VARCHAR(9) CHECK (Status='Departing' OR Status='Delayed' OR Status='Arrived' OR Status='Cancelled'),
	OriginAirportID INT,
	DestinationAirportID INT,
	AirlineID INT,
	CONSTRAINT PK_Flights PRIMARY KEY(FlightID),
	CONSTRAINT FK_Flights_OriginAirports FOREIGN KEY(OriginAirportID) REFERENCES Airports(AirportID),
	CONSTRAINT FK_Flights_DestinationAirports FOREIGN KEY(DestinationAirportID) REFERENCES Airports(AirportID),
	CONSTRAINT FK_Flights_Airlines FOREIGN KEY(AirlineID) REFERENCES Airlines(AirlineID)
)

CREATE TABLE Tickets (
	TicketID INT,
	Price DECIMAL(8,2) NOT NULL,
	Class VARCHAR(6) CHECK(Class='First' OR Class='Second' OR Class='Third'),
	Seat VARCHAR(5) NOT NULL,
	CustomerID INT,
	FlightID INT,
	CONSTRAINT PK_Tickets PRIMARY KEY(TicketID),
	CONSTRAINT FK_Tickets_Customers FOREIGN KEY(CustomerID) REFERENCES Customers(CustomerID),
	CONSTRAINT FK_Tickets_Flights FOREIGN KEY(FlightID) REFERENCES Flights(FlightID)
)

INSERT INTO Towns(TownID, TownName)
VALUES
(1, 'Sofia'),
(2, 'Moscow'),
(3, 'Los Angeles'),
(4, 'Athene'),
(5, 'New York')

INSERT INTO Airports(AirportID, AirportName, TownID)
VALUES
(1, 'Sofia International Airport', 1),
(2, 'New York Airport', 5),
(3, 'Royals Airport', 1),
(4, 'Moscow Central Airport', 2)

INSERT INTO Airlines(AirlineID, AirlineName, Nationality, Rating)
VALUES
(1, 'Royal Airline', 'Bulgarian', 200),
(2, 'Russia Airlines', 'Russian', 150),
(3, 'USA Airlines', 'American', 100),
(4, 'Dubai Airlines', 'Arabian', 149),
(5, 'South African Airlines', 'African', 50),
(6, 'Sofia Air', 'Bulgarian', 199),
(7, 'Bad Airlines', 'Bad', 10)

INSERT INTO Customers(CustomerID, FirstName, LastName, DateOfBirth, Gender, HomeTownID)
VALUES
(1, 'Cassidy', 'Isacc', '19971020', 'F', 1),
(2, 'Jonathan', 'Half', '19830322', 'M', 2),
(3, 'Zack', 'Cody', '19890808', 'M', 4),
(4, 'Joseph', 'Priboi', '19500101', 'M', 5),
(5, 'Ivy', 'Indigo', '19931231', 'F', 1)

--Section 2: DML - 01. Data Insertion
INSERT INTO Flights(FlightID, DepartureTime, ArrivalTime, Status, OriginAirportID, DestinationAirportID, AirlineID) VALUES
(1,	'2016-10-13 06:00',	'2016-10-13 10:00',	'Delayed',   1,	4,	1),
(2,	'2016-10-12 12:00',	'2016-10-12 12:01',	'Departing',	1,	3,	2),
(3,	'2016-10-14 03:00',	'2016-10-20 04:00',	'Delayed',   4,	2,	4),
(4,	'2016-10-12 01:24',	'2016-10-12 4:31',  'Departing',	3,	1,	3),
(5,	'2016-10-12 08:11',	'2016-10-12 11:22',	'Departing',	4,	1,	1),
(6,	'1995-06-21 12:30',	'1995-06-22 08:30',	'Arrived',   2,	3,	5),
(7,	'2016-10-12 11:34',	'2016-10-13 03:00',	'Departing',	2,	4,	2),
(8,	'2016-11-11 01:00',	'2016-11-12 10:00',	'Delayed',   4,	3,	1),
(9,	'2015-10-01 12:00',	'2015-12-01 01:00',	'Arrived',   1,	2,	1),
(10,'2016-10-12 07:30',	'2016-10-13 12:30',	'Departing',	2,	1,	7)

INSERT INTO Tickets(TicketID, Price, Class, Seat, CustomerID, FlightID) VALUES
(1,	3000.00, 'First', '233-A', 3, 8),
(2,	1799.90, 'Second', '123-D', 1, 1),
(3,	1200.50, 'Second', '12-Z', 2, 5),
(4,	410.68,	'Third', '45-Q', 2, 8),
(5,	560.00,	'Third', '201-R', 4, 6),
(6,	2100.00, 'Second', '13-T', 1, 9),
(7,	5500.00, 'First', '98-O', 2, 7)


--Section 2: DML - 02. Update Flights
UPDATE Flights
SET AirlineID = 1
WHERE Status = 'Arrived'

--Section 2: DML - 03. Update Tickets
UPDATE Tickets
SET Price *= 1.5
FROM Tickets AS t
INNER JOIN Flights AS f
ON t.FlightID = f.FlightID
WHERE f.AirlineID = (SELECT TOP(1) AirlineID FROM Airlines
					ORDER BY Rating DESC)

--Section 2: DML - 04. Table Creation
CREATE TABLE CustomerReviews (
	ReviewID INT,
	ReviewContent VARCHAR(255) NOT NUll,
	ReviewGrade INT CHECK(ReviewGrade >= 0 AND ReviewGrade <= 10),
	AirlineID INT,
	CustomerID INT,
	CONSTRAINT PK_CustomerReviews PRIMARY KEY(ReviewID),
	CONSTRAINT FK_CustomerReviews_Airlines FOREIGN KEY(AirlineID) REFERENCES Airlines(AirlineID),
	CONSTRAINT FK_CustomerReviews_Customers FOREIGN KEY(CustomerID) REFERENCES Customers(CustomerID)
)

CREATE TABLE CustomerBankAccounts (
	AccountID INT,
	AccountNumber VARCHAR(10) NOT NULL UNIQUE,
	Balance DECIMAL(10,2) NOT NULL,
	CustomerID INT,
	CONSTRAINT PK_CustomerBankAccounts PRIMARY KEY(AccountID),
	CONSTRAINT FK_CustomerBankAccounts_Customers FOREIGN KEY(CustomerID) REFERENCES Customers(CustomerID)
)

--Section 2: DML - 05. Fillin New Tables
INSERT INTO CustomerReviews(ReviewID, ReviewContent, ReviewGrade, AirlineID, CustomerID) VALUES
(1, 'Me is very happy. Me likey this airline. Me good.', 10, 1, 1),
(2, 'Ja, Ja, Ja... Ja, Gut, Gut, Ja Gut! Sehr Gut!', 10, 1, 4),
(3, 'Meh...', 5, 4, 3),
(4, 'Well Ive seen better, but Ive certainly seen a lot worse...', 7, 3, 5)

INSERT INTO CustomerBankAccounts(AccountID, AccountNumber, Balance, CustomerID) VALUES
(1, '123456790', 2569.23, 1),
(2, '18ABC23672', 14004568.23, 2),
(3, 'F0RG0100N3', 19345.20, 5)

--Section 3: Querying - 01. Extract All Tickets
SELECT TicketID, 
	   Price, 
	   Class, 
	   Seat 
FROM Tickets
ORDER BY TicketID ASC

--Section 3: Querying - 02. Extract All Customers
SELECT CustomerID, 
	   CONCAT(FirstName, ' ', LastName) AS FullName,
	   Gender
FROM Customers
ORDER BY FullName ASC, CustomerID ASC

--Section 3: Querying - 03. Extract Delayed Flights
SELECT FlightID,
	   DepartureTime,
	   ArrivalTime
FROM Flights
WHERE Status = 'Delayed'
ORDER BY FlightID ASC

--Section 3: Querying - 04. Top 5 Airlines
SELECT TOP(5) sq.AirlineID,
	          sq.AirlineName,
	          sq.Nationality,
	          sq.Rating
		FROM (
			  SELECT a.AirlineID,
			  	   a.AirlineName,
			  	   a.Nationality,
			  	   a.Rating,
			  	   COUNT(f.FlightID) AS FlightsCount
			  FROM Airlines AS a 
			  LEFT JOIN Flights AS f
			  ON a.AirlineID = f.AirlineID
			  GROUP BY a.AirlineID,
			  	   a.AirlineName,
			  	   a.Nationality,
			  	   a.Rating
			  ) AS sq
WHERE sq.FlightsCount > 0
ORDER BY Rating DESC, AirlineID ASC

--Section 3: Querying - 05. All Tickets Below 5000
SELECT t.TicketID,
	   a.AirportName AS Destination,
	   CONCAT(c.FirstName, ' ', c.LastName) AS CustomerName
 FROM Tickets AS t
LEFT JOIN Flights AS f
ON t.FlightID = f.FlightID
LEFT JOIN Customers AS c
ON t.CustomerID = c.CustomerID
LEFT JOIN Airports AS a
ON f.DestinationAirportID = a.AirportID
WHERE t.Class = 'First' AND t.Price < 5000

--Section 3: Querying - 06. Customers From Home
SELECT DISTINCT c.CustomerID,
	   CONCAT(c.FirstName, ' ', c.LastName) AS FullName,
	   towns.TownName AS HomeTown,
	   *
FROM Customers AS c
INNER JOIN Tickets
ON c.CustomerID = tickets.CustomerID
INNER JOIN Flights AS f
ON tickets.FlightID  = f.FlightID
INNER JOIN Towns
ON c.HomeTownID = towns.TownID
WHERE c.HomeTownID = f.OriginAirportID
ORDER BY c.CustomerID ASC

--Section 3: Querying - 07. Customers who will fly
SELECT DISTINCT c.CustomerID,
	   CONCAT(c.FirstName, ' ', c.LastName) AS FullName,
	   DATEDIFF(YEAR, c.DateOfBirth, '2016-10-16') AS Age
FROM Customers AS c
LEFT JOIN Tickets AS t
ON c.CustomerID = t.CustomerID
LEFT JOIN Flights AS f
ON t.FlightID = f.FlightID
WHERE f.Status = 'Departing'
ORDER BY Age ASC, c.CustomerID ASC

--Section 3: Querying - 08. Top 3 Customers Delayed
SELECT DISTINCT TOP(3) c.CustomerID,
					   CONCAT(c.FirstName, ' ', c.LastName) AS FullName,
					   t.Price AS TicketPrice,
					   a.AirportName AS Destination
				  FROM Customers AS c
			 LEFT JOIN Tickets AS t
					ON c.CustomerID = t.CustomerID
			 LEFT JOIN Flights AS f
					ON t.FlightID = f.FlightID
			 LEFT JOIN Airports AS a
					ON f.DestinationAirportID = a.AirportID
				 WHERE f.Status = 'Delayed'
			  ORDER BY t.Price DESC

--Section 3: Querying - 09. Last 5 Departing Flights
SELECT * FROM (	SELECT TOP(5) f.FlightID,
							  f.DepartureTime,
							  f.ArrivalTime,
							  aorigin.AirportName AS Origin,
							  adest.AirportName AS Destination
				 FROM Flights AS f
				LEFT JOIN Airports AS aorigin
				ON f.OriginAirportID = aorigin.AirportID
				LEFT JOIN Airports AS adest
				ON f.DestinationAirportID = adest.AirportID
				WHERE f.Status = 'Departing'
				ORDER BY f.DepartureTime DESC, f.FlightID ASC) AS sq
ORDER BY sq.DepartureTime ASC

--Section 3: Querying - 10. Customers Below 21
SELECT DISTINCT c.CustomerID, 
	   CONCAT(c.FirstName, ' ', c.LastName) AS FullName,
	   DATEDIFF(YEAR, c.DateOfBirth, '2016-10-16') AS Age
FROM Customers AS c
LEFT JOIN Tickets AS t
ON c.CustomerID = t.CustomerID
LEFT JOIN Flights AS f
ON t.FlightID= f.FlightID
WHERE f.Status = 'Arrived'
AND DATEDIFF(YEAR, c.DateOfBirth, '2016-10-16') < 21
ORDER BY Age DESC, c.CustomerID ASC

--Section 3: Querying - 11. AIrports and Passengers
SELECT a.AirportID,
	   a.AirportName,
	   COUNT(c.CustomerID) AS Passengers
FROM Airports AS a
LEFT JOIN Flights AS f
ON a.AirportID = f.OriginAirportID
LEFT JOIN Tickets AS t
ON f.FlightID = t.TicketID
LEFT JOIN Customers AS c
ON t.CustomerID = c.CustomerID
WHERE f.Status = 'departing'
GROUP BY a.AirportID, a.AirportName
ORDER BY a.AirportID ASC

--Section 4: Programmibility - 01. Submit Review
GO
CREATE PROCEDURE usp_SubmitReview(@CustomerID INT, @ReviewContent VARCHAR(255), @ReviewGrade INT, @AirlineName VARCHAR(30))
AS
BEGIN
	IF @AirlineName NOT IN (SELECT AirlineName FROM Airlines)
	BEGIN
		RAISERROR('Airline does not exist.', 16, 1)
		RETURN
	END

	DECLARE @AirlineID INT = (SELECT AirlineID FROM Airlines
							  WHERE AirlineName = @AirlineName)
	DECLARE @NextID INT = COALESCE((SELECT TOP(1) ReviewID FROM CustomerReviews
						ORDER BY ReviewID DESC) + 1, 1)

	INSERT INTO CustomerReviews(ReviewID, ReviewContent, ReviewGrade, AirlineID, CustomerID) VALUES
	(@NextID, @ReviewContent, @ReviewGrade, @AirlineID, @CustomerID)
END

EXEC usp_SubmitReview 1, Test, 8, 'Royal Airline'
SELECT * FROM CustomerReviews

--Section 4: Programmibility - 02. Ticket Purchase
GO
CREATE PROCEDURE usp_PurchaseTicket(@CustomerID INT, @FlightID INT, @TicketPrice DECIMAL(8,2), @Class VARCHAR(6), @Seat VARCHAR(5))
AS
BEGIN
	BEGIN TRANSACTION
	IF @TicketPrice > (SELECT Balance FROM CustomerBankAccounts
						WHERE CustomerID = @CustomerID)
	BEGIN
		RAISERROR('Insufficient bank account balance for ticket purchase.', 16, 1)
		ROLLBACK
		RETURN
	END

	IF @TicketPrice < 0
	BEGIN
		RAISERROR('Ticket price must be a positive amount', 16, 1)
		ROLLBACK
		RETURN
	END

	IF @Class NOT IN ('First', 'Second', 'Third')
	BEGIN
		RAISERROR('Invalid class provided', 16, 1)
		ROLLBACK
		RETURN
	END

	DECLARE @NextID INT = COALESCE((SELECT TOP(1) TicketID FROM Tickets
						ORDER BY TicketID DESC) + 1, 1)
	INSERT INTO Tickets(TicketID, Price, Class, Seat, CustomerID, FlightID) VALUES
	(@NextID, @TicketPrice, @Class, @Seat, @CustomerID, @FlightID)

	UPDATE CustomerBankAccounts
	SET Balance -= @TicketPrice
	WHERE CustomerID = @CustomerID

	COMMIT
END

EXEC usp_PurchaseTicket 1, 1, 500, 'fafadfd', 'abcd'
SELECT * FROM CustomerBankAccounts
SELECT * FROM Tickets