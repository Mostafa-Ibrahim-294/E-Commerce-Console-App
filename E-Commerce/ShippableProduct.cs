using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace E_Commerce;

internal class ShippableProduct : IBehavorial
{
    public int ID => 2;
    public int ShippingFees { get; set; }
    public double Weight { get; set; }
}
