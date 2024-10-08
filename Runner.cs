using System;

namespace Todox
{
    public class Runner
    {
        protected static Dictionary<string, string> Actions = new Dictionary<string, string> {
            {"1", "All" },
            {"2", "Add" },
            {"3", "Find" },
            {"4", "Update" },
            {"5", "Remove" },
            {"6", "Exit" }
        };


        public static void Run()
        {
            DisplayActions();
            Console.WriteLine("\n");
            Console.Write("Enter a number: ");

            var action = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(action))
            {
                Console.WriteLine("Please enter a number");
                Run();
            }

            if (!Actions.Keys.Contains(action))
            {
                Console.WriteLine("Please enter a valid number");
                Run();
            }

            switch(action)
            {
                case "1":
                    break;
                case "2":
                    break;
                case "3":
                    break;
                case "4":
                    break;
                case "5":
                    break;
                case "6":
                    break;
                default:
                    Run();
                    break;
            }
        }

        protected static void DisplayActions()
        {
            Console.WriteLine("Input a number for your preferred action");
            foreach (var (key, value) in Actions)
            {
                Console.WriteLine("{0} - {1}", key, value);
            }
        }
    }
}
