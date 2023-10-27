CREATE PROCEDURE [GETBOOKSLIST]

@publisher			NVARCHAR(max) = NULL,
@title				NVARCHAR(max) = NULL,
@authorFirstName	NVARCHAR(max) = NULL,
@authorLastName		NVARCHAR(max) = NULL

AS

BEGIN
	SELECT
	Id AS 'id',
	Publisher AS 'publisher', 
	Title	AS 'title',
	AuthorFirstName	AS 'authorFirstName',
	AuthorLastName	AS 'authorLastName',
	Price AS 'price'
	FROM BookTbl
	WHERE 
(@publisher IS NULL or Publisher LIKE '%'+@publisher+'%')
AND (@title IS NULL or Title LIKE '%'+@title+'%')
AND (@authorFirstName IS NULL or AuthorLastName LIKE '%'+@authorFirstName+'%')
AND (@authorLastName IS NULL or AuthorFirstName LIKE '%'+@authorLastName+'%')
	ORDER BY Publisher ASC, AuthorLastName ASC, AuthorFirstName ASC, Title ASC
END
