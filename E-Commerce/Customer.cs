using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce
{
    internal class Customer
    {
        double balance;
        public Customer() { }
        public string Name { get; set; }
        public double Balance { get => balance; set => balance = value > 0 ? value : 0 ; }

    }
}
