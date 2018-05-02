--01. DDL
--CREATE DATABASE WashingMachineService
--USE WashingMachineService

CREATE TABLE Clients
(
	ClientId INT PRIMARY KEY IDENTITY NOT NULL,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	Phone CHAR(12) NOT NULL
)

CREATE TABLE Mechanics
(
	MechanicId INT PRIMARY KEY IDENTITY NOT NULL,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	Address VARCHAR(255) NOT NULL
)

CREATE TABLE Models
(
	ModelId	INT PRIMARY KEY IDENTITY NOT NULL,
	Name VARCHAR(50) UNIQUE NOT NULL
)

CREATE TABLE Vendors
(
	VendorId INT PRIMARY KEY IDENTITY NOT NULL,
	Name VARCHAR(50) UNIQUE NOT NULL
)

CREATE TABLE Parts
(
	PartId INT PRIMARY KEY IDENTITY NOT NULL,
	SerialNumber VARCHAR(50) NOT NULL UNIQUE,
	Description	VARCHAR(255) NULL,
	Price DECIMAL(6,2) NOT NULL CHECK(Price > 0),
	VendorId INT NOT NULL FOREIGN KEY REFERENCES Vendors(VendorId),
	StockQty INT NOT NULL DEFAULT 0 CHECK(StockQty >= 0)
)

CREATE TABLE Jobs
(
	JobId INT PRIMARY KEY IDENTITY NOT NULL,
	ModelId INT FOREIGN KEY REFERENCES Models(ModelId) NOT NULL,
	Status VARCHAR(11) CHECK(Status = 'Pending' OR Status = 'In Progress' OR Status = 'Finished') DEFAULT 'Pending' NOT NULL,
	ClientId INT FOREIGN KEY REFERENCES Clients(ClientId) NOT NULL,
	MechanicId INT FOREIGN KEY REFERENCES Mechanics(MechanicId) NULL,
	IssueDate DATE NOT NULL,	
	FinishDate DATE NULL
)

CREATE TABLE Orders
(
	OrderId	INT PRIMARY KEY IDENTITY NOT NULL,
	JobId INT FOREIGN KEY REFERENCES Jobs(JobId) NOT NULL,
	IssueDate DATE NULL,
	Delivered BIT DEFAULT 0
)

CREATE TABLE OrderParts
(
	OrderId	INT NOT NULL FOREIGN KEY REFERENCES Orders(OrderId),
	PartId	INT NOT NULL FOREIGN KEY REFERENCES Parts(PartId),
	Quantity INT NOT NULL DEFAULT 1 CHECK(Quantity > 0),
	CONSTRAINT PK_OrderParts PRIMARY KEY(OrderId, PartId)
)

CREATE TABLE PartsNeeded
(
	JobId INT NOT NULL FOREIGN KEY REFERENCES Jobs(JobId),
	PartId INT NOT NULL FOREIGN KEY REFERENCES Parts(PartId),
	Quantity INT NOT NULL DEFAULT 1 CHECK(Quantity > 0),
	CONSTRAINT PK_PartsNeeded PRIMARY KEY(JobId, PartId)
)

--02. Insert
INSERT INTO Clients(FirstName, LastName, Phone) VALUES
('Teri', 'Ennaco', '570-889-5187'),
('Merlyn', 'Lawler', '201-588-7810'),
('Georgene', 'Montezuma', '925-615-5185'),
('Jettie', 'Mconnell', '908-802-3564'),
('Lemuel', 'Latzke', '631-748-6479'),
('Melodie', 'Knipp', '805-690-1682'),
('Candida', 'Corbley', '908-275-8357')

INSERT INTO Parts(SerialNumber, Description, Price, VendorId) VALUES
('WP8182119', 'Door Boot Seal',	117.86, 2),
('W10780048', 'Suspension Rod',	42.81, 1),
('W10841140', 'Silicone Adhesive', 6.77, 4),
('WPY055980', 'High Temperature Adhesive', 13.94, 3)

--03. Update
UPDATE Jobs
SET MechanicId = (SELECT MechanicId 
				  FROM Mechanics
				  WHERE FirstName = 'Ryan'
				  AND LastName = 'Harnos'),
		Status = 'In Progress'
  WHERE Status = 'Pending'

--04. Delete
DELETE FROM OrderParts
WHERE OrderId = 19

DELETE FROM Orders
WHERE OrderId = 19

--05. Clients by Name
SELECT FirstName, 
	   LastName, 
	   Phone 
FROM Clients
ORDER BY LastName ASC, ClientId ASC

--06. Job Status
SELECT Status,
	   IssueDate
FROM Jobs
WHERE Status <> 'Finished'
ORDER BY IssueDate ASC, JobId ASC

--07. Mechanic Assignments
SELECT CONCAT(m.FirstName, ' ', m.LastName) AS Mechanic,
	   j.Status,
	   j.IssueDate
FROM Mechanics AS m
LEFT JOIN Jobs AS j ON m.MechanicId = j.MechanicId
ORDER BY m.MechanicId ASC, j.IssueDate ASC, j.JobId ASC

--08. Current Clients
SELECT CONCAT(c.FirstName, ' ', c.LastName) AS Client,
	   DATEDIFF(DAY, j.IssueDate, '2017-04-24') AS [Days going],
	   j.Status
FROM Clients AS c
INNER JOIN Jobs AS j ON c.ClientId = j.ClientId
WHERE j.Status <> 'Finished'
ORDER BY [Days going] DESC, c.ClientId ASC

--09. Mechanic Performance
SELECT CONCAT(m.FirstName, ' ', m.LastName) AS Mechanic,
		AVG(DATEDIFF(DAY, j.IssueDate, j.FinishDate)) AS [Average Days]
FROM Mechanics AS m
LEFT JOIN Jobs AS j ON m.MechanicId = j.MechanicId
WHERE j.FinishDate IS NOT NULL
GROUP BY CONCAT(m.FirstName, ' ', m.LastName), m.MechanicId
ORDER BY m.MechanicId ASC

--10. Hard Earners
SELECT CONCAT(m.FirstName, ' ', m.LastName) AS Mechanic,
	   COUNT(*) AS Jobs	   
FROM Mechanics AS m
LEFT JOIN Jobs AS j ON m.MechanicId = j.MechanicId
WHERE j.Status <> 'Finished'
GROUP BY CONCAT(m.FirstName, ' ', m.LastName), m.MechanicId
HAVING COUNT(*) > 1
ORDER BY COUNT(*) DESC, m.MechanicId ASC

--11. Available Mechanics
SELECT sq.Mechanic AS Available
FROM (SELECT CONCAT(m.FirstName, ' ', m.LastName) AS Mechanic,
			m.MechanicId,
			MAX(LEN(j.Status)) AS MaxStatus,
			MIN(LEN(j.Status)) AS MinStatus,
			COUNT(j.JobId) AS JobsCount
	 FROM Mechanics AS m
	 LEFT JOIN Jobs AS j ON m.MechanicId = j.MechanicId
	 GROUP BY CONCAT(m.FirstName, ' ', m.LastName), m.MechanicId) AS sq
WHERE (sq.MinStatus = 8 AND sq.MaxStatus = 8) OR sq.JobsCount = 0
ORDER BY sq.MechanicId ASC

--12. Parts Cost
SELECT COALESCE(SUM(p.Price * op.Quantity), 0) AS [Parts Total]
FROM Parts AS p
INNER JOIN OrderParts AS op ON p.PartId = op.PartId
INNER JOIN Orders AS o ON op.OrderId = o.OrderId
WHERE DATEDIFF(WEEK, o.IssueDate, '2017-04-24') <= 3

--13. Past Expenses
SELECT j.JobId,
	   COALESCE(SUM(p.Price * op.Quantity), 0) AS Total
FROM Jobs AS j
LEFT JOIN Orders AS o ON j.JobId = o.JobId
LEFT JOIN OrderParts AS op ON o.OrderId = op.OrderId
LEFT JOIN Parts AS p ON op.PartId = p.PartId
WHERE j.Status = 'Finished'
GROUP BY j.JobId
ORDER BY Total DESC, j.JobId ASC

--14. Model Repair Time
SELECT m.ModelId, 
	   m.Name,
	   CAST(COALESCE(AVG(DATEDIFF(DAY, j.IssueDate, j.FinishDate)), 0) AS VARCHAR) + ' days' AS [Average Service Time]
FROM Models AS m
LEFT JOIN Jobs AS j
ON m.ModelId = j.ModelId
WHERE j.Status = 'Finished'
GROUP BY m.ModelId, m.Name
ORDER BY AVG(DATEDIFF(DAY, j.IssueDate, j.FinishDate)) ASC

--15. Faultiest Model

SELECT TOP 1 WITH TIES
	   m.Name,
	   COUNT(*) AS [Times Serviced],
	   (SELECT COALESCE(SUM(p.Price * op.Quantity), 0)
		FROM Jobs AS j
		INNER JOIN Orders AS o ON j.JobId = o.JobId
		INNER JOIN OrderParts AS op ON o.OrderId = op.OrderId
		INNER JOIN Parts AS p ON op.PartId = p.PartId
		WHERE j.ModelId = m.ModelId) AS [Parts Total]
FROM Models AS m
INNER JOIN Jobs AS j ON m.ModelId = j.ModelId
GROUP BY m.Name, m.ModelId
ORDER BY [Times Serviced] DESC

--16. Missing Parts
SELECT p.PartId,
       p.Description,
       SUM(pn.Quantity) AS Required,
       AVG(p.StockQty) AS [In Stock],
       ISNULL(SUM(op.Quantity), 0) AS Ordered
  FROM Parts AS p
JOIN PartsNeeded pn ON pn.PartId = p.PartId
JOIN Jobs AS j ON j.JobId = pn.JobId
LEFT JOIN Orders AS o ON o.JobId = j.JobId
LEFT JOIN OrderParts AS op ON op.OrderId = o.OrderId
WHERE j.Status <> 'Finished'
GROUP BY p.PartId, p.Description
HAVING AVG(p.StockQty) + ISNULL(SUM(op.Quantity), 0) < SUM(pn.Quantity)
ORDER BY p.PartId

--17. Cost of Order
GO
CREATE FUNCTION udf_GetCost(@JobID INT)
RETURNS DECIMAL(15,2)
AS
BEGIN
	RETURN COALESCE((SELECT SUM(p.Price * op.Quantity) FROM Jobs AS j
			JOIN Orders AS o ON j.JobId = o.JobId
			JOIN OrderParts AS op ON o.OrderId = op.OrderId
			JOIN Parts AS p ON op.PartId = p.PartId
			WHERE j.JobId = @JobID), 0)
END

SELECT dbo.udf_GetCost(1)

--18. Place Order
GO
CREATE OR ALTER PROCEDURE usp_PlaceOrder(@JobID INT, @SerialNumber VARCHAR(50), @Quantity INT)
AS
BEGIN
	DECLARE @PartID INT = (SELECT TOP 1 PartId FROM Parts 
					       WHERE SerialNumber = @SerialNumber)

	DECLARE @OrderID INT = (SELECT TOP 1 OrderId FROM Orders 
							WHERE JobId = @JobID AND IssueDate IS NULL)

	IF (SELECT TOP 1 Status FROM Jobs	WHERE JobID = @JobId) = 'Finished'
	BEGIN
		RAISERROR('This job is not active!', 11, 1)
		RETURN	
	END

	IF @Quantity <= 0
	BEGIN
		RAISERROR('Part quantity must be more than zero!', 12, 1)
		RETURN	
	END

	IF (SELECT TOP 1 JobId FROM Jobs WHERE JobId = @JobID) IS NULL
	BEGIN
		RAISERROR('Job not found!', 13, 1)
		RETURN	
	END

	IF @PartID IS NULL
	BEGIN
		RAISERROR('Part not found!', 14, 1)
		RETURN	
	END

	BEGIN TRANSACTION

	--Check if order exists
	IF @OrderID IS NOT NULL
	BEGIN
		--Order exists and part in it
		IF (SELECT TOP 1 PartId FROM OrderParts WHERE OrderId = @OrderID AND PartId = @PartID) IS NOT NULL
		BEGIN
			UPDATE OrderParts
			SET Quantity += @Quantity
			WHERE OrderId = @OrderID AND PartId = @PartID
		END
		
		--ORder exists, part not in it
		ELSE
		BEGIN
			INSERT INTO OrderParts(OrderId, PartId, Quantity) VALUES
			(@OrderID, @PartID, @Quantity)
		END
	END

	--Order does not exist
	ELSE
	BEGIN
		INSERT INTO Orders(JobId, IssueDate) VALUES
		(@JobID, NULL)

		INSERT INTO OrderParts(OrderId, PartId, Quantity) VALUES
		((SELECT TOP 1 OrderId FROM Orders WHERE JobId = @JobID), @PartID, @Quantity)
	END

	COMMIT
END

--Check
DECLARE @err_msg AS NVARCHAR(MAX);
BEGIN TRY
  EXEC usp_PlaceOrder 45, 'Drain Pump', 1
END TRY

BEGIN CATCH
  SET @err_msg = ERROR_MESSAGE();
  SELECT @err_msg
END CATCH

SELECT * FROM Parts
SELECT * FROM Jobs


SELECT * FROM Orders
ORDER BY JobId

--19. Detect Delivery
GO
CREATE TRIGGER tr_DetectDeliveryAndUpdateStockQuantity ON Orders AFTER UPDATE
AS
BEGIN
	IF (SELECT TOP 1 Delivered FROM deleted) = 0 AND (SELECT TOP 1 Delivered FROM inserted) = 1
	BEGIN
		UPDATE Parts
		SET StockQty += op.Quantity
		FROM deleted AS d
		LEFT JOIN OrderParts AS op ON d.OrderId = op.OrderId
		LEFT JOIN Parts AS p ON op.PartId = p.PartId
	END	
END

--20. Vendor Preference
