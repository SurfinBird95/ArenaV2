using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaV2
{
    public class RNG
    {
        private int lowerRangeInt {get;set;}

        private int upperRangeInt {get;set;}

        Random random = new Random();


        public int createRandomIntNumber(int lowerRangeInt, int upperRangeInt)
        {
            return random.Next(lowerRangeInt, upperRangeInt);
        }
        
    }
}
