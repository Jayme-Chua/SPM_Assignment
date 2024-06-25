using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPM_Assignment
{
    internal class Residential : Building
    {
        public Residential() { }

        public override string ToString()
        {
            return "R";
        }
        public override int calculateUpkeepCost(Building adjacentBuilding)
        {
            if (adjacentBuilding is Residential)
            {
                return 1;
            }
            return 0;
        }
        public override int GenerateCoins(Building adjacentBuilding)
        {
            return 1;
        }

        public override int ProvidePoints(Building adjacentBuilding)
        {
            if (adjacentBuilding is Residential)
                return 1;
            if (adjacentBuilding is Commercial)
                return 1;
            if (adjacentBuilding is Park)
                return 2;
            if (adjacentBuilding is Industry)
                return 1;
            return 0;
        }
    }
}

