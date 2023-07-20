# WebAPI_Using_WatchDog

# Project Description

This project is a .NET Core application that utilizes the WatchDog.NET package to handle exceptions and log errors. The application consists of multiple layers and has been refactored to separate concerns.

## Getting Started

To run the project, follow these steps:

1. Install the WatchDog.NET package via NuGet:

// dotnet add package WatchDog.NET
2. In the `Program.cs` file, add the following code for the service configuration, automatic cleaning, and database connection setup:

```csharp
// Program.cs
// Add WatchDog services for automatic cleaning and database connection setup
builder.Services.AddWatchDogServices(opt =>
{    
    opt.IsAutoClear = false; 
    opt.SetExternalDbConnString = builder.Configuration.GetConnectionString(name: "SampleDbConnection");
    opt.SqlDriverOption = WatchDogSqlDriverEnum.MSSQL;
});

1. Inject the middleware in the app.UseWatchDogExceptionLogger() method:
// Program.cs
// Inject the middleware for exception logging
app.UseWatchDogExceptionLogger();

2. Set up login information for accessing the WatchDog dashboard:
// Program.cs
// Set login information for the WatchDog dashboard
app.UseWatchDog(opt =>
{
    opt.WatchPageUsername = "admin";
    opt.WatchPagePassword = "12345678";
});

3. In the appsettings.json file, add the connection string for your database:
// appsettings.json
"ConnectionStrings": {
    "SampleDbConnection": "Server=DESKTOP-0VT0IBJ\\MSSQLSERVER1; Database=SampleLogDbApp; Trusted_Connection=True;"
}

4. Implement error handling in your application methods:
// Sample method with error logging
public IActionResult Get()
{
    try
    {
        // Your logic here
        // ...

        // Log an information message
        WatchLogger.Log(message: "This is just a sample log entry");

        // If an error occurs, throw an exception and log the error
        throw new Exception("Everything is fine; I'm testing the WatchDog package");
    }
    catch (Exception ex)
    {
        // Log the error
        WatchLogger.LogException(ex);

        // Handle the error
        // ...
    }

    // Other code here
    // ...
}
