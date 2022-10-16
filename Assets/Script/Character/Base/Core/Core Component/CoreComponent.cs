using Character.Base.Core.Core_Manger;
using UnityEngine;

namespace Character.Base.Core.Core_Component
{
    public class CoreComponent : MonoBehaviour
    {
        protected CoreManager coreManager;

        protected virtual void Awake()
        {
            coreManager = transform.parent.GetComponent<CoreManager>();

            if (!coreManager)
            {
                Debug.LogError("Missing Core component in parent");
            }
        }
    }
}