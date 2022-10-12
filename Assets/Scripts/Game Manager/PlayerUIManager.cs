using Tool.Generic;
using UI;
using UnityEngine;

namespace Game_Manager
{
    public class PlayerUIManager : Singleton<PlayerUIManager>
    {
        [SerializeField] private HealthBarController healthBarController;
        [SerializeField] private GameObject HUDWindow;
        
        public void RefreshHealthUI(int currentHealth)
        {
            healthBarController.RefreshHealthUI(currentHealth);
        }

        public void CloseHUD()
        {
            HUDWindow.SetActive(false);
        }

        public void OpenHUD()
        {
            HUDWindow.SetActive(true);
        }
    }
}
