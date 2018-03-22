CREATE TABLE [dbo].[Problems]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Content] NVARCHAR(MAX) NOT NULL, 
    [Category] NVARCHAR(10) NOT NULL DEFAULT 'others', 
    [Difficulty] TINYINT NOT NULL DEFAULT 0, 
    [Options] NVARCHAR(MAX) NOT NULL, 
    [Answer] TINYINT NOT NULL
)
