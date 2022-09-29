using Character.Base.Manager;
using Character.Enemy.Boss.Blood_King.FSM.Super_State;

namespace Character.Enemy.Boss.Blood_King.FSM.Sub_State.Ability_State.Attack_State
{
    public class BloodKingAttack3_2State : BloodKingAbilityState
    {
        public BloodKingAttack3_2State(CharacterManager manager, string animBoolName) : base(manager, animBoolName)
        {
        }
        
        public override void OnEnter()
        {
            base.OnEnter();

            coreManager.MoveCore.MoveToOffset(coreManager.MoveCore.attack3_2Offset * coreManager.MoveCore.Direction);
        }
        
        protected override void OnAnimationFinish()
        {
            stateMachine.TranslateToState(manager.Attack3_3State);
        }
    }
}