using Character.Base.Manager;
using Character.Enemy.Boss.Blood_King.FSM.Super_State;

namespace Character.Enemy.Boss.Blood_King.FSM.Sub_State.Ability_State.Attack_State
{
    public class BloodKingAttack3_1State : BloodKingAbilityState
    {
        protected BloodKingAttack3_1State(CharacterManager manager, string animBoolName) : base(manager, animBoolName)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();
            
            coreManager.MoveCore.SetVelocityX(coreManager.MoveCore.attack3_1Veclocity * coreManager.MoveCore.Direction);
        }

        protected override void OnAnimationFinish()
        {
            stateMachine.TranslateToState(manager.Attack3_2State);
        }
    }
}