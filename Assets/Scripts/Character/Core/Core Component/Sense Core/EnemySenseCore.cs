using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace Character.Core.Core_Component
{
    public class EnemySenseCore : EnemyCoreComponent
    {
        public Transform GroundSensor => groundSensor;
        public Transform WallSensor => wallSensor;
        public Transform LedgeSensor => ledgeSensor;
        
        [Header("Sensors")]
        [SerializeField] private Transform groundSensor;
        [SerializeField] protected Transform wallSensor;
        [SerializeField] protected Transform ledgeSensor;
        [SerializeField] private Transform playerSensor;

        [Header("Ground Sensor")]
        [SerializeField]
        protected LayerMask groundLayerMask;
        [SerializeField] private Vector2 groundSensorSize;
        
        [Header("Wall Sensor")]
        [SerializeField] protected float wallCheckDistance;
        
        [Header("Player Sensor")] // 只有 enemy 会调用
        [SerializeField] private LayerMask playerLayerMask;
        [SerializeField] private float playerFrontCheckDistance;
        [SerializeField] private float playerBackCheckDistance;


        public bool Ground => Physics2D.OverlapBox(groundSensor.position, 
            groundSensorSize, 0f, groundLayerMask);

        public bool WallFront => Physics2D.Raycast(wallSensor.position, Vector2.right * coreManager.MoveCore.Direction,
            wallCheckDistance, groundLayerMask);

        public bool Ledge => Physics2D.Raycast(ledgeSensor.position, Vector2.right * coreManager.MoveCore.Direction,
            wallCheckDistance, groundLayerMask);
        
        public bool PlayerFront => Physics2D.Raycast(playerSensor.position,
            Vector2.right * coreManager.MoveCore.Direction, playerFrontCheckDistance, playerLayerMask);
        
        public bool PlayerBack => Physics2D.Raycast(playerSensor.position,
            Vector2.left * coreManager.MoveCore.Direction, playerBackCheckDistance, playerLayerMask);

        protected void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireCube( groundSensor.position, groundSensorSize);

            Gizmos.color = Color.red;
            Gizmos.DrawRay(playerSensor.position, playerSensor.right * playerFrontCheckDistance);
            Gizmos.DrawRay(playerSensor.position, -playerSensor.right * playerBackCheckDistance);
        }
    }
}