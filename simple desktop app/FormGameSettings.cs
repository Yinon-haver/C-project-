using System;
using System.Windows.Forms;

namespace B17_Ex05_Amir_305296238_Yinon_305763641
{
    public partial class FormGameSettings : Form
    {
        private int m_NumberOfChancesChosen = 4;
        private byte m_MinimumNumberOfChances = 4;
        private byte m_MaximumNumberOfChances = 10;
        private byte m_NumberCounter = 0;
        private bool m_IsStartingGame = false;

        public int NumberOfChances
        {
            get
            {
                return m_NumberOfChancesChosen;
            }
        }
        public bool IsStartingGame
        {
            get
            {
                return m_IsStartingGame;
            }
        }

        public FormGameSettings()
        {
            InitializeComponent();
        }

        private void startButton_Clicked(object sender, EventArgs e)
        {
            m_IsStartingGame = true;
            this.Close();
        }

        private void numberOfChancesButton_Clicked(object sender, EventArgs e)
        {
            m_NumberOfChancesChosen = (m_MinimumNumberOfChances + (++m_NumberCounter % (m_MaximumNumberOfChances - m_MinimumNumberOfChances + 1)));
            this.numberOfChancesButton.Text = "Number of chances: " + m_NumberOfChancesChosen;
        }
    }
}
