using System;

namespace B17_Ex05_Amir_305296238_Yinon_305763641
{
    public enum eColor
    {
        Purple = 0,
        Red = 1,
        Green = 2,
        Cyan = 3,
        Blue = 4,
        Yellow = 5,
        Brown = 6,
        White = 7,
    }

    public enum eGuessFeedback
    {
        Miss = 0,
        Pgia = 1,
        BoolPgia = 2,
    }

    class GameManager
    {
        private eColor[] m_ChosenColorSequence;
        private Random m_Random;

        public eColor[] ChosenColors
        {
            get;
        }

        public GameManager()
        {
            m_ChosenColorSequence = new eColor[4];
            m_Random = new Random();
        }

        public void GenerateColorSequence()
        {
            int[] colorOptions = new int[8];
            for (int i = 0; i < colorOptions.Length; i++)
            {
                colorOptions[i] = i;
            }
            int indexOfNextSwappingPlace = colorOptions.Length - 1;

            for (int i = 0; i < m_ChosenColorSequence.Length; i++)
            {
                int rand = m_Random.Next(colorOptions.Length - i);
                m_ChosenColorSequence[i] = (eColor)colorOptions[rand];
                int temporrayIndex = colorOptions[rand];
                colorOptions[rand] = colorOptions[indexOfNextSwappingPlace];
                colorOptions[indexOfNextSwappingPlace--] = temporrayIndex;
            }
        }

        public eGuessFeedback[] CheckGuess(eColor[] i_UsersGuess)
        {
            int NumberOfCheckToDo = i_UsersGuess.Length;
            eGuessFeedback[] guessFeedback = new eGuessFeedback[NumberOfCheckToDo];

            for (int i = 0; i < NumberOfCheckToDo; i++)
            {
                for (int j = 0; j < NumberOfCheckToDo; j++)
                {
                    if (i_UsersGuess[i] == m_ChosenColorSequence[j] && i == j)
                    {
                        guessFeedback[i] = (eGuessFeedback)2;
                    }
                    else if (i_UsersGuess[i] == m_ChosenColorSequence[j] && i != j)
                    {
                        guessFeedback[i] = (eGuessFeedback)1;
                    }
                }
            }

            Array.Sort(guessFeedback);
            Array.Reverse(guessFeedback);

            return guessFeedback;
        }

        public bool CheckIfUserWonGame(eGuessFeedback[] i_GuessFeedback)
        {
            foreach (eGuessFeedback feedback in i_GuessFeedback)
            {
                if (feedback != eGuessFeedback.BoolPgia)
                {
                    return false;
                }
            }

            return true;
        }        
    }
}
