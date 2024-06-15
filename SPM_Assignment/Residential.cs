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
        public override int GenerateCoins()
        {
            return 1; 
        }

        public override int calculateUpkeepCost()
        {
            return 1; 
        }

        public override int CalculateScore()
        {
            return 10;
        }
    }
}
