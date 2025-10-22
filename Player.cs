using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pcbs_project_c_
{
    public class Player
    {
        public int Money { get; private set; }
        public int Parts { get; private set; }
        public int Reputation { get; private set; }

        public Player(int startMoney, int startParts, int startReputation)
        {
            Money = startMoney;
            Parts = startParts;
            Reputation = startReputation;
        }

        public void ApplyChoice(int partsChange, int moneyChange, int reputationChange)
        {
            Parts += partsChange;
            Money += moneyChange;
            Reputation += reputationChange;

            if (Reputation < 0) Reputation = 0;
            

        }

        public bool CanAfford(int partsCost, int moneyCost)
        {
            return Parts >= partsCost && Money >= moneyCost;
        }
    }
}