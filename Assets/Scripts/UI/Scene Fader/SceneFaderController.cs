using UnityEngine;
using UnityEngine.UI;

namespace UI.Scene_Fader
{
    public class SceneFaderController : MonoBehaviour
    {
        [SerializeField] private GameObject background;

        public void EnableBackground()
        {
            background.SetActive(true);
        }

        public void DisableBackground()
        {
            background.SetActive(false);
        }
    }
}
