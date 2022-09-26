using Character.Base.Manager;
using Character.Enemy.Boss.Heart_Hoarder.FSM.Super_State;
using UnityEngine;

namespace Character.Enemy.Boss.Heart_Hoarder
{
    public class HeartHoarderAttack1GetUpState : HeartHoarderAbilityState
    {
        public HeartHoarderAttack1GetUpState(CharacterManager manager, string animBoolName) : base(manager, animBoolName)
        {
        }
    }
}