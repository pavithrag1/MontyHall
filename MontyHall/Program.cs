using MontyHall.Library;
using MontyHall.Library.Models;
using System;
using System.Text;

namespace MontyHall
{
    class Program
    {        
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to \"Monty Hall Puzzle!\"");
            int choice = 1;
            do
            {
                switch (choice)
                {
                    case 1: RunPuzzle();
                        break;
                    default: choice = 0;
                        break;
                }
                Console.WriteLine("\nPress 1 to play or any key to Quit");
                int.TryParse(Console.ReadLine(), out choice);                    
            } while (choice == 1);
        }

        private static void RunPuzzle()
        {
            var count = GetSimulationCount();
            bool hasSwitched = CheckForSwitchDoor();
            var montyHallModel = RunMontyHallSimulator(count, hasSwitched);
            var sb = PrintSummary(montyHallModel);
            Console.WriteLine(sb);
            Console.ReadLine();
        }

        private static int GetSimulationCount()
        {
            int count;
            do
            {
                Console.WriteLine("\nEnter the number of Simulations: ");
                var input = Console.ReadLine();
                int.TryParse(input, out count);
                if (count < 1)
                {
                    Console.WriteLine("\nInvalid Input");
                }
            } while (count < 1);
            
            return count;               
        }

        private static bool CheckForSwitchDoor()
        {
            Console.WriteLine("\nSWITCH DOOR? [Y/y] for YES, [Any Key] for NO? ");
            var key = Console.ReadKey(false).Key;
            if (key == ConsoleKey.Y)
                return true;
            else
                return false;
        }

        private static MontyHallModel RunMontyHallSimulator(int count, bool hasSwitched)
        {            
            var simulator = new MontyHallSimulator(count, hasSwitched);
            var model = simulator.SimulateMontyHall();
            return model;
        }

        private static string PrintSummary(MontyHallModel montyHallModel)
        {
            var winPerc = ((float)montyHallModel.Wins / (float)montyHallModel.SimulationCount) * 100;
            var sb = new StringBuilder();
            sb.Append("\n\nPuzzle Summary => ");
            if (montyHallModel.HasSwitched)
                sb.Append("\n\tPlayer opted to SWITCH Door!");
            else
                sb.Append("\n\tPlayer opted to NOT SWITCH Door!");
            sb.Append("\n\tTotal Simulations: " + montyHallModel.SimulationCount);
            sb.Append("\n\tTotal Wins: " + montyHallModel.Wins);
            sb.Append("\n\tWin Percentage: " + winPerc.ToString("0.00") + "%");
            return sb.ToString();
        }
    }
}
