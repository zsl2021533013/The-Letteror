using Character.Base.Manager;
using PixelCrushers.Wrappers;
using Script.Character.Player.FSM.Player_State.Super_State;

namespace Script.Character.Player.FSM.Player_State.Sub_State.Ability_State
{
    public class PlayerDeathState : PlayerAbilityState
    {
        public PlayerDeathState(CharacterManager manager, string animBoolName) : base(manager, animBoolName)
        {
        }

        protected override void OnAnimationFinish()
        {
            base.OnAnimationFinish();
            
            SaveSystem.LoadFromSlot(0);
        }
    }
}