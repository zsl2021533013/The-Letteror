using UnityEngine;

namespace Character.Core.Core_Component
{
    public class PlayerMoveCore : MoveCore
    {
        public void CheckFlip(float inputX)
        {
            int inputDirection = inputX > 0 ? 1 : -1;
            if (inputX == 0f)
            {
                inputDirection = 0;
            }
                
            if (inputDirection == -Direction)
            {
                _tempVector3.Set(inputDirection, 1, 1);
                _transform.localScale = _tempVector3;
            }
        }
    }
}