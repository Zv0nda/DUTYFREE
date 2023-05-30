CREATE TABLE [dbo].[Products] (
    [ProductID]   INT             NOT NULL IDENTITY,
    [DataCreated] DATETIME        CONSTRAINT [DF_Products_DataCreated] DEFAULT (getdate()) NOT NULL,
    [CreatedBY]   INT             CONSTRAINT [DF_Products_CreatedBY] DEFAULT ((0)) NOT NULL,
    [DateUpdated] DATETIME        CONSTRAINT [DF_Products_DateUpdated] DEFAULT (getdate()) NOT NULL,
    [UpdatedBy]   INT             CONSTRAINT [DF_Products_UpdatedBy] DEFAULT ((0)) NOT NULL,
    [IsDeleted]   BIT             CONSTRAINT [DF_Products_IsDeleted] DEFAULT ((0)) NOT NULL,
    [Name]        NVARCHAR (512)  NULL,
    [Price]       INT             NULL,
    [Quantity]    INT             NULL,
    [ImageUrl]    NVARCHAR (1024) NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED ([ProductID] ASC)
);

