
# MarketStockDB

MarketStockDB is a Windows Form application developed using .NET 8 and C#. It allows users to manage and view market stock data effectively.

![image](https://github.com/user-attachments/assets/e945332c-32ba-4186-a59b-7c4130b0c2bc) ![image](https://github.com/user-attachments/assets/d32844f3-e9fd-483f-a5ed-ef5deb28cfbd) ![image](https://github.com/user-attachments/assets/e24e3e06-7782-49bf-973a-5f49b2413cfc)

## Features

- **Stock Data Management**: Users can add, edit, and delete stock data.
- **Database Integration**: Data is securely stored using Microsoft SQL Server.
- **User-Friendly Interface**: A simple and intuitive Windows Form interface enhances the user experience.

## Requirements

- **.NET 8 SDK**: Required for building and running the application. [Download here](https://dotnet.microsoft.com/download/dotnet/8.0).
- **Microsoft SQL Server**: Used for database management. [Download the SQL Server Express edition here](https://www.microsoft.com/en-us/sql-server/sql-server-downloads).

## Installation

1. **Clone the Repository**:
   ```bash
   git clone https://github.com/EForce11/MarketStockDB.git
   ```
2. **Navigate to the Project Directory**:
   ```bash
   cd MarketStockDB
   ```
3. **Set Up the Database**:
   - Create a new database in SQL Server.
   - Update the connection string in the `App.config` file with your database details.
4. **Run the Application**:
   - Open the `222017034_Final_Project.sln` solution file in Visual Studio.
   - Build and run the solution.

## Usage

- **Add Stock**: Click the "New Stock" button to input stock details.
- **Edit Stock**: Select a stock from the list and click the "Edit" button to update its information.
- **Delete Stock**: Select a stock from the list and click the "Delete" button to remove it.

## Project Structure

- **Form1**: Main form where stocks are listed and managed.
- **Form2**: Form used for adding and editing stocks.
- **Program.cs**: Entry point of the application.
- **App.config**: Configuration file for the application, including the database connection string.

## License

This project is licensed under the MIT License. See the `LICENSE` file for more information.

## Contact

If you have any questions or suggestions, please contact [EForce11](https://github.com/EForce11) via GitHub.

