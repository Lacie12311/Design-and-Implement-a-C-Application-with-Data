/*******************************************************************
* Name: Lacie Hendershot
* Date: June 7 2023
* Assignment: CIS317 Week 5 Project – Final
* TThe "ExpenseTracker" class  serves as a tracker for expenses, 
* providing functionality to interact with a SQLite database. It establishes a connection to the 
* database upon initialization and creates necessary tables using SQLite commands.
*/
using System;
using System.Collections.Generic;
using System.Data.SQLite;

class ExpenseTracker
{
    private SQLiteConnection connection;
    
    public ExpenseTracker(string databaseName)
    {
        connection = new SQLiteConnection($"Data Source={databaseName};Version=3;");
        connection.Open();
        
        CreateTables();
    }
    
    private void CreateTables()
    {
        using (SQLiteCommand command = new SQLiteCommand("CREATE TABLE IF NOT EXISTS Categories (ID INTEGER PRIMARY KEY, Name TEXT);", connection))
        {
            command.ExecuteNonQuery();
        }
        
        using (SQLiteCommand command = new SQLiteCommand("CREATE TABLE IF NOT EXISTS Expenses (ID INTEGER PRIMARY KEY, Amount REAL, Date TEXT, CategoryID INTEGER, UserID INTEGER, FOREIGN KEY(CategoryID) REFERENCES Categories(ID), FOREIGN KEY(UserID) REFERENCES Users(ID));", connection))
        {
            command.ExecuteNonQuery();
        }
        
        using (SQLiteCommand command = new SQLiteCommand("CREATE TABLE IF NOT EXISTS Users (ID INTEGER PRIMARY KEY, Name TEXT);", connection))
        {
            command.ExecuteNonQuery();
        }
    }
    
    public void AddCategory(Category category)
    {
        using (SQLiteCommand command = new SQLiteCommand("INSERT INTO Categories (Name) VALUES (@Name);", connection))
        {
            command.Parameters.AddWithValue("@Name", category.Name);
            command.ExecuteNonQuery();
        }
    }
    
    public void AddExpense(Expense expense)
    {
        using (SQLiteCommand command = new SQLiteCommand("INSERT INTO Expenses (Amount, Date, CategoryID, UserID) VALUES (@Amount, @Date, @CategoryID, @UserID);", connection))
        {
            command.Parameters.AddWithValue("@Amount", expense.Amount);
            command.Parameters.AddWithValue("@Date", expense.Date);
            command.Parameters.AddWithValue("@CategoryID", expense.CategoryID);
            command.Parameters.AddWithValue("@UserID", expense.UserID);
            command.ExecuteNonQuery();
        }
    }
    
    public void AddUser(User user)
    {
        using (SQLiteCommand command = new SQLiteCommand("INSERT INTO Users (Name) VALUES (@Name);", connection))
        {
            command.Parameters.AddWithValue("@Name", user.Name);
            command.ExecuteNonQuery();
        }
    }
    
    public void PrintAllExpenses()
    {
        using (SQLiteCommand command = new SQLiteCommand("SELECT e.ID, e.Amount, e.Date, c.Name AS Category, u.Name AS User FROM Expenses e JOIN Categories c ON e.CategoryID = c.ID JOIN Users u ON e.UserID = u.ID;", connection))
        using (SQLiteDataReader reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["ID"]);
                double amount = Convert.ToDouble(reader["Amount"]);
                string date = reader["Date"].ToString();
                string category = reader["Category"].ToString();
                string user = reader["User"].ToString();
                
                Console.WriteLine($"Expense ID: {id}");
                Console.WriteLine($"Amount: {amount}");
                Console.WriteLine($"Date: {date}");
                Console.WriteLine($"Category: {category}");
                Console.WriteLine($"User: {user}\n");
            }
        }
    }
}
