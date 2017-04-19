CREATE TABLE [dbo].[Users] (
    [userID]    INT            IDENTITY (1000, 1) NOT NULL,
    [firstName] NVARCHAR (50)  NOT NULL,
    [lastName]  NVARCHAR (100) NOT NULL,
    [userName]  NVARCHAR (25)  NOT NULL,
    [pword]     NVARCHAR (50)  NOT NULL,
    [userType]  CHAR (1)       NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([userID] ASC)
);

