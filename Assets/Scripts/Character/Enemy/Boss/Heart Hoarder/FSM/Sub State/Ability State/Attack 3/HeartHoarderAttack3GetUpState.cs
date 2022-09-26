using Character.Base.Manager;
using Character.Enemy.Boss.Heart_Hoarder.FSM.Super_State;
using UnityEngine;

namespace Character.Enemy.Boss.Heart_Hoarder
{
    public class HeartHoarderAttack3GetUpState : HeartHoarderAbilityState
    {
        public HeartHoarderAttack3GetUpState(CharacterManager manager, string animBoolName) : base(manager, animBoolName)
        {
        }
    }
}