using UnityEngine;

namespace Character.Core.Core_Component
{
    public class PlayerCoreComponent : MonoBehaviour
    {
        protected PlayerCoreManager coreManager;

        protected virtual void Awake()
        {
            coreManager = transform.parent.GetComponent<PlayerCoreManager>();

            if (!coreManager)
            {
                Debug.LogError("Missing Core component in parent");
            }
        }
    }
}