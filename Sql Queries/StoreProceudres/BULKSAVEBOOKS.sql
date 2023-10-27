CREATE PROCEDURE [BULKSAVEBOOKS]
@tblBulkSave [dbo].tblBookStore READONLY
AS
BEGIN

    UPDATE b
    SET b.Publisher = t.Publisher,
        b.Title = t.Title,
        b.AuthorLastName = t.AuthorLastName,
        b.AuthorFirstName = t.AuthorFirstName,
        b.Price = t.Price
    FROM BookTbl b
    JOIN @tblBulkSave t ON b.Id = t.Id;

    -- Insert new records
    INSERT INTO BookTbl (Publisher, Title, AuthorLastName, AuthorFirstName, Price)
	OUTPUT 1 AS ResultCode
    SELECT Publisher, Title, AuthorLastName, AuthorFirstName, Price
    FROM @tblBulkSave t
    WHERE NOT EXISTS (
        SELECT 1
        FROM BookTbl b
        WHERE b.Id = t.Id
    );
END
