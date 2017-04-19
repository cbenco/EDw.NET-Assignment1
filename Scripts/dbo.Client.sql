CREATE TABLE [dbo].[Client] (
    [clientID]       INT             IDENTITY (50000, 1) NOT NULL,
    [clientName]     NVARCHAR (200)  NOT NULL,
    [clientLocation] NVARCHAR (1000) NOT NULL,
    [districtID]     INT             NOT NULL,
    CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED ([clientID] ASC),
    CONSTRAINT [FK_ClientDistrict] FOREIGN KEY ([districtID]) REFERENCES [dbo].[District] ([districtID])
);

