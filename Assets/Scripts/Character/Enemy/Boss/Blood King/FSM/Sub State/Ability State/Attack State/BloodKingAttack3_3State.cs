using Character.Base.Manager;
using Character.Enemy.Boss.Blood_King.FSM.Super_State;

namespace Character.Enemy.Boss.Blood_King.FSM.Sub_State.Ability_State.Attack_State
{
    public class BloodKingAttack3_3State : BloodKingAbilityState
    {
        public BloodKingAttack3_3State(CharacterManager manager, string animBoolName) : base(manager, animBoolName)
        {
        }
        
        public override void OnEnter()
        {
            base.OnEnter();
            
            coreManager.MoveCore.MoveToOffset(coreManager.MoveCore.attack3_3Offset);
        }
        
        protected override void OnAnimationFinish()
        {
            stateMachine.TranslateToState(manager.Attack3_4State);
        }
    }
}