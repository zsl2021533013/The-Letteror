using Game_Manager;
using PixelCrushers;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Script.UI.Start_Menu.Main_Menu
{
    public class MainMenuController : MonoBehaviour
    {
        [SerializeField] private GameObject mainMenuPanel; 
        [SerializeField] private Button newGameBtn;

        private StartMenuManager _manager;

        private void Start()
        {
            _manager = StartMenuManager.Instance;
            _manager.RegisterMainMenu(this);
        }

        public void OpenMainMenu()
        {
            mainMenuPanel.SetActive(true);
            
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(newGameBtn.gameObject);
        }

        public void CloseMainMenu()
        {
            mainMenuPanel.SetActive(false);
            
            EventSystem.current.SetSelectedGameObject(null);
        }
        
        public void OnNewGameBtnPress()
        {
            CloseMainMenu();
            _manager.NewGameNoteController.OpenNewGameNote();
        }

        public void OnContinueBtnPress()
        {
            if (!SaveManager.ExistFile())
            {
                return;
            }
            
            SaveManager.SkipSaving();
            SaveSystem.LoadFromSlot(0);
        }
        
        public void OnExitBtnPress()
        {
            Application.Quit();
        }
    }
}
