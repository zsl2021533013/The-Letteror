using Character.Base.Manager;
using Character.Player.FSM.Player_State.Super_State;
using UnityEngine;

namespace Character.Player.FSM.Player_State.Sub_State.Ability_State.Ground_Attack
{
    public class PlayerGroundAttack3State : PlayerAbilityState
    {
        private Vector2 startPosition;


        public PlayerGroundAttack3State(CharacterManager manager, string animBoolName) : base(manager,
            animBoolName)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();

            startPosition = coreManager.MoveCore.Position;
            coreManager.MoveCore.SetVelocityX(coreManager.MoveCore.PlayerData.attackVelocity3 * coreManager.MoveCore.Direction);
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