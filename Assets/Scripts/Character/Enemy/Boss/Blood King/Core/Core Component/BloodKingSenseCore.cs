using Character.Enemy.Boss.Base.Core.Core_Component;
using UnityEngine;
using UnityEngine.Serialization;

namespace Character.Enemy.Boss.Blood_King.Core.Core_Component
{
    public class BloodKingSenseCore : BossSenseCore
    {
        [Header("Blood King Only")]
        public float attack1Range;
        public float attack3Range;
        public float attack4Range;

        [Header("Jump Attack Sensor")]
        public LayerMask playerLayerMask;
        public Transform playerSensor;
        public Vector2 upwardsSensorSize;
        
        public bool InAttack1Range => JudgeArrive(attack1Range);
        public bool InAttack3Range => JudgeArrive(attack3Range);
        public bool InAttack4Range => JudgeArrive(attack4Range);
        public float Distance => Mathf.Abs(coreManager.MoveCore.Position.x - playerTransform.position.x);
        public bool DetectPlayerUpwards =>
            Physics2D.OverlapBox(playerSensor.position, upwardsSensorSize, 0f, playerLayerMask);

        public float DistanceToPlayer(float positionX) => Mathf.Abs(positionX - playerTransform.position.x);

        protected override void OnDrawGizmosSelected()
        {
            base.OnDrawGizmosSelected();
            
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireCube(playerSensor.position,upwardsSensorSize);
        }
    }
}