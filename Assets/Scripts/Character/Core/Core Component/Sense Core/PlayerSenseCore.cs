using UnityEngine;

namespace Character.Core.Core_Component
{
    public class PlayerSenseCore : PlayerCoreComponent
    {
        public Transform GroundSensor => groundSensor;
        public Transform WallSensor => wallSensor;
        public Transform LedgeSensor => ledgeSensor;
        
        [Header("Sensors")]
        [SerializeField] private Transform groundSensor;
        [SerializeField] protected Transform wallSensor;
        [SerializeField] protected Transform ledgeSensor;

        [Header("Ground Sensor")]
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

        public Vector2 GetCornerPosition() // 只有 player 会调用
        {
            RaycastHit2D hitX = Physics2D.Raycast(coreManager.SenseCore.WallSensor.position,
                Vector2.right * coreManager.MoveCore.Direction, wallCheckDistance,
                groundLayerMask);
            float distanceX = hitX.distance + 0.01f;

            Vector2 detectPosition = (Vector2)coreManager.SenseCore.LedgeSensor.position +
                                     new Vector2(distanceX * coreManager.MoveCore.Direction, 0f);
            float detectDistance = ledgeSensor.position.y - wallSensor.position.y;
            RaycastHit2D hitY = Physics2D.Raycast(detectPosition, Vector2.down,
                detectDistance, groundLayerMask);
            float distanceY = hitY.distance + 0.01f;

            return new Vector2(wallSensor.position.x + distanceX * coreManager.MoveCore.Direction,
                ledgeSensor.position.y - distanceY);
        }
        
        protected virtual void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireCube( groundSensor.position, groundSensorSize);
        }
    }
}