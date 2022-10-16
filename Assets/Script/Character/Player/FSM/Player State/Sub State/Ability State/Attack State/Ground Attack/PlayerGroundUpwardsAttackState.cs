using Character.Base.Manager;
using UnityEngine;

namespace Character.Player.FSM.Player_State.Sub_State.Ability_State.Attack_State.Ground_Attack
{
    public class PlayerGroundUpwardsAttackState : PlayerAttackState
    {
        public PlayerGroundUpwardsAttackState(CharacterManager manager, string animBoolName) : base(manager,
            animBoolName)
        {
        }
        public override void OnEnter()
        {
            base.OnEnter();

            coreManager.MoveCore.SetVelocityX(0f);
            coreManager.MoveCore.Freeze(startPosition);
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            if (isStateFinished)
            {
                return;
            }
            
            coreManager.MoveCore.Freeze(startPosition);
        }
    }
}