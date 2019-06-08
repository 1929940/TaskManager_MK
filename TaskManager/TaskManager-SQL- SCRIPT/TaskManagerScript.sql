DROP TABLE IF EXISTS TaskManagerDB;

DROP PROCEDURE IF EXISTS SelectAllTasks;

DROP PROCEDURE IF EXISTS RemoveTask;

DROP Procedure IF EXISTS AddTask;

DROP Procedure IF EXISTS UpdateTask;

GO


CREATE TABLE TaskManagerDB (
	Id INT IDENTITY PRIMARY KEY,
	TaskDesc VARCHAR(1000) NOT NULL,
	Status VARCHAR(11) NOT NULL,
	Priority VARCHAR(6) NOT NULL,
	Deadline DATE);
	
GO
	
CREATE PROCEDURE SelectAllTasks
AS
SELECT * FROM TaskManagerDB
GO


CREATE PROCEDURE RemoveTask @Id INT
AS
DELETE FROM TaskManagerDB WHERE @Id = Id
GO


CREATE PROCEDURE AddTask 
	@Desc VARCHAR(1000), 
	@Status VARCHAR(11),
	@Priority VARCHAR(6), 
	@Deadline DATE
AS
INSERT INTO TaskManagerDB(TaskDesc, Status, Priority, Deadline)
	VALUES(@Desc, @Status, @Priority, @Deadline)
GO



CREATE PROCEDURE UpdateTask 
	@Id INT,
	@Desc VARCHAR(1000), 
	@Status VARCHAR(11), 
	@Priority VARCHAR(6), 
	@Deadline DATE
AS
UPDATE TaskManagerDB
SET TaskDesc = @Desc, 
	Status = @Status,
	Priority = @Priority,
	Deadline = @Deadline
WHERE Id = @Id
GO
  

INSERT INTO TaskManagerDB(TaskDesc, Status, Priority, Deadline)
	VALUES('Dancing in the rain forever and a day', 'In Progress', 'Normal', '2019-07-08');

INSERT INTO TaskManagerDB(TaskDesc, Status, Priority, Deadline)
	VALUES('Sewing a sweater for my grandchildren', 'In Progress', 'High', '2019-07-03');

INSERT INTO TaskManagerDB(TaskDesc, Status, Priority)
	VALUES('Reading the Song of Ice and Fire books', 'New', 'Low');

INSERT INTO TaskManagerDB(TaskDesc, Status, Priority)
	VALUES('Losing some belly fat', 'New', 'Normal');

INSERT INTO TaskManagerDB(TaskDesc, Status, Priority, Deadline)
	VALUES('Eating that one tasty kebab with double meat', 'Completed', 'High', GETDATE());

INSERT INTO TaskManagerDB(TaskDesc, Status, Priority, Deadline)
	VALUES('Enjoying the sun, the wind, generally, the weather', 'Completed', 'High', GETDATE());

INSERT INTO TaskManagerDB(TaskDesc, Status, Priority, Deadline)
	VALUES('This one is going to be long, very long, I am talking the longest of the longs but not that long. I am not crazy, typing 1000 characters here would take a while, and what if i write 1001? No way, not doing it. However, this should be enough to see how a longer description is displayed', 
	'Completed', 'High', GETDATE());



