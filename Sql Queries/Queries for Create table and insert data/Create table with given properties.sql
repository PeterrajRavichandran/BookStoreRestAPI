
--Creating Table 

CREATE TABLE BookTbl (
    
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Publisher NVARCHAR(255) NULL,
    Title NVARCHAR(255) NULL,
    AuthorLastName NVARCHAR(255) NULL,
    AuthorFirstName NVARCHAR(255) NULL,
    Price DECIMAL(6,2) NULL
);


--Creating User-Defined Table for Bulk Save

CREATE TYPE tblBookStore AS TABLE
(
    Id INT,
    Publisher NVARCHAR(255),
    Title NVARCHAR(255),
    AuthorLastName NVARCHAR(255),
    AuthorFirstName NVARCHAR(255),
    Price DECIMAL(6,2)
)
