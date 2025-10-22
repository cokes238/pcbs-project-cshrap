using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pcbs_project_c_
{
    public class Choice
    {
        public string Description { get; }
        public int PartsChange { get; }
        public int MoneyChange { get; }
        public int ReputationChange { get; }
        public string ResultText { get; }
        

        public Choice(string description, int partsChange, int moneyChange, int reputationChange, string resultText = "")
        {
            Description = description;
            PartsChange = partsChange;
            MoneyChange = moneyChange;
            ReputationChange = reputationChange;
            ResultText = resultText;
            
        }
    }

    public class GameEvent
    {
        public string Description { get; }
        public List<Choice> Choices { get; }

        public GameEvent(string description, List<Choice> choices)
        {
            Description = description;
            Choices = choices;
        }
    }
}
    