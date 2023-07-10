# Web Order Platform - Inventory Management API
  
<h2>About</h2>
<p>Currently, this project contains a .NET Core Web API (utilising Dapper for ORM), created to manage inventory using an SQL database. The API provides functionalities for retrieving and updating inventory data. It's designed to be efficient and reliable, capable of handling bulk data operations.</p>

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

<h4>GET api/OnHandInventory</h4>
<p>Returns all the items in the inventory in JSON format. It retrieves the data from the database, serializes it into JSON, and returns the JSON string.</p>

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

<h4>GET api/OnHandInventory/{upcCode}</h4>
<p>Returns the specific item in the inventory that matches the provided UPC code. It fetches the data from the database, serializes the specific item into JSON, and returns the JSON string.</p>

```json
[
  {
  "UPC": "123456789012",
  "Quantity": 100,
  "Warehouse": "A01"
}
]
```

<h4>POST api/OnHandInventory</h4>
<p>Updates the inventory data. This endpoint expects a list of InventoryModel objects in the request body. The list of incoming inventory is split into items that exist in the current inventory and items that do not. Existing items are updated and non-existing items are inserted into the database. In the case of an exception during the operation, the changes are rolled back and an HTTP status 500 is returned along with the exception message. If the operation is successful, it returns an HTTP status 200.</p>

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

<h2>Running the Application</h2>
<p>To run this application, you need to have .NET Core 3.1 or later installed on your machine. You can clone this repository, navigate to the project directory in your terminal and run the following command:</p>

```sh
dotnet run
```

<H2> Work in Progress! ⚠️</H2>

<h4> ASP.Net MVC UI layer: </h4>

<li>Search the inventory data</li>
<li>Submit orders</li>


<h4> API layer improvements: </h4>
<li>Send orders to external ERP</li>


<h2>Contributing</h2>
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.
