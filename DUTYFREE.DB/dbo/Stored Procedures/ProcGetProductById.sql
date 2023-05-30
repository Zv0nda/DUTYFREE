CREATE PROCEDURE ProcGetProductById
    @ProductId INT
AS
BEGIN
    SELECT * FROM Products WHERE ProductID = @ProductId
END