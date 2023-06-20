CREATE TABLE [dbo].[Answer] (
    [Id]            UNIQUEIDENTIFIER  DEFAULT NEWID(),
    [QuestionId]    UNIQUEIDENTIFIER NOT NULL,
    [Description]    NVARCHAR (MAX) NOT NULL,
    [AnsweredBy]     UNIQUEIDENTIFIER NOT NULL,
    [AnsweredOn]     DATETIME       DEFAULT (getdate()),
    [IsBestSolution] BIT     NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([AnsweredBy]) REFERENCES [dbo].[Employee] ([Id]),
    FOREIGN KEY ([QuestionId]) REFERENCES [dbo].[Question] ([Id])
);

