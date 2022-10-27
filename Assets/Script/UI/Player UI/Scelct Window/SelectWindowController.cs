using System;
using Game_Manager;
using PixelCrushers.Wrappers;
using Script.Character.Player.Input_System;
using Script.Game_Manager;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Script.UI.Player_UI.Scelct_Window
{
    public class SelectWindowController : MonoBehaviour
    {
        [SerializeField] private GameObject selectPanel;
        [SerializeField] private Button continueBtn;
        [SerializeField] private Button reloadBtn;
        [SerializeField] private Button exitBtn;

        private PlayerUIManager UIManager;

        private void Start()
        {
            UIManager = PlayerUIManager.Instance;
            UIManager.RegisterSelectWindowController(this);
        }

        public void OpenOrCloseSelectWindow()
        {
            if (selectPanel.activeInHierarchy)
            {
                CloseSelectWindow();
            }
            else
            {
                OpenSelectWindow();
            }
        }
        
        private void OpenSelectWindow()
        {
            selectPanel.SetActive(true);
            
            UIManager.CloseHUD();
            
            GameManager.Instance.InputHandler.DisableInput();
            
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(continueBtn.gameObject);
        }

        private void CloseSelectWindow()
        {
            selectPanel.SetActive(false);
            
            UIManager.OpenHUD();
            
            GameManager.Instance.InputHandler.EnableInput();
            
            EventSystem.current.SetSelectedGameObject(null);
        }

        public void OnContinueBtnPress()
        {
            OpenOrCloseSelectWindow();
        }

        public void OnReloadBtnPress()
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
