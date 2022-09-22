using Character.Base.Manager;
using UnityEngine;

namespace Character.Player.FSM.Player_State.Sub_State.Ability_State.Attack_State.Special_Attack
{
    public class PlayerSpecialDownwardsAttackState : PlayerAttackState
    {
        public PlayerSpecialDownwardsAttackState(CharacterManager manager, string animBoolName) : base(manager,
            animBoolName)
        {
        }

        public bool AttackEnable => Time.time > startTime + coreManager.MoveCore.PlayerData.specialAttackCoolDown;

        public override void OnEnter()
        {
            base.OnEnter();
            
            coreManager.MoveCore.SetVelocityX(coreManager.MoveCore.PlayerData.specialDownwardsAttackVelocityY);
            coreManager.MoveCore.FreezeY(startPosition);
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            
            coreManager.MoveCore.FreezeY(startPosition);
        }
    }
}