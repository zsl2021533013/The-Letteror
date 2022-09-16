using PlayerManager.Player_FSM;
using UnityEngine;

namespace PlayerManager.Manager
{
    public class PlayerAnimatorManager : MonoBehaviour
    {
        public Player_FSM.PlayerManager PlayerManager { get; set; }

        public void AnimationFinish() => PlayerManager.StateMachine.CurrentState.AnimationFinish();
    }
}
