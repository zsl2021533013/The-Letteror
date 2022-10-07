using Character.Base.Manager;
using Character.Enemy.Boss.Blood_King.FSM.Super_State;

namespace Character.Enemy.Boss.Blood_King.FSM.Sub_State.Ability_State.Attack_State
{
    public class BloodKingAttack4_2State : BloodKingAbilityState
    {
        public BloodKingAttack4_2State(CharacterManager manager, string animBoolName) : base(manager, animBoolName)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();
            
            coreManager.MoveCore.SetVelocityX(coreManager.MoveCore.attack4_2Veclocity * coreManager.MoveCore.CharacterDirection);
        }
        
        protected override void OnAnimationFinish()
        {
            stateMachine.TranslateToState(manager.Attack4_3State);
        }
    }
}