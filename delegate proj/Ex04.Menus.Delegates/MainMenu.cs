namespace Ex04.Menus.Delegates
{
    public class MainMenu
    {
        protected MenuItem m_FirstMenu;

        public MainMenu(MenuItem i_MenuItem)
        {
            m_FirstMenu = i_MenuItem;
        }

        public void Show()
        {
            m_FirstMenu.ActiveMenu();
        }
    }
}
