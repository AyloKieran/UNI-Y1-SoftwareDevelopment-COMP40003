using System;

namespace SDAM_Assignment
{
    class Employee_UI
    {
        public static void addToStock(int id, string name, decimal price, int quantity, DateTime date)
        {
            StockManager.addItem(id, name, quantity, date, price);
        }

        public static void takeFromStock(int id, string name, DateTime date)
        {
            StockManager.removeItem(id, date, name);
        }
    }
}
