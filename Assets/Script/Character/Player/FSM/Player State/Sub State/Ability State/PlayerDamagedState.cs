using Character.Base.Manager;
using Script.Character.Player.FSM.Player_State.Super_State;

namespace Script.Character.Player.FSM.Player_State.Sub_State.Ability_State
{
    public class PlayerDamagedState : PlayerAbilityState
    {
        public PlayerDamagedState(CharacterManager manager, string animBoolName) : base(manager, animBoolName)
        {
        }
    }
}