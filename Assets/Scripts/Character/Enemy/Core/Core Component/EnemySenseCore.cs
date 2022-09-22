using Character.Base.Core.Core_Component;
using UnityEngine;

namespace Character.Enemy.Core.Core_Component
{
    public class EnemySenseCore : SenseCore
    {
        [Header("Player Sensor")] // 只有 enemy 会调用   
        [SerializeField] private Transform playerSensor;
        [SerializeField] private LayerMask playerLayerMask;
        [SerializeField] private float playerFrontCheckDistance;
        [SerializeField] private float playerBackCheckDistance;
        [SerializeField] private float attackDistance;

        public bool InChaseRange => Physics2D.Raycast(playerSensor.position,
            Vector2.right * coreManager.MoveCore.Direction, playerFrontCheckDistance, playerLayerMask);
        
        public bool InFlipRange => Physics2D.Raycast(playerSensor.position,
            Vector2.left * coreManager.MoveCore.Direction, playerBackCheckDistance, playerLayerMask);
        
        public bool InAttackRange => Physics2D.Raycast(playerSensor.position,
            Vector2.right * coreManager.MoveCore.Direction, attackDistance, playerLayerMask);
        
        protected override void OnDrawGizmosSelected()
        {
            base.OnDrawGizmosSelected();

            Gizmos.color = Color.yellow;
            Gizmos.DrawRay(playerSensor.position, Vector2.right * playerFrontCheckDistance);
            Gizmos.DrawRay(playerSensor.position, Vector2.left * playerBackCheckDistance);
            
            Gizmos.color = Color.red;
            Gizmos.DrawRay(playerSensor.position, Vector2.right * attackDistance);
        }
    }
}