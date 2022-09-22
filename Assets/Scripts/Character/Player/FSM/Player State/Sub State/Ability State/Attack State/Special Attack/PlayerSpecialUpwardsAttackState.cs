using Character.Base.Manager;
using UnityEngine;

namespace Character.Player.FSM.Player_State.Sub_State.Ability_State.Attack_State.Special_Attack
{
    public class PlayerSpecialUpwardsAttackState : PlayerAttackState
    {
        public PlayerSpecialUpwardsAttackState(CharacterManager manager, string animBoolName) : base(manager,
            animBoolName)
        {
        }

        public bool AttackEnable => Time.time > startTime + coreManager.MoveCore.PlayerData.airAttackCoolDown;

        public override void OnEnter()
        {
            base.OnEnter();
            
            coreManager.MoveCore.SetVelocityY(coreManager.MoveCore.PlayerData.specialUpwardsAttackVelocityY);
            coreManager.MoveCore.FreezeX(startPosition);
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            
            coreManager.MoveCore.FreezeX(startPosition);
        }
    }
}