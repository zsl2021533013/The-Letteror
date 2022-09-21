using System;
using Character.Base_Manager;
using Character.Base.Base_Manager;
using UnityEngine;

namespace Character.Player.Manager
{
    public class PlayerAnimationManager : CharacterAnimationManager
    {
        public void ResetAttackInput() => ((PlayerManager)manager).Input.ResetAttackInput();
    }
}
