
CREATE TABLE Tasks
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    DatePerformed DATE NOT NULL,
    Description NVARCHAR(255) NOT NULL,
    TimeSpent TIME NOT NULL,
    Performer NVARCHAR(100) NOT NULL
);
