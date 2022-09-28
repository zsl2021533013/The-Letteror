using Character.Base.Manager;
using Character.Enemy.Boss.Blood_King.FSM.Super_State;

namespace Character.Enemy.Boss.Blood_King.FSM.Sub_State.Ability_State.Teleport_State
{
    public class BloodKingDisappearFartherState : BloodKingAbilityState
    {
        protected BloodKingDisappearFartherState(CharacterManager manager, string animBoolName) : base(manager, animBoolName)
        {
        }

        protected override void OnAnimationFinish()
        {
            stateMachine.TranslateToState(manager.AppearFartherState);
        }
    }
}