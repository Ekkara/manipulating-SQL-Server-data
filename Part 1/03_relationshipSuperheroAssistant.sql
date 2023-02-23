USE SuperheroesDb

ALTER TABLE Assistant
	ADD Mentor int NOT NULL 

ALTER TABLE Assistant
	ADD FOREIGN KEY (Mentor) REFERENCES Superhero(SuperheroID)  