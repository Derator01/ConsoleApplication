namespace Games.Words
{
    internal sealed class WordsHold
    {
        private static bool _initialized = false;

        private readonly Random rnd = new();
        internal static List<string> words = new();

        private static readonly string _path = "RusDictionary.txt";

        internal static bool InitHold()
        {
            try
            {
                words = new List<string>(File.ReadAllLines(_path));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            _initialized = true;
            return true;
        }

        internal WordsHold()
        {
            InitHold();
        }

        internal string GetRandomWord()
        {
            if (!_initialized)
                return null;
            return words[rnd.Next(words.Count)];
        }

        internal bool CheckStr(string str)
        {
            if (!_initialized)
                return false;
            return words.Contains(str);
        }
    }
}
