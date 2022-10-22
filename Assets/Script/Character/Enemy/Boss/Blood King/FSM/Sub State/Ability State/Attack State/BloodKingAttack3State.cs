using Character.Base.Manager;
using Character.Enemy.Boss.Blood_King.FSM.Super_State;
using UnityEngine;

namespace Character.Enemy.Boss.Blood_King.FSM.Sub_State.Ability_State.Attack_State
{
    public class BloodKingAttack3State : BloodKingAbilityState
    {
        public BloodKingAttack3State(CharacterManager manager, string animBoolName) : base(manager, animBoolName)
        {
        }
        
        public override void OnEnter()
        {
            base.OnEnter();
            
            coreManager.MoveCore.SetVelocityX(0f);
        }

        public override void OnExit()
        {
            base.OnExit();
            
            manager.IdleState.SetOffset(coreManager.MoveCore.attack4Offset);
        }
    }
}