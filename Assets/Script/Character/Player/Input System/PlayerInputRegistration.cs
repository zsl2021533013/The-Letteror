using PixelCrushers;
using UnityEngine;

namespace Script.Character.Player.Input_System
{
    public class PlayerInputRegistration : MonoBehaviour
    {
        private InputControls controls;

        // Track which instance of this script registered the inputs, to prevent
        // another instance from accidentally unregistering them.
        protected static bool isRegistered = false;
        private bool didIRegister = false;

        private void OnEnable()
        {
            controls = PlayerInputHandler.Instance.Controls;
        
            if (!isRegistered)
            {
                isRegistered = true;
                didIRegister = true;
            
                controls.Enable();
            
                InputDeviceManager.RegisterInputAction("Move", controls.Player.Move);
                InputDeviceManager.RegisterInputAction("Jump", controls.Player.Jump);
                InputDeviceManager.RegisterInputAction("Dash", controls.Player.Dash);
                InputDeviceManager.RegisterInputAction("Attack", controls.Player.Attack);
                InputDeviceManager.RegisterInputAction("SpecialAttack", controls.Player.SpecialAttack);
            }
        }

        private void OnDisable()
        {
            if (didIRegister)
            {
                isRegistered = false;
                didIRegister = false;
            
                controls.Disable();
            
                InputDeviceManager.UnregisterInputAction("Move");
                InputDeviceManager.UnregisterInputAction("Jump");
                InputDeviceManager.UnregisterInputAction("Dash");
                InputDeviceManager.UnregisterInputAction("Attack");
                InputDeviceManager.UnregisterInputAction("SpecialAttack");
            }
        }
    
    }
}
