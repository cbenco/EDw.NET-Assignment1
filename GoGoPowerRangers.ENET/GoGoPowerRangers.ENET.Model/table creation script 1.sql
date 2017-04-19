--DROP TABLE Intervention;
--DROP TABLE UserType;
--DROP TABLE Client;
--DROP TABLE InterventionType;
--DROP TABLE Users;
--DROP TABLE District;


CREATE TABLE [dbo].[Users] (
    [userID]    INT            IDENTITY (1000, 1) NOT NULL,
    [firstName] NVARCHAR (50)  NOT NULL,
    [lastName]  NVARCHAR (100) NOT NULL,
    [userName]  NVARCHAR (25)  NOT NULL,
    [pword]     NVARCHAR (50)  NOT NULL,
    [userType]  CHAR (1)       NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([userID] ASC)
);

CREATE TABLE [dbo].[District] (
    [districtID]   INT            IDENTITY (100, 1) NOT NULL,
    [districtName] NVARCHAR (100) NOT NULL,
    CONSTRAINT [PK_District] PRIMARY KEY CLUSTERED ([districtID] ASC)
);

CREATE TABLE [dbo].[UserType] (
    [userID]        INT             NOT NULL,
    [districtID]    INT             NOT NULL,
    [approvalLimit] DECIMAL (10, 2) NOT NULL,
    [costLimit]     DECIMAL (10, 2) NOT NULL,
    CONSTRAINT [PK_UserType] PRIMARY KEY CLUSTERED ([userID] ASC),
    CONSTRAINT [FK_Users] FOREIGN KEY ([userID]) REFERENCES [dbo].[Users] ([userID]),
    CONSTRAINT [FK_District] FOREIGN KEY ([districtID]) REFERENCES [dbo].[District] ([districtID])
);

CREATE TABLE [dbo].[Client] (
    [clientID]       INT             IDENTITY (50000, 1) NOT NULL,
    [clientName]     NVARCHAR (200)  NOT NULL,
    [clientLocation] NVARCHAR (1000) NOT NULL,
    [districtID]     INT             NOT NULL,
    CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED ([clientID] ASC),
    CONSTRAINT [FK_ClientDistrict] FOREIGN KEY ([districtID]) REFERENCES [dbo].[District] ([districtID])
);

CREATE TABLE [dbo].[InterventionType] (
    [typeID]       INT             IDENTITY (10000, 1) NOT NULL,
    [typeName]     NVARCHAR (100)  NOT NULL,
    [defaultHours] DECIMAL (10, 2) NOT NULL,
    [defaultCost]  DECIMAL (10, 2) NOT NULL,
    CONSTRAINT [PK_InterventionType] PRIMARY KEY CLUSTERED ([typeID] ASC)
);

CREATE TABLE [dbo].[Intervention] (
    [interventionID]   INT             IDENTITY (100000, 1) NOT NULL,
    [typeID]           INT             NOT NULL,
    [clientID]         INT             NOT NULL,
    [proposedBy]       INT             NOT NULL,
    [hours]            DECIMAL (10, 2) NOT NULL,
    [cost]             DECIMAL (10, 2) NOT NULL,
    [interventionDate] DATETIME        NOT NULL,
    [approvedBy]       INT             NULL,
    [status]           NVARCHAR (15)   NOT NULL,
    [remainingLife]    DECIMAL (10, 2) NOT NULL,
    [lastVisit]        DATETIME        NOT NULL,
    [notes]            NVARCHAR (3000) NULL,
    CONSTRAINT [PK_Intervention] PRIMARY KEY CLUSTERED ([interventionID] ASC),
    CONSTRAINT [FK_Users_ProposedBy] FOREIGN KEY ([proposedBy]) REFERENCES [dbo].[Users] ([userID]),
    CONSTRAINT [FK_Users_ApprovedBy] FOREIGN KEY ([approvedBy]) REFERENCES [dbo].[Users] ([userID]),
    CONSTRAINT [FK_Type] FOREIGN KEY ([typeID]) REFERENCES [dbo].[InterventionType] ([typeID]),
    CONSTRAINT [FK_Client] FOREIGN KEY ([clientID]) REFERENCES [dbo].[Client] ([clientID])
);