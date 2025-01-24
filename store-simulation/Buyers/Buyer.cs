using Assignment1.Shop;

namespace Assignment1.Buyers
{
    public abstract class Buyer
    {
        protected Card card;
        protected double budget;
        protected List<Wish> wishList;
        protected List<Product> hasBought;

        protected Buyer(Card card, double budget)
        {
            this.card = card;
            this.budget = budget;
            this.wishList = new List<Wish>();
            this.hasBought = new List<Product>();
        }
        public int WishIdx(Product product)
        {
            return wishList.FindIndex(x => x.GetProduct() == product);
        }
        public void AddToWishList(Product product, int count)
        {
            int idx = WishIdx(product);
            if (idx != -1)
            {
                wishList[idx].SetCount(wishList[idx].GetCount() + count);
            }
            else
            {
                Wish newWish = new Wish(product, count);
                wishList.Add(newWish);
            }
        }

        public Card GetCard() { return card; }

        public double GetBudget() { return budget; }

        public List<Product> GetBought() { return hasBought; }

        public bool CanAfford(double price, int count)
        {
            price *= count;
            if (budget >= price) { return true; }
            else { return false; }
        }

        public bool Inquire(Store store, Wish wish)
        {
            return store.HasProduct(wish.GetProduct(), wish.GetCount());
        }

        public Wish? FindWish(Product product)
        {
            int idx = WishIdx(product);
            if (idx != -1)
            {
                return wishList[idx];
            }
            else { return null; }
        }

        public void SellTo(Product product, int count, double price)
        {
            Wish? wish = FindWish(product);
            if (wish != null)
            {
                if (wish.GetCount() < count) { return; }
                if (wish.Update(count))
                {
                    wishList.Remove(wish);
                }
                budget -= price * count;
                while (count > 0)
                {
                    hasBought.Add(product);
                    count--;
                }
            }
        }

        public abstract void VisitStores(List<Store> stores);
    }
}
