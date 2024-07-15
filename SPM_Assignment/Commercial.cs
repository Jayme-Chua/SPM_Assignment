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
            if (adjacentBuilding.North is Residential || adjacentBuilding.South is Residential || adjacentBuilding.East is Residential || adjacentBuilding.West is Residential || adjacentBuilding.NorthEast is Residential || adjacentBuilding.NorthWest is Residential || adjacentBuilding.SouthEast is Residential || adjacentBuilding.SouthWest is Residential)
            {
                Console.WriteLine("(Commercial.cs) Residential Check +1 coin");
                Console.ReadLine();
                return 1;
            }
            return 0;
        }

        public override int ProvidePoints(Building adjacentBuilding)
        {
            if (adjacentBuilding.North is Commercial || adjacentBuilding.South is Commercial || adjacentBuilding.East is Commercial || adjacentBuilding.West is Commercial || adjacentBuilding.NorthEast is Commercial || adjacentBuilding.NorthWest is Commercial || adjacentBuilding.SouthEast is Commercial || adjacentBuilding.SouthWest is Commercial)
            {
                Console.WriteLine("(Commercial.cs)Commercial Check +1");
                Console.ReadLine();
                Console.WriteLine("(Commercial.cs)All Checks Complete");
                Console.ReadLine();
                return 1;
            }
            return 0;
        }
    }
}
