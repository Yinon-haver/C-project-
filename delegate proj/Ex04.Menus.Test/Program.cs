namespace Ex04.Menus.Test
{
    public class Program
    {
        public static void Main()
        {
            startTest();
        }

        private static void startTest()
        {
            activateIntrfaceVersion();
            activateDelegateVersion();
        }

        private static void activateIntrfaceVersion()
        {
            Interfaces.MenuItem m_VersionsAndActions = new Interfaces.MenuItem("Versions and Actions", null);
            Interfaces.IDoAction showVersion = new VersionDisplay();
            Interfaces.MenuItem m_ShowVersion = new Interfaces.MenuItem("Show Version", showVersion);

            m_VersionsAndActions.AddMenuItem(m_ShowVersion);

            Interfaces.MenuItem m_Actions = new Interfaces.MenuItem("Actions", null);
            Interfaces.IDoAction charsCount = new CharsCount();
            Interfaces.MenuItem m_CharsCount = new Interfaces.MenuItem("Chars Count", charsCount);
            Interfaces.IDoAction countSpaces = new SpacesCount();
            Interfaces.MenuItem m_CountSpaces = new Interfaces.MenuItem("Count Spaces", countSpaces);

            m_Actions.AddMenuItem(m_CharsCount);
            m_Actions.AddMenuItem(m_CountSpaces);
            m_VersionsAndActions.AddMenuItem(m_Actions);

            // Show Time and Date menu
            Interfaces.MenuItem m_ShowDateAndTime = new Interfaces.MenuItem("Show Date/Time", null);
            Interfaces.IDoAction showTime = new TimeDisplay();
            Interfaces.MenuItem m_ShowTime = new Interfaces.MenuItem("Show Time", showTime);
            Interfaces.IDoAction showDate = new DateDisplay();
            Interfaces.MenuItem m_ShowDate = new Interfaces.MenuItem("Show Date", showDate);

            m_ShowDateAndTime.AddMenuItem(m_ShowTime);
            m_ShowDateAndTime.AddMenuItem(m_ShowDate);

            // Main menu
            Interfaces.MenuItem firstMenu = new Interfaces.MenuItem("My Menu implemented with Interfaces", null);
            Interfaces.MainMenu mainMenu = new Interfaces.MainMenu(firstMenu);

            firstMenu.AddMenuItem(m_VersionsAndActions);
            firstMenu.AddMenuItem(m_ShowDateAndTime);

            mainMenu.Show();
        }

        private static void activateDelegateVersion()
        {
            Delegates.MenuItem m_VersionsActions = new Delegates.MenuItem("Versions and Actions");
            Delegates.MenuItem m_ShowVersion = new Delegates.MenuItem("Show Version");
            m_ShowVersion.DoAction += VersionDisplay.ShowVersion;
            m_VersionsActions.AddMenuItem(m_ShowVersion);

            Delegates.MenuItem m_ActionsToDo = new Delegates.MenuItem("Actions");
            Delegates.MenuItem m_CharacterToCount = new Delegates.MenuItem("Chars Count");
            Delegates.MenuItem m_CountingTheSpaces = new Delegates.MenuItem("Count Spaces");
            m_CharacterToCount.DoAction += CharsCount.CountChars;
            m_CountingTheSpaces.DoAction += SpacesCount.CountSpaces;

            m_ActionsToDo.AddMenuItem(m_CharacterToCount);
            m_ActionsToDo.AddMenuItem(m_CountingTheSpaces);
            m_VersionsActions.AddMenuItem(m_ActionsToDo);

            // Show Time and Date menu
            Delegates.MenuItem m_ShowDateTime = new Delegates.MenuItem("Show Date/Time");
            Delegates.MenuItem m_ShowsTime = new Delegates.MenuItem("Show Time");
            Delegates.MenuItem m_ShowsDate = new Delegates.MenuItem("Show Date");
            m_ShowsTime.DoAction += TimeDisplay.ShowTime;
            m_ShowsDate.DoAction += DateDisplay.ShowDate;

            m_ShowDateTime.AddMenuItem(m_ShowsTime);
            m_ShowDateTime.AddMenuItem(m_ShowsDate);

            // Main menu
            Delegates.MenuItem firstMenuDelegates = new Delegates.MenuItem("My Menu implemented with Delegates");
            Delegates.MainMenu mainMenuDelegates = new Delegates.MainMenu(firstMenuDelegates);

            firstMenuDelegates.AddMenuItem(m_VersionsActions);
            firstMenuDelegates.AddMenuItem(m_ShowDateTime);

            mainMenuDelegates.Show();
        }
    }
}