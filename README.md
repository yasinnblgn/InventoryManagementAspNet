# Inventory Management ASP.NET Core Project

An **Inventory Management System** built with **ASP.NET Core 8**, **Entity Framework Core**, and **MSSQL**. This project demonstrates CRUD functionality for managing products, with a responsive frontend and API support.

---

## Features

- **CRUD Operations**: Add, update, delete, and list products.
  
- **MSSQL Integration**: Data persistence using Entity Framework Core.
  
- **Swagger**: Built-in API documentation and testing.
  
- **Bootstrap 5**: Responsive UI for the frontend.

---

## Technologies

- **ASP.NET Core 8**
  
- **Entity Framework Core**
  
- **MSSQL Server**
  
- **Swagger**
  
- **Bootstrap 5**

---

## Configure the Database: Update appsettings.json:

"ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=InventoryDB;Trusted_Connection=True;TrustServerCertificate=True"
}

## Apply Migrations:

 dotnet ef database update
 
## Run the Application:

dotnet run

## Access Points

Frontend: https://localhost:5002/Products/Index

Swagger: https://localhost:5002/swagger

## API Endpoints

Method	Endpoint	Description

GET	/api/products	Get all products

POST	/api/products	Add a product

PUT	/api/products	Update a product

DELETE	/api/products/{id}	Delete a product


## Validation Rules

Name: Required.

Quantity: Must be > 0.

Price: Must be > 0.


