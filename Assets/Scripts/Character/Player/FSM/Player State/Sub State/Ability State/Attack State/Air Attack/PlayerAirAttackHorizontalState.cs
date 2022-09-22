using Character.Base.Manager;
using UnityEngine;

namespace Character.Player.FSM.Player_State.Sub_State.Ability_State.Attack_State.Air_Attack
{
    public class PlayerAirAttackHorizontalState : PlayerAttackState
    {
        public bool AttackEnable => Time.time > startTime + coreManager.MoveCore.PlayerData.airAttackCoolDown;
        
        public PlayerAirAttackHorizontalState(CharacterManager manager, string animBoolName) : base(manager,
            animBoolName)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();
            
            coreManager.MoveCore.SetVelocityX(coreManager.MoveCore.PlayerData.attackVelocity1 * coreManager.MoveCore.Direction);
            coreManager.MoveCore.FreezeY(startPosition);
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            
            coreManager.MoveCore.FreezeY(startPosition);
        }
    }
}