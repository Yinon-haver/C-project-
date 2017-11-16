namespace B17_Ex02
{
    using System.Text;

    public class Board
    {
        private char[,] m_Board;
        private int m_Rows;
        private int m_Columns = 2;
        private StringBuilder m_Representation;

        public Board(int i_Rows, int i_Columns)
        {
            this.m_Rows = i_Rows;
            this.m_Columns = i_Columns;
            this.m_Board = new char[i_Rows, i_Columns];
            this.m_Representation = new StringBuilder();
        }

        public void AddPrefix()
        {
            m_Representation.AppendLine("|Pins:    |Result:| \n" +
                                        "|=========|=======| \n" +
                                        "| # # # # |       | \n" +
                                        "|=========|=======|");
        }

        public string GetCurrentBoardStatus(int i_turnsLeftToPlay)
        {
            StringBuilder currentBoardStatus = new StringBuilder();
            string emptyTableLine = "|         |       |\n" +
                                    "|=========|=======|";
            currentBoardStatus.Append(m_Representation);
            for (int i = 0; i < i_turnsLeftToPlay; i++)
            {
                currentBoardStatus.AppendLine(emptyTableLine);
            }

            return currentBoardStatus.ToString();
        }

        public void PlaceTurnResults(string i_guess, string i_guessFeedback)
        {
            byte numberOfSpacesToAppend = (byte)(7 - i_guessFeedback.Length); // we are adding some spaces in order for the table to look alligned
            StringBuilder whiteSpaces = new StringBuilder();

            for (int i = 0; i < numberOfSpacesToAppend; i++)
            {
                whiteSpaces.Append(" ");
            }

            string turnResultsInTable = "| " + i_guess + " |" + i_guessFeedback + whiteSpaces + "| \n" +
                                        "|=========|=======|";
            m_Representation.AppendLine(turnResultsInTable);
        }

        override
        public string ToString()
        {
            return m_Representation.ToString();
        }
    }
}