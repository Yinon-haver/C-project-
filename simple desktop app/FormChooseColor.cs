using System;
using System.Drawing;
using System.Windows.Forms;

namespace B17_Ex05_Amir_305296238_Yinon_305763641
{
    public partial class FormChooseColor : Form
    {
        private Color m_LastColorChosen;
        private bool m_ButtonWasColored;
        private bool m_ColorWasChosenInTheLastSession;

        public Color LastColorchosen
        {
            get
            {
                return m_LastColorChosen;
            }
        }  
        public bool ColorWasChosenInTheLastSession
        {
            get
            {
                return m_ColorWasChosenInTheLastSession;
            }
        }
        public bool ButtonWasColored
        {
            get
            {
                return m_ButtonWasColored;
            }
            set
            {
                m_ButtonWasColored = value;
            }
        }

        public FormChooseColor()
        {
            InitializeComponent();
            this.FormClosing += fileTypeDialog_FormClosing;
        }

        private void colorButton_Clicked(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            m_ColorWasChosenInTheLastSession = true;
            m_LastColorChosen = clickedButton.BackColor;
            this.Close();
        }

        private void fileTypeDialog_FormClosing(object sender, EventArgs e)
        {
            if (m_ColorWasChosenInTheLastSession)
            {
                m_ButtonWasColored = true;
                m_ColorWasChosenInTheLastSession = false; // We reset it for the next dialog seassion
            }
        }      
    }
}
