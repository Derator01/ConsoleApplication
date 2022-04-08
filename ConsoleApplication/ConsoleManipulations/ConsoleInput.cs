namespace ConsoleApplication.ConsoleManipulations
{
    internal sealed class ConsoleInput
    { 
        internal static int ConsoleIntInput()
        {
            int output = 0;
            bool keepLooping = true;
            while (keepLooping)
            {
                try
                {
                    output = int.Parse(Console.ReadLine());
                    keepLooping = false;
                }
                catch
                {
                    Console.WriteLine("Wrong input");
                    keepLooping = true;
                }
            }
            return output;
        }
    }
}