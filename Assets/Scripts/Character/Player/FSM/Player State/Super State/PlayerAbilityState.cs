using Character.Base.Manager;

namespace Character.Player.FSM.Player_State.Super_State
{
    
    public class PlayerAbilityState : PlayerState
    {
        protected bool isAbilityDone;

        private bool isGrounded;


        public PlayerAbilityState(CharacterManager manager, string animBoolName) : base(manager,
            animBoolName)
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
                    stateMachine.TranslateToState(manager.IdleState);
                }
                else
                {
                    stateMachine.TranslateToState(manager.AirState);
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