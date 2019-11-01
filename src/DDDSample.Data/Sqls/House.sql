IF EXISTS(SELECT 1 FROM [sysobjects] WHERE id = OBJECT_ID('[dbo].[DDDSample.Houses]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1)
BEGIN
DROP table [dbo].[DDDSample.Houses];     
END
GO 

CREATE TABLE [dbo].[DDDSample.Houses] (
[Id] VARCHAR(63) NOT NULL,
[OwnerId] VARCHAR(63) NOT NULL,
[Name] NVARCHAR(255) NOT NULL,
[TradeState] NVARCHAR(255) NOT NULL,
[Address] NVARCHAR(255) NOT NULL,
[Area] FLOAT NOT NULL,

[Enable] BIT NOT NULL ,
[CreateTime] DATETIMEOFFSET NOT NULL ,
[UpdateTime] DATETIMEOFFSET NOT NULL ,
[ConcurrencyToken] VARCHAR(63) NOT NULL,
PRIMARY KEY ([Id])
)