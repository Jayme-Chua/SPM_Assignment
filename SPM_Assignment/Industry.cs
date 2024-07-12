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
        public override int calculateUpkeepCostFP(Building adjacentBuilding)
        {
            return 1; 
        }
        public override int GenerateCoinsFP(Building adjacentBuilding)
        {
            return 2;
        }
        //Arcade
        public override int calculateUpkeepCostARC(Building adjacentBuilding)
        {
            return 0;
        }
        public override int GenerateCoinsARC(Building adjacentBuilding)
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
