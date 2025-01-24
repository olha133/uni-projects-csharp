namespace Assignment1.Shop
{
    public class Product
    {
        private string name;
        private double price;
        private ProductType category;

        public Product(string name, double price, ProductType category)
        {
            this.name = name;
            this.price = price;
            this.category = category;
        }

        public double GetPrice() { return price; }
        public ProductType GetCategory() { return category; }

        public override string ToString()
        {
            return this.name;
        }
    }
}
