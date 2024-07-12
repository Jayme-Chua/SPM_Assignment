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
            if (adjacentBuilding is Residential)
            {
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
            // Define a list of adjacent buildings to iterate over
            var adjacentBuildings = new List<Building> { adjacentBuilding.North, adjacentBuilding.South, adjacentBuilding.East, adjacentBuilding.West };
            int score = 0;

            // Iterate over each adjacent building
            foreach (var building in adjacentBuildings)
            {
                if (building != null)
                {
                    if (building is Industry)
                    {
                        Console.WriteLine("Industry Check +1");
                        Console.ReadLine();
                        return 1;
                    }

                    else if (building is Residential)
                    {
                        Console.WriteLine("Residen Check +1");
                        Console.ReadLine();
                        score += 1;
                    }
                    else if (building is Commercial)
                    {
                        Console.WriteLine("Commercial Check +1");
                        Console.ReadLine();
                        score += 1;
                    }
                    else if (building is Park)
                    {
                        Console.WriteLine("park Check +1");
                        Console.ReadLine();
                        score += 2;
                    }
                }
            }
            return score;

        }
    }
}

