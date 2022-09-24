using Character.Base.Manager;

namespace Character.Player.FSM.Player_State.Sub_State.Ability_State.Attack_State.Ground_Attack
{
    public class PlayerGroundAttack2State : PlayerAttackState
    {
        public PlayerGroundAttack2State(CharacterManager manager, string animBoolName) : base(manager,
            animBoolName)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();

            coreManager.MoveCore.SetVelocityX(coreManager.MoveCore.StateMachineData.groundAttack2VelocityX * coreManager.MoveCore.Direction);
            coreManager.MoveCore.FreezeY(startPosition);
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            if (isStateFinished)
            {
                return;
            }
            
            coreManager.MoveCore.FreezeY(startPosition);
        }
    }
}