# Web Order Platform - Inventory Management API
  
<h2>About</h2>
This repo contains a .NET Core Web API (utilising Dapper for ORM), created to manage inventory using an SQL database. The API provides functionalities for retrieving and updating inventory data. It's designed to be efficient and reliable, capable of handling bulk data operations.

<h2>Database</h2>
The inventory data is stored in a SQL database with the table structure as follows:

```sql
CREATE TABLE [dbo].[OnHandInventory]
(
    [UPC] NCHAR(12) NOT NULL, 
    [Quantity] INT NOT NULL, 
    [Warehouse] NVARCHAR(5) NOT NULL, 
    PRIMARY KEY ([UPC])
)
```

<h2>API Endpoints</h2>

<h3>GET api/OnHandInventory</h3>
A successful request returns the HTTP status code 200 (OK) along with a JSON array of InventoryModel objects. Each object includes the properties UPC, Quantity, and Warehouse.

```json
[
  {
    "UPC": "123456789012",
    "Quantity": 100,
    "Warehouse": "A01"
  },
  {
    "UPC": "234567890123",
    "Quantity": 200,
    "Warehouse": "B02"
  }
]
```

<h3>GET api/OnHandInventory/{upcCode}</h3>
This endpoint retrieves a specific inventory item that matches the provided UPC code. The data is fetched from the database, the specific item is serialized into JSON, and the JSON string is returned in the response body.

<h5>Parameters:</h5>

upcCode: The UPC code of the item to retrieve.

<h5>Response:</h5>
A successful request returns the HTTP status code 200 (OK) along with a JSON object of the InventoryModel. If the requested UPC code doesn't exist, it returns 404 (Not Found).</p>

```json
[
  {
  "UPC": "123456789012",
  "Quantity": 100,
  "Warehouse": "A01"
}
]
```

<h3>POST api/OnHandInventory</h3>
This endpoint is used to update the inventory data. It expects a list of InventoryModel objects in the request body. The list of incoming inventory is split into items that already exist in the current inventory and items that do not. Existing items are updated and non-existing items are inserted into the database. In the case of an exception during the operation, the changes are rolled back, and an HTTP status 500 (Internal Server Error) is returned along with the exception message. If the operation is successful, it returns an HTTP status 200 (OK).

<h5>Request body:</h5>
The request body should include a JSON array of InventoryModel objects. Each object should include the properties UPC, Quantity, and Warehouse.</p>

```json
[
  {
    "UPC": "123456789012",
    "Quantity": 110,
    "Warehouse": "A01"
  },
  {
    "UPC": "345678901234",
    "Quantity": 150,
    "Warehouse": "C03"
  }
]
```
<h5>Response:</h5>
A successful request returns the HTTP status code 200 (OK). In case of an error, it returns 400 (Bad Request) if the incoming inventory is null or empty, or 500 (Internal Server Error) for any other exceptions during the operation.

<H2> Work in Progress! ⚠️</H2>

<h4> ASP.Net MVC UI layer: </h4>

<li>Search the inventory data</li>
<li>Submit orders</li>


<h4> API layer improvements: </h4>
<li>Send orders to external ERP</li>

