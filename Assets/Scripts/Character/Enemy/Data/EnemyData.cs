using UnityEngine;

namespace Character.Enemy.Data
{
    [CreateAssetMenu(fileName = "New Enemy Data",menuName = "Data/Enemy Data/Base Data")]
    public class EnemyData : ScriptableObject
    {
        [Header("Move State")] 
        public float moveVelocity;
    }
}
