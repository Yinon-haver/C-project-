using System;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class SpacesCount : IDoAction
    {
        public static void CountSpaces()
        {
            Console.Clear();
            Console.WriteLine("Please enter a sentence that you wish to get the number of white spcaes that it's composed of");
            string sentenceToCount = Console.ReadLine();
            int counter = 0;
            for (int i = 0; i < sentenceToCount.Length; i++)
            {
                if (char.IsWhiteSpace(sentenceToCount[i]))
                {
                    counter++;
                }
            }

            Console.WriteLine(string.Format("There are {0} white spaces in the given sentence", counter));
            Console.ReadLine();
        }

        public void RunWhenActivated()
        {
            CountSpaces();
        }
    }
}
