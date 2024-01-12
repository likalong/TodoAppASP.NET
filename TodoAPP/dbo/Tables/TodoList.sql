CREATE TABLE TodoList (
    Id INT PRIMARY KEY IDENTITY,
    Title NVARCHAR(255) NOT NULL,
    Description NVARCHAR(255) NOT NULL,
	Status INT NOT NULL default 1,
    CreatedOn DATETIME NULL,
    CreatedBy NVARCHAR(100) NULL,
    ModifiedOn DATETIME NULL,
    ModifiedBy NVARCHAR(100) NULL,
);

ALTER TABLE TodoList ALTER COLUMN Title NVARCHAR(255);


INSERT INTO TodoList (Title, Description, Status, CreatedOn, CreatedBy, ModifiedOn, ModifiedBy)
VALUES
    ('Test1', 'Generate Select query to get data from table', 1, GETDATE(), 'lia',  GETDATE(), 'user1'),
    ('Test2', 'Generate Select query to get data from table', 2, GETDATE(), 'lia',  GETDATE(), '')

SELECT * FROM TodoList

SELECT * FROM TodoList WHERE Id = 3;