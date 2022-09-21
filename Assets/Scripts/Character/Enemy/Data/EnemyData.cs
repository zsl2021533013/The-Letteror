using System.Collections.Generic;
using UnityEngine;

namespace Character.Enemy.Data
{
    [CreateAssetMenu(fileName = "New Enemy Data",menuName = "Data/Enemy Data/Base Data")]
    public class EnemyData : ScriptableObject
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
