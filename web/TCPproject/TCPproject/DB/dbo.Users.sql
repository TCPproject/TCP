CREATE TABLE [dbo].[User] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [Nickname]  NVARCHAR (MAX) NULL,
    [Highscore] INT            NOT NULL,
    [Email]     NVARCHAR (MAX) NULL,
    [Password]  NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([Id] ASC)
);

