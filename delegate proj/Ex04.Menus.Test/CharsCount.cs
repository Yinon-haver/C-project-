using System;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class CharsCount : IDoAction
    {
        public static void CountChars()
        {
            Console.Clear();
            Console.WriteLine("Please enter a sentence that you wish to get the number of chars that it's composed of");
            string sentenceToCount = Console.ReadLine();
            int counter = 0;
            for (int i = 0; i < sentenceToCount.Length; i++)
            {
                if (char.IsLetter(sentenceToCount[i]))
                {
                    counter++;
                }
            }

            Console.WriteLine(string.Format("There are {0} letters in the given sentence", counter));
            Console.ReadLine();
        }

        public void RunWhenActivated()
        {
            CountChars();
        }
    }
}
