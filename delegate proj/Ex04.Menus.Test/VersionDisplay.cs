using System;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class VersionDisplay : IDoAction
    {
        public static void ShowVersion()
        {
            Console.Clear();
            Console.WriteLine("Version: 17.2.4.0");
            Console.ReadLine();
        }

        public void RunWhenActivated()
        {
            ShowVersion();
        }
    }
}
