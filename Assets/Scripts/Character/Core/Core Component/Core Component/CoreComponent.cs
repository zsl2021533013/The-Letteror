using System;
using UnityEngine;

namespace Character.Core.Core_Component
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