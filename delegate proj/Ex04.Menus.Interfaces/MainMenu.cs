namespace Ex04.Menus.Interfaces
{
    public class MainMenu
    {
        protected MenuItem m_menuItem;

        public MainMenu(MenuItem i_menuItem)
        {
            m_menuItem = i_menuItem;
        }

        public void Show()
        {
            m_menuItem.ActiveMenu();
        }
    }
}