using Character.Base.Manager;
using Character.Enemy.Boss.Blood_King.FSM.Super_State;

namespace Character.Enemy.Boss.Blood_King.FSM.Sub_State.Ability_State.Attack_State
{
    public class BloodKingAttack2State : BloodKingAbilityState
    {
        public BloodKingAttack2State(CharacterManager manager, string animBoolName) : base(manager, animBoolName)
        {
        }
    }
}