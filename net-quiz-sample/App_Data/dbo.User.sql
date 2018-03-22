CREATE TABLE [dbo].[Users]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Username] NCHAR(10) NOT NULL, 
    [Identifier] NVARCHAR(50) NOT NULL
)
