using System;
using Tool.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Character.Player.Input_System
{
    public enum PlayerInputDirectionType
    {
        None,
        Up,
        Down,
        Left,
        Right
    }

    public class PlayerInputHandler : Singleton<PlayerInputHandler>
    {
        public bool isInputEnable;
        public Vector2 MovementInput { get; private set; }
        public bool JumpInput { get; private set; }
        public bool JumpInputStop { get; private set; }
        public bool DashInput { get; private set; }
        public bool SpecialDashInput { get; private set; }
        public bool RollInput { get; private set; }
        public bool AttackInput { get; private set; }
        public bool SpecialAttackInput { get; private set; }
        
        public InputControls Controls{ get; private set; }

        public int InputDirection
        {
            get
            {
                if (MovementInput.x == 0f)
                {
                    return 0;
                }

                return MovementInput.x > 0f ? 1 : -1;
            }
        }
        
        public PlayerInputDirectionType InputDirectionType
        {
            get
            {
                if (MovementInput == Vector2.zero)
                {
                    return PlayerInputDirectionType.None;
                }
                
                if (Mathf.Abs(MovementInput.x) > Mathf.Abs(MovementInput.y))
                {
                    if (MovementInput.x < 0)
                    {
                        return PlayerInputDirectionType.Left;
                    }

                    return PlayerInputDirectionType.Right;
                }

                if (MovementInput.y < 0)
                {
                    return PlayerInputDirectionType.Down;
                }

                return PlayerInputDirectionType.Up;
            }
        }

        protected override void Awake()
        {
            base.Awake();
            
            Controls = new InputControls();
            Controls.Enable();

            Controls.Player.Move.performed += OnMoveInput;
            Controls.Player.Move.canceled += OnMoveInput;
            
            Controls.Player.Jump.started += OnJumpInput;
            Controls.Player.Jump.canceled += OnJumpInput;
            
            Controls.Player.Dash.started += OnDashInput;
            
            Controls.Player.SpecialDash.started += OnSpecialDashInput;
            Controls.Player.SpecialDash.canceled += OnSpecialDashInput;
            
            Controls.Player.Roll.started += OnRollInput;

            Controls.Player.Attack.started += OnAttackInput;
            
            Controls.Player.SpecialAttack.started += OnSpecialAttackInput;
        }   

        #region Input Event

        public void OnMoveInput(InputAction.CallbackContext ctx)
        {
            if (ctx.performed)
            {
                MovementInput = ctx.ReadValue<Vector2>();
            }

            if (ctx.canceled)
            {
                MovementInput = Vector2.zero;
            }
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
        
        public void OnSpecialDashInput(InputAction.CallbackContext ctx)
        {
            if (ctx.started)
            {
                SpecialDashInput = true;
            }

            if (ctx.canceled)
            {
                SpecialDashInput = false;
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
        public void ResetSpecialDashInput() => SpecialDashInput = false;
        public void ResetRollInput() => RollInput = false;
        public void ResetAttackInput() => AttackInput = false;
        public void ResetSpecialAttackInput() => SpecialAttackInput = false;

        #endregion

    }
    
}
