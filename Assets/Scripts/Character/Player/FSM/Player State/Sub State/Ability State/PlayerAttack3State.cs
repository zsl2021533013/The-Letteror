using Character.Base.Manager;
using Character.Player.FSM.Player_State.Super_State;
using UnityEngine;

namespace Character.Player.FSM.Player_State.Sub_State.Ability_State
{
    public class PlayerAttack3State : PlayerAbilityState
    {
        private Vector2 _startPosition;


        public PlayerAttack3State(CharacterManager manager, string animBoolName) : base(manager,
            animBoolName)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();

            _startPosition =manager.transform.position;
            coreManager.MoveCore.SetVelocityX(coreManager.MoveCore.PlayerData.attackVelocity3 * coreManager.MoveCore.Direction);
            coreManager.MoveCore.FreezeY(_startPosition);
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            if (isStateFinished)
            {
                return;
            }
            
            coreManager.MoveCore.FreezeY(_startPosition);
        }
    }
}