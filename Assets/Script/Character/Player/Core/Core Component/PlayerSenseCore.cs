using Character.Base.Core.Core_Component;
using Environment.Trigger.Base;
using Script.Environment;
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
        public Transform triggerSensor;
        public Transform NPCSensor;
        public Transform oneWayPlatformSensor;

        [Header("Ground Sensor")]
        public Vector2 groundSensorSize;
        public LayerMask groundLayerMask;
        
        [Header("Wall Sensor")]
        public float wallCheckDistance;
        public LayerMask wallLayerMask;

        [Header("One Way Platform Sensor")] 
        public Vector2 oneWayPlatformSensorSize;
        public LayerMask oneWayPlatformLayerMask;

        [Header("Special Dash Sensor")] 
        public float specialDashSensorRadius;
        public LayerMask specialDashLayerMask;

        [Header("Trigger Sensor")] 
        public Vector2 triggerSensorSize;
        public LayerMask triggerLayerMask;
        public float aheadSenseDistance;
        
        [Header("NPC Sensor")]
        public float NPCSensorRadius;
        public LayerMask NPCLayerMask;
        
        public Collider2D DetectOneWayPlatform => Physics2D.OverlapBox(oneWayPlatformSensor.position, 
            oneWayPlatformSensorSize, 0f, oneWayPlatformLayerMask);

        public bool DetectGround => Physics2D.OverlapBox(groundSensor.position,
            groundSensorSize, 0f, groundLayerMask);

        public bool DetectWall => Physics2D.Raycast(wallSensor.position,
            Vector2.right * coreManager.MoveCore.CharacterDirection,
            wallCheckDistance, wallLayerMask);

        public bool DetectLedge => Physics2D.Raycast(ledgeSensor.position,
            Vector2.right * coreManager.MoveCore.CharacterDirection,
            wallCheckDistance, wallLayerMask);

        public bool DetectDashFruit => Physics2D.OverlapCircle(specialDashSensor.position,
            specialDashSensorRadius, specialDashLayerMask);
        
        public bool DetectTrigger => Physics2D.OverlapBox(triggerSensor.position, 
            triggerSensorSize, 0f, triggerLayerMask);

        public bool DetectTriggerAhead => Physics2D.Raycast(triggerSensor.position,
            coreManager.MoveCore.CharacterDirection * Vector2.right, aheadSenseDistance, triggerLayerMask);
        
        public bool DetectNPC => Physics2D.OverlapCircle(NPCSensor.position,
            NPCSensorRadius, NPCLayerMask);
        
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

        public TriggerBase GetTrigger()
        {
            Collider2D trigger = Physics2D.OverlapBox(triggerSensor.position, triggerSensorSize, 0f, triggerLayerMask);
            TriggerBase targetTrigger = trigger.transform.GetComponent<TriggerBase>();
            return targetTrigger;
        }
        
        public TriggerBase GetTriggerAhead()
        {
            Collider2D triggeCollider = Physics2D.Raycast(triggerSensor.position,
                coreManager.MoveCore.CharacterDirection * Vector2.right, aheadSenseDistance, triggerLayerMask).collider;
            TriggerBase targetTrigger = triggeCollider.transform.GetComponent<TriggerBase>();
            return targetTrigger;
        }
        
        public DashFruitController GetDashFruit()
        {
            Collider2D trigger = Physics2D.OverlapCircle(specialDashSensor.position,
                specialDashSensorRadius + 1f, specialDashLayerMask); // 加 1f 预防极限情况
            
            if (trigger)
            {
                DashFruitController targetDashFruit = trigger.transform.GetComponent<DashFruitController>();
                return targetDashFruit;
            }
            else
            {
                return null;
            }
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
            Gizmos.DrawWireCube(triggerSensor.position, triggerSensorSize);
            
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(NPCSensor.position, NPCSensorRadius);
        }
    }
}