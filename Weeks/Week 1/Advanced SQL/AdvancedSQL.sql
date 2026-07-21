
SELECT 
    ProductID,
    ProductName,
    Category,
    Price,
    ROW_NUMBER() OVER(PARTITION BY Category ORDER BY Price DESC) as RowNum,
    RANK() OVER(PARTITION BY Category ORDER BY Price DESC) as Rnk,
    DENSE_RANK() OVER(PARTITION BY Category ORDER BY Price DESC) as DenseRnk
FROM 
    Products;


CREATE PROCEDURE GetProductsByCategory
    @CategoryName NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        ProductID,
        ProductName,
        Price
    FROM 
        Products
    WHERE 
        Category = @CategoryName;
END;
GO

EXEC GetProductsByCategory @CategoryName = 'Electronics';
GO
