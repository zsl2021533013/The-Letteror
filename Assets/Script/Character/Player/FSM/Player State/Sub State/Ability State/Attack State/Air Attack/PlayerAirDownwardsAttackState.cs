using Character.Base.Manager;
using UnityEngine;

namespace Character.Player.FSM.Player_State.Sub_State.Ability_State.Attack_State.Air_Attack
{
    public class PlayerAirDownwardsAttackState : PlayerAttackState
    {
        public bool AttackEnable => Time.time > startTime + coreManager.MoveCore.StateMachineData.airAttackCoolDown;
        
        public PlayerAirDownwardsAttackState(CharacterManager manager, string animBoolName) : base(manager, animBoolName)
        {
        }
    }
}