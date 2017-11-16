using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    public class MenuItem
    {
        private List<MenuItem> m_ListMenuItems;
        private string m_NameOfMenu;
        private MenuItem m_Father;
        private IDoAction m_DoAction;

        public MenuItem father
        {
            get
            {
                return m_Father;
            }

            set
            {
                m_Father = value;
            }
        }

        private bool isFirstMenuItem
        {
            get
            {
                return m_Father == null;
            }
        }

        public string nameOfMenu
        {
            get
            {
                return m_NameOfMenu;
            }
        }

        public MenuItem(string i_NameOfMenu, IDoAction i_DoAction)
        {
            m_ListMenuItems = new List<MenuItem>();
            m_NameOfMenu = i_NameOfMenu;
            m_Father = null;
            m_DoAction = i_DoAction;
        }

        public void ShowMenu()
        {
            Console.Clear();
            string firstSentence = string.Format("You are currently in {0}{1}", m_NameOfMenu, Environment.NewLine);
            StringBuilder stringBuilder = new StringBuilder(firstSentence);
            int index = 1;

            foreach (MenuItem item in m_ListMenuItems)
            {
                stringBuilder.Append(string.Format("{0} - {1}{2}", index, m_ListMenuItems[index - 1].nameOfMenu, Environment.NewLine));
                index++;
            }

            if (isFirstMenuItem)
            {
                stringBuilder.Append("0 - Exit");
            }
            else
            {
                stringBuilder.Append("0 - Back");
            }

            Console.WriteLine(stringBuilder);
        }

        public void AddMenuItem(MenuItem i_MenuItem)
        {
            i_MenuItem.father = this;
            m_ListMenuItems.Add(i_MenuItem);
        }

        private int GetInput()
        {
            string display = string.Format("Please enter a number between {0} - {1}", 0, m_ListMenuItems.Count);
            Console.WriteLine(display);
            string getInput = Console.ReadLine();
            int numberChosen;
            while (!int.TryParse(getInput, out numberChosen) || numberChosen < 0 || numberChosen > m_ListMenuItems.Count)
            {
                Console.WriteLine("Please enter a valid number");
                getInput = Console.ReadLine();
            }

            return numberChosen;
        }

        public void Activate(int i_NumberChosen)
        {
            if (i_NumberChosen > m_ListMenuItems.Count)
            {
                do
                {
                    i_NumberChosen = GetInput();
                }
                while (i_NumberChosen > m_ListMenuItems.Count);
            }

            m_ListMenuItems[i_NumberChosen - 1].ActiveMenu();
        }

        public void DoWhenChosen()
        {
            while (true)
            {
                ShowMenu();
                int numberChosen = GetInput();
                if (numberChosen == 0)
                {
                    break;
                }

                Activate(numberChosen);
            }
        }

        internal void ActiveMenu()
        {
            if (m_DoAction == null)
            {
                DoWhenChosen();
            }
            else
            {
                m_DoAction.RunWhenActivated();
            }
        }
    }
}
