using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Delegates
{
    public delegate void ActionToDoDelegate();

    public class MenuItem
    {
        public event ActionToDoDelegate DoAction;

        private readonly List<MenuItem> r_ListMenuItems;
        private string m_NameOfMenu;
        private MenuItem m_Father;

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

        public ActionToDoDelegate action
        {
            get
            {
                return DoAction;
            }
        }

        public string nameOfMenu
        {
            get
            {
                return m_NameOfMenu;
            }
        }

        public MenuItem(string i_NameOfMenu)
        {
            r_ListMenuItems = new List<MenuItem>();
            m_NameOfMenu = i_NameOfMenu;
            m_Father = null;
            DoAction = null;
        }

        public void ShowMenu()
        {
            Console.Clear();
            string firstSentence = string.Format("You are currently in {0}{1}", m_NameOfMenu, Environment.NewLine);
            StringBuilder stringBuilder = new StringBuilder(firstSentence);
            int index = 1;

            foreach (MenuItem item in r_ListMenuItems)
            {
                stringBuilder.Append(string.Format("{0} - {1}{2}", index, r_ListMenuItems[index - 1].nameOfMenu, Environment.NewLine));
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
            r_ListMenuItems.Add(i_MenuItem);
        }

        private int GetInput()
        {
            string display = string.Format("Please enter a number between {0} - {1}", 0, r_ListMenuItems.Count);
            Console.WriteLine(display);
            string getInput = Console.ReadLine();
            int numberChosen;
            while (!int.TryParse(getInput, out numberChosen) || numberChosen < 0 || numberChosen > r_ListMenuItems.Count)
            {
                Console.WriteLine("Please enter a valid number");
                getInput = Console.ReadLine();
            }

            return numberChosen;
        }

        public void Activate(int i_NumberChosen)
        {
            if (i_NumberChosen > r_ListMenuItems.Count)
            {
                do
                {
                    i_NumberChosen = GetInput();
                }
                while (i_NumberChosen > r_ListMenuItems.Count);
            }

            r_ListMenuItems[i_NumberChosen - 1].ActiveMenu();
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
            if (DoAction == null)
            {
                DoWhenChosen();
            }
            else
            {
                DoAction.Invoke();
            }
        }
    }
}