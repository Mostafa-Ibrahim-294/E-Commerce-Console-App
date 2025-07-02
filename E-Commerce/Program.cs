
namespace E_Commerce;

class Program
{
    static void Main(string[] args)
    {
        try
        {
         
            Customer customer = new Customer { Name = "Mostafa", Balance = 15000 };

            Cart cart = new Cart();

           
            Console.WriteLine("Available products:");
            foreach (var p in AvailableProducts.Products.Values)
     Console.WriteLine($"- {p.Name} | Price: {p.Price} | Quantity: {p.Quantity}");

            Console.WriteLine("\n----------------------------\n");

            Console.WriteLine("Adding Cheese (valid product) to cart...");
            cart.AddToCart("Cheese", 2);
            Console.WriteLine("Product added successfully.\n");

            Console.WriteLine("Trying to add Yogurt (expired product)...");
            try
            {
                cart.AddToCart("Yogurt", 1);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Expected error: {ex.Message}");
            }

            Console.WriteLine("\n----------------------------\n");

            Console.WriteLine("Adding Laptop to cart...");
            cart.AddToCart("Laptop", 1);
            Console.WriteLine("Product added successfully.\n");

            Console.WriteLine("Adding E-Book (non-shippable) to cart...");
            cart.AddToCart("E-Book", 3);
            Console.WriteLine("Product added successfully.\n");

            Console.WriteLine("\n----------------------------\n");

            Console.WriteLine("Performing checkout...");
            CheckOut checkout = new CheckOut();
            checkout.Checkout(cart, customer);

            Console.WriteLine("\n----------------------------\n");

            Console.WriteLine($"Customer balance after purchase: {customer.Balance:C}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error: {ex.Message}");
        }
    }
}

