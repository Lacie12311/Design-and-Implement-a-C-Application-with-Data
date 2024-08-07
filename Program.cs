/*******************************************************************
* Name: Lacie Hendershot
* Date: June 7 2023
* Assignment: CIS317 Week 5 Project – Final
* The "Program" class in C# serves as the entry point for an Expense Tracking application. 
* It initializes an instance of the "ExpenseTracker" class and demonstrates 
* the functionality by adding categories, users, and expenses to the expense tracker database. 
* Finally, it prints all the expenses stored in the database. The "Program" class acts as the central 
* orchestrator, showcasing the capabilities of the Expense Tracking application.
*/
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Expense Tracking Application");

        string databaseName = "ExpenseTracker.db";
        ExpenseTracker expenseTracker = new ExpenseTracker(databaseName);
        
        // Add categories
        Category foodCategory = new Category { Name = "Food" };
        expenseTracker.AddCategory(foodCategory);

        Category transportationCategory = new Category { Name = "Transportation" };
        expenseTracker.AddCategory(transportationCategory);

        // Add users
        User user1 = new User { Name = "John" };
        expenseTracker.AddUser(user1);

        User user2 = new User { Name = "Jane" };
        expenseTracker.AddUser(user2);

        // Add expenses
        Expense expense1 = new Expense { Amount = 10.50, Date = "2023-05-30", CategoryID = 1, UserID = 1 };
        expenseTracker.AddExpense(expense1);

        Expense expense2 = new Expense { Amount = 20.75, Date = "2023-05-31", CategoryID = 2, UserID = 2 };
        expenseTracker.AddExpense(expense2);

        // Print all expenses
        Console.WriteLine("\nPrinting all expenses:");
        expenseTracker.PrintAllExpenses();
    }
}
