using Script.UI.Player_UI.Scelct_Window;
using Tool.Generic;
using UI;
using UnityEngine;

namespace Game_Manager
{
    public class PlayerUIManager : Singleton<PlayerUIManager>
    {
        [SerializeField] private HealthBarController healthBarController;
        [SerializeField] private GameObject HUDWindow;

        private SelectWindowController _selectWindowController;

        protected override void Awake()
        {
            base.Awake();

            _selectWindowController = GetComponentInChildren<SelectWindowController>();
        }

        public void RegisterSelectWindowController(SelectWindowController selectWindowController) =>
            _selectWindowController = selectWindowController;

        public void RefreshHealthUI(int currentHealth) => healthBarController.RefreshHealthUI(currentHealth);

        public void OpenHUD() => HUDWindow.SetActive(true);

        public void CloseHUD() => HUDWindow.SetActive(false);

        public void OpenOrCloseSelectWindow() => _selectWindowController.OpenOrCloseSelectWindow();
    }
}
