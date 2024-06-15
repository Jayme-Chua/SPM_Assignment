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
        public override int GenerateCoins()
        {
            return 0; 
        }

        public override int calculateUpkeepCost()
        {
            return 1; 
        }

        public override int CalculateScore()
        {
            return 5; 
        }
    }
}
