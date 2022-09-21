using Character.Player.Data;
using Character.Player.Manager;
using Character.Player.Player_FSM;

namespace Character.Player.Player_State.Super_State
{
    
    public class PlayerAbilityState : PlayerState
    {
        protected bool isAbilityDone;

        private bool isGrounded;
        
        public PlayerAbilityState(PlayerManager playerManager, PlayerData playerData, string animBoolName) : base(
            playerManager, playerData, animBoolName)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();
            
            isAbilityDone = false;
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            if (isAnimationFinish)
            {
                OnAnimationFinish();
            }
            
            if (isAbilityDone)
            {
                if (isGrounded && coreManager.MoveCore.CurrentVelocity.y < 0.01f)
                {
                    stateMachine.TranslateToState(playerManager.IdleState);
                }
                else
                {
                    stateMachine.TranslateToState(playerManager.AirState);
                }
            }
        }

        public override void DoChecks()
        {
            base.DoChecks();

            isGrounded = coreManager.SenseCore.DetectGround;
        }

        protected virtual void OnAnimationFinish()
        {
            isAbilityDone = true;
        }
    }
}