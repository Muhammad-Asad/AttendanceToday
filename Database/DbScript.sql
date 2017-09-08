USE [TestDB]
GO

drop table StudentClass
drop table ClassSubject
drop table Student
drop table Subject
drop table Class




CREATE TABLE [dbo].[Student](
	[ID] [bigint] primary key Identity,
	[RollNumber] [varchar](50) unique,
	[Name] [varchar](150) NULL,
	[FatherName] [varchar](150) NULL,
	[ContactNumber] [varchar](50) NULL,
) ON [PRIMARY]


CREATE TABLE [dbo].[Subject](
	[ID] [bigint] primary key Identity,
	[Name] [varchar](250) NULL,
	[Description] [varchar](500) NULL
) ON [PRIMARY]

GO


CREATE TABLE [dbo].[Class](
	[ID] [bigint] Primary key Identity,
	[Level] [varchar](250) NOT NULL,
	[Description] [varchar](250) NOT NULL
) ON [PRIMARY]

GO


CREATE TABLE [dbo].[ClassSubject](
    [ID] [bigint] Primary Key Identity,
	[ClassID] [bigint] NOT NULL,
	[SubjectID] [bigint] NOT NULL
) ON [PRIMARY]


GO

CREATE TABLE [dbo].[StudentClass](
	[ID] [bigint] Primary Key Identity,
	[StudentID] [bigint] NOT NULL,
	[ClassSubjectID] [bigint] NOT NULL
) ON [PRIMARY]

GO

