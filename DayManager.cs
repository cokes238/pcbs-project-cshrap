using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pcbs_project_c_
{
    public class DayManager
    {
        public int CurrentDay { get; private set; }
        public int TotalDays { get; private set; }
        public int EventCounter { get; set; }

        public DayManager(int totalDays)
        {
            CurrentDay = 1;
            TotalDays = totalDays;
            EventCounter = 0;
        }

        public void NextDay()
        {
            CurrentDay++;
        }

        public void ShowDayHeader(Player player)
        {
            Console.Clear();
            Console.WriteLine($"=== ДЕНЬ {CurrentDay}/{TotalDays} ===");
            Console.WriteLine($" Деньги: ${player.Money}");
            Console.WriteLine($" Детали: {player.Parts}");
            Console.WriteLine($" Репутация: {player.Reputation}%");
            Console.WriteLine();
        }
    }
}