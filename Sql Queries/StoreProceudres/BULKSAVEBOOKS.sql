CREATE PROCEDURE [BK].[BULKSAVEBOOKS]
@tblBulkSave [BK].tblBookStore READONLY

AS
BEGIN
    MERGE BookStoreTbl  AS bookStoreTbl
    USING @tblBulkSave AS tblTypeBkSave
    ON (bookStoreTbl.Id = tblTypeBkSave.Id)

    WHEN  MATCHED THEN
        UPDATE SET  Publisher = tblTypeBkSave.Publisher,
                    Title = tblTypeBkSave.Title,
                    AuthorLastName= tblTypeBkSave.AuthorLastName,
                    AuthorFirstName= tblTypeBkSave.AuthorFirstName,
                    Price= tblTypeBkSave.Price

    WHEN NOT MATCHED THEN
        INSERT ([Publisher],[Title],[AuthorLastName],[AuthorFirstName],[Price])
        VALUES (tblTypeBkSave.Publisher,tblTypeBkSave.Title,tblTypeBkSave.AuthorLastName,tblTypeBkSave.AuthorFirstName,tblTypeBkSave.Price);
END
