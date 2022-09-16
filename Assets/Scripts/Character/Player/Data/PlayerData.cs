using UnityEngine;

namespace Character.Player.Data
{
    [CreateAssetMenu(fileName = "New Player Data",menuName = "Data/Player Data/Base Data")]
    public class PlayerData : ScriptableObject
    {
        [Header("Move State")] 
        public float movementVelocity;
        
        [Header(("Jump State"))]
        public float jumpVelocity;
        public int amountOfJump;
        
        [Header("In Air State")]
        public float coyoteTime;
        public float variableJumpHeightMultiplier;

        [Header("Wall Slide State")] 
        public float wallSlideVelocity;

        [Header("Wall Climb State")] 
        public float wallClimbVelocity;

        [Header("Wall Jump State")] 
        public float wallJumpVelocity;
        public float wallJumpTime;
        public Vector2 wallJumpAngle;

        [Header("Ledge Climb State")] 
        public Vector2 startOffset;
        public Vector2 stopOffset;

        [Header("Dash State")] 
        public float dashVelocity;
        public int amountOfDash;
        
        [Header("Sensors Attribute")] 
        public Vector2 groundSensorSize;
        public LayerMask groundLayerMask;
        public float wallCheckDistance;
    }
}