using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPM_Assignment
{
    internal class Park : Building
    {
        public Park() { }

        public override string ToString()
        {
            return "O";
        }
        public override int GenerateCoinsFP(Building adjacentBuilding)
        {
            return 0; 
        }

        public override int calculateUpkeepCostFP(Building adjacentBuilding)
        {
            return 1; 
        }
        //Arcade
        public override int GenerateCoinsARC(Building adjacentBuilding)
        {
            return 0;
        }

        public override int calculateUpkeepCostARC(Building adjacentBuilding)
        {
            return 0;
        }

        public override int ProvidePoints(Building adjacentBuilding)
        {
            if (adjacentBuilding is Park)
                return 1;
            return 0;
        }
    }
}
