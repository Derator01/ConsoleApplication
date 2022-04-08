using KLIN;

namespace ConsoleApplication
{
    internal sealed partial class ConsoleRouter
    {
        static string lunchConfigName = "launchWithConsole";

        static KLINInstanse _kLINInstanse = new();

        private static void Main()
        {
            if (_kLINInstanse.GetValue(lunchConfigName, "true") == "false")
            {
                
                if (_kLINInstanse.GetValue("Setup?", "false")!="true")
                {
                    _kLINInstanse.ChangeValue(lunchConfigName, "true");
                
                    SuperSetuper.Setuper.LunchSetup();
                }

            }
            else
            {
                StartWithConsole();
            }
            Environment.Exit(0);
        }
    }
}
