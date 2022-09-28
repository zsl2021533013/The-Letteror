using Character.Base.Core.Core_Manger;
using Character.Enemy.Boss.Blood_King.Core.Core_Component;
using Character.Enemy.Boss.Colossal_Boss.Core.Core_Component;
using UnityEngine;

namespace Character.Enemy.Boss.Blood_King.Core.Core_Manager
{
    public class BloodKingCoreManager : CoreManager
    {
        public new BloodKingMoveCore MoveCore { get; private set; }
        public new BloodKingSenseCore SenseCore { get; private set; }
        
        protected override void Awake()
        {
            base.Awake();

            if (base.MoveCore is not BloodKingMoveCore)
            {
                Debug.LogError("Missing Blood Boss Move Core");
            }
            if (base.SenseCore is not BloodKingSenseCore)
            {
                Debug.LogError("Missing Blood Boss Sense Core");
            }

            MoveCore = (BloodKingMoveCore)base.MoveCore;
            SenseCore = (BloodKingSenseCore)base.SenseCore;
        }
    }
}