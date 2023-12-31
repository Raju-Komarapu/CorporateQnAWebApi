﻿CREATE TABLE [dbo].[Designation] (
    [Id]    UNIQUEIDENTIFIER DEFAULT NEWID(),
    [Title] NVARCHAR (150) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    UNIQUE NONCLUSTERED ([Title] ASC)
);

