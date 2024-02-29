create database RecruitingPlatform;
use RecruitingPlatform;

CREATE TABLE Candidate (
candidateID INT PRIMARY KEY,
first_name VARCHAR(50),
last_name VARCHAR(50),
email VARCHAR(50),
phone_number VARCHAR(50),
candidate_address TEXT,
resume_file VARCHAR(5),
skills TEXT,
education TEXT,
experience TEXT);

CREATE TABLE Job(
jobID INT PRIMARY KEY,
job_title VARCHAR(50),
job_description TEXT,
companyID INT,
FOREIGN KEY (companyID) REFERENCES Employer(companyID),
job_location VARCHAR(100),
required_skills TEXT,
application_deadline DATE,
salary_range VARCHAR(50),
job_category VARCHAR(50),
);

CREATE TABLE Employer(
companyID INT PRIMARY KEY,
company_name VARCHAR(100),
industry VARCHAR(50),
company_location VARCHAR(50),
website VARCHAR(50),
email VARCHAR(50),
phone_number VARCHAR(20)
);

CREATE TABLE Applications(
applicationID INT PRIMARY KEY,
candidateID INT,
FOREIGN KEY (candidateID) REFERENCES Candidate(candidateID),
jobID INT,
FOREIGN KEY (jobID) REFERENCES Job(jobID),
application_status VARCHAR(50),
application_date DATE,
attachment VARCHAR(5)
);

CREATE TABLE User_account(
userID INT PRIMARY KEY,
username VARCHAR(50),
user_password VARCHAR(50),
user_role VARCHAR(20),
last_login DATETIME
);

CREATE TABLE Interview(
interviewID INT PRIMARY KEY,
candidateID INT,
FOREIGN KEY (candidateID) REFERENCES Candidate(candidateID),
jobID INT,
FOREIGN KEY (jobID) REFERENCES Job(jobID),
interview_date DATETIME,
interviewer VARCHAR(50),
interview_location VARCHAR(50),
feedback TEXT
);

CREATE TABLE Feedback(
feedbackID INT PRIMARY KEY,
candidateID INT,
FOREIGN KEY (candidateID) REFERENCES Candidate(candidateID),
recruiterID INT,
FOREIGN KEY (recruiterID) REFERENCES Employer(companyID),
interviewID INT,
FOREIGN KEY (interviewID) REFERENCES Interview(interviewID),
feedback_timestamp DATETIME,
feedback TEXT
);

CREATE TABLE Skills(
skillID INT PRIMARY KEY,
skill_name VARCHAR(50),
skill_description TEXT
);

CREATE TABLE Task(
taskID INT PRIMARY KEY,
userID INT,
FOREIGN KEY (userID) REFERENCES User_account(userID),
task_title VARCHAR(100),
task_description TEXT,
due_date DATE,
task_status VARCHAR(20)
);


CREATE TABLE Conversations(
messageID INT PRIMARY KEY,
senderID INT,
FOREIGN KEY (senderID) REFERENCES User_account(userID),
recipientID INT,
FOREIGN KEY (recipientID) REFERENCES User_account(userID),
message_subject VARCHAR(50),
message_timestamp DATETIME,
message_body TEXT
);

INSERT INTO Candidate(candidateID, first_name, last_name, email, phone_number, candidate_address, resume_file, skills, education, experience)
VALUES ('12','John', 'Doe', 'john.doe@example.com','0752358112', '123 Main St,City', 'yes', 'Programming, Data Analysis', 'BSc in Computer Science', '3 years');

INSERT INTO Candidate(candidateID, first_name, last_name, email, phone_number, candidate_address, resume_file, skills, education, experience)
VALUES ('1','Jane', 'Smith', 'jane.smith@yahoo.com','0741937229', '456 Elm St, Town', 'no', 'Student', 'BSc in Computer Science', '0 years');

INSERT INTO Candidate(candidateID, first_name, last_name, email, phone_number, candidate_address, resume_file, skills, education, experience)
VALUES ('89','Emily', 'Brown', 'emily.b@gmail.com','0721312095', '567 Pine St, Suburb', 'yes', 'Graphic Design, UI/UX', 'BFA in Design', '2 years');

INSERT INTO Candidate(candidateID, first_name, last_name, email, phone_number, candidate_address, resume_file, skills, education, experience)
VALUES ('2','Alex', 'Brown', 'alexbb@gmail.com','0764324557', '456 Oak St, Town', 'yes', 'Programming, Project Management', 'BFA in Computer Science', '5 years');

INSERT INTO Candidate(candidateID, first_name, last_name, email, phone_number, candidate_address, resume_file, skills, education, experience)
VALUES ('33','Vanessa', 'Mihai', 'mvanessa@gmail.com','076793142', '789 Elm St, Village, Country', 'no', 'Programming', 'Student', '0 years');

INSERT INTO Candidate(candidateID, first_name, last_name, email, phone_number, candidate_address, resume_file, skills, education, experience)
VALUES ('8','Andreea', 'Pop', 'andreea.pop@gmail.com','0752759341', '56 Elf St, Suburb', 'yes', 'Graphic Design, UI/UX', 'BFA in Design', '1 year');

SELECT* from Candidate;

INSERT INTO Job(jobID, job_title, job_description, companyID, job_location, required_skills, application_deadline, salary_range, job_category)
VALUES
('21', 'Software Developer', 'Develop software', '1', 'Cluj-Napoca', 'Programming, Problem Solving', '2023-11-01', '6000-8000', 'IT'),
('3', 'Marketing Specialist', 'Marketing ', '2', 'Brasov', 'Marketing, Communication', '2023-11-15', '4500-5000', 'Marketing'),
('4', 'Financial Analyst', 'Analyze finances', '3', 'Timisoara', 'Finance, Data Analysis', '2023-10-01', '7000-9000', 'Finance');

INSERT INTO Job (jobID, job_title, job_description, companyID, job_location, required_skills, application_deadline, salary_range, job_category)
VALUES
('14', 'Graphic Designer', 'Create visual concepts', '2', 'Brasov', 'Adobe Creative Suite, Illustration, Layout', '2023-11-25', '4000-5000', 'Design'),
('5', 'Data Analyst', 'Analyze and interpret data', '3', 'Timisoara', 'Data Mining, Statistics, Excel', '2023-11-30', '3500-4500', 'Analytics'),
('6', 'Sales Representative', 'Promote company products', '1', 'Cluj-Napoca', 'Sales Techniques, Customer Relations, Negotiation', '2023-12-20', '4500-6500', 'Sales');


SELECT * FROM Job;

INSERT INTO Employer(companyID, company_name, industry, company_location, website, email, phone_number)
VALUES
('1','Bosch', 'IT', 'Cluj-Napoca', 'bosch.com', 'bosch@office.com', '0214929202'),
('2', 'Dedeman', 'Home depot', 'Brasov','dedeman.ro', 'dedeman@office.com', '0938384821'),
('3', 'Endava', 'IT', 'Timisoara', 'endava.com', 'endava@office.com', '0092484628');


INSERT INTO Employer (companyID, company_name, industry, company_location, website, email, phone_number)
VALUES
('8', 'Arobs', 'Technology', 'Cluj-Napoca', 'www.arobs.com', 'info@arobs.com', '111-111-1111'),
('76', 'Global Print', 'Marketing', 'Oradea', 'www.globalprint.com', 'info@globalmarketing.com', '222-222-2222'),
('12', 'Technoworks', 'Analytics', 'Cluj-Napoca', 'www.technoworks.com', 'info@technoworks.com', '333-333-3333');
SELECT * FROM Employer;


INSERT INTO Applications(applicationID, candidateID, jobID, application_status, application_date, attachment)
VALUES
('234','12', '21', 'received', '2023-07-12', 'yes'),
('43', '1', '3', 'in progress', '2023-10-11', 'yes'),
('56', '89', '4', 'denied', '2023-09-05', 'yes');

INSERT INTO Applications (applicationID, candidateID, jobID, application_status, application_date, attachment)
VALUES
('1', '8', '14', 'pending', '2023-11-05', 'yes'),
('26', '2', '5', 'in progress', '2023-10-20', 'yes'),
('34', '33', '6', 'denied', '2023-09-15', 'no');

SELECT * FROM Applications;

UPDATE Candidate
SET first_name='Sergiu'
WHERE candidateID<10;

SELECT * FROM Candidate;

UPDATE Employer
SET company_name='Arobs', website='arobs.ro', email='office@arobs.com'
WHERE company_name LIKE 'Bosch';

SELECT * FROM Employer;

UPDATE Applications
SET application_status='received'
WHERE attachment='yes' AND application_status='in progress';

SELECT * FROM Applications;

DELETE FROM Applications
WHERE applicationID BETWEEN '40' AND '45';
--pb
SELECT * FROM Job;

SELECT company_location FROM Employer
UNION
SELECT job_location FROM Job
ORDER BY company_location;

(SELECT candidateID FROM Candidate
WHERE first_name='Sergiu' OR first_name='Emily')
UNION
(SELECT companyID FROM Employer
WHERE company_name='Dedeman' OR company_name='Endava')

SELECT jobID FROM Job
INTERSECT
SELECT jobID FROM Applications;

SELECT companyID FROM Employer
INTERSECT
SELECT companyID FROM Job;

SELECT candidateID, first_name, last_name
FROM Candidate
EXCEPT
SELECT candidateID, '', ''
FROM Applications;

SELECT candidateID, first_name, last_name
FROM Candidate
WHERE candidateID NOT IN (SELECT candidateID FROM Applications);

SELECT Candidate.first_name, Candidate.last_name, Job.job_title
FROM Candidate
INNER JOIN Applications ON Candidate.candidateID = Applications.candidateID
INNER JOIN Job ON Applications.jobID = Job.jobID;

SELECT Candidate.first_name, Candidate.last_name, Applications.application_status
FROM Candidate
LEFT JOIN Applications ON Candidate.candidateID = Applications.candidateID;

SELECT Applications.application_status, Job.job_title, Employer.company_name
FROM Applications
RIGHT JOIN Job ON Applications.jobID = Job.jobID
RIGHT JOIN Employer ON Job.companyID = Employer.companyID;

SELECT Candidate.first_name, Candidate.last_name, Applications.application_status
FROM Candidate
FULL JOIN Applications ON Candidate.candidateID = Applications.candidateID;

SELECT candidateID, first_name, last_name
FROM Candidate
WHERE candidateID IN (SELECT candidateID FROM Applications WHERE application_status = 'received');

SELECT candidateID, first_name, last_name
FROM Candidate
WHERE candidateID IN (SELECT candidateID FROM Applications WHERE jobID IN (SELECT jobID FROM Job WHERE job_category = 'IT'));

SELECT jobID, job_title
FROM Job J
WHERE EXISTS (SELECT 1 FROM Applications A WHERE J.jobID = A.jobID AND A.application_status = 'denied');

SELECT jobID, job_title
FROM Job J
WHERE EXISTS (SELECT 1 FROM Applications A WHERE J.jobID = A.jobID AND EXISTS (SELECT 1 FROM Candidate C WHERE A.candidateID = C.candidateID AND C.skills LIKE '%Programming%'));

SELECT AVG(total_applications)
FROM (SELECT COUNT(*) AS total_applications FROM Applications GROUP BY jobID) AS TotalApplicationsPerJob;

SELECT A.*
FROM (SELECT * FROM Applications WHERE application_status = 'received') AS A;

SELECT jobID, COUNT(*) AS total_applications
FROM Applications
GROUP BY jobID
HAVING COUNT(*) > 2;

SELECT jobID, COUNT(*) AS total_applications
FROM Applications
GROUP BY jobID
HAVING COUNT(*) > (SELECT COUNT(*) FROM Candidate);

SELECT jobID, job_title
FROM Job
WHERE jobID = ANY (SELECT jobID FROM Applications WHERE application_status = 'in progress');

SELECT jobID, job_title
FROM Job
WHERE jobID IN (SELECT jobID FROM Applications WHERE application_status = 'denied');

SELECT jobID, job_title
FROM Job
WHERE jobID = ANY (SELECT jobID FROM Applications GROUP BY jobID HAVING COUNT(*) > 1);

SELECT jobID, job_title
FROM Job
WHERE jobID IN (SELECT jobID FROM Applications GROUP BY jobID HAVING COUNT(*) = (SELECT MAX(app_count) FROM (SELECT COUNT(*) AS app_count FROM Applications GROUP BY jobID) AS Counts));


CREATE PROCEDURE ModifyColumnType
AS
	ALTER TABLE Candidate
	ALTER COLUMN resume_file TEXT;
GO

CREATE PROCEDURE RevertModifyColumnType
AS
    ALTER TABLE Candidate
    ALTER COLUMN resume_file VARCHAR(5);
GO

CREATE PROCEDURE AddNewColumn
AS
    ALTER TABLE Candidate
    ADD date_of_birth DATE;
GO

CREATE PROCEDURE RevertAddNewColumn
AS
    ALTER TABLE Candidate
    DROP COLUMN date_of_birth;
GO

CREATE PROCEDURE AddDefaultConstraint
AS
    ALTER TABLE Candidate
    ADD CONSTRAINT Default_Candidate_Address DEFAULT 'Not provided' FOR candidate_address;
GO

CREATE PROCEDURE RevertAddDefaultConstraint
AS
	ALTER TABLE Candidate DROP CONSTRAINT Default_Candidate_Address;
GO
CREATE PROCEDURE AddPrimaryKey
AS
    ALTER TABLE Candidate
    ADD CONSTRAINT PK_CandidateID PRIMARY KEY (candidateID);
GO

CREATE PROCEDURE RevertAddPrimaryKey
AS
    ALTER TABLE Candidate
    DROP CONSTRAINT PK_CandidateID;
GO

CREATE PROCEDURE AddCandidateKey
AS
    ALTER TABLE Candidate
    ADD CONSTRAINT AK_Email UNIQUE (email);
GO

CREATE PROCEDURE RevertAddCandidateKey
AS
    ALTER TABLE Candidate
    DROP CONSTRAINT AK_Email;
GO

CREATE PROCEDURE AddForeignKey
AS
    ALTER TABLE Applications
    ADD CONSTRAINT FK_CandidateID
    FOREIGN KEY (candidateID) REFERENCES Candidate(candidateID);
GO

CREATE PROCEDURE RevertAddForeignKey
AS
    ALTER TABLE Applications
    DROP CONSTRAINT FK_CandidateID;
GO

CREATE PROCEDURE DropTableSkills
AS
    DROP TABLE IF EXISTS Skills;
GO

CREATE PROCEDURE RevertDropTableSkills
AS
    CREATE TABLE Skills (
        skillID INT PRIMARY KEY,
        skill_name VARCHAR(50),
        skill_description TEXT
    );
GO

CREATE TABLE versionTable (
	version INT
)

INSERT INTO versionTable 
VALUES
	(1)

CREATE TABLE procedureTable (
	initial_version INT,
	final_version INT,
	procedure_name VARCHAR(MAX),
	PRIMARY KEY (initial_version, final_version)
)

INSERT INTO procedureTable VALUES
(1,2,'AddCandidateKey'),
(2,1,'RevertAddCandidateKey'),
(2,3,'AddDefaultConstraint'),
(3,2,'RevertAddDefaultConstraint'),
(3,4,'AddForeignKey'),
(4,3,'RevertAddForeignKey'),
(4,5,'AddNewColumn'),
(5,4,'RevertAddNewColumn'),
(5,6,'AddPrimaryKey'),
(6,5,'RevertAddPrimaryKey'),
(6,7,'DropTableSkills'),
(7,6,'RevertDropTableSkills'),
(7,8,'ModifyColumnType'),
(8,7,'RevertModifyColumnType')

GO
CREATE OR ALTER PROCEDURE goToVersion(@newVersion INT) 
AS
	DECLARE @current_version INT
	DECLARE @procedureName VARCHAR(MAX)
	SELECT @current_version = version FROM versionTable

	IF (@newVersion > (SELECT MAX(final_version) FROM procedureTable) OR @newVersion < 1)
		RAISERROR ('Bad version', 10, 1)
	ELSE
	BEGIN
		IF @newVersion = @current_version
			PRINT('You are already on this version!');
		ELSE
		BEGIN
			IF @current_version > @newVersion
			BEGIN
				WHILE @current_version > @newVersion 
					BEGIN
						SELECT @procedureName = procedure_name FROM procedureTable WHERE initial_version = @current_version AND final_version = @current_version-1
						PRINT('Executing ' + @procedureName);
						EXEC (@procedureName)
						SET @current_version = @current_version - 1
					END
			END

			IF @current_version < @newVersion
			BEGIN
				WHILE @current_version < @newVersion 
					BEGIN
						SELECT @procedureName = procedure_name FROM procedureTable WHERE initial_version = @current_version AND final_version = @current_version+1
						PRINT('Executing ' + @procedureName);
						EXEC (@procedureName)
						SET @current_version = @current_version + 1
					END
			END

			UPDATE versionTable SET version = @newVersion
		END
	END

SELECT * FROM versionTable;
EXEC goToVersion 1;

--lab4

CREATE TABLE [Tables] (
	[TableID] [int] IDENTITY (1, 1) NOT NULL ,
	--ID column is set as an identity column 
	--starting at 1 and incrementing by 1. When you insert a new row into this table 
	--without specifying a value for the ID column,
	--SQL Server automatically assigns a unique, incremental value to that column.
	[Name] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL 
) ON [PRIMARY]--the data for this table should be stored in the primary filegroup

GO
CREATE TABLE [TestRunTables] (
	[TestRunID] [int] NOT NULL ,
	[TableID] [int] NOT NULL ,
	[StartAt] [datetime] NOT NULL ,
	[EndAt] [datetime] NOT NULL 
) ON [PRIMARY]

GO
CREATE TABLE [TestRunViews] (
	[TestRunID] [int] NOT NULL ,
	[ViewID] [int] NOT NULL ,
	[StartAt] [datetime] NOT NULL ,
	[EndAt] [datetime] NOT NULL 
) ON [PRIMARY]

GO
CREATE TABLE [TestRuns] (
	[TestRunID] [int] IDENTITY (1, 1) NOT NULL ,
	[Description] [nvarchar] (2000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[StartAt] [datetime] NULL ,
	[EndAt] [datetime] NULL 
) ON [PRIMARY]

GO
CREATE TABLE [TestTables] (
	[TestID] [int] NOT NULL ,
	[TableID] [int] NOT NULL ,
	[NoOfRows] [int] NOT NULL ,
	[Position] [int] NOT NULL 
) ON [PRIMARY]

GO
CREATE TABLE [TestViews] (
	[TestID] [int] NOT NULL ,
	[ViewID] [int] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [Tests] (
	[TestID] [int] IDENTITY (1, 1) NOT NULL ,
	[Name] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL 
) ON [PRIMARY]

GO
CREATE TABLE [Views] (
	[ViewID] [int] IDENTITY (1, 1) NOT NULL ,
	[Name] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL 
) ON [PRIMARY]
GO

ALTER TABLE [Tables] WITH NOCHECK ADD 
	CONSTRAINT [PK_Tables] PRIMARY KEY  CLUSTERED 
	(
		[TableID]
	)  ON [PRIMARY] 
GO
ALTER TABLE [TestRunTables] WITH NOCHECK ADD 
	CONSTRAINT [PK_TestRunTables] PRIMARY KEY  CLUSTERED 
	(
		[TestRunID],
		[TableID]
	)  ON [PRIMARY] 
GO
ALTER TABLE [TestRunViews] WITH NOCHECK ADD 
	CONSTRAINT [PK_TestRunViews] PRIMARY KEY  CLUSTERED 
	(
		[TestRunID],
		[ViewID]
	)  ON [PRIMARY] 
GO
ALTER TABLE [TestRuns] WITH NOCHECK ADD 
	CONSTRAINT [PK_TestRuns] PRIMARY KEY  CLUSTERED 
	(
		[TestRunID]
	)  ON [PRIMARY] 
GO
ALTER TABLE [TestTables] WITH NOCHECK ADD 
	CONSTRAINT [PK_TestTables] PRIMARY KEY  CLUSTERED 
	(
		[TestID],
		[TableID]
	)  ON [PRIMARY] 
GO
ALTER TABLE [TestViews] WITH NOCHECK ADD 
	CONSTRAINT [PK_TestViews] PRIMARY KEY  CLUSTERED 
	(
		[TestID],
		[ViewID]
	)  ON [PRIMARY] 
GO
ALTER TABLE [Tests] WITH NOCHECK ADD 
	CONSTRAINT [PK_Tests] PRIMARY KEY  CLUSTERED 
	(
		[TestID]
	)  ON [PRIMARY] 
GO
ALTER TABLE [Views] WITH NOCHECK ADD 
	CONSTRAINT [PK_Views] PRIMARY KEY  CLUSTERED 
	(
		[ViewID]
	)  ON [PRIMARY] 
GO
ALTER TABLE [TestRunTables] ADD 
	CONSTRAINT [FK_TestRunTables_Tables] FOREIGN KEY 
	(
		[TableID]
	) REFERENCES [Tables] (
		[TableID]
	) ON DELETE CASCADE  ON UPDATE CASCADE ,
	CONSTRAINT [FK_TestRunTables_TestRuns] FOREIGN KEY 
	(
		[TestRunID]
	) REFERENCES [TestRuns] (
		[TestRunID]
	) ON DELETE CASCADE  ON UPDATE CASCADE 
GO
ALTER TABLE [TestRunViews] ADD 
	CONSTRAINT [FK_TestRunViews_TestRuns] FOREIGN KEY 
	(
		[TestRunID]
	) REFERENCES [TestRuns] (
		[TestRunID]
	) ON DELETE CASCADE  ON UPDATE CASCADE ,
	CONSTRAINT [FK_TestRunViews_Views] FOREIGN KEY 
	(
		[ViewID]
	) REFERENCES [Views] (
		[ViewID]
	) ON DELETE CASCADE  ON UPDATE CASCADE 
GO
ALTER TABLE [TestTables] ADD 
	CONSTRAINT [FK_TestTables_Tables] FOREIGN KEY 
	(
		[TableID]
	) REFERENCES [Tables] (
		[TableID]
	) ON DELETE CASCADE  ON UPDATE CASCADE ,
	CONSTRAINT [FK_TestTables_Tests] FOREIGN KEY 
	(
		[TestID]
	) REFERENCES [Tests] (
		[TestID]
	) ON DELETE CASCADE  ON UPDATE CASCADE 
GO
ALTER TABLE [TestViews] ADD 
	CONSTRAINT [FK_TestViews_Tests] FOREIGN KEY 
	(
		[TestID]
	) REFERENCES [Tests] (
		[TestID]
	),
	CONSTRAINT [FK_TestViews_Views] FOREIGN KEY 
	(
		[ViewID]
	) REFERENCES [Views] (
		[ViewID]
	)
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[FK_TestRunTables_Tables]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [TestRunTables] DROP CONSTRAINT FK_TestRunTables_Tables

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[FK_TestTables_Tables]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [TestTables] DROP CONSTRAINT FK_TestTables_Tables

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[FK_TestRunTables_TestRuns]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [TestRunTables] DROP CONSTRAINT FK_TestRunTables_TestRuns

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[FK_TestRunViews_TestRuns]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [TestRunViews] DROP CONSTRAINT FK_TestRunViews_TestRuns

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[FK_TestTables_Tests]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [TestTables] DROP CONSTRAINT FK_TestTables_Tests

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[FK_TestViews_Tests]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [TestViews] DROP CONSTRAINT FK_TestViews_Tests

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[FK_TestRunViews_Views]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [TestRunViews] DROP CONSTRAINT FK_TestRunViews_Views

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[FK_TestViews_Views]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [TestViews] DROP CONSTRAINT FK_TestViews_Views

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[Tables]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [Tables]

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[TestRunTables]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [TestRunTables]

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[TestRunViews]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [TestRunViews]

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[TestRuns]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [TestRuns]

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[TestTables]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [TestTables]

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[TestViews]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [TestViews]

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[Tests]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [Tests]

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[Views]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [Views]

GO

CREATE OR ALTER PROCEDURE addTableToTables(@tableName VARCHAR(50))
AS
BEGIN
	IF @tableName IN (SELECT [Name] FROM [TABLES])
	BEGIN
		PRINT 'The table is already in the Tables'
		RETURN
	END
	IF @tableName NOT IN (SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES)
	BEGIN
		PRINT 'The table is not present in the database'
		RETURN
	END
	INSERT INTO [Tables] ([Name])
	VALUES
	(@tableName)
END

GO

CREATE OR ALTER PROCEDURE addViewToViews(@viewName VARCHAR(50))
AS
BEGIN
	IF @viewName IN (SELECT [Name] FROM [Views])
	BEGIN
		PRINT 'The view is already in the views table'
		RETURN
	END
	IF @viewName NOT IN (SELECT TABLE_NAME FROM INFORMATION_SCHEMA.VIEWS)
	BEGIN
		PRINT 'The view is not in the database'
		RETURN
	END
	INSERT INTO [Views] ([Name])
	VALUES
	(@viewName)
END

GO

CREATE OR ALTER PROCEDURE addTestToTests(@testName VARCHAR(50))
AS
BEGIN
	IF @testName IN (SELECT [Name] FROM [Tests])
	BEGIN
		PRINT 'the test is already in the table Tests'
		RETURN
	END
	INSERT INTO [Tests] ([Name])
	VALUES
	(@testName)
END
GO

CREATE OR ALTER PROCEDURE connectTableToTest(@tableName VARCHAR(50), @testName VARCHAR(50),@rows INT, @position INT) AS
BEGIN
	IF @tableName NOT IN(SELECT [Name] FROM [Tables])	
	BEGIN
		PRINT 'Table is not present in tables'
		RETURN
	END
	IF @testName NOT IN (SELECT [Name] FROM [Tests])
	BEGIN
		PRINT 'Test not present in Tests'
		RETURN
	END
	IF EXISTS(
			SELECT * FROM TestTables T1 
			JOIN Tests T2
			ON T1.TestID=T2.TestID
			WHERE T2.[Name]=@testName and Position=@position
	)
	BEGIN
		PRINT 'the position is the same as the previous positions'
		RETURN
	END
	INSERT INTO [TestTables] (TestID, TableID, NoOfRows, Position)
	VALUES(
	(SELECT [Tests].TestID FROM [Tests] WHERE [Name]=@testName),
	(SELECT [Tables].TableID FROM [Tables] WHERE [Name]=@tableName),
	@rows,
	@position
	)
END
GO

CREATE OR ALTER PROCEDURE connectViewToTest(@viewName VARCHAR(50),@testName VARCHAR(50)) 
AS
BEGIN
	IF @viewName NOT IN (SELECT [Name] FROM [Views])
	BEGIN
		PRINT 'the view is not in the views table'
		RETURN
	END
	IF @testName NOT IN (SELECT [Name] FROM [Tests])
	BEGIN
		PRINT 'the test in not in the tests table'
		RETURN
	END
	INSERT INTO [TestViews](TestID, ViewID)
	VALUES
	(
		(SELECT [Tests].TestID FROM [Tests] WHERE [Name]=@testName),
		(SELECT [Views].ViewID FROM [Views] WHERE [Name]=@viewName)
	)
END
GO

CREATE OR ALTER PROCEDURE deleteFromTable(@tableID INT)
AS
BEGIN
	IF @tableID NOT IN (SELECT [TableID] FROM [Tables])
	BEGIN
		PRINT 'Table is not in Tables'
		RETURN
	END

	DECLARE @tableName NVARCHAR(50) = (SELECT [Name] FROM [Tables] WHERE TableID = @tableID)
	PRINT 'Deleting data from ' + @tableName

	DECLARE @query NVARCHAR(100) = N'DELETE FROM ' + QUOTENAME(@tableName)
	PRINT @query

	EXEC sp_executesql @query
END
GO


CREATE OR ALTER PROCEDURE deleteFromAllTables(@testID INT)
AS
BEGIN
	IF @testID NOT IN (SELECT [TestID] FROM [Tests])
	BEGIN
		PRINT 'Test is not present in Tests'
		RETURN
	END
	PRINT 'deleting data from all tables for the test ' + CONVERT(VARCHAR,@testID)
	DECLARE @tableID INT
	DECLARE @position INT
	DECLARE CntTableDesc CURSOR LOCAL FOR
		SELECT T1.TableID, T1.Position
		FROM TestTables T1
		INNER JOIN Tests T2 ON T2.TestID=T1.TestID
		WHERE T2.TestID=@testID
		ORDER BY T1.Position DESC

	OPEN CntTableDesc
	FETCH CntTableDesc INTO @tableID, @position
	WHILE @@FETCH_STATUS=0
	BEGIN
		EXEC deleteFromTable @tableID
		FETCH NEXT FROM CntTableDesc INTO @tableID, @position
	END
	CLOSE CntTableDesc
	DEALLOCATE CntTableDesc
END
GO

CREATE OR ALTER PROCEDURE insertDataIntoTable (@testRunID INT, @testID INT, @tableID INT)
AS
BEGIN
	IF @testID NOT IN (SELECT [TestID] FROM [Tests])
	BEGIN
		PRINT 'Test not present in Tests'
		RETURN
	END
	IF @testRunID NOT IN (SELECT [TestRunID] FROM [TestRuns])
    BEGIN
        INSERT INTO TestRuns (TestRunID, StartAt, EndAt)
        VALUES (@testRunID, NULL, NULL);

        PRINT 'Created TestRun entry with ID ' + CONVERT(VARCHAR, @testRunID);
    END
	IF @tableID NOT IN (SELECT [TableID] FROM [Tables])
	BEGIN
		PRINT 'table is not in tables table'
		RETURN
	END
	DECLARE @startTime DATETIME=SYSDATETIME()
	DECLARE @tableName VARCHAR(50)=(
		SELECT [Name] FROM [Tables]
		WHERE TableID=@tableID
	)
	PRINT 'inserting data into table '+@tableName
	DECLARE @numberOfRows INT=(
		SELECT [NoOfRows] FROM [TestTables]
		WHERE TestID=@testID AND TableID=@tableID
	)
	EXEC generateRandomDataForTable @tableName, @numberOfRows
	DECLARE @endTime DATETIME=SYSDATETIME()
	INSERT INTO TestRunTables(TestRunID, TableID, StartAt, EndAt)
	VALUES
	(@testRunID,@tableID,@startTime,@endTime)
END
GO

CREATE OR ALTER PROCEDURE insertDataIntoAllTables (@testRunID INT, @testID INT) AS
BEGIN
	IF @testID NOT IN (SELECT [TestID] FROM [Tests])
	BEGIN
		PRINT 'Test not present in Tests.'
		RETURN
	END

	IF @testRunID NOT IN (SELECT [TestRunID] FROM [TestRuns])
	BEGIN
		PRINT 'Test run not present in TestRuns.'
		RETURN
	END

	PRINT 'Insert data in all the tables for the test ' + CONVERT(VARCHAR, @testID)
	DECLARE @tableID INT
	DECLARE @pos INT
	DECLARE allTableCursorAsc CURSOR LOCAL FOR
		SELECT T1.TableID, T1.Position
		FROM TestTables T1
		INNER JOIN Tests T2 ON T2.TestID = T1.TestID
		WHERE T1.TestID = @testID
		ORDER BY T1.Position ASC

	OPEN allTableCursorAsc
	FETCH allTableCursorAsc INTO @tableID, @pos
	WHILE @@FETCH_STATUS = 0
	BEGIN
		EXEC insertDataIntoTable @testRunID, @testID, @tableID
		FETCH NEXT FROM allTableCursorAsc INTO @tableID, @pos
	END
	CLOSE allTableCursorAsc
	DEALLOCATE allTableCursorAsc
END
GO

CREATE OR ALTER PROCEDURE selectDataFromView (@viewID INT, @testRunID INT) AS
BEGIN
	IF @viewID NOT IN (SELECT [ViewID] FROM [Views])
	BEGIN
		PRINT 'View not present in Views.'
		RETURN
	END

	IF @testRunID NOT IN (SELECT [TestRunID] FROM [TestRuns])
	BEGIN
		PRINT 'Test run not present in TestRuns.'
		RETURN
	END

	DECLARE @startTime DATETIME = SYSDATETIME()
	DECLARE @viewName VARCHAR(100) = (
		SELECT [Name]
		FROM [Views]
		WHERE ViewID = @viewID
	)
	PRINT 'Selecting data from the view ' + @viewName
	DECLARE @query NVARCHAR(150) = N'SELECT * FROM ' + @viewName
	EXEC sp_executesql @query

	DECLARE @endTime DATETIME = SYSDATETIME()
	INSERT INTO TestRunViews(TestRunID, ViewID, StartAt, EndAt)
	VALUES (@testRunID, @viewID, @startTime, @endTime)
END
GO

CREATE OR ALTER PROCEDURE selectAllViews (@testRunID INT, @testID INT) AS
BEGIN
	IF @testID NOT IN (SELECT [TestID] FROM [Tests])
	BEGIN
		PRINT 'Test not present in Tests.'
		RETURN
	END

	IF @testRunID NOT IN (SELECT [TestRunID] FROM [TestRuns])
	BEGIN
		PRINT 'Test run not present in TestRuns.'
		RETURN
	END

	PRINT 'Selecting data from all the views from the test ' + CONVERT(VARCHAR, @testID)
	DECLARE @viewID INT
	DECLARE selectAllViewsCursor CURSOR LOCAL FOR
		SELECT T1.ViewID FROM TestViews T1
		INNER JOIN Tests T2 ON T2.TestID = T1.TestID
		WHERE T1.TestID = @testID

	OPEN selectAllViewsCursor
	FETCH selectAllViewsCursor INTO @viewID
	WHILE @@FETCH_STATUS = 0 
	BEGIN
		EXEC selectDataFromView @viewID, @testRunID
		FETCH NEXT FROM selectAllViewsCursor INTO @viewID
	END
	CLOSE selectAllViewsCursor
	DEALLOCATE selectAllViewsCursor
END
GO

CREATE OR ALTER PROCEDURE runTest(@testID INT, @description VARCHAR(MAX)) AS
BEGIN
	IF @testID NOT IN 
	(SELECT [TestID] FROM [Tests])
	BEGIN
		PRINT 'the test is not present in tests'
	END
	PRINT 'Runnning test with id ' +CONVERT(VARCHAR,@testID)
	INSERT INTO TestRuns([Description])
	VALUES(@description)
	DECLARE @testRunID INT=(
		SELECT MAX(TestRunID)
		FROM [TestRuns]
		)
	DECLARE @startTime DATETIME = SYSDATETIME()
	EXEC insertDataIntoAllTables @testRunID, @testID
	EXEC selectAllViews @testRunID, @testID
	DECLARE @endTime DATETIME = SYSDATETIME()
	EXEC deleteFromAllTables @testID

	UPDATE [TestRuns] SET StartAt = @startTime, EndAt = @endTime
	DECLARE @timeDifference INT = DATEDIFF(SECOND, @startTime, @endTime)
	PRINT 'The test with id ' + CONVERT(VARCHAR, @testID) + ' took ' + CONVERT(VARCHAR, @timeDifference) + ' seconds.'
END
GO

CREATE OR ALTER PROCEDURE runAllTests AS
BEGIN
	DECLARE @testName VARCHAR(50)
	DECLARE @testID INT
	DECLARE @description VARCHAR(2000)
	DECLARE allTestsCursor CURSOR LOCAL FOR
		SELECT *
		FROM [Tests]

	OPEN allTestsCursor
	FETCH allTestsCursor INTO @testID, @testName
	WHILE @@FETCH_STATUS = 0
	BEGIN
		PRINT 'Running ' + @testName
		SET @description = 'Test results for test with the ID ' + CAST(@testID AS VARCHAR(2))
		EXEC runTest @testID, @description
		FETCH NEXT FROM allTestsCursor INTO @testID, @testName
	END
	CLOSE allTestsCursor
	DEALLOCATE allTestsCursor
END
GO
 ---a view with a SELECT statement operating on one table;
CREATE OR ALTER VIEW candidateWithMoreThanOneExperience AS
	SELECT C.first_name, C.candidateID
	FROM Candidate C
	WHERE C.candidateID > 10

EXEC sp_helptext 'candidateWithMoreThanOneExperience'
--  a view with a SELECT statement operating on at least 2 tables
SELECT * FROM candidateWithMoreThanOneExperience
GO
SELECT * FROM Job;
SELECT *FROM Employer;
CREATE OR ALTER VIEW CandidateApplicationsView AS
    SELECT
        C.candidateID,
        C.first_name,
        C.last_name,
        C.email,
        C.phone_number,
        C.candidate_address,
        C.resume_file,
        C.skills,
        C.education,
        C.experience,
        A.applicationID,
        A.jobID,
        A.application_status,
        A.application_date,
        A.attachment
    FROM
        Candidate C
    JOIN
        Applications A ON C.candidateID = A.candidateID;

-- a view with a SELECT statement that has a GROUP BY clause and operates on at least 2 tables
GO
CREATE OR ALTER VIEW ApplicationsPerJobView AS
    SELECT J.jobID, J.job_title,COUNT(A.applicationID) AS total_applications
    FROM Job J
    LEFT JOIN Applications A ON J.jobID = A.jobID
    GROUP BY J.jobID, J.job_title;

GO
SELECT * FROM ApplicationsPerJobView

-- first test
-- a table with no foreign key and a single-column primary key, a table with a foreign key and a single-column primary key and a table with a multi-column primary key
-- a view with a SELECT statement that has a GROUP BY clause and operates on at least 2 tables
EXEC addViewToViews 'ApplicationsPerJobView'
EXEC addTestToTests 'Test1'
EXEC addTableToTables 'Candidate'
EXEC connectTableToTest 'Candidate', 'Test1', 10, 1
EXEC addTableToTables 'Job'
EXEC connectTableToTest 'Job', 'Test1', 10, 2
EXEC addTableToTables 'Feedback'
EXEC connectTableToTest 'Feedback', 'Test1', 10, 3
EXEC addTableToTables 'Applications'
EXEC connectTableToTest 'Applications', 'Test1', 10, 4
EXEC insertDataIntoTable 10, 1, 4
EXEC connectViewToTest 'ApplicationsPerJobView', 'Test1'

-- second test
-- a table with a single-column primary key 
-- a view with a SELECT statement operating on one table
EXEC addViewToViews 'candidateWithMoreThanOneExperience'
EXEC addTestToTests 'Test2'
EXEC addTableToTables 'Candidate'
EXEC connectTableToTest 'Candidate', 'Test2', 10, 1
EXEC connectViewToTest 'candidateWithMoreThanOneExperience', 'Test2'

-- third test
-- a view with a SELECT statement operating on at least two tables
-- a table with no foreign key and a single-column primary key and a table with a foreign key
EXEC addViewToViews 'CandidateApplicationsView'
EXEC addTestToTests 'Test3'
EXEC addTableToTables 'Candidate'
EXEC connectTableToTest 'Candidate', 'Test3', 10, 1
EXEC addTableToTables 'Applications'
EXEC connectTableToTest 'Applications', 'Test3', 10, 2
EXEC connectViewToTest 'CandidateApplicationsView', 'Test3'

EXEC runAllTests
SELECT *
FROM [Views]

SELECT *
FROM [Tables]

SELECT *
FROM [Tests]

SELECT *
FROM [TestTables]

SELECT *
FROM [TestViews]

SELECT *
FROM [TestRuns]

SELECT *
FROM [TestRunTables]

SELECT *
FROM [TestRunViews]

---generators
CREATE OR ALTER PROCEDURE generateRandomString @stringValue VARCHAR(10) OUTPUT AS
BEGIN
	DECLARE @length INT
	DECLARE @charPool VARCHAR(55)
	DECLARE @charPoolLength INT
	SET @charPool = 'abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ'
	SET @charPoolLength = LEN(@charPool)
	SET @length = FLOOR(RAND() * 10 + 5)
	SET @stringValue = ''
	WHILE @length > 0
	BEGIN
		SET @stringValue = @stringValue + SUBSTRING(@charPool, CONVERT(INT, RAND() * @charPoolLength) + 1, 1)
		SET @length = @length - 1
	END
END

-- generate random data for a table

GO
CREATE OR ALTER PROCEDURE generateRandomDataForTable @tableName VARCHAR(50), @numberOfRows INT AS
BEGIN
	-- create a cursor to iterate through the names of the column and their types
	DECLARE dataCursor SCROLL CURSOR FOR
		SELECT COLUMN_NAME, DATA_TYPE
		FROM INFORMATION_SCHEMA.COLUMNS
		WHERE TABLE_NAME = @tableName
		ORDER by ORDINAL_POSITION

	-- query for the insert in tables
	DECLARE @insertQuery VARCHAR(MAX)

	DECLARE @columnName VARCHAR(200)
	DECLARE @dataType VARCHAR(10)
	DECLARE @intValue INT
	DECLARE @stringValue VARCHAR(50)
	DECLARE @checkIfPKQuery NVARCHAR(2000)
	DECLARE @hasPK INT

	OPEN dataCursor

	WHILE @numberOfRows > 0
	BEGIN
		SET @hasPK = 0
		SET @insertQuery = 'INSERT INTO ' + @tableName + ' VALUES('
		SET @checkIfPKQuery = N'SELECT @outputPK = COUNT(*) FROM ' + @tableName + ' WHERE '
		FETCH FIRST FROM dataCursor INTO @columnName, @dataType
		WHILE @@FETCH_STATUS = 0
		BEGIN
			IF COLUMNPROPERTY(OBJECT_ID(@tableName), @columnName, 'IsIdentity') = 0
			BEGIN
				-- check if the current column has a foreign key property and if it has, take its values from the referenced table
				IF EXISTS(
					SELECT *
					FROM INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE C
					WHERE C.CONSTRAINT_NAME like 'FK%' AND @columnName = C.COLUMN_NAME AND @tableName = C.TABLE_NAME)
					BEGIN
						-- get the name of the referenced table and the name of the referenced column
						DECLARE @referencedTable VARCHAR(50)
						DECLARE @referencedColumn VARCHAR(50)
						DECLARE @result TABLE([tableName] VARCHAR(50), [columnName] VARCHAR(50))
						INSERT INTO @result SELECT OBJECT_NAME (f.referenced_object_id) AS referenced_table_name,
						COL_NAME(fc.referenced_object_id, fc.referenced_column_id) AS referenced_column_name
						FROM sys.foreign_keys AS f
						INNER JOIN sys.foreign_key_columns AS fc ON f.object_id = fc.constraint_object_id
						WHERE fc.parent_object_id = OBJECT_ID(@tableName) AND COL_NAME(fc.parent_object_id, fc.parent_column_id) = @columnName

						SET @referencedTable = (SELECT TOP 1 [tableName] FROM @result)
						SET @referencedColumn = (SELECT TOP 1 [columnName] FROM @result)
						
						-- empty the table, otherwise it will always have at the top the first table and column found
						DELETE FROM @result

						-- int case
						IF @dataType = 'int'
							BEGIN
								-- get a random value from the referenced table
								DECLARE @getRandomFK NVARCHAR(1000)
								SET @getRandomFK = N'SELECT TOP 1 @intValue = [' + @referencedColumn + '] FROM ' + @referencedTable + ' ORDER BY NEWID()'
								EXEC sp_executesql @getRandomFK, N'@intValue INT OUTPUT', @intValue OUTPUT
								SET @insertQuery = @insertQuery + CAST(@intValue AS NVARCHAR(10)) + ','
							END
						ELSE
							-- string case
							IF @dataType = 'varchar'
								BEGIN
									-- get a random value from the values in the referenced table
									DECLARE @getStringQuery NVARCHAR(200)
									SET @getStringQuery = N'SELECT TOP 1 @stringValue = ['  + @referencedColumn + '] FROM ' + @referencedTable + ' T WHERE ' +
									@columnName + ' = T.' + @columnName + ' ORDER BY NEWID()'
									EXEC sp_executesql @getStringQuery, N'@stringValue VARCHAR(50) OUTPUT', @stringValue OUTPUT
									SET @insertQuery = @insertQuery + '''' + @stringValue + ''','
								END
					END
				ELSE
					-- not a foreign key, does not depend on another table
					BEGIN
						IF @dataType = 'int'
							BEGIN
								-- generate a random number
								SET @intValue = FLOOR(RAND() * 1000) + 1
								SET @insertQuery = @insertQuery + CAST(@intValue AS NVARCHAR(10)) + ','
							END
						ELSE
							IF @dataType = 'varchar'
								BEGIN
									-- generate a random string
									EXEC generateRandomString @stringValue OUTPUT
									SET @insertQuery = @insertQuery + '''' + @stringValue + '''' + ','
								END
							ELSE
								BEGIN
									SET @insertQuery = @insertQuery + 'NULL' + ','
								END
					END

				-- if the column has a primary key, create a query t check its validity
				-- this will also check for multicolumn primary keys
				IF EXISTS(
					SELECT *
					FROM INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE
					WHERE TABLE_NAME = @tableName AND COLUMN_NAME = @columnName AND CONSTRAINT_NAME LIKE 'PK%')
					BEGIN
						SET @hasPK = 1
						IF @dataType = 'varchar'
							BEGIN
								SET @checkIfPKQuery = @checkIfPKQuery + @columnName + '=''' + @stringValue + ''' AND '
							END
						IF @dataType = 'int'
							BEGIN
								SET @checkIfPKQuery = @checkIfPKQuery + @columnName + '=' + CAST(@intValue AS VARCHAR(10)) + ' AND '
							END
					END
			END
			FETCH NEXT FROM dataCursor INTO @columnName, @dataType
		END
		-- insert only if the primary key is valid
		IF @hasPK = 1
			BEGIN
				SET @checkIfPKQuery = LEFT(@checkIfPKQuery, LEN(@checkIfPKQuery) - 4)
				DECLARE @outputPK INT
				EXEC sp_executesql @checkIfPKQuery, N'@outputPK INT OUTPUT', @outputPK OUTPUT
				IF @outputPK = NULL OR @outputPK = 0
					BEGIN
						SET @insertQuery = LEFT(@insertQuery, LEN(@insertQuery) - 1) + ')'
						EXEC (@insertQuery)
						SET @numberOfRows = @numberOfRows - 1
					END
			END
		ELSE
			-- in this case there is no primary key
			BEGIN 
				SET @insertQuery = LEFT(@insertQuery, LEN(@insertQuery) - 1) + ')'
				EXEC (@insertQuery)
				SET @numberOfRows = @numberOfRows - 1
			END
	END
	CLOSE dataCursor
	DEALLOCATE dataCursor
END





---l5
CREATE TABLE Ta(
	aid INT PRIMARY KEY,
	a2 INT UNIQUE,
	a3 INT
)

CREATE TABLE Tb(
	bid INT PRIMARY KEY,
	b2 INT
)

CREATE TABLE Tc(
	cid INT PRIMARY KEY,
	aid INT FOREIGN KEY REFERENCES Ta(aid),
	bid INT FOREIGN KEY REFERENCES Tb(bid)
)

INSERT INTO Ta (aid, a2, a3) VALUES
(1, 11, 21),
(2, 12, 22),
(3, 13, 23),
(4, 14, 24),
(5, 15, 25);

INSERT INTO Tb (bid, b2) VALUES
(1, 101),
(2, 102),
(3, 103),
(4, 104),
(5, 105);

INSERT INTO Tc (cid, aid, bid) VALUES
(101, 1, 1),
(102, 2, 2),
(103, 3, 3),
(104, 4, 4),
(105, 5, 5);
/* 
- clustered index automatically created for the aid column from Ta
- nonclustered index automatically created for the a2 column from Ta
- clustered index automatically created for the bid column from Tb
- clustered index automatically created for the cid column from Tc
*/

---clustered index scan-scan the entire table
SELECT * FROM Ta

---clustered index seek-return a specific subset of rows from a clustered index
SELECT *
FROM Ta
WHERE aid<152

---nonclustered index scan-scan the entire nonclustered index
SELECT a2
FROM Ta
ORDER BY a2

-- nonclustered index seek - return a specific subset of rows from a nonclustered index
SELECT a2
FROM Ta
WHERE a2 > 21 AND a2 < 23

-- key lookup - nonclustered index seek + key lookup - the data is found in a nonclustered index, but additional data is needed
SELECT a3, a2
FROM Ta
WHERE a2 = 24
---b Write a query on table Tb with a WHERE clause of the form WHERE b2 = value and analyze its execution plan. 
---Create a nonclustered index that can speed up the query. Examine the execution plan again.
SELECT *
FROM Tb
WHERE b2 > 103

DROP INDEX Tb_b2_index ON Tb
CREATE NONCLUSTERED INDEX Tb_b2_index ON Tb(b2)
GO
---c Create a view that joins at least 2 tables. Check whether existing indexes are helpful;
---if not, reassess existing indexes / examine the cardinality of the tables.
CREATE OR ALTER VIEW View1 AS
	SELECT A.aid, B.bid, C.cid
	FROM Tc C
	INNER JOIN Ta A ON A.aid = C.aid
	INNER JOIN Tb B ON B.bid = C.bid
	WHERE B.b2 > 100 AND A.a3 < 23

GO
SELECT *
FROM View1

DROP INDEX Ta_a3_index ON Ta
CREATE NONCLUSTERED INDEX Ta_a3_index ON Ta(a3)

DROP INDEX Tc_index ON Tc
CREATE NONCLUSTERED INDEX Tc_index ON Tc(aid, bid)

