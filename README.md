# OMS_ABP
## Description
The OMS is a REST API application with folowing notifications. Based on DDD principles and Abp.Framework. Created on .Net 7 (Migration to .Net 8 version comming soon). The Northwind demo database in SQLite format is used to facilitate distribution. The project was created using the author's set of business rules. The project is aimed for working with frequently changing business rules. Adding and modifying business rules is done through EntityManagers.
### Used books:
- __Eric Evans__ - "Domain Driven Design" with Martin Fowler preface.
- __ABP.io__ - "Implementing Domain Driven Design".
- [Mastering ABP Framework: Build maintainable .NET solutions by implementing software development best practices](https://www.amazon.com/Mastering-ABP-Framework-maintainable-implementing/dp/1801079242)
### Project links:
- [ABP Documentation](https://docs.abp.io/en/abp/latest)
- [Demo version](https://github.com/BorisMinin/OMS_Demo_Sample)
## Entities Definition
### Category entity
- __Definition__: Contains information about the categories of products available for sale. Provides an organized way to categorize products.
- __Business Rules__:
  - The created and updated Category instance must not contain a CategoryName that already exists in the database.
### Customer entity
- __Definition__: Contains information about the the company's customers.
### OrderDetail entity
- __Definition__: Contains the details of individual products within an order.
- __Business Rules__:
  - Getting, updating and deleting records from the OrderDetail table is prohibited.
  - Adding Product to OrderDetail is possible only in an amount not exceeding the number of products in stock.
### Order entity
- __Definition__: Contains information about each customer's order made in the system.
- __Business Rules__:
  - The created and updated Order instance must contain the CustomerId that already exists in the database.
### Product entity
- __Definition__: Contains information about all products offered by the company.
- __Business Rules__:
  - The created and updated Product instance must contain the CategoryId that already exists in the database.
  - The created and updated Product instance must not contain the CategoryName that already exists in the database.
### Shipper entity
- __Definition__: Contains information about the companies responsible for delivering orders to customers.
