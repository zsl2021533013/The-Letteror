using System;
using Character.Base.Manager;
using UnityEngine;

namespace Character.Player.Manager
{
    public class PlayerAnimationManager : CharacterAnimationManager
    {
        public void ResetAttackInput() => ((PlayerManager)manager).Input.ResetAttackInput();
    }
}
