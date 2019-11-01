IF EXISTS(SELECT 1 FROM [sysobjects] WHERE id = OBJECT_ID('[dbo].[DDDSample.Users]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1)
BEGIN
DROP table [dbo].[DDDSample.Users];     
END
GO 

CREATE TABLE [dbo].[DDDSample.Users] (
[Id] VARCHAR(63) NOT NULL,
[Name] NVARCHAR(255) NOT NULL,
[PhoneNumber] NVARCHAR(255) NOT NULL,
[IDNo] NVARCHAR(255) NOT NULL,

[Enable] BIT NOT NULL ,
[CreateTime] DATETIMEOFFSET NOT NULL ,
[UpdateTime] DATETIMEOFFSET NOT NULL ,
[ConcurrencyToken] VARCHAR(63) NOT NULL,
PRIMARY KEY ([Id])
)