using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class HealthBarController : MonoBehaviour
    {
        [SerializeField] private Image healthUI;

        public void RefreshHealthUI(int currentHealth)
        {
            healthUI.fillAmount = currentHealth / 15f;
        }
    }
}
