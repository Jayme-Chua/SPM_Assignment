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
            if (adjacentBuilding.North is Park || adjacentBuilding.South is Park || adjacentBuilding.East is Park || adjacentBuilding.West is Park || adjacentBuilding.NorthEast is Park || adjacentBuilding.NorthWest is Park || adjacentBuilding.SouthEast is Park || adjacentBuilding.SouthWest is Park)
            {
                Console.WriteLine("(Park.cs) Park Check +1");
                Console.ReadLine();
                score+= 1;
            }
            if (adjacentBuilding.North is Residential || adjacentBuilding.South is Residential || adjacentBuilding.East is Residential || adjacentBuilding.West is Residential || adjacentBuilding.NorthEast is Residential || adjacentBuilding.NorthWest is Residential || adjacentBuilding.SouthEast is Residential || adjacentBuilding.SouthWest is Residential)
            {
                Console.WriteLine("(Park.cs)Residential Check +2");
                Console.ReadLine();
                score += 2;
            }
            Console.WriteLine("(Park.cs)All Checks Complete");
            Console.ReadLine();
            return score;
        }
    }
}
