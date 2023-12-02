# API for State and National Parks

#### By _**Jessica Hattig**_

#### _Epicodus, Week 25-26 Independent Project: C# and .NET, Building an API and Further Exploration with Authentication_

## Description
The Parks API project is a web application designed to provide information about state and national parks. The API serves as a central hub for accessing details such as park names, locations, and descriptions. Whether you're planning a hiking adventure or simply curious about different parks, this API offers a convenient way to retrieve valuable information.

On the second branch, "Authentication," this API further explores authentication within the context of a built API.

## Technologies Used
- C#
- Entity Framework Core
- ASP.NET Core
- Swagger

## Setup/Installation Requirements
### Install Tools

Install the tools that are introduced in [this series of lessons on LearnHowToProgram.com](https://www.learnhowtoprogram.com/c-and-net/getting-started-with-c).

If you have not already, install the `dotnet-ef` tool by running the following command in your terminal:

```
dotnet tool install --global dotnet-ef --version 6.0.0
```

### Set Up and Run Project

1. Clone this repo.
2. Open the terminal and navigate to this project's production directory called "ParksApi".
3. Within the production directory "CretaceousApi", create two new files: `appsettings.json` and `appsettings.Development.json`.
4. Within `appsettings.json`, put in the following code. Make sure to replacing the `uid` and `pwd` values in the MySQL database connection string with your own username and password for MySQL.

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;database=parks_api;uid=[YOUR_USERNAME];pwd=[YOUR_MYSQL_PASSWORD];"
  }
}
```

5. Within `appsettings.Development.json`, add the following code:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Trace",
      "Microsoft.AspNetCore": "Information",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  }
}
```

6. Create the database using the migrations in the Parks API project. Open your shell (e.g., Terminal or GitBash) to the production directory "ParksApi", and run `dotnet ef database update`. You may need to run this command for each of the branches in this repo. 
7. Within the production directory "ParksApi", run `dotnet run` in the command line to start the project server. 
9. Use your program of choice to make API calls. In your API calls, use the domain _http://localhost:5000_. 

## Project Roadmap, Notes and Documentation
- [Project Roadmap and Notes](https://github.com/)
- [API Documentation](https://github.com/)

## Known Bugs
- Please visit this projects [GitHub repository](https://github.com/jessicahattig/ParksApi.Solution.git) to submit Issues and Pull Requests.

## License
MIT License

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the “Software”), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

Copyright (c) Jessica Hattig 2023 