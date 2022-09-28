using Character.Base.Core.Core_Component;
using UnityEngine;

namespace Character.Enemy.Core.Core_Component
{
    public class EnemyMoveCore : MoveCore
    {
        [Header("Patrol State")] 
        public float patrolRange;
        
        [Header("Idle State")] 
        public float waitTime;
        
        [Header("Attack State")] 
        public float attackCoolDown;

        public bool JudgeArrive(float positionX)
        {
            if (Mathf.Abs(Position.x - positionX) < 0.1f)
            {
                return true;
            }

            return false;
        }
        
        private void OnDrawGizmosSelected()
        {
            /*Gizmos.color = Color.blue;
            Gizmos.DrawRay(transform.position, Vector3.right * enemyData.patrolRange);
            Gizmos.DrawRay(transform.position, Vector3.left * enemyData.patrolRange);*/
        }
    }
}