using Character.Base.Manager;
using Character.Enemy.Boss.Blood_King.FSM.Super_State;

namespace Character.Enemy.Boss.Blood_King.FSM.Sub_State.Ability_State.Attack_State
{
    public class BloodKingAttack3_1State : BloodKingAbilityState
    {
        public BloodKingAttack3_1State(CharacterManager manager, string animBoolName) : base(manager, animBoolName)
        {
        }
        
        protected override void OnAnimationFinish()
        {
            stateMachine.TranslateToState(manager.Attack3_2State);
        }
    }
}