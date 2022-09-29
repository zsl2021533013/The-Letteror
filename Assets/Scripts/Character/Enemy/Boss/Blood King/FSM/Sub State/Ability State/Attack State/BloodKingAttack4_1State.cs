using Character.Base.Manager;
using Character.Enemy.Boss.Blood_King.FSM.Super_State;

namespace Character.Enemy.Boss.Blood_King.FSM.Sub_State.Ability_State.Attack_State
{
    public class BloodKingAttack4_1State : BloodKingAbilityState
    {
        public BloodKingAttack4_1State(CharacterManager manager, string animBoolName) : base(manager, animBoolName)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();
            
            coreManager.MoveCore.SetVelocityX(0f);
        }

        protected override void OnAnimationFinish()
        {
            stateMachine.TranslateToState(manager.Attack4_2State);
        }
    }
}