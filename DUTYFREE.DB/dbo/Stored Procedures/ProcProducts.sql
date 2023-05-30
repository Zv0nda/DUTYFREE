CREATE PROCEDURE [dbo].[ProcProducts]
AS
BEGIN
    SELECT *
FROM Products
WHERE IsDeleted = 0

END;