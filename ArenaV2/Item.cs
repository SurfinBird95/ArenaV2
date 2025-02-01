using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ArenaV2
{
    public class Item
    {

        public string Name {get; set;}
        public int Price {get; set;}
        public int Weight {get; set;}

        public Item(string name, int price, int weight)
        {
            Name = name;
            Price = price;
            Weight = weight;
        }

    }
}