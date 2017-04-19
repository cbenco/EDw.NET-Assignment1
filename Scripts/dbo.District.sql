CREATE TABLE [dbo].[District] (
    [districtID]   INT            IDENTITY (100, 1) NOT NULL,
    [districtName] NVARCHAR (100) NOT NULL,
    CONSTRAINT [PK_District] PRIMARY KEY CLUSTERED ([districtID] ASC)
);

