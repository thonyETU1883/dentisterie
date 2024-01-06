CREATE TABLE personne (
  id_personne INTEGER PRIMARY KEY,
  nom VARCHAR(50)  
);

CREATE TABLE type_dent(
    id_type_dent INTEGER PRIMARY KEY,
    nom VARCHAR(50)
);

CREATE TABLE traitment (
    id_traitment INTEGER PRIMARY KEY,
    nom_traitment VARCHAR(50),
    niveau_min INTEGER,
    niveau_max INTEGER,
    apres_traitment INTEGER
);

CREATE TABLE dent (
    id_dent INTEGER PRIMARY KEY,
    type_dent INTEGER,
    FOREIGN KEY(type_dent) REFERENCES type_dent(id_type_dent)
);

CREATE TABLE dent_traitment(
    id_dent_traitment SERIAL PRIMARY KEY,
    id_dent INTEGER,
    id_traitment INTEGER,
    prix DOUBLE PRECISION,
    FOREIGN KEY(id_dent) REFERENCES dent(id_dent)
);


CREATE TABLE etat_personne (
    id_etat_personne SERIAL PRIMARY KEY,
    date TIMESTAMP,
    id_personne INTEGER,
    id_dent INTEGER,
    etat INTEGER,
    FOREIGN KEY(id_personne) REFERENCES personne(id_personne),
    FOREIGN KEY(id_dent) REFERENCES dent(id_dent)
);

CREATE TABLE offre (
    id_offre INTEGER PRIMARY KEY,
    nom VARCHAR(50)
);