using Character.Base.Manager;
using UnityEngine;

namespace Character.Player.FSM.Player_State.Sub_State.Ability_State.Attack_State.Air_Attack
{
    public class PlayerAirHorizontalAttack2State : PlayerAttackState
    {
        public PlayerAirHorizontalAttack2State(CharacterManager manager, string animBoolName) : base(manager,
            animBoolName)
        {
        }
        
        public override void OnEnter()
        {
            base.OnEnter();

            coreManager.MoveCore.SetVelocityX(coreManager.MoveCore.PlayerData.airAttack2VelocityX *
                                              coreManager.MoveCore.Direction);
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