using Character.Base.Manager;
using Character.Enemy.FSM.Enemy_State.Super_State;
using UnityEngine;

namespace Character.Enemy.FSM.Enemy_State.Sub_State.Enemy_Ability_State
{
    public class EnemyGetHitState : EnemyAbilityState
    {
        public EnemyGetHitState(CharacterManager manager, string animBoolName) : base(manager, animBoolName)
        {
        }
    }
}