namespace B17_Ex02
{
    public class WordGuesserGame
    {
        public static void Main(string[] args)
        {
            bool playGame = true;

            while (playGame)
            {
                byte numberOfGuesses = GameController.GetNumberOfGuesses();
                GameManager gameManager = new GameManager(numberOfGuesses);
                gameManager.StartGame();
                playGame = GameController.PlayAgainQuery();
            }
        }
    }
}
