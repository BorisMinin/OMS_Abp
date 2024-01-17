# OMS_Demo_Sample
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
