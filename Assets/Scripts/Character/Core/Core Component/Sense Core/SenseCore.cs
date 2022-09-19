using UnityEngine;

namespace Character.Core.Core_Component
{
    public class SenseCore : CoreComponent
    {
        public Transform GroundSensor => groundSensor;
        public Transform WallSensor => wallSensor;
        public Transform LedgeSensor => ledgeSensor;
        
        [Header("Sensors")]
        [SerializeField] private Transform groundSensor;
        [SerializeField] protected Transform wallSensor;
        [SerializeField] protected Transform ledgeSensor;

        [Header("Ground Senesor")]
        [SerializeField]
        protected LayerMask groundLayerMask;
        [SerializeField] private Vector2 groundSensorSize;
        
        [Header("Wall Sensor")]
        [SerializeField]
        protected float wallCheckDistance;


        public bool Ground => Physics2D.OverlapBox(groundSensor.position, 
            groundSensorSize, 0f, groundLayerMask);

        public bool WallFront => Physics2D.Raycast(wallSensor.position, Vector2.right * coreManager.MoveCore.Direction,
            wallCheckDistance, groundLayerMask);

        public bool Ledge => Physics2D.Raycast(ledgeSensor.position, Vector2.right * coreManager.MoveCore.Direction,
            wallCheckDistance, groundLayerMask);

        protected virtual void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireCube( groundSensor.position, groundSensorSize);
        }
    }
}