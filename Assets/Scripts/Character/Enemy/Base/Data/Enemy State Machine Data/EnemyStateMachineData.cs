using UnityEngine;

namespace Character.Enemy.Core.Data
{
    [CreateAssetMenu(fileName = "New Enemy State Machine Data",menuName = "Data/Enemy Data/Enemy State Machine Data")]
    public class EnemyStateMachineData : ScriptableObject
    {
        [Header("Idle State")] 
        public float waitTime;
        
        [Header("Move State")] 
        public float moveVelocity;

        [Header("Attack State")] 
        public float attackCoolDown;

        [Header("Patrol State")] 
        public float patrolRange;
    }
}
