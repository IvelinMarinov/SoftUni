--01. Create Database
CREATE DATABASE Minions

--02. Create Tables
USE Minions
CREATE TABLE Minions (
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(50),
	Age INT 
)

CREATE TABLE Towns(
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(50)
)

--03. Alter Minions Table
ALTER TABLE Minions
ADD TownId INT FOREIGN KEY REFERENCES Towns(Id)

--04. Insert Records in Both Tables
INSERT INTO Towns (Id, [Name]) VALUES
(1,'Sofia'),
(2,'Plovdiv'),
(3,'Varna')

INSERT INTO Minions (Id, [Name], Age, TownId) VALUES
(1,'Kevin', 22, 1),
(2,'Bob', 15, 3),
(3,'Steward', NULL, 2)

--05. Truncate Table Minions
TRUNCATE TABLE Minions

--06. Drop All Tables
DROP TABLE Towns
DROP TABLE Minions

--07. Create Table People
DROP TABLE People
TRUNCATE TABLE People

CREATE TABLE People(
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(200) NOT NULL,
	Picture VARBINARY(max) NULL,
	Height DECIMAL(3,2) NULL,
	Weight DECIMAL(5,2) NULL,
	Gendre CHAR(1) NOT NULL,
	Birthdate SMALLDATETIME NOT NULL,
	Biography NVARCHAR(max) NULL
)

ALTER TABLE People
ADD CONSTRAINT CK_PictureSize2MB CHECK (DATALENGTH(Picture) <= 2097152)

INSERT INTO People([Name], Picture, Height, Weight, Gendre, Birthdate, Biography) VALUES
('Test', 0xABC23187, 1.85, 88.5, 'm', '1988-06-07', 'TEST TEST TEST' ),
('Test1', 0xDBE1231, 1.85, 88.5, 'm', '1988-06-07', 'TEST TEST TEST' ),
('Test2', 0xAB2831E, 1.85, 88.5, 'm', '1988-06-07', 'TEST TEST TEST' ),
('Test3', 0xA878BE8C, 1.85, 88.5, 'm', '1988-06-07', 'TEST TEST TEST' ),
('Test4', 0x111111, 1.85, 88.5, 'm', '1988-06-07', 'TEST TEST TEST' )

--08. Create Table Users
DROP TABLE Users

CREATE TABLE Users(
	Id BIGINT IDENTITY PRIMARY KEY,
	Username VARCHAR(30) UNIQUE NOT NULL,
	Password VARCHAR(26) NOT NULL,
	ProfilePicture VARBINARY(max) NULL,
	LastLoginTime DATETIME NULL,
	IsDeleted BIT
)

ALTER TABLE Users
ADD CONSTRAINT CK_ProfilePicture900KB CHECK (DATALENGTH(ProfilePicture) <= 921600)

INSERT INTO Users VALUES
('Test Username', 'Test Password', 0xABC32131, '2017-09-23', 'true'),
('Test Username1', 'Test Password1', 0xABC6533, '2017-09-23 12:25:33', 'false'),
('Test Username2', 'Test Password2', 0xABC86812, '2017-09-23 12:25:33.999', 'true'),
('Test Username3', 'Test Password3', 0xABC542252, '2017-09-23', NULL),
('Test Username4', 'Test Password4', NULL, NULL, NULL)

--09. Change Primary Key
ALTER TABLE Users
DROP CONSTRAINT PK__Users__3214EC07CF1A6D40

ALTER TABLE Users
ADD CONSTRAINT PK_UsersPlusUsername
PRIMARY KEY (Id, Username)

--10. Add Check Constraint
ALTER TABLE Users
ADD CONSTRAINT CK_PasswordLength
CHECK (DATALENGTH(Password) >= 5)

--11. Set Default Value of a Field
ALTER TABLE Users
DROP CONSTRAINT DF_LastLogin

ALTER TABLE Users
ADD CONSTRAINT DF_LastLogin 
DEFAULT GETDATE() FOR LastLoginTime

INSERT INTO Users(Username, Password) VALUES
('Test Username9', 'Test Password9')

--12. Set Unique Field
ALTER TABLE Users
DROP CONSTRAINT PK_UsersPlusUsername

ALTER TABLE Users
ADD CONSTRAINT PK_Users
PRIMARY KEY (Id)

ALTER TABLE Users
ADD CONSTRAINT CK_UsernameLength
CHECK (DATALENGTH(Username) >= 3)

--13. Movies Database
CREATE DATABASE Movies

USE Movies
CREATE TABLE Directors(
	Id INT PRIMARY KEY IDENTITY,
	DirectorName NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(500) NULL
)

CREATE TABLE Genres(
	Id INT PRIMARY KEY IDENTITY,
	GenreName NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(500) NULL
)

CREATE TABLE Categories(
	Id INT PRIMARY KEY IDENTITY,
	CategoryName NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(500) NULL
)

CREATE TABLE Movies(
	Id INT PRIMARY KEY IDENTITY,
	Title NVARCHAR(50) NOT NULL,
	DirectorId INT NOT NULL FOREIGN KEY REFERENCES Directors (Id),
	CopyrightYear INT NULL,
	Length INT NULL,
	GenreId INT NOT NULL FOREIGN KEY REFERENCES Genres (Id),
	CategoryId INT NOT NULL FOREIGN KEY REFERENCES Categories (Id),
	Rating DECIMAL(5,2) NULL,
	Notes NVARCHAR(500) NULL
)

INSERT INTO Directors(DirectorName, Notes) VALUES
('TestDirectorName1', 'TestDirectorNotes1'),
('TestDirectorName2', 'TestDirectorNotes2'),
('TestDirectorName3', 'TestDirectorNotes3'),
('TestDirectorName4', NULL),
('TestDirectorName5', NULL)

INSERT INTO Genres(GenreName, Notes) VALUES
('TestGenreName1', 'TestGenreNote1'),
('TestGenreName2', NULL),
('TestGenreName3', NULL),
('TestGenreName4', 'TestGenreNote4'),
('TestGenreName5', NULL)

INSERT INTO Categories(CategoryName, Notes) VALUES
('TestCategoryName1', 'TestCategoryNote1'),
('TestCategoryName2', 'TestCategoryNote2'),
('TestCategoryName3', 'TestCategoryNote3'),
('TestCategoryName4', 'TestCategoryNote4'),
('TestCategoryName5', 'TestCategoryNote5')

INSERT INTO Movies(Title, DirectorId, CopyrightYear, Length, GenreId, CategoryId, Rating, Notes) VALUES
('TestTitle1', 1, 1999, 120, 1, 1, 8.5, 'Some Notes'),
('TestTitle2', 2, 2012, 105, 2, 2, 3.33, 'Some More Notes'),
('TestTitle3', 3, 1976, 180, 5, 4, 9.99, NULL),
('TestTitle4', 1, 2017, NULL, 1, 1, NULL, NULL),
('TestTitle5', 5, 1999, NULL, 1, 2, NULL, 'Some Notes')

--14. Car Rental Database
CREATE DATABASE CarRental

USE CarRental

CREATE TABLE Categories(
	Id INT PRIMARY KEY IDENTITY,
	CategoryName NVARCHAR(50) NOT NULL,
	DailyRate DECIMAL(7,2) NOT NULL,
	WeeklyRate DECIMAL(7,2) NOT NULL,
	MonthlyRate DECIMAL(7,2) NOT NULL,
	WeekendRate DECIMAL(7,2) NOT NULL
)

CREATE TABLE Cars(
	Id INT PRIMARY KEY IDENTITY,
	PlateNumber NVARCHAR(10) NOT NULL,
	Manufacturer NVARCHAR(20) NOT NULL,
	Model NVARCHAR(20) NOT NULL,
	CarYear INT NULL,
	CategoryId INT NOT NULL FOREIGN KEY REFERENCES Categories(Id),
	Doors INT NULL,
	Picture VARBINARY(max) NULL,
	Condition NVARCHAR(500) NULL,
	Available BIT NOT NULL DEFAULT 1
)

CREATE TABLE Employees(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(20) NOT NULL,
	LastName NVARCHAR(20) NOT NULL,
	Title NVARCHAR(20) NULL,
	Notes NVARCHAR(500) NULL
)

CREATE TABLE Customers(
	Id INT PRIMARY KEY IDENTITY,
	DriverLicenceNumber NVARCHAR(50) NOT NULL,
	FullName NVARCHAR(50) NOT NULL,
	Address NVARCHAR(100) NOT NULL,
	City NVARCHAR(50) NOT NULL,
	ZIPCode NVARCHAR(10) NOT NULL,
	Notes NVARCHAR(500) NULL
)

CREATE TABLE RentalOrders(
	Id INT PRIMARY KEY IDENTITY,
	EmployeeId INT NOT NULL FOREIGN KEY REFERENCES Employees(Id),
	CustomerId INT NOT NULL FOREIGN KEY REFERENCES Customers(Id),
	CarId INT NOT NULL FOREIGN KEY REFERENCES Cars(Id),
	TankLevel INT NOT NULL,
	KilometrageStart INT NOT NULL,
	KilometrageEnd INT NOT NULL,
	TotalKilometrage INT NOT NULL,
	StartDate DATE NOT NULL,
	EndDate DATE NOT NULL,
	TotalDays INT NOT NULL,
	RateApplied DECIMAL(7,2) NOT NULL,
	TaxRate DECIMAL(5,2) NOT NULL,
	OrderStatus NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(500) NULL
)

INSERT INTO Categories(CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate) VALUES
('Limos', 200, 1000, 3000, 350),
('Luxury', 300, 1500, 4500, 500),
('Affordable', 50, 200, 600, 70)

INSERT INTO Cars(PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Picture, Condition, Available) VALUES
('CB9999AB', 'Rolls-Royce', 'Ghost', 2015, 2, 4, 0x2311ADEF, 'Brand new', 1),
('B4400BH', 'Mercedes-Benz', 'S class', 2012, 1, 4, 0x262986ADEF, 'Armoured', 1),
('P5050PB', 'Peugeot', '307SW', 2004, 3, 4, 0xC31231ADEF, 'Better than the ghost', 0)

INSERT INTO Employees(FirstName, LastName, Title, Notes) VALUES
('John', 'Smith', NULL, NULL),
('Ivelin', 'Marinov', 'Janitor', 'On probation!'),
('Arsene', 'Wenger', 'Manager', NULL)

INSERT INTO Customers(DriverLicenceNumber, FullName, Address, City, ZIPCode, Notes) VALUES
('License Number1', 'FullName1', 'Address1', 'City1', 'ZIPcode1', NULL),
('License Number2', 'FullName2', 'Address2', 'City2', 'ZIPcode2', NULL),
('License Number3', 'FullName3', 'Address3', 'City3', 'ZIPcode3', NULL)

INSERT INTO RentalOrders(EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd, TotalKilometrage,
			StartDate, EndDate, TotalDays, RateApplied, TaxRate, OrderStatus, Notes) VALUES
(1, 1, 1, 50, 50000, 51000, 1000, '2017-09-01', '2017-09-20', 20, 500, 10, 'Test Status1', NULL),
(2, 2, 2, 80, 150000, 151000, 1000, '2017-09-01', '2017-09-20', 20, 500, 15, 'Test Status2', NULL),
(3, 3, 3, 20, 220000, 225000, 3000, '2017-08-01', '2017-08-30', 30, 100, 20, 'Test Status3', NULL)

--15. Hotel Database
CREATE DATABASE Hotel
USE Hotel

CREATE TABLE Employees(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(50) NOT NULL, 
	LastName NVARCHAR(50) NOT NULL, 
	Title NVARCHAR(50) NULL, 
	Notes NVARCHAR(500) NULL, 
)

CREATE TABLE Customers(
	AccountNumber NVARCHAR(50) NOT NULL PRIMARY KEY, 
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	PhoneNumber NVARCHAR(50) NOT NULL,
	EmergencyName NVARCHAR(50) NOT NULL,
	EmergencyNumber NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(500) NULL
)

CREATE TABLE RoomStatus(
	RoomStatus NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(500) NULL
)

CREATE TABLE RoomTypes(
	RoomType NVARCHAR(50), 
	Notes NVARCHAR(500) NULL
)

CREATE TABLE BedTypes(
	BedType NVARCHAR(50), 
	Notes NVARCHAR(500) NULL
)

CREATE TABLE Rooms(
	RoomNumber INT NOT NULL PRIMARY KEY,
	RoomType NVARCHAR(50) NOT NULL,
	BedType NVARCHAR(50) NOT NULL,
	Rate DECIMAL(10,2) NOT NULL,
	RoomStatus NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(500) NULL
)

CREATE TABLE Payments(
	Id INT PRIMARY KEY IDENTITY,
	EmployeeId INT NOT NULL FOREIGN KEY REFERENCES Employees(Id),
	PaymentDate DATE NOT NULL,
	AccountNumber NVARCHAR(50) NOT NULL FOREIGN KEY REFERENCES Customers(AccountNumber),
	FirstDateOccupied DATE NOT NULL,
	LastDateOccupied DATE NOT NULL,
	TotalDays INT NOT NULL,
	AmountCharged DECIMAL(10,2) NOT NULL,
	TaxRate DECIMAL(10,2) NOT NULL,
	TaxAmount DECIMAL(10,2) NOT NULL,
	PaymentTotal DECIMAL(10,2) NOT NULL,
	Notes NVARCHAR(500)
)

CREATE TABLE Occupancies(
	Id INT PRIMARY KEY IDENTITY,
	EmployeeId INT NOT NULL FOREIGN KEY REFERENCES Employees(Id),
	DateOccupied DATE NOT NULL,
	AccountNumber NVARCHAR(50) NOT NULL FOREIGN KEY REFERENCES Customers(AccountNumber),
	RoomNumber INT NOT NULL FOREIGN KEY REFERENCES Rooms(RoomNumber),
	RateApplied DECIMAL(10,2) NOT NULL,
	PhoneCharge DECIMAL(10,2) NOT NULL,
	Notes NVARCHAR(500) NULL
)

INSERT INTO Employees(FirstName, LastName, Title, Notes) VALUES
('Gosho', 'Toshov', 'Manager', NULL),
('Tosho', 'Goshov', 'Bell boy', NULL),
('Pesho', 'Peshov', 'Cook', NULL)

INSERT INTO Customers(AccountNumber, FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber, Notes) VALUES
('2139131', 'John', 'Smith', '+123456789', 'Jane Smith', '+123456780', NULL),
('4343135', 'Jane', 'Smith', '+123456780', 'John Smith', '+123456789', NULL),
('64254252', 'Peter', 'Pan', '+231319', 'n/a', '+00000', NULL)

INSERT INTO RoomStatus(RoomStatus, Notes) VALUES
('Test1', 'Test1'),
('Test2', 'Test2'),
('Test3', 'Test3')

INSERT INTO RoomTypes(RoomType, Notes) VALUES
('Test1', 'Test1'),
('Test2', 'Test2'),
('Test3', 'Test3')

INSERT INTO BedTypes(BedType, Notes) VALUES
('Test1', 'Test1'),
('Test2', 'Test2'),
('Test3', 'Test3')

INSERT INTO Rooms(RoomNumber, RoomType, BedType, Rate, RoomStatus, Notes) VALUES
('101', 1, 1, 50.00, 1, NULL),
('102', 2, 2, 60.00, 2, NULL),
('103', 3, 3, 70.00, 3, NULL)

INSERT INTO Payments(EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, TotalDays, AmountCharged,
					TaxRate, TaxAmount, PaymentTotal, Notes) VALUES
(1, '2017-06-06', '2139131', '2017-06-20', '2017-06-25', 5, 1000, 15, 150, 1150, NULL),
(2, '2017-07-06', '4343135', '2017-06-20', '2017-06-25', 5, 1000, 15, 150, 1150, NULL),
(3, '2017-08-06', '64254252', '2017-06-20', '2017-06-25', 5, 1000, 15, 150, 1150, NULL)

INSERT INTO Occupancies(EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied, PhoneCharge, Notes) VALUES
(1, '2017-06-06', '2139131', 101, 15, 50, NULL),
(1, '2017-06-08', '4343135', 102, 15, 12, NULL),
(1, '2017-06-10', '64254252', 103, 15, 0, NULL)

--16. Create SoftUni Database
CREATE DATABASE SoftUni
USE SoftUni

CREATE TABLE Towns(
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(50) NOT NULL
)

CREATE TABLE Addresses(
	Id INT PRIMARY KEY IDENTITY,
	AddressText NVARCHAR(100) NOT NULL,
	TownId INT NOT NULL FOREIGN KEY REFERENCES Towns(Id)
)

CREATE TABLE Departments(
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(50) NOT NULL
)

CREATE TABLE Employees(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	MiddleName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	JobTitle NVARCHAR(50) NOT NULL,
	DepartmentId INT NOT NULL FOREIGN KEY REFERENCES Departments(Id),
	HireDate DATE NOT NULL,
	Salary DECIMAL(10,2) NOT NULL,
	AddressId INT NULL FOREIGN KEY REFERENCES Addresses(Id)
)

--17. Backup Database --- TO DO 
BACKUP DATABASE SoftUni
TO DISK = 'C:\softuni-bakup.bak'

USE master
GO
DROP DATABASE SoftUni

RESTORE DATABASE SoftUni
FROM DISK = 'C:\softuni-bakup.bak'

--18. Basic Insert
USE SoftUni

INSERT INTO Towns(Name) VALUES
('Sofia'),
('Plovdiv'),
('Varna'),
('Burgas')

INSERT INTO Departments(Name) VALUES
('Engineering'), 
('Sales'), 
('Marketing'), 
('Software Development'), 
('Quality Assurance')

INSERT INTO Employees(FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary, AddressId) VALUES
('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 4, '2013-02-01',	3500.00, NULL),
('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1, '2004-03-02', 4000.00, NULL),
('Maria', 'Petrova', 'Ivanova', 'Intern', 5, '2016-08-28', 525.25, NULL),
('Georgi', 'Teziev', 'Ivanov', 'CEO', 2, '2007-12-09', 3000.00, NULL),
('Peter', 'Pan', 'Pan', 'Intern', 3, '2016-08-28', 599.88, NULL)

--19. Basic Select All Fields
SELECT * FROM Towns
SELECT * FROM Departments 
SELECT * FROM Employees 

--20. Basic Select All Fields and Order Them
SELECT * FROM Towns ORDER BY [Name] ASC
SELECT * FROM Departments ORDER BY [Name] ASC
SELECT * FROM Employees ORDER By Salary DESC

--21. Basic Select Some Fields
SELECT [Name] FROM Towns ORDER BY [Name] ASC
SELECT [Name] FROM Departments ORDER BY [Name] ASC
SELECT FirstName, LastName, JobTitle, Salary FROM Employees ORDER By Salary DESC

--22. Increase Employees Salary
USE SoftUni

UPDATE Employees
SET Salary *= 1.1
SELECT Salary FROM Employees

--23. Decrease Tax Rate
USE Hotel

UPDATE Payments
SET TaxRate *= 0.97
SELECT TaxRate FROM Payments

--24. Delete All Records
USE Hotel

TRUNCATE TABLE Occupancies

SELECT * FROM Occupancies