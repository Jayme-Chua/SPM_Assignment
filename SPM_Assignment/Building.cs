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

        public Building() { }

        public abstract int GenerateCoins(Building adjacentBuilding);


        public abstract int ProvidePoints(Building adjacentBuilding);

        public abstract int calculateUpkeepCost(Building adjacentBuilding);

    }
}
