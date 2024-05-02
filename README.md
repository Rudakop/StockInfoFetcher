# StockInfoApp


## Overview
`StockInfoApp` is a .NET Core console application that fetches and displays stock information based on a symbol provided as a command-line argument. It utilizes the FinnHub API to retrieve stock details like the symbol and description.


## Prerequisites
- .NET Core 3.1 SDK or later
- Visual Studio 2019 or any compatible IDE that supports .NET Core development
- An API key from FinnHub (register at [FinnHub](https://finnhub.io/register) to obtain an API key)

## Setup

### API Key Configuration
After obtaining your API key from FinnHub, perform the following steps to configure your application:
1. Open the `appsettings.json` file located in the root directory of the project.
2. Replace the placeholder `your_api_key_here` with your actual FinnHub API key:
    ```json
    {
      "FinnhubApiKey": "your_actual_api_key_here"
    }
    ```

### Clone the Repository
To get started with the StockInfoApp, clone the source code from the repository or download the zip file to your local machine. Use the following command to clone:
```bash
git clone https://github.com/Rudakop/StockInfoApp


## Running the Application
To run the application, navigate to the project directory where the .csproj file is located and execute the following commands:


## Build the Application
Compile the application to ensure there are no compilation errors:

````dotnet build````


## Run the Application
Execute the application with a stock symbol as the command-line argument:

````dotnet run -- <StockSymbol>````

Replace **<StockSymbol>** with the actual stock symbol you want to query, such as **MSFT** for Microsoft. For example:

````dotnet run -- MSFT````

This command fetches and displays information about Microsoft stock.


## Features
**Command-Line Input**: The application accepts a stock symbol as an input via command line.
**Stock Data Retrieval**: Connects to the FinnHub API to retrieve and display stock data.
**Error Handling**: Implements basic error handling for API connectivity issues and data processing errors.


## Contributing
Contributions to the StockInfoApp are welcome! Please fork the repository, make your changes, and submit a pull request with your improvements.


## License
This project is released under the MIT License. For more details, see the LICENSE.md file included with the project.