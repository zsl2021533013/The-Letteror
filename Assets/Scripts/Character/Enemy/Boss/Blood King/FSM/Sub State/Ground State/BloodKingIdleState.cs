using Character.Base.Manager;
using Character.Enemy.Boss.Blood_King.FSM.Base;
using UnityEngine;

namespace Character.Enemy.Boss.Blood_King.FSM.Sub_State.Ground_State
{
    public class BloodKingIdleState : BloodKingState
    {
        protected BloodKingIdleState(CharacterManager manager, string animBoolName) : base(manager, animBoolName)
        {
        }
    }
}