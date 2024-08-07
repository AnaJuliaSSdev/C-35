CREATE TABLE Products (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(255) NOT NULL,
    Description NVARCHAR(255) NOT NULL,
    Perishable BIT NOT NULL,
    Category NVARCHAR(255) NOT NULL,
    Subcategory NVARCHAR(255) NOT NULL,
    Price DECIMAL(10, 2) NOT NULL
);