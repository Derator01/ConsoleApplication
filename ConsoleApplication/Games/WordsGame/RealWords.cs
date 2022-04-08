namespace Games.Words
{
    internal sealed class RealWords
    {
        private static readonly Random rnd = new();

        public static void StartRealWordsGame()
        {
            if (!WordsHold.InitHold())
            {
                Console.WriteLine("Go To Hell! There is non such file!");
                return;
            }
            while (true)
            {
                bool keepPicking = true;

                string word = "";
                while (keepPicking)
                {
                    word = WordsHold.words[rnd.Next(WordsHold.words.Count)];
                    if (word.Length > 2)
                    {
                        keepPicking = false;
                    }
                }

                int firstLetter = rnd.Next(word.Length - 2);
                Console.WriteLine(new string(new char[] { word[firstLetter], word[firstLetter + 1], word[firstLetter + 2] }));

                if (WordsHold.words.Contains(Console.ReadLine().ToLower()))
                {
                    Console.WriteLine("You're right!");
                }
                else
                {
                    Console.WriteLine("You're wrong!");
                }
            }
        }
    }
}
