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
            if (adjacentBuilding.North is Residential || adjacentBuilding.South is Residential || adjacentBuilding.East is Residential || adjacentBuilding.West is Residential || adjacentBuilding.NorthEast is Residential || adjacentBuilding.NorthWest is Residential || adjacentBuilding.SouthEast is Residential || adjacentBuilding.SouthWest is Residential)
            {
                Console.WriteLine("(Industry.cs)Residential Check +1 coin");
                Console.ReadLine();
                return 1;
            }
            return 0;
        }

        public override int ProvidePoints(Building adjacentBuilding)
        {
            int score = 0;
            Console.WriteLine("(Industry.cs)Industry Check +1");
            Console.ReadLine();
            score += 1;
            if (adjacentBuilding.North is Residential || adjacentBuilding.South is Residential || adjacentBuilding.East is Residential || adjacentBuilding.West is Residential || adjacentBuilding.NorthEast is Residential || adjacentBuilding.NorthWest is Residential || adjacentBuilding.SouthEast is Residential || adjacentBuilding.SouthWest is Residential)
            {
                Console.WriteLine("(Industry.cs)Residential Check +1");
                Console.ReadLine();
                score += 1;
            }
            Console.WriteLine("(Industry.cs)All Checks Complete");
            Console.ReadLine();
            return score;
        }
    }
}
