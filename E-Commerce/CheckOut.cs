using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce
{
    internal class CheckOut
    {
        public double OrderSubTotal(Cart cart , Customer customer)
        {
            Console.WriteLine($"** Checkout receipt **");
            double total = 0;
            foreach(var order in cart.Orders)
            {
                    total += order.Price * order.Quantity;
                Console.WriteLine($"{order.Quantity}x {order.Name} {order.Price * order.Quantity}");
            }
            return total;
        }
        public double GetShippingFees(Cart cart , Customer customer)
        {
            List<Product> shippableProducts = new List<Product>();
            double total = 0;
            foreach (var order in cart.Orders)
            {
                if (order.Behaviors.ContainsKey(2)) // Assuming 2 is the ID for ShippableProduct
                {
                    var shippable = order.Behaviors[2] as ShippableProduct;
                    if (shippable != null)
                    {
                        total += shippable.ShippingFees * order.Quantity;
                    }
                }
            }
            return total;
        }
        public double SendToShippingService(Cart cart, Customer customer)
        {
            List<Product> shippableProducts = new List<Product>();
            double totalWeight = 0;
            foreach (var order in cart.Orders)
            {
                if (order.Behaviors.ContainsKey(2)) // Assuming 2 is the ID for ShippableProduct
                {
                    var shippable = order.Behaviors[2] as ShippableProduct;
                    if (shippable != null)
                    {
                        totalWeight += shippable.Weight * order.Quantity;
                        Console.WriteLine($"{order.Quantity}x {order.Name} {shippable.Weight * order.Quantity}g");
                        shippableProducts.Add(order);
                    }
                }
            }
            ShippingService.AddToService(shippableProducts);
            return totalWeight;
        }

        public void Checkout(Cart cart, Customer customer)
        {
            if (cart.Orders.Count == 0)
            {
                throw new Exception("Your cart is empty.");
            }
            Console.WriteLine("** Shipment notice **");
            double totalWeight = SendToShippingService(cart, customer);
            Console.WriteLine($"Total package weight : {totalWeight}g");
            double subTotal = OrderSubTotal(cart, customer);
            double shippingFees = GetShippingFees(cart, customer);
            double totalOrder = subTotal + shippingFees;

            if (customer.Balance < totalOrder)
            {
                throw new Exception("Your balance isn't enough.");
            }
            Console.WriteLine("----------------------------");
            Console.WriteLine($"subtotal :         {subTotal}");
            Console.WriteLine($"shipping :         {shippingFees}");
            Console.WriteLine($"Amount :            {totalOrder}");
            customer.Balance -= totalOrder;
        }

    }
}
