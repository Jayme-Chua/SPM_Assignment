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

        public override int calculateUpkeepCostFP(Building adjacentBuilding)
        {
            return 2; 
        }

        public override int GenerateCoinsFP(Building adjacentBuilding)
        {
            return 3;
        }
        //Arcade
        public override int calculateUpkeepCostARC(Building adjacentBuilding)
        {
            return 0;
        }

        public override int GenerateCoinsARC(Building adjacentBuilding)
        {
            if (adjacentBuilding is Residential)
                return 1;
            return 0;
        }

        public override int ProvidePoints(Building adjacentBuilding)
        {
            if (adjacentBuilding is Commercial)
                return 1;
            return 0;
        }
    }
}
