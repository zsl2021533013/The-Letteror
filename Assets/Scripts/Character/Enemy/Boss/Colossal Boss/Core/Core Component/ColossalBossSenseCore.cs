using Character.Enemy.Boss.Base.Core.Core_Component;
using Character.Enemy.Boss.Colossal_Boss.Core.Core_Manager;
using UnityEngine;

namespace Character.Enemy.Boss.Colossal_Boss.Core.Core_Component
{
    public class ColossalBossSenseCore : BossSenseCore
    {
        protected new ColossalBossCoreManager coreManager;
        
        [Header("Colossal Boss Only")]
        public float attackRange;

        protected override void Awake()
        {
            base.Awake();

            coreManager = (ColossalBossCoreManager)base.coreManager;
        }

        public bool InAttackRange => JudgeArrive(attackRange);
        public bool InTargetPoint => coreManager.MoveCore.Distance < attackRange;
    }
}