using UnityEngine;

namespace Character.Core.Core_Component
{
    public class EnemyMoveCore : MoveCore
    {
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
    }
}