using System;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class TimeDisplay : IDoAction
    {
        public static void ShowTime()
        {
            Console.Clear();
            Console.WriteLine(string.Format("The time right now is {0}", DateTime.Now.ToString("hh:mm:ss tt")));
            Console.ReadLine();
        }

        public void RunWhenActivated()
        {
            ShowTime();
        }
    }
}
