using Character.Base.Manager;
using Character.Enemy.Boss.Heart_Hoarder.FSM.Super_State;
using UnityEngine;

namespace Character.Enemy.Boss.Heart_Hoarder.FSM.Sub_State.Ability_State
{
    public class HeartHoarderWakeState : HeartHoarderAbilityState
    {
        public HeartHoarderWakeState(CharacterManager manager, string animBoolName) : base(manager, animBoolName)
        {
        }
    }
}