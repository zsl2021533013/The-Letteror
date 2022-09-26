using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Character.Player.Input_System
{
    public enum PlayerInputDirection
    {
        None,
        Up,
        Down,
        Left,
        Right
    }

    public class PlayerInputHandler : MonoBehaviour
    {
        public Vector2 MovementInput { get; private set; }
        public bool JumpInput { get; private set; }
        public bool JumpInputStop { get; private set; }
        public bool DashInput { get; private set; }
        public bool RollInput { get; private set; }
        public bool AttackInput { get; private set; }
        public bool SpecialAttackInput { get; private set; }

        public PlayerInputDirection InputDirection
        {
            get
            {
                if (MovementInput == Vector2.zero)
                {
                    return PlayerInputDirection.None;
                }
                
                if (Mathf.Abs(MovementInput.x) > Mathf.Abs(MovementInput.y))
                {
                    if (MovementInput.x < 0)
                    {
                        return PlayerInputDirection.Left;
                    }

                    return PlayerInputDirection.Right;
                }

                if (MovementInput.y < 0)
                {
                    return PlayerInputDirection.Down;
                }

                return PlayerInputDirection.Up;
            }
        }

        #region Input Event

        public void OnMoveInput(InputAction.CallbackContext ctx)
        {
            MovementInput = ctx.ReadValue<Vector2>();
        }

        public void OnJumpInput(InputAction.CallbackContext ctx)
        {
            if (ctx.started)
            {
                JumpInput = true;
                JumpInputStop = false;
            }

            if (ctx.canceled)
            {
                JumpInputStop = true;
            }
        }

        public void OnDashInput(InputAction.CallbackContext ctx)
        {
            if (ctx.started)
            {
                DashInput = true;
            }
        }

        public void OnRollInput(InputAction.CallbackContext ctx)
        {
            if (ctx.started)
            {
                RollInput = true;
            }
        }

        public void OnAttackInput(InputAction.CallbackContext ctx)
        {
            if (ctx.started)
            {
                AttackInput = true;
            }
        }
        
        public void OnSpecialAttackInput(InputAction.CallbackContext ctx)
        {
            if (ctx.started)
            {
                SpecialAttackInput = true;
            }
        }

        #endregion
        

        #region Reset Trigger
        
        public void ResetJumpInput() => JumpInput = false;
        public void ResetDashInput() => DashInput = false;
        public void ResetRollInput() => RollInput = false;
        public void ResetAttackInput() => AttackInput = false;
        public void ResetSpecialAttackInput() => SpecialAttackInput = false;
        
        #endregion

    }
    
}
