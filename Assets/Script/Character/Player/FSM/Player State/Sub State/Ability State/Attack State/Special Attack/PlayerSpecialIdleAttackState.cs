using Character.Base.Manager;
using UnityEngine;

namespace Character.Player.FSM.Player_State.Sub_State.Ability_State.Attack_State.Special_Attack
{
    public class PlayerSpecialIdleAttackState : PlayerAttackState
    {
        public PlayerSpecialIdleAttackState(CharacterManager manager, string animBoolName) : base(manager, animBoolName)
        {
        }

        public bool AttackEnable => Time.time > startTime + coreManager.MoveCore.StateMachineData.airAttackCoolDown;

        public override void OnEnter()
        {
            base.OnEnter();
            Debug.Log("Idle Attack");
            Debug.Log(manager.Input.MovementInput);
            coreManager.MoveCore.SetVelocityX(0f);
            coreManager.MoveCore.FreezeY(startPosition);
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            
            coreManager.MoveCore.FreezeY(startPosition);
        }
    }
}