using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce
{
    internal class Cart
    {
        private List<Product> orders;
        public Cart()
        {
            Orders = new List<Product>();
        }

        internal List<Product> Orders { get => orders; set => orders = value; }

        public void AddToCart(string name , int quantity)
        {
            if ( name == null || string.IsNullOrEmpty(name))
                throw new ArgumentException("Product cannot be null or have an empty name.");
            Product product = AvailableProducts.IsFound(name);
            if (quantity <= 0 || product == null)
                throw new ArgumentException("NOT Available Today");
            if (product.Behaviors.ContainsKey(1))
            {
                var behavior = product.Behaviors[1] as ExpiredProduct;
                if (behavior != null && behavior.Expired < DateTime.Now)
                    throw new Exception("This product is expired and cannot be purchased.");

            }
            Orders.Add(new Product(product.Behaviors) { Name = name ,Price = product.Price
                , Quantity = quantity
            });
            AvailableProducts.Products[product.Name].Quantity -= product.Quantity;
        }
    }
}
