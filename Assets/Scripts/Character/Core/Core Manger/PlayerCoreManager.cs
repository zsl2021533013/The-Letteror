using System;
using Character.Core.Core_Component;
using UnityEngine;

namespace Character.Core
{
    public class PlayerCoreManager : MonoBehaviour
    {
        public PlayerMoveCore MoveCore { get; private set; }
        public PlayerSenseCore SenseCore { get; private set; }

        private void Awake()
        {
            MoveCore = GetComponentInChildren<PlayerMoveCore>();
            SenseCore = GetComponentInChildren<PlayerSenseCore>();

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