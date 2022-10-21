using Character.Base.Manager;
using UnityEngine;

namespace Character.Player.FSM.Player_State.Sub_State.Ability_State.Attack_State.Special_Attack
{
    public class PlayerSpecialDashAttackState : PlayerAttackState
    {
        private int _specialAttackAmountLeft;
        
        public PlayerSpecialDashAttackState(CharacterManager manager, string animBoolName) : base(manager, animBoolName)
        {
        }
        
        public override void OnEnter()
        {
            base.OnEnter();

            DecreaseAmountOfSpecialAttack();
            
            coreManager.MoveCore.SetVelocityX(coreManager.MoveCore.StateMachineData.specialAttackVelocityX *
                                              coreManager.MoveCore.CharacterDirection);
            coreManager.MoveCore.FreezeY(startPosition);
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            
            coreManager.MoveCore.FreezeY(startPosition);
        }

        public bool CheckAmountOfSpecialAttack() =>
            _specialAttackAmountLeft - (manager.AbilityData.isSpecialHorizontalAttackEnable ? 0 : 1) > 0;

        public void ResetAmountOfSpecialAttack() => _specialAttackAmountLeft = coreManager.MoveCore.StateMachineData.specialAttackAmount;

        public void DecreaseAmountOfSpecialAttack() => --_specialAttackAmountLeft;
    }
}