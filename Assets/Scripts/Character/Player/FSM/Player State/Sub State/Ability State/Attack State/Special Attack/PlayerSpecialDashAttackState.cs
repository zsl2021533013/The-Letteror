using Character.Base.Manager;
using UnityEngine;

namespace Character.Player.FSM.Player_State.Sub_State.Ability_State.Attack_State.Special_Attack
{
    public class PlayerSpecialDashAttackState : PlayerAttackState
    {
        public PlayerSpecialDashAttackState(CharacterManager manager, string animBoolName) : base(manager, animBoolName)
        {
        }

        public bool AttackEnable => Time.time > startTime + coreManager.MoveCore.PlayerData.specialAttackCoolDown;

        public override void OnEnter()
        {
            base.OnEnter();
            Debug.Log("Dash Attack");
            Debug.Log(manager.Input.MovementInput);
            coreManager.MoveCore.SetVelocityX(coreManager.MoveCore.PlayerData.specialAttackVelocityX *
                                              coreManager.MoveCore.Direction);
            coreManager.MoveCore.FreezeY(startPosition);
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            
            coreManager.MoveCore.FreezeY(startPosition);
        }
    }
}