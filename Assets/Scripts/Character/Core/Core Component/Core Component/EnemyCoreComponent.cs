using UnityEngine;

namespace Character.Core.Core_Component
{
    public class EnemyCoreComponent : MonoBehaviour
    {
        protected EnemyCoreManager coreManager;

        protected virtual void Awake()
        {
            coreManager = transform.parent.GetComponent<EnemyCoreManager>();

            if (!coreManager)
            {
                Debug.LogError("Missing Core component in parent");
            }
        }
    }
}