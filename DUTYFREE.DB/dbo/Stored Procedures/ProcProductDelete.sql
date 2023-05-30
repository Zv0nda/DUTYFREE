CREATE PROCEDURE ProcProductDelete
    @ProductId INT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Products
    SET IsDeleted = 1,
        DateUpdated = GETDATE()
    WHERE ProductId = @ProductId;
END;