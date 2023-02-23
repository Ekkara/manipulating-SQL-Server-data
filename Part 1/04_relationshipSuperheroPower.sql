USE SuperheroesDb

CREATE TABLE SuperheroPower(
	SuperheroID int NOT NULL,
	PowerID int NOT NULL,
	PRIMARY KEY (SuperheroID, PowerID),
	FOREIGN KEY (SuperheroID) REFERENCES Superhero(SuperheroID),
	FOREIGN KEY (PowerID) REFERENCES Power(PowerID)
);


