using Assignment1.Shop;

namespace Assignment1.Buyers
{
    public class Wish
    {
        private Product product;
        private int count;

        public Wish(Product product, int count)
        {
            this.product = product;
            this.count = count;
        }
        public Product GetProduct() { return product; }
        public int GetCount() { return count; }
        public void SetCount(int count) { this.count = count; }
        public bool Update(int bought)
        {
            if (bought > count) { return false; }
            else
            {
                count -= bought;
                if (count == 0) { return true; }
                else { return false; }
            }
        }
    }
}
