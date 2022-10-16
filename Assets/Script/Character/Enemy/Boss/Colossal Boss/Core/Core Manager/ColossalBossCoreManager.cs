using Character.Base.Core.Core_Manger;
using Character.Enemy.Boss.Colossal_Boss.Core.Core_Component;
using UnityEngine;

namespace Character.Enemy.Boss.Colossal_Boss.Core.Core_Manager
{
    public class ColossalBossCoreManager : CoreManager
    {
        public new ColossalBossMoveCore MoveCore { get; private set; }
        public new ColossalBossSenseCore SenseCore { get; private set; }
        
        protected override void Awake()
        {
            base.Awake();

            if (base.MoveCore is not ColossalBossMoveCore)
            {
                Debug.LogError("Missing Colossal Boss Move Core");
            }
            if (base.SenseCore is not ColossalBossSenseCore)
            {
                Debug.LogError("Missing Colossal Boss Sense Core");
            }
            
            MoveCore = (ColossalBossMoveCore)base.MoveCore;
            SenseCore = (ColossalBossSenseCore)base.SenseCore;
        }
    }
}