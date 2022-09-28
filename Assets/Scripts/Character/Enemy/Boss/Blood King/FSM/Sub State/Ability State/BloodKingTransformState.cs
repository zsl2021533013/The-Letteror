using Character.Base.Manager;
using Character.Enemy.Boss.Blood_King.FSM.Super_State;
using UnityEngine;

namespace Character.Enemy.Boss.Blood_King.FSM.Sub_State.Ability_State
{
    public class BloodKingTransformState : BloodKingAbilityState
    {
        protected BloodKingTransformState(CharacterManager manager, string animBoolName) : base(manager, animBoolName)
        {
        }
    }
}