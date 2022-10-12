using Character.Base.Core.Core_Component;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace Character.Player.Core.Core_Component
{
    public class PlayerSenseCore : SenseCore
    {
        [Header("Sensors")]
        public Transform groundSensor;
        public Transform wallSensor;
        public Transform ledgeSensor;
        public Transform specialDashSensor;
        public Transform newAbilitySensor;
        public Transform interactSensor;

        [Header("Ground Sensor")]
        public LayerMask groundLayerMask;
        public Vector2 groundSensorSize;
        
        [Header("Wall Sensor")]
        public float wallCheckDistance;
        
        [Header("One Way Platform Sensor")] 
        public Transform oneWayPlatformSensor;
        public LayerMask oneWayPlatformLayerMask;
        public Vector2 oneWayPlatformSensorSize;

        [Header("Special Dash Sensor")] 
        public float specialDashSensorRadius;
        public LayerMask specialDashLayerMask;

        [Header("New Ability Sensor")] 
        public float newAbilitySensorRadius;
        public LayerMask newAbilityLayerMask;
        
        [Header("Interact Sensor")]
        public float interactSensorRadius;
        public LayerMask interactLayerMask;
        
        public Collider2D DetectOneWayPlatform => Physics2D.OverlapBox(oneWayPlatformSensor.position, 
            oneWayPlatformSensorSize, 0f, oneWayPlatformLayerMask);

        public bool DetectGround => Physics2D.OverlapBox(groundSensor.position,
            groundSensorSize, 0f, groundLayerMask);

        public bool DetectWall => Physics2D.Raycast(wallSensor.position,
            Vector2.right * coreManager.MoveCore.CharacterDirection,
            wallCheckDistance, groundLayerMask);

        public bool DetectLedge => Physics2D.Raycast(ledgeSensor.position,
            Vector2.right * coreManager.MoveCore.CharacterDirection,
            wallCheckDistance, groundLayerMask);

        public bool DetectDashFruit => Physics2D.OverlapCircle(specialDashSensor.position,
            specialDashSensorRadius, specialDashLayerMask);
        
        public bool DetectNewAbility => Physics2D.OverlapCircle(newAbilitySensor.position,
            newAbilitySensorRadius, newAbilityLayerMask);
        
        public bool DetectInteract => Physics2D.OverlapCircle(interactSensor.position,
            interactSensorRadius, interactLayerMask);
        
        public Vector2 GetCornerPosition()
        {
            RaycastHit2D hitX = Physics2D.Raycast(wallSensor.position,
                Vector2.right * coreManager.MoveCore.CharacterDirection, wallCheckDistance,
                groundLayerMask);
            float distanceX = hitX.distance + 0.01f;

            Vector2 detectPosition = (Vector2)ledgeSensor.position +
                                     new Vector2(distanceX * coreManager.MoveCore.CharacterDirection, 0f);
            float detectDistance = ledgeSensor.position.y - wallSensor.position.y;
            RaycastHit2D hitY = Physics2D.Raycast(detectPosition, Vector2.down,
                detectDistance, groundLayerMask);
            float distanceY = hitY.distance + 0.01f;

            return new Vector2(wallSensor.position.x + distanceX * coreManager.MoveCore.CharacterDirection,
                ledgeSensor.position.y - distanceY);
        }

        protected override void OnDrawGizmosSelected()
        {
            base.OnDrawGizmosSelected();
            
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireCube( groundSensor.position, groundSensorSize);
            
            Gizmos.color = Color.magenta;
            Gizmos.DrawWireCube( oneWayPlatformSensor.position, oneWayPlatformSensorSize);
            
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireSphere(specialDashSensor.position, specialDashSensorRadius);
            
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(newAbilitySensor.position, newAbilitySensorRadius);
            
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(interactSensor.position, interactSensorRadius);
        }
    }
}