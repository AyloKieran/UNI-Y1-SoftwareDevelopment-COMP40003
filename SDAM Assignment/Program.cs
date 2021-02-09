using System;

namespace SDAM_Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            const int ADDTOSTOCK = 1;
            const int TAKEFROMSTOCK = 2;
            const int INVENTORYREPORT = 3;
            const int FINANCIALREPORT = 4;
            const int DISPLAYTRANSACTIONLOG = 5;
            const int REPORTPERSONALUSAGE = 6;
            const int EXIT = 7;

            DisplayMenu();
            int choice = GetMenuChoice();

            while (choice != EXIT)
            {
                switch (choice)
                {
                    case ADDTOSTOCK:
                        AddToStock();
                        break;
                    case TAKEFROMSTOCK:
                        TakeFromStock();
                        break;
                    case INVENTORYREPORT:
                        InventoryReport();
                        break;
                    case FINANCIALREPORT:
                        FinancialReport();
                        break;
                    case DISPLAYTRANSACTIONLOG:
                        DisplayTransactionLog();
                        break;
                    case REPORTPERSONALUSAGE:
                        ReportPersonalUsage();
                        break;
                }
                DisplayMenu();
                choice = GetMenuChoice();
            }
        }

        private static void DisplayMenu()
        {
            Console.WriteLine("\n1. Add to Stock");
            Console.WriteLine("2. Take from Stock");
            Console.WriteLine("3. Inventory Report");
            Console.WriteLine("4. Financial Report");
            Console.WriteLine("5. Display Transaction Log");
            Console.WriteLine("6. Report Personal Usage");
            Console.WriteLine("7. Exit");
        }

        private static int GetMenuChoice()
        {
            int option = ReadInteger("\nOption");
            while (option < 1 || option > 7)
            {
                Console.WriteLine("\nOption not recognised. Please try again.");
                option = ReadInteger("\nOption");
            }
            return option;
        }

        private static int ReadInteger(string prompt)
        {
            while (true)
            {
                Console.Write(prompt + ": > ");
                try
                {
                    int num = Convert.ToInt32(Console.ReadLine());
                    if (num > 0)
                    {
                        return num;
                    } else {
                        Console.WriteLine("Please enter a number larger than 0.");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid Input, try again.");
                }
            }
        }

        private static string ReadString(string prompt)
        {
            while (true)
            {
                Console.Write(prompt + ": > ");
                try
                {
                    string str = Convert.ToString(Console.ReadLine());
                    if (str != "")
                    {
                        return str;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a String.");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid Input, try again.");
                }
            }
        }

        private static decimal ReadDecimal(string prompt)
        {
            while (true)
            {
                Console.Write(prompt + ": > ");
                try
                {
                    decimal num = Convert.ToDecimal(Console.ReadLine());
                    if (num > 0)
                    {
                        return num;
                    } else 
                    {
                        Console.WriteLine("Please Enter a Decimal larger than 0.");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid Input, try again.");
                }
            }
        }

        private static DateTime ReadDate(string prompt)
        {
            while (true)
            {
                Console.Write(prompt + ": > ");
                try
                {
                    return Convert.ToDateTime(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid Input, try again.");
                }
            }
        }

        private static void AddToStock()
        {
            int id = ReadInteger("\nItem ID");
            string name = ReadString("Item Name");
            int quantity = ReadInteger("Quantity");
            decimal price = ReadDecimal("Price");
            DateTime date = ReadDate("Date added");

            Employee_UI.addToStock(id, name, price, quantity, date);
        }

        private static void TakeFromStock()
        {
            int id = ReadInteger("\nItem ID");
            string name = ReadString("Employee Name");
            DateTime date = ReadDate("Date removed");

            Employee_UI.takeFromStock(id, name, date);
        }

        private static void InventoryReport()
        {
            Manager_UI.InventoryReport();
        }

        private static void FinancialReport()
        {
            Manager_UI.FinancialReport();
        }

        private static void DisplayTransactionLog()
        {
            Manager_UI.DisplayTransactionLog();
        }

        private static void ReportPersonalUsage()
        {
            string employee = ReadString("Employee");
            Manager_UI.ReportPersonalUsage(employee);
        }
    }
}
