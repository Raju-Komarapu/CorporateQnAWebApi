CREATE TABLE [dbo].[Employee] (
    [Id]            UNIQUEIDENTIFIER DEFAULT NEWID(),
    [FirstName]     NVARCHAR (100) NOT NULL,
    [LastName]      NVARCHAR (100) NULL,
    [Email]         NVARCHAR (100) NOT NULL,
    [DesignationId] UNIQUEIDENTIFIER NOT NULL,
    [DepartmentId]  UNIQUEIDENTIFIER NOT NULL,
    [LocationId]    UNIQUEIDENTIFIER NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([DepartmentId]) REFERENCES [dbo].[Department] ([Id]),
    FOREIGN KEY ([DesignationId]) REFERENCES [dbo].[Designation] ([Id]),
    FOREIGN KEY ([LocationId]) REFERENCES [dbo].[Location] ([Id]),
    UNIQUE NONCLUSTERED ([Email] ASC)
);

