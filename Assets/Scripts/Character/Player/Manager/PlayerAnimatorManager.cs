using UnityEngine;

namespace Character.Player.Manager
{
    public class PlayerAnimatorManager : MonoBehaviour
    {
        public PlayerManager PlayerManager { get; set; }

        public void AnimationFinish() => PlayerManager.StateMachine.CurrentState.AnimationFinish();
    }
}
