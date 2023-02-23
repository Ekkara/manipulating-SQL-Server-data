USE SuperheroesDb

INSERT INTO Power (PowerName, PowerDesc) VALUES ('Spider Powers', 'Does whatever a spider does')
INSERT INTO Power (PowerName, PowerDesc) VALUES ('Super Speed', 'He is still late to work though...')
INSERT INTO Power (PowerName, PowerDesc) VALUES ('Lying', 'Not telling the truth')
INSERT INTO Power (PowerName, PowerDesc) VALUES ('Peak Intelligence', 'Has big brain, is big smort')

INSERT INTO SuperheroPower (SuperheroID, PowerID) VALUES (1, 1)
INSERT INTO SuperheroPower (SuperheroID, PowerID) VALUES (1, 4)
INSERT INTO SuperheroPower (SuperheroID, PowerID) VALUES (2, 2)
INSERT INTO SuperheroPower (SuperheroID, PowerID) VALUES (2, 4)
INSERT INTO SuperheroPower (SuperheroID, PowerID) VALUES (3, 3)
INSERT INTO SuperheroPower (SuperheroID, PowerID) VALUES (3, 4)