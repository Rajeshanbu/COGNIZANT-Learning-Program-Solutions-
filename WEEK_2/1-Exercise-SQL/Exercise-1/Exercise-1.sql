USE tanvidb;
CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName VARCHAR(100),
    Category VARCHAR(50),
    Price DECIMAL(10, 2)
);
INSERT INTO Products (ProductID, ProductName, Category, Price) VALUES
(1, 'Laptop Pro 15"', 'Electronics', 1500.00),
(2, 'Smartphone X', 'Electronics', 1000.00),
(3, 'Bluetooth Speaker', 'Electronics', 300.00),
(4, '4K Monitor', 'Electronics', 500.00),
(5, 'Mouse', 'Electronics', 50.00),
(6, 'Gaming Chair', 'Furniture', 350.00),
(7, 'Desk', 'Furniture', 200.00),
(8, 'Bookshelf', 'Furniture', 180.00),
(9, 'Office Chair', 'Furniture', 250.00),
(10, 'Couch', 'Furniture', 700.00),
(11, 'T-shirt', 'Apparel', 25.00),
(12, 'Leather Jacket', 'Apparel', 150.00),
(13, 'Sneakers', 'Apparel', 120.00),
(14, 'Jeans', 'Apparel', 80.00),
(15, 'Sweatshirt', 'Apparel', 60.00);
SELECT *
FROM (
    SELECT *,
           ROW_NUMBER() OVER(PARTITION BY Category ORDER BY Price DESC) AS RowNum
    FROM Products
) ranked
WHERE RowNum <= 3;
 Using RANK()
SELECT *
FROM (
    SELECT *,
           RANK() OVER(PARTITION BY Category ORDER BY Price DESC) AS RankNum
    FROM Products
) ranked
WHERE RankNum <= 3;

 Using DENSE_RANK()
SELECT *
FROM (
    SELECT *,
           DENSE_RANK() OVER(PARTITION BY Category ORDER BY Price DESC) AS DenseRankNum
    FROM Products
) ranked
WHERE DenseRankNum <= 3;
