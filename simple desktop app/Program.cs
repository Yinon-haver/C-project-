using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace B17_Ex05_Amir_305296238_Yinon_305763641
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            FormGameSettings formGameSettings = new FormGameSettings();
            Application.Run(formGameSettings);
            if (formGameSettings.IsStartingGame)
            {
                FormGameManager formGameManager = new FormGameManager(formGameSettings.NumberOfChances);
                formGameManager.ShowDialog();
            }
        }
    }
}
