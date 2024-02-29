
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


