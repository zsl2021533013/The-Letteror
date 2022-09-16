using UnityEngine;
using UnityEngine.Serialization;

namespace Character.Player.Data
{
    [CreateAssetMenu(fileName = "New Player Data",menuName = "Data/Player Data/Base Data")]
    public class PlayerData : ScriptableObject
    {
        [Header("Move State")] 
        public float movementVelocity;
        
        [Header(("Jump State"))]
        public float jumpVelocity;
        public int amountOfJumps;
        
        [Header("InAir State")]
        public float coyoteTime;
        public float variableJumpHeightMultiplier;

        [Header("WallSlide State")] 
        public float wallSlideVelocity;

        [Header("WallClimb State")] 
        public float wallClimbVelocity;

        [Header("WallJump State")] 
        public float wallJumpVelocity;
        public float wallJumpTime;
        public Vector2 wallJumpAngle;

        [Header("Sensors Attribute")] 
        public Vector2 groundSensorSize;
        public LayerMask groundLayerMask;
        public float wallCheckDistance;
    }
}