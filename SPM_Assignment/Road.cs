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
        public override int GenerateCoins(Building adjacentBuilding)
        {
            return 0; 
        }

        public override int calculateUpkeepCost(Building adjacentBuilding)
        {
            return 0; 
        }

        public override int ProvidePoints(Building adjacentBuilding)
        {
            if (adjacentBuilding is Road)
                return 1;
            return 0;
        }
    }
}
