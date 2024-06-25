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
        public override int calculateUpkeepCost(Building adjacentBuilding)
        {
            return 1; 
        }
        public override int GenerateCoins(Building adjacentBuilding)
        {
            if (adjacentBuilding is Residential)
            {
                return 1;
            }
            return 0;
        }

        public override int ProvidePoints(Building adjacentBuilding)
        {
            return 1;
        }

    }
}
