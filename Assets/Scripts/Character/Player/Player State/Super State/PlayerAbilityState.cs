using Character.Player.Data;
using Character.Player.Manager;
using Character.Player.Player_FSM;

namespace Character.Player.Player_State.Super_State
{
    
    public class PlayerAbilityState : PlayerState
    {
        protected bool isAbilityDone;

        private bool isGrounded;
        
        public PlayerAbilityState(PlayerManager playerManager, PlayerStateMachine stateMachine,
            PlayerData playerData, string animBoolName) : base(playerManager, stateMachine, playerData, animBoolName)
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

            if (isAbilityDone)
            {
                if (isGrounded && playerManager.Rb.velocity.y < 0.01f)
                {
                    stateMachine.ChangeState(playerManager.IdleState);
                }
                else
                {
                    stateMachine.ChangeState(playerManager.AirState);
                }
            }
        }

        public override void DoChecks()
        {
            base.DoChecks();

            isGrounded = playerManager.CheckGrounded();
        }
    }
}