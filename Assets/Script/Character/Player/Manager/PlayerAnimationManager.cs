using System;
using Character.Base.Manager;
using UnityEngine;

namespace Character.Player.Manager
{
    public class PlayerAnimationManager : CharacterAnimationManager
    {
        protected new PlayerManager manager;

        protected override void Awake()
        {
            base.Awake();

            manager = (PlayerManager)base.manager;
        }

        public void ResetAttackInput() => manager.Input.ResetAttackInput();
    }
}
