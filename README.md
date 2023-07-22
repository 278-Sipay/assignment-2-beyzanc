# Sipay&Patika.dev .NET Bootcamp - Case #2: Transactin Filter APİ

This is a transaction API project that allows users to retrieve transactions based on various filtering criteria. The API exposes a GetByParameter endpoint in the TransactionController, which accepts query parameters to filter transactions based on specific criteria, such as account number, credit amount, debit amount, description, transaction date, and reference number.

The project is built using ASP.NET Core with Entity Framework Core for data access. The data models are defined using the Code-First approach with a database context class representing the database schema. The Generic Repository pattern is implemented to provide common CRUD operations for entities, and the TransactionRepository extends the generic repository to add filtering capabilities for transactions.

## How to Use

1. Clone the repository and open the project in your preferred development environment (e.g., Visual Studio or Visual Studio Code).

2. Configure the database connection in the appsettings.json file to point to your SQL Server or another compatible database.

3. Use Entity Framework Core migrations to create the database schema:

```
dotnet ef migrations add InitialCreate
dotnet ef database update
```
4. Run the API project:

``` dotnet run --project TransactionApi ```

5. The API will be hosted at `http://localhost:<port>/sipay/api/transaction` where <port> is the port number specified in the configuration.

6. Access the GetByParameter endpoint with the required query parameters to retrieve filtered transactions.


## Query Parameters

The Transaction API supports various endpoints, but for this assignment, the main API to utilize is the GetByParameter method, which allows users to filter transactions based on different criteria. The supported filter criteria are:

- **AccountNumber:** Exact match filter for the account number.
- **MinAmountCredit, MaxAmountCredit:** Range filter for credit amount.
- **MinAmountDebit, MaxAmountDebit:** Range filter for debit amount.
- **Description:** Filter by a partial match of the transaction description.
- **BeginDate, EndDate:** Range filter for the transaction date.
- **ReferenceNumber:** Exact match filter for the reference number.

You can make a GET request to the endpoint **/sipay/api/transaction/GetByParameter** and pass the filter criteria as query parameters. The API will then return a list of transactions that match the provided filters.

## Some Example Filtering Scenarios:

- Retrieve transactions for a specific account number within a date range and with a minimum credit amount:

`GET sipay/api/Transaction/GetByParameter?accountNumber=12345&beginDate=2023-01-01&endDate=2023-06-30&minAmountCredit=100 `

- Find transactions with a description containing a specific keyword and a maximum debit amount:

`GET sipay/api/Transaction/GetByParameter?description=Payment&maxAmountDebit=500`

- Filter transactions with a reference number and a minimum credit amount:

`GET sipay/api/Transaction/GetByParameter?referenceNumber=12345&minAmountCredit=200`

- Retrieve transactions with a specific account number and a range of debit amounts:

`GET sipay/api/Transaction/GetByParameter?accountNumber=54321&minAmountDebit=50&maxAmountDebit=300 `

- Search for transactions with a description containing a keyword and a reference number:

`GET sipay/api/Transaction/GetByParameter?description=Transfer&referenceNumber=56789`

- Filter transactions within a date range and with a specific account number:

`GET sipay/api/Transaction/GetByParameter?accountNumber=67890&beginDate=2023-03-01&endDate=2023-03-31 `

## LINQ Usage

The TransactionApi project leverages LINQ (Language-Integrated Query) to perform data querying and manipulation. LINQ is a powerful feature of C# that enables concise and type-safe querying of various data sources.

In this project, LINQ is primarily employed within the TransactionRepository class to filter transactions based on different criteria in the GetByFilter method. Utilizing LINQ expressions in combination with Entity Framework Core's IQueryable interface allows the creation of efficient database queries.

## SOLID Principles in the TransactionApi Project:

- **Single Responsibility Principle:** Each class has a single responsibility, e.g., Transaction for representing a transaction and TransactionController for handling API requests.
  
- **Open/Closed Principle**: The project is open for extension through new repositories but closed for modification of existing classes when introducing new features.
  
- **Liskov Substitution Principle:** Derived classes like TransactionRepository can substitute their base class GenericRepository<Transaction> without affecting behavior.
  
- **Interface Segregation Principle:** Specific interfaces like ITransactionRepository provide only required methods for specific clients, preventing unnecessary dependencies.
  
- **Dependency Inversion Principle:** High-level modules like TransactionController depend on abstractions (interfaces) rather than concrete implementations (e.g., TransactionRepository).

## Idempotence

The project follows the principles of idempotence, which means that calling the same API endpoint multiple times with the same parameters will yield the same results. The **GetByParameter endpoint** is designed to be ***idempotent***, meaning that multiple identical requests will not create any unintended side effects, and the returned data will remain consistent.

## Object-Oriented Programming in the TransactionApi Project

- **Abstraction:** Abstraction is achieved in the TransactionApi project through the use of interfaces like ITransactionRepository and IGenericRepository, allowing the decoupling of concrete implementations from clients and promoting modularity.

- **Polymorphism:** Polymorphism is evident in the project as different classes implement the same interfaces (ITransactionRepository, IGenericRepository), enabling interchangeable usage of various repository implementations without impacting the client code.

- **Encapsulation:** Encapsulation is practiced in the project by encapsulating data and behavior within classes. For example, the Transaction class encapsulates its properties, and access to them is controlled through getters and setters, ensuring data integrity.

- **Inheritance:** Inheritance is utilized in the project through the BaseModel class, which serves as the base class for domain models like Transaction. This enables code reuse and promotes a consistent structure across domain entities.
  
## Development Tools

- .NET Core
- Entity Framework Core
- Microsoft.EntityFrameworkCore.SqlServer
- ASP.NET Core
- Visual Studio Code
- Swagger
