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










