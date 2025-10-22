using pcbs_project_c_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace pcbs_project_c_
{
    public class Game
    {
        private Player player;
        private DayManager dayManager;
        private EventManager eventManager;
        private bool gameRunning;

        public Game()
        {
            player = new Player(50, 5, 10);
            dayManager = new DayManager(25);
            eventManager = new EventManager();
            gameRunning = true;
        }

        public void Start()
        {
            ShowTitleScreen();

            while (gameRunning && dayManager.CurrentDay <= dayManager.TotalDays)
            {
                

                dayManager.ShowDayHeader(player);

                if (eventManager.HasMoreEvents())
                {
                    eventManager.ShowCurrentEvent(player);
                    eventManager.MoveToNextEvent();
                }

                Console.WriteLine("\nНажмите Enter для продолжения...");
                Console.ReadLine();
                dayManager.NextDay();
            }

            if (dayManager.CurrentDay > dayManager.TotalDays)
            {
                ShowTimeUpScreen();
            }

            if (CheckLoseCondition())
            {
                ShowGameOver();
            }
            else if (CheckWinCondition())
            {
                ShowWinScreen();
            }
            else
            {
                ShowTimeUpScreen();
            }
        }

        private bool CheckWinCondition()
        {
            return player.Money >= 5000 && player.Reputation >= 150;
        }

        private bool CheckLoseCondition()
        {
            return player.Money <= 0 || player.Parts <= 0 || player.Reputation <= 0;
        }

        private void ShowTitleScreen()
        {
            Console.Clear();
            Console.WriteLine("=== pcbs | git: cokes238 ===");
            Console.WriteLine("\nИспытайте азарт сборки и починки ПК...");
            Console.WriteLine("\nЦель игры: заработать 5000$ и получить 150% репутации");
            Console.WriteLine("\nНе угробьте свой авторитет и не обанкротьтесь!");
            Console.WriteLine($"\nУ вас есть:\nНАЛИЧНЫЕ: ${player.Money}\nЗАПЧАСТИ: {player.Parts}\nРЕПУТАЦИЯ: {player.Reputation}%");
            Console.WriteLine("\nНАЖМИТЕ ENTER ДЛЯ НАЧАЛА...");
            Console.ReadLine();
        }

        
        private void ShowWinScreen()
        {
            Console.WriteLine("\n" + new string('=', 50));
            Console.WriteLine("ПОБЕДА!");
            Console.WriteLine("Вы успешно развили свою мастерскую!");
            Console.WriteLine(new string('=', 50));
            Console.WriteLine($"Деньги: ${player.Money}");
            Console.WriteLine($"Репутация: {player.Reputation}%");
            Console.WriteLine($"Детали: {player.Parts}");
            Console.WriteLine(new string('=', 50));
        }

        private void ShowGameOver()
        {
            Console.WriteLine("\n" + new string('=', 50));
            Console.WriteLine("ИГРА ОКОНЧЕНА");
            Console.WriteLine("Вы не справились с управлением бизнесом");
            Console.WriteLine(new string('=', 50));

            if (player.Money <= 0)
                Console.WriteLine("Причина: банкротство (закончились деньги)");
            if (player.Parts <= 0)
                Console.WriteLine("Причина: нет запчастей для работы");
            if (player.Reputation <= 0)
                Console.WriteLine("Причина: полностью испорченная репутация");

            Console.WriteLine(new string('=', 50));
        }

        private void ShowTimeUpScreen()
        {
            Console.WriteLine("\n" + new string('=', 50));
            Console.WriteLine("25 ДНЕЙ ПРОШЛО");
            Console.WriteLine("К сожалению, вы не достигли поставленных целей");
            Console.WriteLine(new string('=', 50));
            Console.WriteLine($"Требовалось: $5000 и 150% репутации");
            Console.WriteLine($"Ваш результат: ${player.Money} и {player.Reputation}%");

            if (player.Money < 5000)
                Console.WriteLine($"Не хватило денег: ${5000 - player.Money}");
            if (player.Reputation < 150)
                Console.WriteLine($"Не хватило репутации: {150 - player.Reputation}%");

            Console.WriteLine(new string('=', 50));
        }
        
}}