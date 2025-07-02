using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce;

internal class Product
{
    double price;
    int quantity;
    public readonly Dictionary<int, IBehavorial> Behaviors;
   
    public Product( Dictionary<int, IBehavorial> behaviors)
    { 
        this.Behaviors = behaviors;
    }
    public double Price { get => price; set => price = value > 0 ? value : 0; }
    public string Name { get; set; }
    public int Quantity { get => quantity; set => quantity = value > 0 ? value : 0 ; }


    public void AddBehaviour(IBehavorial behavourial) 
    {
        if(!Behaviors.ContainsKey(behavourial.ID))
           Behaviors.Add(behavourial.ID , behavourial);
    }
    
}
