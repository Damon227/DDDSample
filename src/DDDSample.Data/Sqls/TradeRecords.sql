IF EXISTS(SELECT 1 FROM [sysobjects] WHERE id = OBJECT_ID('[dbo].[DDDSample.TradeRecords]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1)
BEGIN
DROP table [dbo].[DDDSample.TradeRecords];     
END
GO 

CREATE TABLE [dbo].[DDDSample.TradeRecords] (
[Id] VARCHAR(63) NOT NULL,
[HouseId] VARCHAR(63) NOT NULL,
[SellerId] VARCHAR(63) NOT NULL,
[BuyerId] VARCHAR(63) NOT NULL,
[Description] NVARCHAR(255) NULL,

[Enable] BIT NOT NULL ,
[CreateTime] DATETIMEOFFSET NOT NULL ,
[UpdateTime] DATETIMEOFFSET NOT NULL ,
[ConcurrencyToken] VARCHAR(63) NOT NULL,
PRIMARY KEY ([Id])
)