using Character.Base.Manager;
using Script.Character.Player.FSM.Player_State.Super_State;

namespace Script.Character.Player.FSM.Player_State.Sub_State.Ability_State
{
    public class PlayerGainAbilityState : PlayerAbilityState
    {
        public PlayerGainAbilityState(CharacterManager manager, string animBoolName) : base(manager, animBoolName)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();
            
            coreManager.MoveCore.SetVelocityX(0f);
        }

        protected override void OnAnimationFinish()
        {
            base.OnAnimationFinish();
            
            manager.Input.ResetGainAbility();
        }
    }
}