create database ContactDB
Go

use ContactDB
Go

CREATE TABLE [contact_info](
	[contact_id] [int] IDENTITY(1,1) Primary Key,
	[first_name] [varchar](64) NULL,
	[last_name] [varchar](64) NULL,
	[email] [varchar](64) NOT NULL,
	[phone_no] [varchar](64) NULL,
	[status] [bit] NOT NULL)

Go

CREATE TABLE [user_info](
	[user_id] [int] IDENTITY(1,1) Primary Key,
	[user_name] [varchar](60) NOT NULL,
	[password] [varchar](60) NOT NULL)

GO

Insert into [user_info] values('Test','Test')
Go

