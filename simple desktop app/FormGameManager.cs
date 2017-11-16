using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace B17_Ex05_Amir_305296238_Yinon_305763641
{

    public class ColorChosenEventArgs : EventArgs
    {

        private int m_TurnNumber;

        public int TurnNumber
        {
            get
            {
                return m_TurnNumber;
            }
        }

        public ColorChosenEventArgs(int i_TurnNumber)
        {
            m_TurnNumber = i_TurnNumber;
        }
    }
    public class CheckGuessEventArgs : EventArgs
    {
        private int m_TurnNumber;
        private GameManager m_GameManager;
        private Dictionary<Color, int> m_ColorDictionery;
        private Dictionary<int, Color> m_feedbackDictionery;

        internal CheckGuessEventArgs(GameManager i_GameManager, Dictionary<Color, int> i_ColorDictionery, Dictionary<int, Color> i_FeedbackDictionery, int i_TurnNumber)
        {
            m_GameManager = i_GameManager;
            m_ColorDictionery = i_ColorDictionery;
            m_feedbackDictionery = i_FeedbackDictionery;
            m_TurnNumber = i_TurnNumber;
        }

        public int TurnNumber
        {
            get
            {
                return m_TurnNumber;
            }
        }

        internal GameManager GameManager
        {
            get
            {
                return m_GameManager;
            }
        }

        internal Dictionary<Color, int> ColorDictionery
        {
            get
            {
                return m_ColorDictionery;
            }
        }

        internal Dictionary<int, Color> FeedbackDictionery
        {
            get
            {
                return m_feedbackDictionery;
            }
        }
    }

    public delegate void ColorChosenDelegate(object sender, ColorChosenEventArgs e);
    public delegate void CheckGuessDelegate(object sender, CheckGuessEventArgs e);
    public delegate void GameWonOnThisTurnDelegate(object sender, EventArgs e);

    public partial class FormGameManager : Form
    {
        public static GameWonOnThisTurnDelegate m_GameWonOnThisTurn;

        ColorChosenDelegate m_ColorChosen;
        CheckGuessDelegate m_CheckGuess;

        private const int k_NumberOfColorsToChoose = 4;
        private FormChooseColor m_FormChooseColor;
        private GameManager m_GameManager;
        private ChosenColorSequence m_ChosenColorSequence;
        private Turn[] m_Turns;
        private Dictionary<Color, int> m_ColorDictionery;
        private Dictionary<int, Color> m_FeedbackDictionery;

        public FormGameManager(int i_NumberOfChances)
        {
            m_GameManager = new GameManager();
            m_ChosenColorSequence = new ChosenColorSequence(k_NumberOfColorsToChoose);
            m_Turns = new Turn[i_NumberOfChances];
            m_FormChooseColor = new FormChooseColor();
            initializeColorDictionery();
            initializeFeedbackDictionery();
            m_GameManager.GenerateColorSequence();

            m_ChosenColorSequence.InitializeColorSequence();

            for (int i = 0; i < k_NumberOfColorsToChoose; i++)
            {
                this.Controls.Add(m_ChosenColorSequence.ColorSequence[i]);
            }

            for (int i = 0; i < i_NumberOfChances; i++)
            {
                m_Turns[i] = new Turn(k_NumberOfColorsToChoose, i);
                m_Turns[i].InitializeTurn();
                m_ColorChosen += m_Turns[i].ColorButton_Clicked;
                m_CheckGuess += m_Turns[i].CheckGuessButton_Clicked;


                for (int j = 0; j < k_NumberOfColorsToChoose; j++)
                {
                    this.Controls.Add(m_Turns[i].UserGuess[j]);
                    this.m_Turns[i].UserGuess[j].Click += new System.EventHandler(this.chooseColorBotton_Clicked);

                    this.Controls.Add(m_Turns[i].UserFeedback[j]);
                }

                this.Controls.Add(m_Turns[i].CheckGuessButton);
                this.m_Turns[i].CheckGuessButton.Click += new System.EventHandler(this.checkGuessButton_Clicked);
            }

            this.AutoSize = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void initializeColorDictionery()
        {
            m_ColorDictionery = new Dictionary<Color, int>();
            m_ColorDictionery.Add(Color.Purple, 0);
            m_ColorDictionery.Add(Color.Red, 1);
            m_ColorDictionery.Add(Color.SpringGreen, 2);
            m_ColorDictionery.Add(Color.Cyan, 3);
            m_ColorDictionery.Add(Color.Blue, 4);
            m_ColorDictionery.Add(Color.Yellow, 5);
            m_ColorDictionery.Add(Color.Brown, 6);
            m_ColorDictionery.Add(Color.White, 7);
        }

        private void initializeFeedbackDictionery()
        {
            m_FeedbackDictionery = new Dictionary<int, Color>();
            m_FeedbackDictionery.Add(0, Color.Silver); // Will be used to check if this was a miss
            m_FeedbackDictionery.Add(1, Color.Yellow);
            m_FeedbackDictionery.Add(2, Color.Black);
        }

        private void chooseColorBotton_Clicked(object sender, EventArgs e)
        {
            ColoredGameButton clickedGuessingButton = (ColoredGameButton)sender;
            m_FormChooseColor.ShowDialog();
            if (m_FormChooseColor.ButtonWasColored)
            {
                clickedGuessingButton.ColorButton(m_FormChooseColor.LastColorchosen);
                // We want to check in which turn was the pressed button included in
                for (int i = 0; i < m_Turns.Length; i++)
                {
                    int turnNumberOfButton = m_Turns[i].GetTurnNumberOfButton(clickedGuessingButton);
                    if (turnNumberOfButton != -1)
                    {
                        OnColorChosen(sender, turnNumberOfButton);
                        break;
                    }
                }
            }
            // reset this for the next button that will be clicked
            m_FormChooseColor.ButtonWasColored = false; 
        }

        public void OnColorChosen(object sender, int i_TurnNumber)
        {
            if (m_ColorChosen != null)
            {
                m_ColorChosen.Invoke(sender, new ColorChosenEventArgs(i_TurnNumber));
            }
        }

        private void checkGuessButton_Clicked(object sender, EventArgs e)
        {
            CheckGuessButton clickedCheckGuessButton = (CheckGuessButton)sender;

            // We want to check in which turn was the pressed button included in
            for (int i = 0; i < m_Turns.Length; i++)
            {
                int turnNumberOfButton = m_Turns[i].GetTurnNumberOfButton(clickedCheckGuessButton);
                if (turnNumberOfButton != -1)
                {
                    OnCheckGuess(turnNumberOfButton);
                    break;
                }
            }
        }

        private void OnCheckGuess(int i_TurnNumber)
        {
            if (m_CheckGuess != null)
            {
                m_CheckGuess.Invoke(this, new CheckGuessEventArgs(m_GameManager, m_ColorDictionery, m_FeedbackDictionery, i_TurnNumber));
            }
        }

        public class ChosenColorSequence
        {
            private ColoredGameButton[] m_ColorSequenceChosen;
            public ColoredGameButton[] ColorSequence
            {
                get
                {
                    return m_ColorSequenceChosen;
                }
            }

            public ChosenColorSequence(int i_NumberOfColorsTheUserChooses)
            {
                m_ColorSequenceChosen = new ColoredGameButton[i_NumberOfColorsTheUserChooses];
                m_GameWonOnThisTurn += this.Game_Won;
            }

            public void InitializeColorSequence()
            {
                int buttonMeasurement = 40;
                int baseHeightAndLeftSpaceFromForm = 20;
                int spaceBetweenButtons = 0;
                int spaceBetweenGuessButtonsNeeded = 42;

                for (int i = 0; i < m_ColorSequenceChosen.Length; i++)
                {
                    m_ColorSequenceChosen[i] = new ColoredGameButton(baseHeightAndLeftSpaceFromForm, baseHeightAndLeftSpaceFromForm + spaceBetweenButtons, buttonMeasurement, buttonMeasurement);
                    m_ColorSequenceChosen[i].ColorButton(Color.Black);
                    m_ColorSequenceChosen[i].TurnOff();

                    spaceBetweenButtons += spaceBetweenGuessButtonsNeeded;
                }
            }

            // If the user gusseed correctly, color the black buttons with the winning turn button colors
            public void Game_Won(object sender, EventArgs e)
            {
                ColoredGameButton[] winningGuessSequence = (ColoredGameButton[])sender;

                for (int i = 0; i < k_NumberOfColorsToChoose; i++)
                {
                    m_ColorSequenceChosen[i].ColorButton(winningGuessSequence[i].BackColor);
                }
            }
        }       
    }

    public class Turn
    {
        private int m_TurnNumber;
        private int m_NumberOfColorsTheUserGuesses;
        private ColoredGameButton[] m_UserGuess;
        private CheckGuessButton m_CheckGuessButton;
        private ColoredGameButton[] m_UserFeedback;

        public int NumberOfColorsTheUserGuesses
        {
            get
            {
                return m_NumberOfColorsTheUserGuesses;
            }
        }
        public ColoredGameButton[] UserGuess
        {
            get
            {
                return m_UserGuess;
            }
        }
        public CheckGuessButton CheckGuessButton
        {
            get
            {
                return m_CheckGuessButton;
            }
        }
        public ColoredGameButton[] UserFeedback
        {
            get
            {
                return m_UserFeedback;
            }
        }

        public Turn(int i_numberOfColorsTheUserGuesses, int i_TurnNumber)
        {
            m_TurnNumber = i_TurnNumber;
            m_NumberOfColorsTheUserGuesses = i_numberOfColorsTheUserGuesses;
            m_UserGuess = new ColoredGameButton[m_NumberOfColorsTheUserGuesses];
            m_CheckGuessButton = new CheckGuessButton();
            m_UserFeedback = new ColoredGameButton[m_NumberOfColorsTheUserGuesses];
            FormGameManager.m_GameWonOnThisTurn += this.Game_Won;
        }

        public void InitializeTurn()
        {
            int spaceBetweenTurns = 42;
            placeGuessingButtons(m_TurnNumber, spaceBetweenTurns);
            placeCheckGuessButton(m_TurnNumber, spaceBetweenTurns);
            placeFeedbackButtons(m_TurnNumber, spaceBetweenTurns);
        }

        private void placeGuessingButtons(int i_TurnNumber, int i_SpaceBetweenTurnsAndButtons)
        {
            int buttonMeasurement = 40;
            int baseHeightFromForm = 80;
            int baseLeftSpaceFromform = 20;
            int spaceBetweenGuessButtons = 0;

            for (int i = 0; i < m_NumberOfColorsTheUserGuesses; i++)
            {
                m_UserGuess[i] = new ColoredGameButton((i_TurnNumber * i_SpaceBetweenTurnsAndButtons) + baseHeightFromForm, baseLeftSpaceFromform + spaceBetweenGuessButtons, buttonMeasurement, buttonMeasurement);
                spaceBetweenGuessButtons += i_SpaceBetweenTurnsAndButtons;
            }
        }

        private void placeCheckGuessButton(int i_TurnNumber, int i_SpaceBetweenTurnsAndButtons)
        {
            int baseHeightFromForm = 90;
            int baseLeftSpaceFromform = 200;
            int buttonMeasurement = 40;

            m_CheckGuessButton = new CheckGuessButton((i_TurnNumber * i_SpaceBetweenTurnsAndButtons) + baseHeightFromForm, baseLeftSpaceFromform, buttonMeasurement, buttonMeasurement / 2);
        }

        private void placeFeedbackButtons(int i_TurnNumber, int i_SpaceBetweenTurnsAndButtons)
        {
            int buttonMeasurement = 15;
            int baseHeightFromForm = 85;
            int baseLeftSpaceFromform = 250;

            m_UserFeedback[0] = new ColoredGameButton((i_TurnNumber * i_SpaceBetweenTurnsAndButtons) + baseHeightFromForm, baseLeftSpaceFromform, buttonMeasurement, buttonMeasurement);
            m_UserFeedback[1] = new ColoredGameButton((i_TurnNumber * i_SpaceBetweenTurnsAndButtons) + baseHeightFromForm, baseLeftSpaceFromform + buttonMeasurement, buttonMeasurement, buttonMeasurement);
            m_UserFeedback[2] = new ColoredGameButton((i_TurnNumber * i_SpaceBetweenTurnsAndButtons) + baseHeightFromForm + buttonMeasurement, baseLeftSpaceFromform, buttonMeasurement, buttonMeasurement);
            m_UserFeedback[3] = new ColoredGameButton((i_TurnNumber * i_SpaceBetweenTurnsAndButtons) + baseHeightFromForm + buttonMeasurement, baseLeftSpaceFromform + buttonMeasurement, buttonMeasurement, buttonMeasurement);

            foreach (ColoredGameButton feedbackButton in m_UserFeedback)
            {
                feedbackButton.TurnOff();
            }
        }

        // When a button is clicked and is colored, we will check all 4 buttons in a turn in order to see if we can click the check guess button
        public void ColorButton_Clicked(object sender, ColorChosenEventArgs e)
        {
            ColoredGameButton theButtonThatWasClicked = (ColoredGameButton)sender;
            // If the button that we clicked on belong to this turn we need to check all guesses
            if (m_TurnNumber == e.TurnNumber)
            {
                for (int i = 0; i < m_NumberOfColorsTheUserGuesses; i++)
                {
                    // If we chose a color that was already chosen in the same turn, choose a different color

                    if (theButtonThatWasClicked.ButtonCollor == UserGuess[i].ButtonCollor && theButtonThatWasClicked != UserGuess[i])
                    {
                        theButtonThatWasClicked.PerformClick();
                    }
                }

                for (int i = 0; i < m_NumberOfColorsTheUserGuesses; i++)
                {
                    // if not all 4 guessButtons are colored, no need to activate checkGuessButton
                    if (!UserGuess[i].IsColored)
                    {
                        return;
                    }
                } 
                // If we have chosen 4 uniqe colors, activate checkGuessbutton
                m_CheckGuessButton.TurnOn();
            }
        }

        // If the button is part of this turn it will return the turn number, if it is not it will return -1
        public int GetTurnNumberOfButton(GameButton i_Button)
        {
            // Check if the button is one of the colorGuess buttons
            for (int i = 0; i < m_NumberOfColorsTheUserGuesses; i++)
            {
                if (i_Button == m_UserGuess[i])
                {
                    return m_TurnNumber;
                }
            }
            // Check if the button is the checkGuessButton
            if (i_Button == m_CheckGuessButton)
            {
                return m_TurnNumber;
            }

            return -1;
        }

        public void CheckGuessButton_Clicked(object sender, CheckGuessEventArgs e)
        {
            // If the button that we clicked on belong to this turn 
            if (m_TurnNumber == e.TurnNumber)
            {
                eGuessFeedback[] guessFeedback = e.GameManager.CheckGuess(convertColorToeColorArray(m_UserGuess, e.ColorDictionery));
                Color[] feedbackColors = this.converteGuessFeedbackToColorArray(guessFeedback, e.FeedbackDictionery);

                this.changeFeedbackButtonsColorAccordingToFeedback(feedbackColors);

                m_CheckGuessButton.TurnOff();
                for (int i = 0; i < m_NumberOfColorsTheUserGuesses; i++)
                {
                    m_UserGuess[i].TurnOff();
                }

                bool userWonGame = e.GameManager.CheckIfUserWonGame(guessFeedback);

                if (userWonGame)
                {
                    OnGameWonInThisTurn(m_UserGuess);
                }
            }
        }

        private eColor[] convertColorToeColorArray(ColoredGameButton[] i_UserGuess, Dictionary<Color, int> i_ColorDictionery)
        {
            eColor[] GuessAseColors = new eColor[m_NumberOfColorsTheUserGuesses];
            for (int i = 0; i < m_NumberOfColorsTheUserGuesses; i++)
            {
                int eColor;
                i_ColorDictionery.TryGetValue(i_UserGuess[i].ButtonCollor, out eColor);
                GuessAseColors[i] = (eColor)eColor;
            }

            return GuessAseColors;
        }

        private Color[] converteGuessFeedbackToColorArray(eGuessFeedback[] i_GuessFeedback, Dictionary<int, Color> i_FeedbackDictionery)
        {
            Color[] feedbackColors = new Color[m_NumberOfColorsTheUserGuesses];
            for (int i = 0; i < m_NumberOfColorsTheUserGuesses; i++)
            {
                Color color;
                i_FeedbackDictionery.TryGetValue((int)i_GuessFeedback[i], out color);
                feedbackColors[i] = color;
            }

            return feedbackColors;
        }

        private void changeFeedbackButtonsColorAccordingToFeedback(Color[] i_FeedbackColors)
        {
            for (int i = 0; i < m_NumberOfColorsTheUserGuesses; i++)
            {
                if (i_FeedbackColors[i] != Color.Silver)
                {
                    m_UserFeedback[i].ColorButton(i_FeedbackColors[i]);
                }
            }
        }

        public void OnGameWonInThisTurn(ColoredGameButton[] i_UserGuess)
        {
            if (FormGameManager.m_GameWonOnThisTurn != null)
            {
                FormGameManager.m_GameWonOnThisTurn.Invoke(i_UserGuess, EventArgs.Empty);
            }
        }

        // Disable the rest of the turns when the game was won
        public void Game_Won(object sender, EventArgs e)
        {

            foreach (ColoredGameButton guessButton in UserGuess)
            {
                guessButton.TurnOff();
            }

            m_CheckGuessButton.TurnOff();
        }
    }

    public abstract class GameButton : Button
    {

        public GameButton()
        {
        }
        public GameButton(int i_TopOfButton, int i_LeftOfButton, int i_WidthOfButton, int i_HeightOfButton)
        {
            this.Top = i_TopOfButton;
            this.Left = i_LeftOfButton;
            this.Width = i_WidthOfButton;
            this.Height = i_HeightOfButton;
        }

        public void TurnOn()
        {
            this.Enabled = true;
        }

        public void TurnOff()
        {
            this.Enabled = false;
        }
    }

    public class CheckGuessButton : GameButton
    {
        private const string k_TextInsideButton = "-->>";

        public CheckGuessButton()
        {
        }

        public CheckGuessButton(int i_TopOfButton, int i_LeftOfButton, int i_WidthOfButton, int i_HeightOfButton) : base(i_TopOfButton, i_LeftOfButton, i_WidthOfButton, i_HeightOfButton)
        {
            this.Text = k_TextInsideButton;
            this.Enabled = false;
        }
    }

    public class ColoredGameButton : GameButton
    {
        private Color m_ButtonColor;
        private bool m_IsColored;

        public Color ButtonCollor
        {
            get
            {
                return m_ButtonColor;
            }
        }

        public bool IsColored
        {
            get
            {
                return m_IsColored;
            }
        }


        public ColoredGameButton(int i_TopOfButton, int i_LeftOfButton, int i_WidthOfButton, int i_HeightOfButton) : base(i_TopOfButton, i_LeftOfButton, i_WidthOfButton, i_HeightOfButton)
        {
            m_IsColored = false;
        }

        public void ColorButton(Color i_Color)
        {
            m_ButtonColor = i_Color;
            this.BackColor = i_Color;
            m_IsColored = true;
        }
    }
}
