using System;

namespace SDAM_Assignment
{
    class Transaction
    {
        private Item Item { get; }
        private string Employee { get; }
        private string Type { get; }
        private DateTime Date { get; }
        private decimal Price { get; }

        public Transaction(Item item, string type, string name, DateTime date, decimal price)
        {
            this.Item = item;
            this.Type = type;
            this.Employee = name;
            this.Date = date;
            this.Price = price;
        }

        public Item getItem()
        {
            return this.Item;
        }

        public string getEmployee()
        {
            return this.Employee;
        }

        public string getType()
        {
            return this.Type;
        }

        public DateTime getDate()
        {
            return this.Date;
        }

        public decimal getPrice()
        {
            return this.Price;
        }
    }
}
