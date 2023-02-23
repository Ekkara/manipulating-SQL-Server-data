USE SuperheroesDb

CREATE TABLE Superhero(
	SuperheroID int IDENTITY(1,1) PRIMARY KEY,
	SuperheroName nvarchar(20),
	SuperheroAlias nvarchar(20),
	SuperheroOrigin nvarchar(50)
);

CREATE TABLE Assistant(
	AssistantID int IDENTITY(1,1) PRIMARY KEY,
	AssistantName nvarchar(20)
);

CREATE TABLE Power(
	PowerID int IDENTITY(1,1) PRIMARY KEY,
	PowerName nvarchar(20),
	PowerDesc nvarchar(50),
);