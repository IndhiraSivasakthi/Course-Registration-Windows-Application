use Project;

CREATE TABLE Users (
    UserID INT PRIMARY KEY IDENTITY(1,1),
    Username VARCHAR(50) NOT NULL UNIQUE,
    Password VARCHAR(100) NOT NULL,
    Email VARCHAR(100) NOT NULL UNIQUE
);
select * from Users;
CREATE TABLE Students
(
    StudentID INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(100) NOT NULL,
    RegisterNo VARCHAR(20) NOT NULL,
    Department VARCHAR(50) NOT NULL,
    Semester VARCHAR(10) NOT NULL,
    Year VARCHAR(10) NOT NULL,
    Email VARCHAR(100) NOT NULL,
	ContactNo VARCHAR(10) NOT NULL,
	Section VARCHAR(10) NOT NULL,
	Regulation VARCHAR(10) NOT NULL,
	Programme VARCHAR(10) NOT NULL,
    Photo VARBINARY(MAX) NULL 
);

Select * from Students;


CREATE TABLE CourseDetails (
    ID INT PRIMARY KEY IDENTITY(1,1),
    RegisterNo NVARCHAR(50),
    Semester NVARCHAR(50),
    
    Subject1 NVARCHAR(50),
    SubjectCode1 NVARCHAR(50),
    TheoryLab1 NVARCHAR(50),
    Staff1 NVARCHAR(50),
    
    Subject2 NVARCHAR(50),
    SubjectCode2 NVARCHAR(50),
    TheoryLab2 NVARCHAR(50),
    Staff2 NVARCHAR(50),
    
    Subject3 NVARCHAR(50),
    SubjectCode3 NVARCHAR(50),
    TheoryLab3 NVARCHAR(50),
    Staff3 NVARCHAR(50),
    
    Subject4 NVARCHAR(50),
    SubjectCode4 NVARCHAR(50),
    TheoryLab4 NVARCHAR(50),
    Staff4 NVARCHAR(50),
    
    Subject5 NVARCHAR(50),
    SubjectCode5 NVARCHAR(50),
    TheoryLab5 NVARCHAR(50),
    Staff5 NVARCHAR(50),
    
    Subject6 NVARCHAR(50),
    SubjectCode6 NVARCHAR(50),
    TheoryLab6 NVARCHAR(50),
    Staff6 NVARCHAR(50),
    
    Subject7 NVARCHAR(50),
    SubjectCode7 NVARCHAR(50),
    TheoryLab7 NVARCHAR(50),
    Staff7 NVARCHAR(50)
);




select * from CourseDetails;

DROP TABLE CourseDetails;

CREATE TABLE FeedbackResponses (
   ID INT PRIMARY KEY IDENTITY(1,1), 
    Rating VARCHAR(5),
    TechnicalIssue VARCHAR(30),
    Suggestion VARCHAR(30),
);

drop table FeedbackResponses;
select * from FeedbackResponses;


