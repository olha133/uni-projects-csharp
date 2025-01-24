namespace Assignment1.Shop
{
    public class Article
    {
        private Product product;
        private double incomeRate;
        private double discount;
        private int quantity;

        public Article(Product product, double incomeRate, int quantity, double discount)
        {
            this.product = product;
            this.incomeRate = incomeRate;
            this.quantity = quantity;
            this.discount = discount;
        }

        public double GetDiscount() { return discount; }
        public Product GetProduct() { return product; }
        public int GetQuantity() { return quantity; }
        public double GetPrice()
        {
            return (product.GetPrice() + product.GetPrice() * incomeRate) * (1 - discount);
        }

        public ProductType GetCategory() { return product.GetCategory(); }

        public void SetQuantity(int count) { this.quantity = count; }
        public void SetDiscount(double discount) { this.discount = discount; }

        public void SetIncomeRate(double incomeRate) { this.incomeRate = incomeRate; }

        public bool CanSell(int count) { return quantity >= count; }

        public bool Sell(int count)
        {
            if (CanSell(count))
            {
                this.quantity -= count;
                return true;
            }
            return false;
        }
    }
}
