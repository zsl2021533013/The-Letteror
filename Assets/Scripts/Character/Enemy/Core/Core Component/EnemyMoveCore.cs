using Character.Base.Core.Core_Component;
using Character.Enemy.Core.Data;
using UnityEngine;

namespace Character.Enemy.Core.Core_Component
{
    public class EnemyMoveCore : MoveCore
    {
        [SerializeField] private EnemyData enemyData;
        public EnemyData EnemyData => enemyData;
        
        public void Flip()
        {
            tempVector3.Set(-transform.localScale.x, 1, 1);
            transform.localScale = tempVector3;
        }

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