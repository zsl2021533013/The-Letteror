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
        [SerializeField] private Transform wallSensor;
        [SerializeField] private Transform ledgeSensor;

        [Header("Sensors Attitude")] 
        [SerializeField] private Vector2 groundSensorSize;
        [SerializeField] private LayerMask groundLayerMask;
        [SerializeField] private float wallCheckDistance;


        public bool Ground => Physics2D.OverlapBox(groundSensor.position, 
            groundSensorSize, 0f, groundLayerMask);

        public bool WallFront => Physics2D.Raycast(wallSensor.position, Vector2.right * coreManager.MoveCore.Direction,
            wallCheckDistance, groundLayerMask);

        public bool Ledge => Physics2D.Raycast(ledgeSensor.position, Vector2.right * coreManager.MoveCore.Direction,
            wallCheckDistance, groundLayerMask);
    }
}