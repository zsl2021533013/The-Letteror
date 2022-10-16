using Character.Base.Manager;
using Character.Player.FSM.Player_State.Super_State;
using UnityEngine;

namespace Character.Player.FSM.Player_State.Sub_State.Ability_State
{
    public class PlayerAttackState : PlayerAbilityState
    {
        protected Vector2 startPosition;
        
        public PlayerAttackState(CharacterManager manager, string animBoolName) : base(manager, animBoolName)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();
            
            startPosition = coreManager.MoveCore.Position;
        }
    }
}