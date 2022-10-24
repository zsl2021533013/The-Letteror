using Character.Base.Manager;
using Script.Environment.Camera;
using UnityEngine;

namespace Character.Player.FSM.Player_State.Sub_State.Ability_State.Attack_State.Special_Attack
{
    public class PlayerSpecialDownwardsAttack3State : PlayerAttackState
    {
        public PlayerSpecialDownwardsAttack3State(CharacterManager manager, string animBoolName) : base(manager, animBoolName)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();

            manager.ShakeCamera(coreManager.MoveCore.StateMachineData.specialDownwardsAttackShakeIntensity,
                manager.cameraShakeTime);
        }
    }
}