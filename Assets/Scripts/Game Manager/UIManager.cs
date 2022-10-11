using Tool.Generic;
using UI;
using UnityEngine;

namespace Game_Manager
{
    public class UIManager : Singleton<UIManager>
    {
        [SerializeField] private HealthBarController healthBarController;
        
        public void RefreshHealthUI(int currentHealth)
        {
            healthBarController.RefreshHealthUI(currentHealth);
        }
    }
}
