CREATE DATABASE TableRelationsExercise
USE TableRelationsExercise

DROP TABLE Persons
DROP TABLE Passports 

--01. One-To-One Relationship
CREATE TABLE Passports
(
	PassportID INT NOT NULL IDENTITY(101,1),
	PassportNumber VARCHAR(50),
)

CREATE TABLE Persons
(
	PersonID INT NOT NULL IDENTITY,
	FirstName VARCHAR(50) NOT NULL,
	Salary DECIMAL(8,2) NOT NULL,
	PassportID INT NOT NULL,
)

INSERT INTO Passports (PassportNumber)
VALUES
('N34FG21B'),
('K65LO4R7'),
('ZE657QP2')

INSERT INTO Persons (FirstName, Salary, PassportID)
VALUES
('Roberto', 43300.00, 102),
('Tom', 56100.00, 103),
('Yana', 60200.00, 101)

ALTER TABLE Passports
ADD CONSTRAINT pk_Passports 
PRIMARY KEY(PassportID)

ALTER TABLE Persons
ADD CONSTRAINT pk_Persons PRIMARY KEY(PersonID)

ALTER TABLE Persons
ADD	CONSTRAINT fk_Persons_Passports FOREIGN KEY(PassportID) 
	REFERENCES Passports(PassportID)

--02. One-To-Many Relationship
DROP TABLE Models
DROP TABLE Manufacturers

CREATE TABLE Manufacturers
(
	ManufacturerID INT NOT NULL IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	EstablishedOn DATE NOT NULL
)

CREATE TABLE Models
(
	ModelID INT NOT NULL IDENTITY(101, 1),
	[Name] VARCHAR(50) NOT NULL,
	ManufacturerID INT NOT NULL
)

INSERT INTO Manufacturers([Name], EstablishedOn)
VALUES
('BMW',	'1916-03-07'),
('Tesla', '2003-01-01'),
('Lada', '1966-05-01')

INSERT INTO Models([Name], ManufacturerID)
VALUES
('X1', 1),
('i6',	1),
('Model S', 2),
('Model X', 2),
('Model 3', 2),
('Nova', 3)

ALTER TABLE Models
ADD CONSTRAINT pk_Models PRIMARY KEY(ModelID)

ALTER TABLE Manufacturers
ADD CONSTRAINT pk_Manufacturers PRIMARY KEY (ManufacturerID)

ALTER TABLE Models
ADD CONSTRAINT fk_Models_Manufacturers FOREIGN KEY (ManufacturerID) 
	REFERENCES Manufacturers(ManufacturerID)

--03. Many-To-Many Relationship
CREATE TABLE Students
(
	StudentID INT NOT NULL IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Exams
(
	ExamID INT NOT NULL IDENTITY(101,1),
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE StudentsExams
(
	StudentID INT NOT NULL,
	ExamID INT NOT NULL
)

INSERT INTO Students ([Name])
VALUES
('Mila'),                                      
('Toni'),
('Ron')

INSERT INTO Exams (ExamID, [Name])
VALUES
('SpringMVC'),
('Neo4j'),
('Oracle 11g')

INSERT INTO StudentsExams (StudentID, ExamID)
VALUES
(1, 101),
(1, 102),
(2, 101),
(3, 103),
(2, 102),
(2, 103)

ALTER TABLE Students
ADD CONSTRAINT pk_Students PRIMARY KEY(StudentID)

ALTER TABLE Exams
ADD CONSTRAINT pk_Exams PRIMARY KEY(ExamID)

ALTER TABLE StudentsExams
ADD CONSTRAINT pk_StudentsExams PRIMARY KEY (StudentID, ExamID)

ALTER TABLE StudentsExams
ADD CONSTRAINT fk_StudentExams_Students FOREIGN KEY (StudentID) 
	REFERENCES Students(StudentID)

ALTER TABLE StudentsExams
ADD CONSTRAINT fk_StudentExams_Exams FOREIGN KEY (ExamID) 
	REFERENCES Exams(ExamID)

--04. Self-Referencing
CREATE TABLE Teachers
(
	TeacherID INT NOT NULL,
	[Name] VARCHAR(50) NOT NULL,
	ManagerID INT NULL
)

INSERT INTO Teachers (TeacherID, [Name], ManagerID)
VALUES
(101, 'John	', NULL),
(102, 'Maya	', 106),
(103, 'Silvia', 106),
(104, 'Ted	', 105),
(105, 'Mark	', 101),
(106, 'Greta', 101)

ALTER TABLE Teachers
ADD CONSTRAINT pk_Teachers PRIMARY KEY (TeacherID)

ALTER TABLE Teachers
ADD CONSTRAINT fk_Teachers_Teachers FOREIGN KEY (ManagerID) 
	REFERENCES Teachers(TeacherID)

--05. Online Store Database
CREATE TABLE Cities 
(
	CityID INT NOT NULL IDENTITY,
	[Name] VARCHAR(50) NOT NULL
	CONSTRAINT pk_Cities PRIMARY KEY (CityID)
)

CREATE TABLE Customers
(
	CustomerID INT NOT NULL IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	Birthday DATE,
	CityID INT NOT NULL
	CONSTRAINT pk_Customers PRIMARY KEY (CustomerID),
	CONSTRAINT fk_Customers_Cities FOREIGN KEY (CityID) REFERENCES Cities (CityID)
)

CREATE TABLE Orders
(
	OrderID INT NOT NULL IDENTITY,
	CustomerID INT NOT NULL,
	CONSTRAINT pk_Orders PRIMARY KEY (OrderID),
	CONSTRAINT fk_Orders_Customers FOREIGN KEY (CustomerID) REFERENCES Customers (CustomerID)
)

CREATE TABLE ItemTypes
(
	ItemTypeID INT NOT NULL IDENTITY,
	[Name] VARCHAR(50) NOT NULL
	CONSTRAINT pk_ItemTypes PRIMARY KEY (ItemTypeID)
)

CREATE TABLE Items
(
	ItemID INT NOT NULL IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	ItemTypeID INT NOT NULL
	CONSTRAINT pk_Items PRIMARY KEY (ItemID),
	CONSTRAINT fk_Items_ItemTypes FOREIGN KEY (ItemTypeID) REFERENCES ItemTypes (ItemTypeID)
)

CREATE TABLE OrderItems
(
	OrderID INT NOT NULL,
	ItemID INT NOT NULL,
	CONSTRAINT pk_OrderItems PRIMARY KEY (OrderID, ItemID),
	CONSTRAINT fk_OrderItems_Items FOREIGN KEY (ItemID) REFERENCES Items (ItemID),
	CONSTRAINT fk_OrderItems_Orders FOREIGN KEY (OrderID) REFERENCES Orders (OrderID)
)

DROP TABLE OrderItems
DROP TABLE Orders
DROP TABLE Items
DROP TABLE ItemTypes
DROP TABLE Customers
DROP TABLE Cities

--06. University Database
DROP TABLE Students

CREATE TABLE Subjects
(
	SubjectID INT NOT NULL IDENTITY,
	SubjectName VARCHAR(50) NOT NULL
	CONSTRAINT pk_Subjects PRIMARY KEY (SubjectID)
)

CREATE TABLE Majors
(
	MajorID INT NOT NULL IDENTITY,
	Name VARCHAR(50) NOT NULL,
	CONSTRAINT pk_Majors PRIMARY KEY (MajorID)
)

CREATE TABLE Students
(
	StudentID INT NOT NULL IDENTITY,
	StudentNumber VARCHAR(50) NOT NULL,
	StudentName VARCHAR(50) NOT NULL,
	MajorID INT NOT NULL,
	CONSTRAINT pk_Students PRIMARY KEY (StudentID),
	CONSTRAINT fk_Students_Majors FOREIGN KEY (MajorID) REFERENCES Majors (MajorID)
)

CREATE TABLE Payments
(
	PaymentID INT NOT NULL IDENTITY,
	PaymentDate DATE NOT NULL,
	PaymentAmount DECIMAL(8,2) NOT NULL,
	StudentID INT NOT NULL,
	CONSTRAINT pk_Payments PRIMARY KEY (PaymentID),
	CONSTRAINT fk_Payments_Students FOREIGN KEY (StudentID) REFERENCES Students (StudentID) 
)

CREATE TABLE Agenda
(
	StudentID INT NOT NULL,
	SubjectID INT NOT NULL,
	CONSTRAINT pk_Agenda PRIMARY KEY (StudentID, SubjectID),
	CONSTRAINT fk_Agenda_Subjects FOREIGN KEY (SubjectID) REFERENCES Subjects (SubjectID),
	CONSTRAINT fk_Agenda_Students FOREIGN KEY (StudentID) REFERENCES Students (StudentID)
)

DROP TABLE Subjects
DROP TABLE Majors
DROP TABLE Students
DROP TABLE Payments
DROP TABLE Agenda

--07. SoftUni Design

--08. Geography Design

--09. *Peaks in Rila
USE Geography

SELECT m.MountainRange, 
	   p.PeakName, 
	   p.Elevation 
FROM Mountains AS m
INNER JOIN Peaks AS p 
ON m.Id = p.MountainId
WHERE m.MountainRange = 'Rila'
ORDER BY p.Elevation DESC