using System;
using Todox.Store;

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
                    Add();
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

        protected static void Add()
        {
            var title = GetTitle();
            var priority = GetPriority();

            var todo = new Todo
            {
                Title = title,
                Priority = priority,
                Id = RandomInt(),
                CreatedAt = DateTime.Now
            };

            if (!Storage.Init().Add(todo))
            {
                Console.WriteLine("Todo could not be added.\n");

                Add();
            }

            Console.WriteLine("Todo added successfully.\n");
            Run();
        }

        protected static void DisplayActions()
        {
            Console.WriteLine("Input a number for your preferred action");
            foreach (var (key, value) in Actions)
            {
                Console.WriteLine("{0} - {1}", key, value);
            }
        }

        protected static string GetTitle(int maxLength = 100)
        {
            var title = "";
            while (string.IsNullOrWhiteSpace(title) || title.Length > maxLength)
            {
                Console.Write("Enter title: ");
                title = Console.ReadLine();
            }

            return title;
        }

        protected static string GetPriority()
        {
            Console.Write("Enter priority - low, normal, high: ");
            var priority = Console.ReadLine();

            while (
                !string.IsNullOrWhiteSpace(priority)
                && (
                    priority.ToLower() != "low"
                    && priority.ToUpper() != "normal"
                    && priority.ToLower() != "high"
            ))
            {
                Console.Write("Enter priority - low, normal, high: ");
                priority = Console.ReadLine();
            }

            if (string.IsNullOrWhiteSpace(priority))
            {
                priority = "normal";
            }

            return priority.ToLower();
        }

        protected static int RandomInt(int min = 10000, int max = 99999)
        {
            var random = new Random();

            return random.Next(min, max);
        }
    }
}
