using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace Character.Core.Core_Component
{
    public class EnemySenseCore : SenseCore
    {
        [Header("Player Sensor")] // 只有 enemy 会调用   
        [SerializeField] private Transform playerSensor;
        [SerializeField] private LayerMask playerLayerMask;
        [SerializeField] private float playerFrontCheckDistance;
        [SerializeField] private float playerBackCheckDistance;

        public bool PlayerFront => Physics2D.Raycast(playerSensor.position,
            Vector2.right * coreManager.MoveCore.Direction, playerFrontCheckDistance, playerLayerMask);
        
        public bool PlayerBack => Physics2D.Raycast(playerSensor.position,
            Vector2.left * coreManager.MoveCore.Direction, playerBackCheckDistance, playerLayerMask);

        protected override void OnDrawGizmosSelected()
        {
            base.OnDrawGizmosSelected();

            Gizmos.color = Color.red;
            Gizmos.DrawRay(playerSensor.position, Vector2.right * playerFrontCheckDistance);
            Gizmos.DrawRay(playerSensor.position, Vector2.left * playerBackCheckDistance);
        }
    }
}