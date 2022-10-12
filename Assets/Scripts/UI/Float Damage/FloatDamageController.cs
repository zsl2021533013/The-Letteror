using UnityEngine;

namespace UI
{
    public class FloatDamageController : MonoBehaviour
    {
        [SerializeField]
        private TextMesh text;

        public void SetDamageNumber(int attack)
        {
            text.text = attack.ToString();
        }

        public void OnAnimationFinish()
        {
            Destroy(transform.parent.gameObject);
        }
    }
}