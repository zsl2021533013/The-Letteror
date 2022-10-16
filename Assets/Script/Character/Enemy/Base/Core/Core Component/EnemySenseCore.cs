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
        [SerializeField] private float specialAttackDistance;

        public bool InChaseRange => Physics2D.Raycast(playerSensor.position,
            Vector2.right * coreManager.MoveCore.CharacterDirection, playerFrontCheckDistance, playerLayerMask);
        
        public bool InFlipRange => Physics2D.Raycast(playerSensor.position,
            Vector2.left * coreManager.MoveCore.CharacterDirection, playerBackCheckDistance, playerLayerMask);
        
        public bool InAttackRange => Physics2D.Raycast(playerSensor.position,
            Vector2.right * coreManager.MoveCore.CharacterDirection, attackDistance, playerLayerMask);
        
        public bool InSpecialAttackRange => Physics2D.Raycast(playerSensor.position,
            Vector2.right * coreManager.MoveCore.CharacterDirection, specialAttackDistance, playerLayerMask); 
        
        protected override void OnDrawGizmosSelected()
        {
            base.OnDrawGizmosSelected();

            Gizmos.color = Color.yellow;
            Gizmos.DrawRay(playerSensor.position, Vector2.right * playerFrontCheckDistance);
            Gizmos.DrawRay(playerSensor.position, Vector2.left * playerBackCheckDistance);

            if (attackDistance > 0)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawRay(playerSensor.position + Vector3.up / 2, Vector2.right * attackDistance);
            }

            if (specialAttackDistance > 0)
            {
                Gizmos.color = Color.magenta;
                Gizmos.DrawRay(playerSensor.position + Vector3.up, Vector2.right * specialAttackDistance);
            }
            
        }
    }
}