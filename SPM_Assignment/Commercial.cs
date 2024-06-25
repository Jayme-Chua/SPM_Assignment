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

        public override int calculateUpkeepCost(Building adjacentBuilding)
        {
            return 1; 
        }

        public override int GenerateCoins(Building adjacentBuilding)
        {
            if (adjacentBuilding is Residential)
                return 1;

            return 0;
        }

        public override int ProvidePoints(Building adjacentBuilding)
        {
            if (adjacentBuilding is Commercial)
                return 1;
            if (adjacentBuilding is Residential)
                return 1;
            return 0;
        }
    }
}
