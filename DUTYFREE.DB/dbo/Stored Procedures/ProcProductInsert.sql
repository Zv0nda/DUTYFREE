CREATE PROCEDURE [dbo].[ProcProductInsert]
    @Name NVARCHAR(512),
    @ImageUrl NVARCHAR(1024),
    @Quantity INT,
    @Price DECIMAL(10, 2)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Products(Name, ImageUrl, Quantity, Price)
    OUTPUT INSERTED.Name,Inserted.ImageUrl,INSERTED.Quantity,INSERTED.Price
    VALUES (@Name, @ImageUrl, @Quantity, @Price);
END;