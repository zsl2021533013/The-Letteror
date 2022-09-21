using System;
using UnityEngine;

namespace Character.Player.Manager
{
    public class PlayerAnimationManager : MonoBehaviour
    {
        private PlayerManager _manager;

        private void Awake()
        {
            _manager = GetComponentInParent<PlayerManager>();
        }

        public void AnimationFinish() => _manager.StateMachine.CurrentState.AnimationFinish();

        public void ResetAttackInput() => _manager.Input.ResetAttackInput();
    }
}
