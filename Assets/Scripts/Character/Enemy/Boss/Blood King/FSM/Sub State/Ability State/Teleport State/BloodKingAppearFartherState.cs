using Character.Base.Manager;
using Character.Enemy.Boss.Blood_King.FSM.Super_State;

namespace Character.Enemy.Boss.Blood_King.FSM.Sub_State.Ability_State.Teleport_State
{
    public class BloodKingAppearFartherState : BloodKingAbilityState
    {
        public BloodKingAppearFartherState(CharacterManager manager, string animBoolName) : base(manager, animBoolName)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();
            
            coreManager.MoveCore.MoveTo(coreManager.SenseCore.DistanceToPlayer(coreManager.MoveCore.leftPointX) >
                                        coreManager.SenseCore.DistanceToPlayer(coreManager.MoveCore.rightPointX)
                ? coreManager.MoveCore.LeftPointPosition
                : coreManager.MoveCore.RightPointPosition);
            
            if (coreManager.MoveCore.CharacterDirection != coreManager.SenseCore.PlayerDirection)
            {
                coreManager.MoveCore.Flip();
            }
        }

        protected override void OnAnimationFinish()
        {
            stateMachine.TranslateToState(manager.Attack2State);
        }
    }
}