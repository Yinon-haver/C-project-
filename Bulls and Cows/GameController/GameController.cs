namespace B17_Ex02
{
    using System;
    using System.Collections.Generic;

    public static class GameController
    {
        public static byte GetNumberOfGuesses()
        {
            Console.WriteLine("Please choose the number of guesses you would like to get. Choose a number between 4 - 10 included");
            byte o_numberOfGuesses = 0;
            while (o_numberOfGuesses == 0)
            {
                byte.TryParse(Console.ReadLine(), out o_numberOfGuesses);
                if (o_numberOfGuesses < 4 || o_numberOfGuesses > 10)
                {
                    Console.WriteLine("Please choose a number between 4 - 10 included");
                    o_numberOfGuesses = 0;
                }
            }

            return o_numberOfGuesses;
        }

        public static string GetUserGuess()
        {
            Console.WriteLine("Please type your next guess < A B C D > or 'Q' to quit");
            string userGuess = string.Empty;
            while (userGuess.Equals(string.Empty))
            {
                userGuess = Console.ReadLine();
                if (userGuess.Equals("Q"))
                {
                    Console.WriteLine("Thanks for playing! Quitting game");
                    return "QUIT";
                }
                else if (!isValidGuess(userGuess))
                {
                    userGuess = string.Empty;
                }
            }

            return userGuess;
        }

        public static bool PlayAgainQuery()
        {
            string answer = string.Empty;
            Console.WriteLine("Would you like to start a new game? <Y/N>");

            while (answer.Equals(string.Empty))
            {
                answer = Console.ReadLine();
                if (answer.Equals("Y"))
                {
                    Ex02.ConsoleUtils.Screen.Clear();
                    return true;
                }
                else if (answer.Equals("N"))
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Please type Y to Start a new game or N to quit");
                    answer = string.Empty;
                }
            }

            return true;
        }

        private static bool isValidGuess(string i_guess)
        {
            byte guessLength = (byte)i_guess.Length;
            HashSet<char> set = new HashSet<char>();

            // a valid user guess is at the form of <A B C D>, 4 letters and 3 whitespaces
            if (guessLength != 7)
            {
                Console.WriteLine("Please enter a guess at the form of <A B C D> Such that the letter are A - H with camel case");
                return false;
            }

            for (int i = 0; i < i_guess.Length; i++)
            {
                // We are in an index that should be an A-H letter
                if (i % 2 == 0 && (i_guess[i] < 65 || i_guess[i] > 72))
                {
                    Console.WriteLine("Your guess should be at the form of <A B C D> Such that the letter are A - H with camel case");
                    return false;
                }

                // We are in an index that is a white space
                else if (i % 2 == 1 && i_guess[i] != ' ')
                {
                    Console.WriteLine("Your guess should be at the form of <A B C D>. Don't forget to put whitespaces between letters");
                    return false;
                }

                if (set.Contains(i_guess[i]))
                {
                    Console.WriteLine("Please choose a word that contains uniqe letters.");
                    return false;
                }

                if (i % 2 == 0)
                {
                    // add the letter to the hash set so we know it was chosen already
                    set.Add(i_guess[i]);
                }
            }

            return true;
        }
    }
}
