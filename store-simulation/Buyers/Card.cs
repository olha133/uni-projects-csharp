using Assignment1.Shop;

namespace Assignment1.Buyers
{
    public class Card
    {
        private List<ProductType> validFor;
        private double discount;

        public Card(List<ProductType> validFor, double discount)
        {
            this.validFor = validFor;
            this.discount = discount;
        }

        public double GetDiscount() { return discount; }
        public bool IsValidFor(ProductType category)
        {
            return validFor.Contains(category);
        }
    }
}
