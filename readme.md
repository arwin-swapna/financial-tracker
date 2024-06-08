# Finance Tracker Application

This is a finance tracker application built with .NET 8.0 and Entity Framework Core. It uses MySQL as the database.

## Features

- Exception handling with custom middleware
- Dependency Injection for services
- MySQL database connection with EF Core
- Swagger for API documentation
- HTTPS redirection and Authorization

## Services

- `TellerService`: This service is responsible for the main operations related to finance tracking.

## Middleware

- `ExceptionMiddleware`: This middleware is used for handling exceptions globally across the application.

## Setup

1. Clone the repository
2. Open the project in Visual Studio Code
3. Update the connection string in the `appsettings.json` file with your MySQL server details
4. Run the application

## Running the Application

You can run the application using the `dotnet run` command in the terminal.

## API Documentation

When running in development mode, you can access the Swagger UI for API documentation at the `/swagger` endpoint.

## Contributing

Contributions are welcome. Please open an issue or submit a pull request.

## License

This project is licensed under the MIT License.