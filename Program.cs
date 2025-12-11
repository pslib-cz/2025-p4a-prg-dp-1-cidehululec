using Command_TaskManager.Commands;

namespace Command_TaskManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<TaskItem> tasks = new List<TaskItem>();
            CommandManager manager = new CommandManager();

            Console.WriteLine("Náš nádherný a okouzlující todo list");
            PrintHelp();

            while (true)
            {
                Console.Write("\n(config)# ");
                string input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input)) continue;

                string[] parts = input.Split(' ', 2); 
                string action = parts[0].ToLower();
                string argument = parts.Length > 1 ? parts[1] : "";

                if (action == "exit") break;

                try
                {
                    switch (action)
                    {
                        case "add":
                            if (string.IsNullOrWhiteSpace(argument))
                            {
                                Console.WriteLine("Chyba: Zadejte text úkolu.");
                                break;
                            }
                            manager.ExecuteCommand(new AddCommand(tasks, argument));
                            break;

                        case "rm":
                            if (int.TryParse(argument, out int rmIndex))
                            {
                                manager.ExecuteCommand(new RemoveCommand(tasks, rmIndex - 1));
                            }
                            else Console.WriteLine("Chyba: Zadejte číslo úkolu.");
                            break;

                        case "done":
                            if (int.TryParse(argument, out int doneIndex))
                            {
                                manager.ExecuteCommand(new ToggleCommand(tasks, doneIndex - 1));
                            }
                            else Console.WriteLine("Chyba: Zadejte číslo úkolu.");
                            break;

                        case "undo":
                            manager.UndoLast();
                            break;

                        case "list":
                            PrintTasks(tasks);
                            break;

                        case "help":
                            PrintHelp();
                            break;

                        default:
                            Console.WriteLine("Neznámý příkaz.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Neočekávaná chyba: {ex.Message}");
                }
            }
        }

        static void PrintTasks(List<TaskItem> tasks)
        {
            Console.WriteLine("--- Seznam úkolů ---");
            if (tasks.Count == 0)
            {
                Console.WriteLine("(prázdný)");
                return;
            }

            for (int i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {tasks[i]}");
            }
        }

        static void PrintHelp()
        {
            Console.WriteLine("Příkazy: add <text>, rm <číslo>, done <číslo>, list, undo, exit");
        }
    }
}
