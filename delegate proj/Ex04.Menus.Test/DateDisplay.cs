using System;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class DateDisplay : IDoAction
    {
        public static void ShowDate()
        {
            Console.Clear();
            Console.WriteLine(string.Format("The date today is {0}", DateTime.Today.ToString("dd/MM/yyyy")));
            Console.ReadLine();
        }

        public void RunWhenActivated()
        {
            ShowDate();
        }
    }
}
