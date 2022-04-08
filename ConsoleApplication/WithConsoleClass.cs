using System.Runtime.InteropServices;

namespace ConsoleApplication
{
    using ConsoleManipulations;
    internal sealed partial class ConsoleRouter
    {
        static readonly List<string> _routes = new() { "Notation Converter", "Setuper", "Games" };

        static readonly List<string> _games = new() { "Words" };

        internal static void StartWithConsole()
        {
            AllocConsole();
            Console.Title = _kLINInstanse.GetValue("ConsoleTitle", "NotSuspitiousProgram");
            Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), _kLINInstanse.GetValue("ConsoleForeColor", "10"));

            string error = _kLINInstanse.GetValue("Error", "null");

            if (error != "null")
            {
                Console.WriteLine(error);
                _kLINInstanse.ChangeValue("Error", "null");
            }
            while (true)
            {
                int counter = 0;
                foreach (var route in _routes)
                {
                    Console.WriteLine($"{route} - {counter}");
                    counter++;
                }

                int choice = ConsoleInput.ConsoleIntInput();

                switch (choice)
                {
                    case 0:
                        {
                            NotationConverter.Functions.ConsoleConvertion();
                        }
                        break;
                    case 1:
                        {
                            SuperSetuper.Setuper.Configure();

                            Console.WriteLine("Do you want to disable console?");

                            if (Console.ReadLine() == "+")
                                _kLINInstanse.ChangeValue(lunchConfigName, "false");

                            Console.WriteLine("Be aware that there must be a \"SourceFolder\"\n");
                        }
                        break;
                    case 2:
                        {
                            counter = 0;
                            foreach (var game in _games)
                            {
                                Console.WriteLine($"{game} - {counter}");
                                counter++;
                            }

                            choice = ConsoleInput.ConsoleIntInput();

                            switch (choice)
                            {
                                case 0:
                                    {
                                        Games.Words.RealWords.StartRealWordsGame();
                                    }
                                    break;
                                default:
                                    {
                                        Console.WriteLine("There is no such game");
                                    }
                                    break;
                            }
                        }
                        break;
                    default:
                        {
                            Console.WriteLine("There is no such method");
                        }
                        break;
                }
            }
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();
    }
}
