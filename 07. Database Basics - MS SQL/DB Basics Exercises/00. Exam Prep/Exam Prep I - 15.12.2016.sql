--Section 1: DDL 1. Database Design
--CREATE DATABASE TheNerdHerd

CREATE TABLE Credentials
(
Id INT PRIMARY KEY IDENTITY,
Email VARCHAR(30),
Password VARCHAR(20)
)

CREATE TABLE Locations
(
Id INT PRIMARY KEY IDENTITY,
Latitude FLOAT,
Longitude FLOAT
)

CREATE TABLE Users
(
Id INT IDENTITY PRIMARY KEY ,
Nickname VARCHAR(25),
Gender CHAR(1),
Age INT,
LocationId INT FOREIGN KEY REFERENCES Locations(Id),
CredentialId INT FOREIGN KEY REFERENCES Credentials(Id) UNIQUE
)

CREATE TABLE Chats
(
Id INT PRIMARY KEY IDENTITY,
Title VARCHAR(32),
StartDate DATE,
IsActive BIT
)

CREATE TABLE Messages
(
Id INT PRIMARY KEY IDENTITY,
Content VARCHAR(200),
SentOn DATE,
ChatId INT FOREIGN KEY REFERENCES Chats(Id),
UserId INT FOREIGN KEY REFERENCES Users(Id)
)

CREATE TABLE UsersChats
(
UserId INT FOREIGN KEY REFERENCES Users(Id),
ChatId INT FOREIGN KEY REFERENCES Chats(Id),
CONSTRAINT PK_UsersChats PRIMARY KEY(ChatId,UserId)
)

--Section 2. DML 2. Insert
SELECT * FROM Messages

INSERT INTO Messages(Content, SentOn, ChatId, UserId)
SELECT CONCAT(u.Age, '-', u.Gender, '-', l.Latitude, '-', l.Longitude),
	   FORMAT(GETDATE(), 'yyyy-MM-dd'),
	   CASE u.Gender
	       WHEN 'F' THEN CEILING(SQRT(u.Age * 2))
	       WHEN 'M' THEN CEILING(POWER((u.Age / 18), 3))
	   END,
	   u.Id
FROM Users AS u
INNER JOIN Locations AS l
ON u.LocationId = l.Id
WHERE u.Id BETWEEN 10 AND 20

--Section 2. DML 3. Update
UPDATE [Chats]
SET StartDate = (SELECT MIN(m.SentOn) 
				  FROM [Chats] AS c 
				  JOIN [Messages] AS m ON c.Id = m.ChatId 
				 WHERE c.Id = Chats.Id)
WHERE Chats.Id IN  (SELECT c.Id 
					  FROM Chats AS c 
					  JOIN [Messages] AS m ON c.Id = m.ChatId 
					 GROUP BY c.Id, c.StartDate 
					HAVING c.StartDate > MIN(m.SentOn))
--FOR CHECK
SELECT COUNT(*) 
FROM Chats AS c
INNER JOIN Messages AS m
ON c.Id = m.ChatId
WHERE c.StartDate > m.SentOn

--Section 2. DML 4. Delete
DELETE FROM Locations
WHERE Id IN (SELECT l.Id FROM Users AS u
			 FULL OUTER JOIN Locations AS l
			 ON u.LocationId = l.Id
			 WHERE u.Id IS NULL)

--Section 3: Querying - 5. Age Range
SELECT Nickname, 
	   Gender, 
	   Age 
  FROM Users
 WHERE Age BETWEEN 22 AND 37

--Section 3: Querying - 6. Messages
SELECT Content, 
   	   SentOn 
FROM Messages
WHERE SentOn > '2014-05-12' AND Content LIKE '%just%'
ORDER BY Id DESC

--Section 3: Querying - 7. Chats
SELECT Title, 
	   IsActive 
FROM Chats
WHERE (IsActive = 0 AND LEN(Title) < 5)
OR SUBSTRING(Title, 3, 2) = 'tl'
ORDER BY Title DESC

--Section 3: Querying - 8. Chat Messages
SELECT c.Id, 
	   c.Title, 
	   m.Id 
FROM Chats AS c
LEFT JOIN Messages AS m
ON c.Id = m.ChatId
WHERE m.SentOn < '2012-03-26'
AND RIGHT(c.Title, 1) = 'x'
ORDER BY c.Id ASC, m.Id ASC

--Section 3: Querying - 9.	Message Count
SELECT TOP(5) m.ChatId, 
			  COUNT(m.Id) AS TotalMessages
		 FROM Messages AS m
		WHERE m.Id < 90
	GROUP BY m.ChatId
	ORDER BY TotalMessages DESC, m.ChatId ASC

--Section 3: Querying - 10. Credentials
   SELECT u.Nickname, 
	      c.Email, 
	      c.Password
     FROM Users AS u
LEFT JOIN Credentials AS c
	   ON u.CredentialId = c.Id
	WHERE c.Email LIKE '%co.uk'
 ORDER BY c.Email ASC

--Section 3: Querying - 11. Locations
   SELECT u.Id, 
	      u.Nickname, 
  	      u.Age
     FROM Users AS u
LEFT JOIN Locations AS l
		ON u.LocationId = l.Id
	 WHERE l.Id IS NULL

--Section 3: Querying - 12. Left Users
SELECT m.Id, 
	   m.ChatId , 
	   m.UserId
FROM Messages AS m
WHERE m.ChatId = 17
AND m.UserId NOT IN (SELECT UserId 
					FROM UsersChats
				    WHERE ChatId = 17)
OR m.UserId IS NULL
ORDER BY m.Id DESC

--Section 3: Querying - 13. Users in Bulgaria
SELECT u.Nickname,
	   c.Title,
	   l.Latitude,
	   l.Longitude
FROM Users AS u
INNER JOIN Locations AS l
ON u.LocationId = l.Id
INNER JOIN UsersChats AS uc
ON u.Id = uc.UserId
INNER JOIN Chats AS c
ON uc.ChatId = c.Id
WHERE (CAST(Latitude AS numeric(38,18)) BETWEEN 41.14 AND 44.13)
AND (CAST(Longitude AS numeric(38,18)) BETWEEN 22.21 AND 28.36)
ORDER BY c.Title ASC

--Section 3: Querying - 14. Last Chat
SELECT TOP(1) WITH TIES c.Title, 
						m.Content 
FROM Chats AS c
LEFT JOIN Messages AS m
ON c.Id = m.ChatId
ORDER BY c.StartDate DESC, m.SentOn ASC

--Section 4: Programmability - 15. Radians
GO
CREATE FUNCTION udf_GetRadians(@Degrees FLOAT)
RETURNS FLOAT
AS
BEGIN
	RETURN @Degrees * PI() / 180
END

SELECT dbo.udf_GetRadians(22.12) AS Radians

--Section 4: Programmability - 16. Change Password
GO
CREATE PROCEDURE udp_ChangePassword(@Email VARCHAR(50), @NewPass VARCHAR(50))
AS
BEGIN
	IF @Email NOT IN (SELECT Email FROM Credentials)
	BEGIN
		RAISERROR('The email does''t exist!', 16, 1)
		RETURN
	END

	UPDATE Credentials
	SET Password = @NewPass
	WHERE Email = @Email
END

EXEC udp_ChangePassword 'abarnes0@sogou.com','new_pass'

SELECT * FROM Credentials
WHERE Email = 'abarnes0@sogou.com'

--Section 4: Programmability - 17.	Send Message
GO
CREATE PROCEDURE udp_SendMessage(@UserId INT, @ChatId INT, @Content VARCHAR(50))
AS
BEGIN
	IF @UserId NOT IN (SELECT UserId FROM UsersChats
						WHERE ChatId = @ChatId)
	BEGIN
		RAISERROR('There is no chat with that user!', 16, 1)
		RETURN
	END

	INSERT INTO Messages(Content, SentOn, ChatId, UserId) VALUES
	(@Content, FORMAT(GETDATE(), 'yyyy-MM-dd'), @ChatId, @UserId)
END

EXEC dbo.udp_SendMessage 19, 17, 'Awesome'

SELECT TOP(1) * FROM Messages
ORDER BY Id DESC

--Section 4: Programmability - 18.	Log Messages
CREATE TABLE MessageLogs 
(
	Id INT PRIMARY KEY IDENTITY,
	Content VARCHAR(200),
	SentOn DATE,
	ChatId INT FOREIGN KEY REFERENCES Chats(Id),
	UserId INT FOREIGN KEY REFERENCES Users(Id)
)

GO
CREATE TRIGGER tr_LogDeletedMessages ON Messages AFTER DELETE
AS
BEGIN
	INSERT INTO MessageLogs(Id, Content, SentOn, ChatId, UserId) 
	SELECT d.Id, 
		   d.Content,
		   d.SentOn,
		   d.ChatId,
		   d.UserId
	FROM deleted AS d
END

DELETE FROM Messages
WHERE Id = 135

SELECT * FROM MessageLogs

--Section 5: Bonus - 19. Delete users
SELECT * FROM Users