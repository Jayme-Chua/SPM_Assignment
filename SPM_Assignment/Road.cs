using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPM_Assignment
{
    internal class Road : Building
    {
        public Road() { }

        public override string ToString()
        {
            return "*";
        }
        public override int GenerateCoins()
        {
            return 0; 
        }

        public override int calculateUpkeepCost()
        {
            return 0; 
        }

        public override int ProvidePoints()
        {
            return 0; 
        }
    }
}
