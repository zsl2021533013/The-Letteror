using Script.UI.Start_Menu.Main_Menu;
using Script.UI.Start_Menu.New_Game_Note;
using Tool.Generic;

namespace Script.UI.Start_Menu
{
    public class StartMenuManager : Singleton<StartMenuManager>
    {
        public MainMenuController MainMenuController { get; private set; }
        public NewGameNoteController NewGameNoteController { get; private set; }

        public void RegisterMainMenu(MainMenuController mainMenuController) 
            => MainMenuController = mainMenuController;

        public void RegisterNewGameNote(NewGameNoteController newGameNoteController)
            => NewGameNoteController = newGameNoteController;


    }
}
