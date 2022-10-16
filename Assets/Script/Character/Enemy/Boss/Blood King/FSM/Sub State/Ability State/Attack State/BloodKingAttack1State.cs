using Character.Base.Manager;
using Character.Enemy.Boss.Blood_King.FSM.Super_State;

namespace Character.Enemy.Boss.Blood_King.FSM.Sub_State.Ability_State.Attack_State
{
    public class BloodKingAttack1State : BloodKingAbilityState
    {
        public BloodKingAttack1State(CharacterManager manager, string animBoolName) : base(manager, animBoolName)
        {
        }
    }
}