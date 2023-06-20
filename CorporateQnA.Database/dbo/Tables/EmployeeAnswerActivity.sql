CREATE TABLE [dbo].[EmployeeAnswerActivity] (
    [Id]         UNIQUEIDENTIFIER DEFAULT NEWID(),
    [AnswerId]   UNIQUEIDENTIFIER NOT NULL,
    [EmployeeId] UNIQUEIDENTIFIER NOT NULL,
    [VoteStatus] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([AnswerId]) REFERENCES [dbo].[Answer] ([Id]),
    FOREIGN KEY ([EmployeeId]) REFERENCES [dbo].[Employee] ([Id]),
    CONSTRAINT [Unique_Ans_Emp] UNIQUE NONCLUSTERED ([AnswerId] ASC, [EmployeeId] ASC)
);

