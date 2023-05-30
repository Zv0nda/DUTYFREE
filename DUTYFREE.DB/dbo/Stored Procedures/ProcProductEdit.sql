CREATE PROCEDURE [dbo].[ProcProductEdit]
    @ProductId INT,
    @Name NVARCHAR(50),
    @ImageUrl NVARCHAR(100),
    @Quantity INT,
    @Price DECIMAL(10, 2)
AS
BEGIN
    SET NOCOUNT ON;

    --DECLARE @UpdatedBy NVARCHAR(50) = 'YourUsername'; -- Nahraďte 'YourUsername' vaším uživatelským jménem

    UPDATE Products
    SET Name = @Name,
        ImageUrl = ISNULL(@ImageUrl, ImageUrl),
        Quantity = @Quantity,
        Price = @Price,
        DateUpdated = GETDATE()
        --UpdatedBy = @UpdatedBy
    WHERE ProductId = @ProductId;
END;
