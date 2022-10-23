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
        
        [Header("Upwards Attack Sensor")]
        public Transform playerSensor;
        public Vector2 upwardsSensorSize;
        
        public bool InAttackRange => JudgeArrive(attackRange);
        public bool InTargetPoint => coreManager.MoveCore.Distance < attackRange;
        public bool DetectPlayerUpwards =>
            Physics2D.OverlapBox(playerSensor.position, upwardsSensorSize, 0f, playerLayerMask);

        protected override void Awake()
        {
            base.Awake();

            coreManager = (ColossalBossCoreManager)base.coreManager;
        }

        protected override void OnDrawGizmosSelected()
        {
            base.OnDrawGizmosSelected();
            
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireCube(playerSensor.position,upwardsSensorSize);
        }
    }
}