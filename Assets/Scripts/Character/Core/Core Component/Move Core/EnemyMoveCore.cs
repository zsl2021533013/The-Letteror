using UnityEngine;

namespace Character.Core.Core_Component
{
    public class EnemyMoveCore : MoveCore
    {
        public void Flip()
        {
            _tempVector3.Set(-_transform.localScale.x, 1, 1);
            _transform.localScale = _tempVector3;
        }
    }
}