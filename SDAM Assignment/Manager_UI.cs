using System;
using System.Collections.Generic;

namespace SDAM_Assignment
{
    class Manager_UI
    {
        private static void DisplayTransaction(Transaction transaction)
        {
            string type = transaction.getType();
            string date = transaction.getDate().ToString();
            string id = transaction.getItem().getID().ToString();
            string itemname = transaction.getItem().getItemName();

            if (type == "add")
            {
                string price = transaction.getPrice().ToString();
                Console.WriteLine("\t{0, -19} {1, -6} {2, -3} {3, -10} {4, -10} {5, -5}",
                    date,
                    type,
                    id,
                    itemname,
                    "",
                    price);
            }
            else
            {
                string name = transaction.getEmployee();
                Console.WriteLine("\t{0, -19} {1, -6} {2, -3} {3, -10} {4, -10} {5, -5}",
                    date,
                    type,
                    id,
                    itemname,
                    name,
                    "");
            }
        }

        private static void DisplayItem(Item item)
        {
            Console.WriteLine("\t{0, -3} {1, -15} {2, -3}",
                item.getID().ToString(),
                item.getItemName(),
                item.getQuantity().ToString());
        }

        private static void DisplayItemFinance(string id, string name, string total)
        {
            Console.WriteLine("\t{0, -3} {1, -15} {2, -3}",
                id,
                name,
                total);
        }
        public static void InventoryReport()
        {
            List<Item> Items = StockManager.getAllItems();

            Console.WriteLine("\nInventory Report");
            Console.WriteLine("\t{0, -3} {1, -15} {2, -3}",
                "ID",
                "Name",
                "Quantity");

            foreach (Item item in Items)
            {
                DisplayItem(item);
            }
        }

        public static void FinancialReport()
        {
            List<Item> Items = StockManager.getAllItems();
            List<Transaction> Transactions = StockManager.getAllTransactions();
            decimal globaltotal = 0;

            Console.WriteLine("\nFinancial Report");
            Console.WriteLine("\t{0, -3} {1, -10} {2, -5}",
                "ID",
                "Name",
                "Expenditure");

            foreach (Item item in Items)
            {
                int id = item.getID();
                decimal total = 0;

                foreach (Transaction transaction in Transactions)
                {
                    if (transaction.getItem().getID() == id)
                    {
                        total += transaction.getPrice();
                    }
                }

                DisplayItemFinance(id.ToString(), item.getItemName(), total.ToString());
                globaltotal += total;
            }

            Console.WriteLine("\n\tTotal Expenditure is: " + globaltotal.ToString());
        }

        public static void DisplayTransactionLog()
        {
            List<Transaction> Transactions = StockManager.getAllTransactions();

            Console.WriteLine("\nTransaction Log");
            Console.WriteLine("\t{0, -19} {1, -6} {2, -3} {3, -10} {4, -10} {5, -5}",
                "Date",
                "Type",
                "ID",
                "Name",
                "Employee",
                "Price");

            foreach (Transaction transaction in Transactions)
            {
                DisplayTransaction(transaction);
            }
        }

        public static void ReportPersonalUsage(string employee)
        {
            List<Transaction> Transactions = StockManager.getAllTransactions();

            Console.WriteLine("\nTransaction Log");
            Console.WriteLine("\t{0, -19} {1, -6} {2, -3} {3, -10} {4, -10} {5, -5}",
                "Date",
                "Type",
                "ID",
                "Name",
                "Employee",
                "Price");

            foreach (Transaction transaction in Transactions)
            {
                if (transaction.getEmployee() == employee)
                {
                    DisplayTransaction(transaction);
                }
            }
        }
    }
}
