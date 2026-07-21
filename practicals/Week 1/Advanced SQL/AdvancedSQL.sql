-- Exercise 1: Ranking and Window Functions
-- Scenario: Find the top 3 most expensive products in each category using different ranking functions.

-- Using ROW_NUMBER(), RANK(), DENSE_RANK()
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


-- Exercise 1 & 5 (Stored Procedure)
-- Scenario: Create a stored procedure and return data from a stored procedure

-- Create a Stored Procedure (Exercise 1)
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

-- Execute and return data from Stored Procedure (Exercise 5)
EXEC GetProductsByCategory @CategoryName = 'Electronics';
GO
