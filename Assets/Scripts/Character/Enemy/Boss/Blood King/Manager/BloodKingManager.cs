using Character.Base.Manager;
using Character.Enemy.Boss.Blood_King.FSM.Sub_State.Ground_State;
using UnityEngine;

namespace Character.Enemy.Boss.Blood_King.Manager
{
    public class BloodKingManager : CharacterManager
    {
        public BloodKingIdleState IdleState { get; private set; }
    }
}