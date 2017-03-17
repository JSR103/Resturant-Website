using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Models
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        public virtual void AddItem(Menu1 product, int quantity)
        {
            CartLine line = lineCollection
                .Where(p => p.Food.Menu1ID == product.Menu1ID)
                .FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new CartLine
                {
                    Food = product,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public virtual void RemoveLine(Menu1 product) =>
            lineCollection.RemoveAll(l => l.Food.Menu1ID == product.Menu1ID);

        public virtual decimal ComputeTotalValue() =>
            lineCollection.Sum(e => e.Food.Price1 * e.Quantity);

        public virtual void Clear() => lineCollection.Clear();

        public virtual IEnumerable<CartLine> Lines => lineCollection;
    }

    public class CartLine
    {
        public int CartLineID { get; set; }
        public Menu1 Food { get; set; }
        public int Quantity { get; set; }
    }
}

