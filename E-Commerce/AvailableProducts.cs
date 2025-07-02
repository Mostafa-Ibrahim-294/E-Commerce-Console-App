using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce
{
    internal static class AvailableProducts
    {
        private readonly static Dictionary<string , Product> products
            = new Dictionary<string, Product>();

        internal static Dictionary<string, Product> Products => products;

        static AvailableProducts()
        {
            products = new Dictionary<string, Product>();

            AddProduct(new Product(new Dictionary<int, IBehavorial>
    {
        {1, new ExpiredProduct(DateTime.Now.AddDays(5))},
        {2, new ShippableProduct {Weight = 0.3, ShippingFees = 10}}
    })
            {
                Name = "Milk",
                Price = 20,
                Quantity = 50
            });

            AddProduct(new Product(new Dictionary<int, IBehavorial>
    {
        {2, new ShippableProduct {Weight = 1.2, ShippingFees = 25}}
    })
            {
                Name = "Laptop",
                Price = 12000,
                Quantity = 15
            });

            AddProduct(new Product(new Dictionary<int, IBehavorial>
    {
        {1, new ExpiredProduct(DateTime.Now.AddDays(7))} // منتهي بالفعل
    })
            {
                Name = "Yogurt",
                Price = 8,
                Quantity = 30
            });

            AddProduct(new Product(new Dictionary<int, IBehavorial>())
            {
                Name = "E-Book",
                Price = 150,
                Quantity = 100
            });

            AddProduct(new Product(new Dictionary<int, IBehavorial>
    {
        {2, new ShippableProduct {Weight = 5.5, ShippingFees = 75}}
    })
            {
                Name = "Washing Machine",
                Price = 8000,
                Quantity = 7
            });

            AddProduct(new Product(new Dictionary<int, IBehavorial>())
            {
                Name = "Mobile Recharge Card",
                Price = 50,
                Quantity = 500
            });

            AddProduct(new Product(new Dictionary<int, IBehavorial>
    {
        {1, new ExpiredProduct(DateTime.Now.AddDays(60))},
        {2, new ShippableProduct {Weight = 0.7, ShippingFees = 15}}
    })
            {
                Name = "Cheese",
                Price = 100,
                Quantity = 100
            });

            AddProduct(new Product(new Dictionary<int, IBehavorial>
    {
        {2, new ShippableProduct {Weight = 0.05, ShippingFees = 5}}
    })
            {
                Name = "USB Cable",
                Price = 25,
                Quantity = 200
            }); 
        }
        public static void AddProduct(Product product)
        {
            if (product == null || string.IsNullOrEmpty(product.Name))
                throw new ArgumentException("Product cannot be null or have an empty name.");
            if (Products.ContainsKey(product.Name))
                throw new ArgumentException("Product with the same name already exists.");
            Products[product.Name] = product;
        }
        public static void DeleteProduct(string name)
        {
            if (name != null && Products.ContainsKey(name))
            {
            Products.Remove(name);
            }
        }
        static void UpdateOptions(string name)
        {
            Console.WriteLine($"enter number to update product options:\n" +
                                  "1. Update Price\n" +
                                  "2. Update Quantity\n" +
                                  "3. Update Behaviours");
            int.TryParse(Console.ReadLine(), out int choice);
            switch (choice)
            {
                case 1:
                    double.TryParse(Console.ReadLine(), out var price);
                    Products[name].Price = price;
                    break;
                case 2:
                    int.TryParse(Console.ReadLine(), out var quantity);
                    Products[name].Quantity = quantity;
                    break;
                case 3:
                    Console.WriteLine("Enter new behaviours (1 for Expired , 2 for Shippable):");
                    int.TryParse(Console.ReadLine(), out int behaviorChoice);
                    switch (behaviorChoice)
                    {
                        case 1:
                            Products[name].AddBehaviour(new ExpiredProduct());
                            break;
                        case 2:
                            Products[name].AddBehaviour(new ShippableProduct());
                            break;
                        default:
                            Console.WriteLine("Invalid choice.");
                            break;
                    }
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
            }
        public static void UpdateProduct(string name)
        {
            if (name != null && Products.ContainsKey(name))
            {
                UpdateOptions(name);
            }
        }
        public static Product IsFound(string name)
        {
           return Products.ContainsKey(name) ? Products[name] : null ;
        }




    }
}
