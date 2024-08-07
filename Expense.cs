/*******************************************************************
* Name: Lacie Hendershot
* Date: June 7 2023
* Assignment: CIS317 Week 5 Project – Final
* The "Expense" class represents an expense and includes properties for 
* the amount, date, category ID, and user ID. It provides a structured representation of 
* expense data, allowing for storage, retrieval, and modification of expense information. 
* This class is useful for applications such as personal finance management and expense tracking, enabling users to 
* track their spending and perform financial analyses.
*/
class Expense
{
    public double Amount { get; set; }
    public string Date { get; set; }
    public int CategoryID { get; set; }
    public int UserID { get; set; }
}