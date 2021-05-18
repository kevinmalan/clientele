# clientele
Follows a 3 tier architecture consisting of
- ASP.NET CORE API Backend
- SQL Server Database
- Angular Frontend

## Getting Started
- Add your SQL Server connection string value to the key "sqlConnectionString" inside appsettings.json
- Publish Clientele.Data to your SQL Server
- Start the API Project: Clientele.API
- Via the command line, navigate to ~Clientele\Clientele-Web and run ng serve --open
- Via your browser, navigate to http://localhost:4200/
