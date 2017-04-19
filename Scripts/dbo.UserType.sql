CREATE TABLE [dbo].[UserType] (
    [userID]        INT             NOT NULL,
    [districtID]    INT             NOT NULL,
    [approvalLimit] DECIMAL (10, 2) NOT NULL,
    [costLimit]     DECIMAL (10, 2) NOT NULL,
    CONSTRAINT [PK_UserType] PRIMARY KEY CLUSTERED ([userID] ASC),
    CONSTRAINT [FK_Users] FOREIGN KEY ([userID]) REFERENCES [dbo].[Users] ([userID]),
    CONSTRAINT [FK_District] FOREIGN KEY ([districtID]) REFERENCES [dbo].[District] ([districtID])
);

