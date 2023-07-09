CREATE TABLE [dbo].[OnHandInventory] (
    [UPC]      NCHAR (12) NOT NULL,
    [Quantity] INT        NOT NULL,
    [Warehouse] NCHAR(10) NOT NULL, 
    PRIMARY KEY CLUSTERED ([UPC] ASC)
);

