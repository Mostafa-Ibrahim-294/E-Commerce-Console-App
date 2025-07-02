using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce;

internal class ExpiredProduct :IBehavorial
{
    public int ID => 1;
     public DateTime Expired { get; set; }
    public ExpiredProduct(DateTime expired)
    {
        if (expired < DateTime.Now)
            throw new ArgumentException("Expiration date cannot be in the past.");
        Expired = expired;   
    }
    public ExpiredProduct()
    {
        
    }
}
