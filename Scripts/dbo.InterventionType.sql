CREATE TABLE [dbo].[InterventionType] (
    [typeID]       INT             IDENTITY (10000, 1) NOT NULL,
    [typeName]     NVARCHAR (100)  NOT NULL,
    [defaultHours] DECIMAL (10, 2) NOT NULL,
    [defaultCost]  DECIMAL (10, 2) NOT NULL,
    CONSTRAINT [PK_InterventionType] PRIMARY KEY CLUSTERED ([typeID] ASC)
);

