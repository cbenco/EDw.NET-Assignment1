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

