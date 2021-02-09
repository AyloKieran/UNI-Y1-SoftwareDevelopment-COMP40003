using System;
using System.Collections.Generic;

namespace SDAM_Assignment
{
    class StockManager
    {
        private static List<Item> Items = new List<Item>();
        private static List<Transaction> Transactions = new List<Transaction>();

        public static Item findItem(int id)
        {
            Item foundItem = null;

            for (int i = 0; foundItem == null && i < Items.Count; i++)
            {
                Item Item = Items[i];
                if (Item.getID() == id)
                {
                    foundItem = Item;
                }
            }
            return foundItem;
        }

        public static void addItem(int id, string name, int quantity, DateTime date, decimal price)
        {
            Item Item = findItem(id);

            if (Item != null)
            {
                Item.setQuantity(Item.getQuantity() + quantity);
            } 
            else
            {
                Items.Add(new Item(id, name, quantity));
            }

            addTransaction(findItem(id), "add", null, date, price);
        }

        public static void removeItem(int id, DateTime date, string name)
        {
            Item Item = findItem(id);

            if (Item != null)
            {
                if (Item.getQuantity() >= 1)
                {

                    Item.setQuantity(Item.getQuantity() - 1);
                }
            }

            addTransaction(findItem(id), "remove", name, date, 0);
        }

        public static void addTransaction(Item item, string type, string name, DateTime date, decimal price)
        {
            Transactions.Add(new Transaction(item, type, name, date, price));
        }

        public static List<Item> getAllItems()
        {
            return Items;
        }

        public static List<Transaction> getAllTransactions()
        {
            return Transactions;
        }
    }
}
