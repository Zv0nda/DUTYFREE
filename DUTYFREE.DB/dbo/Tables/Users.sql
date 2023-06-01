CREATE TABLE [dbo].[Users] (
    [UserID]   INT            IDENTITY (1, 1) NOT NULL,
    [Name]     NVARCHAR (256) NULL,
    [Email]    NVARCHAR (256) NULL,
    [ImageUrl] VARCHAR (1024) NULL,
    [Role]     INT            CONSTRAINT [DF_Users_Role] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([UserID] ASC)
);

