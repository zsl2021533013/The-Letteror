using Character.Player.Data;
using Character.Player.Manager;
using UnityEngine;

namespace Character.Core.Core_Component.Move_Core
{
    public class PlayerMoveCore : MoveCore
    {
        [SerializeField] private PlayerData playerData;
        public PlayerData PlayerData => playerData;
        
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