using Character.Enemy.Data;
using Character.Enemy.Manager;
using UnityEngine;

namespace Character.Enemy.Enemy_FSM.Enemy_State.Super_State
{
    public class EnemyAbilityState : EnemyState
    {
        public EnemyAbilityState(EnemyManager enemyManager, EnemyData enemyData, string animBoolName) : base(
            enemyManager, enemyData, animBoolName)
        {
        }
    }
}