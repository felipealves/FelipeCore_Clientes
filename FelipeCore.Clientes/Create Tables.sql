PRAGMA foreign_keys = off;

BEGIN TRANSACTION;

CREATE TABLE Clientes (
    Id       INTEGER        PRIMARY KEY AUTOINCREMENT
                            NOT NULL,
    Nome     VARCHAR (2000),
    Email    VARCHAR (200),
    Telefone VARCHAR (20) 
);

INSERT INTO Clientes (
                         Id,
                         Nome,
                         Email,
                         Telefone
                     )
                     VALUES (
                         1,
                         'Felipe3',
                         'felipe603@gmail.com',
                         '1111'
                     );

COMMIT TRANSACTION ; 

PRAGMA foreign_keys = on;