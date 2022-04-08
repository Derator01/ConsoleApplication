using System.Text;

namespace NotationConverter
{
    public static class Functions
    {
        public static void ConsoleConvertion()
        {
            Console.WriteLine("Choose convert to or from");

            if (Console.ReadLine().ToLower() == "to")
            {
               Console.WriteLine(ConsoleConvertToNotation());
                return;
            }
            else
            {
               Console.WriteLine(ConsoleConvertFromTotation());
                return;
            }
        }

        public static int ConsoleConvertToNotation()
        {
            bool isInputValid = false;
            int number = 0;
            int baseN = 0;
            while (!isInputValid)
            {
                try
                {
                    Console.WriteLine("Enter value and desired notation");

                    number = int.Parse(Console.ReadLine());
                    baseN = int.Parse(Console.ReadLine());
                    isInputValid = true;
                }
                catch
                {
                    Console.WriteLine("Wrong Nuber!");
                    isInputValid = false;
                }
            }
            if (number == 0)
                return 0;
            if (baseN < 2)
                return 0;

            StringBuilder Sb = new();
            bool signed = false;

            if (number < 0)
            {
                signed = true;
                number = -number;
            }

            while (number > 0)
            {
                Sb.Insert(0, number % baseN);
                number /= baseN;
            }

            if (signed)
                Sb.Insert(0, '-');

            return int.Parse(Sb.ToString());
        }

        public static int ConsoleConvertFromTotation()
        {
            bool isInputValid = false;

            int number = 0, baseN = 0;

            while (!isInputValid)
            {
                try
                {
                    Console.WriteLine("Enter value and it's notation");

                    number = int.Parse(Console.ReadLine());
                    baseN = int.Parse(Console.ReadLine());
                    isInputValid = true;
                }
                catch
                {
                    Console.WriteLine("Wrong Nuber!");
                    isInputValid = false;
                }
            }
            if (number == 0)
                return 0;
            if (baseN < 2)
                return 0;

            int output = 0, remainder, i = 0;

            while (number != 0)
            {
                remainder = number % 10;
                number /= 10;

                // Computing the decimal digit
                output += remainder *
                                 (int)Math.Pow(baseN, i);
                ++i;
            }
            return output;
        }
    }
}
