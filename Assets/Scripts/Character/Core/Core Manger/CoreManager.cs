using System;
using Character.Core.Core_Component;
using UnityEngine;

namespace Character.Core
{
    public class CoreManager : MonoBehaviour
    {
        public MoveCore MoveCore { get; private set; }
        public SenseCore SenseCore { get; private set; }

        protected virtual void Awake()
        {
            MoveCore = GetComponentInChildren<MoveCore>();
            SenseCore = GetComponentInChildren<SenseCore>();

            if (!MoveCore)
            {
                Debug.LogError("Missing MoveCore in CoreManager");
            }

            if (!SenseCore)
            {
                Debug.LogError("Missing SenseCore in CoreManager");
            }
        }

        public void OnUpdate()
        {
            MoveCore.OnUpdate();
        }
    }
}
