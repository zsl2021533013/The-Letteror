using Character.Base.Core.Core_Component;
using Character.Player.Core.Data;
using UnityEngine;

namespace Character.Player.Core.Core_Component
{
    public class PlayerMoveCore : MoveCore
    {
        [SerializeField] private PlayerStateMachineData playerStateMachineData;
        public PlayerStateMachineData StateMachineData => playerStateMachineData;
        
        public void CheckFlip(float inputX)
        {
            int inputDirection = inputX > 0 ? 1 : -1;
            if (inputX == 0f)
            {
                inputDirection = 0;
            }
                
            if (inputDirection == -Direction)
            {
                tempVector3.Set(inputDirection, 1, 1);
                transform.localScale = tempVector3;
            }
        }
    }
}