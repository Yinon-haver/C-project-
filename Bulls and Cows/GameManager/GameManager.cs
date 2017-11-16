namespace B17_Ex02
{
    using System;
    using System.Text;

    public class GameManager
    {
        private Board m_GameBoard;
        private int m_NumberOfGuesses;
        private string m_ChosenWord;

        public GameManager(int i_numberOfGuesses)
        {
            this.m_NumberOfGuesses = i_numberOfGuesses;
            this.m_GameBoard = new Board(i_numberOfGuesses, 2);
            this.m_ChosenWord = string.Empty;
        }

        public void GenerateWord()
        {
            Random random = new Random();
            char[] chosenWord = new char[4];
            char[] lettersOptions = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H' };
            int indexOfNextSwappingPlace = lettersOptions.Length - 1;

            for (int i = 0; i < chosenWord.Length; i++)
            {
                int rand = random.Next(lettersOptions.Length - i);
                chosenWord[i] = lettersOptions[rand];
                char temporrayIndex = lettersOptions[rand];
                lettersOptions[rand] = lettersOptions[indexOfNextSwappingPlace];
                lettersOptions[indexOfNextSwappingPlace--] = temporrayIndex;
                m_ChosenWord = this.addWhiteSpaces(chosenWord);
            }
        }

        public string GenerateGuessFeedback(string i_guess)
        {
            StringBuilder guessFeedback = new StringBuilder();

            for (int i = 0; i < i_guess.Length; i++)
            {
                for (int j = 0; j < m_ChosenWord.Length; j++)
                {
                    if (i_guess[i] == m_ChosenWord[j] && i == j && i_guess[i] != ' ')
                    {
                        guessFeedback.Append("V");
                    }
                    else if (i_guess[i] == m_ChosenWord[j] && i != j && i_guess[i] != ' ')
                    {
                        guessFeedback.Append("X");
                    }
                }
            }

            char[] sortedFeedback = guessFeedback.ToString().ToCharArray();
            Array.Sort(sortedFeedback);

            return this.addWhiteSpaces(sortedFeedback);
        }

        // Play the Game
        public void StartGame()
        {
            byte turnsLeftToPlay = (byte)m_NumberOfGuesses;
            Console.WriteLine("Game is starting with " + m_NumberOfGuesses + " guesses.");
            m_GameBoard.AddPrefix();
            this.GenerateWord();

            for (int i = 1; i <= m_NumberOfGuesses; i++)
            {
                turnsLeftToPlay = (byte)(m_NumberOfGuesses - i + 1);
                Console.WriteLine(m_GameBoard.GetCurrentBoardStatus(turnsLeftToPlay));
                string guess = GameController.GetUserGuess();
                if (guess.Equals("QUIT"))
                {
                    return;
                }

                string guessFeedback = this.GenerateGuessFeedback(guess);
                m_GameBoard.PlaceTurnResults(guess, guessFeedback);

                if (guess.Equals(m_ChosenWord))
                {
                    Console.WriteLine(m_GameBoard.GetCurrentBoardStatus(turnsLeftToPlay - 1));
                    Console.WriteLine("You won ! You guessed after " + i + " steps!");

                    return;
                }
            }

            Console.WriteLine(m_GameBoard.GetCurrentBoardStatus(0));
            Console.WriteLine("You lost :( The word was " + m_ChosenWord + ".");
            return;
        }

        private string addWhiteSpaces(char[] io_word)
        {
            StringBuilder arrangedFeedback = new StringBuilder();

            for (int i = 0; i < io_word.Length; i++)
            {
                if (i == io_word.Length - 1)
                {
                    arrangedFeedback.Append(io_word[i]); // If we are in the last letter, do not add whitespace
                }
                else
                {
                    arrangedFeedback.Append(io_word[i] + " ");
                }
            }

            return arrangedFeedback.ToString();
        }
    }
}
