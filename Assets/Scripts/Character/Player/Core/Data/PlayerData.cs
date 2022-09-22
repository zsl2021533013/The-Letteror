﻿using UnityEngine;

namespace Character.Player.Core.Data
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

        [Header("Wall Jump State")] 
        public float wallJumpVelocity;
        public float wallJumpTime;
        public Vector2 wallJumpAngle;

        [Header("Ledge Climb State")] 
        public Vector2 startOffset;

        [Header("Dash State")] 
        public float dashVelocity;
        public int amountOfDash;

        [Header("Roll State")] 
        public float rollVelocity;

        [Header("Ground Attack State")] 
        public float groundAttack1VelocityX;
        public float groundAttack2VelocityX;
        
        [Header("Air Attack State")]
        public float airAttack1VelocityX;
        public float airAttack2VelocityX;
        public float airUpwardsAttackVelocityY;
        public float airAttackCoolDown;
        
        [Header("Special Attack State")]
        public float specialAttackVelocityX;
        public float specialUpwardsAttackVelocityY;
        public float specialDownwardsAttackVelocityY;
        public float specialAttackCoolDown;
    }
}