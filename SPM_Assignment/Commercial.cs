using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPM_Assignment
{
    internal class Commercial : Building
    {
        public Commercial() { }

        public override string ToString()
        {
            return "C";
        }
        public override int GenerateCoins()
        {
            return 3; 
        }

        public override int calculateUpkeepCost()
        {
            return 2; 
        }

        public override int ProvidePoints()
        {
            return 15;
        }
    }
}
}
