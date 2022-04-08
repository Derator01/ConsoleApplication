using ConsoleApplication.ConsoleManipulations;
using KLIN;

namespace SuperSetuper
{
    internal static class Setuper
    {
        private static readonly string[] _destPathsVariants = new string[] { @"C:\temp", @"C:\Users\Public", @"C:\Users\User\Desktop" };

        private static readonly string _sourcePath = @".\SourceFolder";

        private static KLINInstanse _kLINInstanse = new();

        private static readonly string _configDestPathName = "DestPath";

        internal static void Configure()
        {
            Console.WriteLine("Do you want to write full destination path yourself?\n");

            if (Console.ReadLine() == "+")
            {
                Console.WriteLine("Please Enter");
                _kLINInstanse.ChangeValue(_configDestPathName, Console.ReadLine());
            }
            else
            {
                Console.WriteLine("Please Choose");
                int counter = 0;
                foreach (string path in _destPathsVariants)
                {
                    Console.WriteLine($"{path} - {counter}");
                    counter++;
                }

                int choice = ConsoleInput.ConsoleIntInput();

                _kLINInstanse.ChangeValue(_configDestPathName, _destPathsVariants[choice]);
            }

            Console.WriteLine("Do you want to enable setup?");

            if (Console.ReadLine() == "+")
            {
                _kLINInstanse.ChangeValue("Setup?", "true");
            }
            else
            {
                _kLINInstanse.ChangeValue("Setup?", "false");
            }
        }

        static internal void LunchSetup()
        {
            if (_kLINInstanse.GetValue("Setup?", "false") != "true")
                return;

            string destPath = _kLINInstanse.GetValue(_configDestPathName, "NaV");

            if (destPath == "NaV")
                return;

            CopyDirectory(_sourcePath, destPath, true);

            _kLINInstanse.ChangeValue("launchWithConsole", "true");
        }


        static void CopyDirectory(string sourceDir, string destinationDir, bool recursive)
        {
            var dir = new DirectoryInfo(sourceDir);

            if (!dir.Exists)
            {
                _kLINInstanse.ChangeValue("Error", "ThereisnoSourseFolder");
            }
            DirectoryInfo[] dirs = new DirectoryInfo[] { };
            try
            {
                dirs = dir.GetDirectories();
            }
            catch
            {
                _kLINInstanse.ChangeValue("Error", "ThereisnoSourseFolder");
                return;
            }

            Directory.CreateDirectory(destinationDir);

            foreach (FileInfo file in dir.GetFiles())
            {
                string targetFilePath = Path.Combine(destinationDir, file.Name);
                file.CopyTo(targetFilePath);
            }

            if (recursive)
            {
                foreach (DirectoryInfo subDir in dirs)
                {
                    string newDestinationDir = Path.Combine(destinationDir, subDir.Name);
                    CopyDirectory(subDir.FullName, newDestinationDir, true);
                }
            }
        }
    }
}
