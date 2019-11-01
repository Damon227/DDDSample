IF EXISTS(SELECT 1 FROM [sysobjects] WHERE id = OBJECT_ID('[dbo].[DDDSample.Productions]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1)
BEGIN
DROP table [dbo].[DDDSample.Productions];     
END
GO 

CREATE TABLE [dbo].[DDDSample.Productions] (
[Id] VARCHAR(63) NOT NULL,
[Name] NVARCHAR(255) NOT NULL,
[FullName] NVARCHAR(255) NOT NULL,
[Price] BIGINT NOT NULL,

[Enable] BIT NOT NULL ,
[CreateTime] DATETIMEOFFSET NOT NULL ,
[UpdateTime] DATETIMEOFFSET NOT NULL ,
[ConcurrencyToken] VARCHAR(63) NOT NULL,
PRIMARY KEY ([Id])
)