using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPM_Assignment
{
    internal abstract class Building
    {
        private Building north;
        public Building North { get; set; }

        private Building south;
        public Building South { get; set; }

        private Building east;
        public Building East { get; set; }

        private Building west;
        public Building West { get; set; }

        private Building northEast;
        public Building NorthEast { get; set; }

        private Building southEast;
        public Building SouthEast { get; set; }

        private Building northWest;
        public Building NorthWest { get; set; }

        private Building southWest;
        public Building SouthWest { get; set; }

        public Building() { }

        public abstract int GenerateCoinsFP(Building adjacentBuilding);


        public abstract int ProvidePoints(Building adjacentBuilding);

        public abstract int calculateUpkeepCostFP(Building adjacentBuilding);

        public abstract int GenerateCoinsARC(Building adjacentBuilding);

        public abstract int calculateUpkeepCostARC(Building adjacentBuilding);

    }
}
