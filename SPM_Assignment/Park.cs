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
            int score = 0;
            if (adjacentBuilding is Park)
            {
                score+= 1;
            }
            if (adjacentBuilding is Residential)
            {
                score += 2;
            }
            return score;
        }
    }
}
