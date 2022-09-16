using UnityEngine;
using UnityEngine.InputSystem;

namespace Character.Player.Input_System
{
    public class InputHandler : MonoBehaviour
    {
        public Vector2 MovementInput { get; private set; }
        public bool JumpInput { get; private set; }
        public bool JumpInputStop { get; private set; }
        public bool GrabInput { get; private set; }
        
        public int InputDirection
        {
            get
            {
                if (MovementInput.x == 0f)
                {
                    return 0;
                }
                return MovementInput.x < 0 ? -1 : 1;
            }
        }

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

        public void UseJumpInput() => JumpInput = false;
        
        public void OnGrabInput(InputAction.CallbackContext ctx)
        {
            if (ctx.started)
            {
                GrabInput = true;
            }

            if (ctx.canceled)
            {
                GrabInput = false;
            }
        }
    }
    
}
