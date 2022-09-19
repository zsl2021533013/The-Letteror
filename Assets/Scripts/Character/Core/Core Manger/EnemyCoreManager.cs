using Character.Core.Core_Component;
using UnityEngine;

namespace Character.Core
{
    public class EnemyCoreManager : MonoBehaviour
    {
        public EnemyMoveCore MoveCore { get; private set; }
        public EnemySenseCore SenseCore { get; private set; }

        private void Awake()
        {
            MoveCore = GetComponentInChildren<EnemyMoveCore>();
            SenseCore = GetComponentInChildren<EnemySenseCore>();

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