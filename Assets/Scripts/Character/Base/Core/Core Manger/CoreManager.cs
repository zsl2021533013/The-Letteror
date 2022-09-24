using Character.Base.Core.Core_Component;
using UnityEngine;

namespace Character.Base.Core.Core_Manger
{
    public class CoreManager : MonoBehaviour
    {
        public MoveCore MoveCore;
        public SenseCore SenseCore;

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
