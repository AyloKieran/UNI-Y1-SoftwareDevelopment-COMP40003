namespace SDAM_Assignment
{
    class Item
    {
        private int ID { get; }
        private string Name { get; }
        private int Quantity { get; set; }

        public Item(int id, string name, int quantity)
        {
            this.ID = id;
            this.Name = name;
            this.Quantity = quantity;
        }

        public int getID()
        {
            return this.ID;
        }

        public string getItemName()
        {
            return this.Name;
        }

        public int getQuantity()
        {
            return this.Quantity;
        }

        public void setQuantity(int quantity)
        {
            this.Quantity = quantity;
        }
    }
}
