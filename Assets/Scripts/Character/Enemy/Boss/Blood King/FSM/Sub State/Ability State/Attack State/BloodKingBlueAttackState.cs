using Character.Base.Manager;
using Character.Enemy.Boss.Blood_King.FSM.Super_State;

namespace Character.Enemy.Boss.Blood_King.FSM.Sub_State.Ability_State.Attack_State
{
    public class BloodKingBlueAttackState : BloodKingAbilityState
    {
        protected BloodKingBlueAttackState(CharacterManager manager, string animBoolName) : base(manager, animBoolName)
        {
        }
    }
}