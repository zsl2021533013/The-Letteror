using Game_Manager;
using PixelCrushers;
using Script.UI.CG_Player;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Script.UI.Start_Menu.New_Game_Note
{
    public class NewGameNoteController : MonoBehaviour
    {
        [SerializeField] private GameObject newGameNotePanel;
        [SerializeField] private Button confirmBtn;
        private StartMenuManager _manager;

        private void Start()
        {
            _manager = StartMenuManager.Instance;
            _manager.RegisterNewGameNote(this);
        }
    
        public void OpenNewGameNote()
        {
            newGameNotePanel.SetActive(true);
        
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(confirmBtn.gameObject);
        }

        public void CloseNewGameNote()
        {
            newGameNotePanel.SetActive(false);
            
            EventSystem.current.SetSelectedGameObject(null);
        }

        public void OnConfirmBtnPress()
        {
            CloseNewGameNote();
            
            CGPlayerController.Instance.PlayEnterAnimation();
        }

        public void OnCancelBtnPress()
        {
            CloseNewGameNote();
            _manager.MainMenuController.OpenMainMenu();
        }
    }
}
