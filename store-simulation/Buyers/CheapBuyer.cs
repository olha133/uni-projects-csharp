using Assignment1.Shop;

namespace Assignment1.Buyers
{
    public class CheapBuyer : Buyer
    {
        public CheapBuyer(Card card, double budget) : base(card, budget)
        {
        }

        public override void VisitStores(List<Store> stores)
        {
            foreach (var wish in wishList.ToList())
            {
                List<double> prices = new List<double>();
                List<Store> res_stores = new List<Store>();
                Product product = wish.GetProduct();
                int count = wish.GetCount();
                bool flag = false;
                foreach (var store in stores)
                {
                    if (Inquire(store, wish))
                    {
                        double price = store.GetPrice(product, card);
                        if (price > 0)
                        {
                            if (CanAfford(price, count))
                            {
                                prices.Add(price);
                                res_stores.Add(store);
                                flag = true;
                            }
                        }
                    }
                }
                if (flag)
                {
                    double minValue = prices.Min();
                    int minIndex = prices.IndexOf(minValue);
                    res_stores[minIndex].SellProduct(product, count, this);
                }
            }

        }
    }
}
