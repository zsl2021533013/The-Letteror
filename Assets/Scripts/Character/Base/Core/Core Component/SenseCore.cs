using UnityEngine;

namespace Character.Base.Core.Core_Component
{
    public class SenseCore : CoreComponent
    {
        public Transform GroundSensor => groundSensor;
        public Transform WallSensor => wallSensor;
        public Transform LedgeSensor => ledgeSensor;
        
        [Header("Sensors")]
        public Transform groundSensor;
        public Transform wallSensor;
        public Transform ledgeSensor;

        [Header("Ground Sensor")]
        public LayerMask groundLayerMask;
        public Vector2 groundSensorSize;
        
        [Header("Wall Sensor")]
        public float wallCheckDistance;


        public bool DetectGround => Physics2D.OverlapBox(groundSensor.position, 
            groundSensorSize, 0f, groundLayerMask);

        public bool DetectWall => Physics2D.Raycast(wallSensor.position, Vector2.right * coreManager.MoveCore.Direction,
            wallCheckDistance, groundLayerMask);

        public bool DetectLedge => Physics2D.Raycast(ledgeSensor.position, Vector2.right * coreManager.MoveCore.Direction,
            wallCheckDistance, groundLayerMask);

        protected virtual void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireCube( groundSensor.position, groundSensorSize);
        }
    }
}