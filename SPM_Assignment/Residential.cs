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
        public override int calculateUpkeepCostFP(Building adjacentBuilding)
        {
            if (adjacentBuilding.North is Residential || adjacentBuilding.South is Residential || adjacentBuilding.East is Residential || adjacentBuilding.West is Residential || adjacentBuilding.NorthEast is Residential || adjacentBuilding.NorthWest is Residential || adjacentBuilding.SouthEast is Residential || adjacentBuilding.SouthWest is Residential)
            {
                Console.WriteLine("(Residential.cs)Residential Check -1 upkeepCost");
                Console.ReadLine();
                return 1;
            }
            return 0;
        }
        public override int GenerateCoinsFP(Building adjacentBuilding)
        {
            return 1;
        }
        //Arcade
        public override int calculateUpkeepCostARC(Building adjacentBuilding)
        {
            return 0;
        }
        public override int GenerateCoinsARC(Building adjacentBuilding)
        {
            return 0;
        }

        public override int ProvidePoints(Building adjacentBuilding)
        {
            int score = 0;
            if (adjacentBuilding is Industry)
            {
                return 1;
            }
            if (adjacentBuilding is Residential)
            {
                score += 1;
            }
            if(adjacentBuilding is Commercial)
            {
                score += 1;
            }
            if(adjacentBuilding is Park)
            {
                score += 2;
            }

            return score;

        }
    }
}

