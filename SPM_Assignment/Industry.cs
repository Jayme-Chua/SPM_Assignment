using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPM_Assignment
{
    internal class Industry : Building
    {
        public Industry() { }

        public override string ToString()
        {
            return "I";
        }
        public override int GenerateCoins()
        {
            return 5; 
        }

        public override int calculateUpkeepCost()
        {
            return 3;
        }

        public override int ProvidePoints()
        {
            return 20; 
        }
    }
}
