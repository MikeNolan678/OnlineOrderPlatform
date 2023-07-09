CREATE TABLE [dbo].[OnHandInventory]
(
    [UPC] NCHAR(12) NOT NULL, 
    [Quantity] INT NOT NULL, 
    [Warehouse] NVARCHAR(5) NOT NULL, 
    PRIMARY KEY ([UPC])
	)
