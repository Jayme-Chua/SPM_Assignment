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
            if (adjacentBuilding.North is Industry || adjacentBuilding.South is Industry || adjacentBuilding.East is Industry || adjacentBuilding.West is Industry || adjacentBuilding.NorthEast is Industry || adjacentBuilding.NorthWest is Industry || adjacentBuilding.SouthEast is Industry || adjacentBuilding.SouthWest is Industry)
            {
                Console.WriteLine("(Residential.cs)Industry Check +1");
                Console.ReadLine();
                Console.WriteLine("(Residential.cs)All Checks Complete");
                Console.ReadLine();
                return 1;
            }
            if (adjacentBuilding.North is Residential || adjacentBuilding.South is Residential || adjacentBuilding.East is Residential || adjacentBuilding.West is Residential || adjacentBuilding.NorthEast is Residential || adjacentBuilding.NorthWest is Residential || adjacentBuilding.SouthEast is Residential || adjacentBuilding.SouthWest is Residential)
            {
                Console.WriteLine("(Residential.cs)Residential Check +1");
                Console.ReadLine();
                score += 1;
            }
            if(adjacentBuilding.North is Commercial || adjacentBuilding.South is Commercial || adjacentBuilding.East is Commercial || adjacentBuilding.West is Commercial || adjacentBuilding.NorthEast is Commercial || adjacentBuilding.NorthWest is Commercial || adjacentBuilding.SouthEast is Commercial || adjacentBuilding.SouthWest is Commercial)
            {
                Console.WriteLine("(Residential.cs)Commercial Check +1");
                Console.ReadLine();
                score += 1;
            }
            if(adjacentBuilding.North is Park || adjacentBuilding.South is Park || adjacentBuilding.East is Park || adjacentBuilding.West is Park || adjacentBuilding.NorthEast is Park || adjacentBuilding.NorthWest is Park || adjacentBuilding.SouthEast is Park || adjacentBuilding.SouthWest is Park)
            {
                Console.WriteLine("(Residential.cs)Park Check +2");
                Console.ReadLine();
                score += 2;
            }
            Console.WriteLine("(Residential.cs)All Checks Complete");
            Console.ReadLine();
            return score;

            // Define a list of adjacent buildings to iterate over
            //var adjacentBuildings = new List<Building> { adjacentBuilding.North, adjacentBuilding.South, adjacentBuilding.East, adjacentBuilding.West };
            //int score = 0;

            // Iterate over each adjacent building
            //foreach (var building in adjacentBuildings)
            //{
            //    if (building != null)
            //    {
            //        if (building is Industry)
            //        {
            //            Console.WriteLine("Industry Check +1");
            //            Console.ReadLine();
            //            return 1;
            //        }

            //        else if (building is Residential)
            //        {
            //            Console.WriteLine("Residential Check +1");
            //            Console.ReadLine();
            //            score += 1;
            //        }
            //        else if (building is Commercial)
            //        {
            //            Console.WriteLine("Commercial Check +1");
            //            Console.ReadLine();
            //            score += 1;
            //        }
            //        else if (building is Park)
            //        {
            //            Console.WriteLine("park Check +1");
            //            Console.ReadLine();
            //            score += 2;
            //        }
            //    }
            //}
            //return score;

        }
    }
}

