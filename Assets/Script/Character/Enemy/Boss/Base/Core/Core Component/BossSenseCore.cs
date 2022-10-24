using System;
using Character.Base.Core.Core_Component;
using Game_Manager;
using Script.Game_Manager;
using UnityEngine;

namespace Character.Enemy.Boss.Base.Core.Core_Component
{
    public class BossSenseCore : SenseCore
    {
        [Header("Player Nearby Detect")] 
        public Transform nearbySensor;
        public LayerMask playerLayerMask;
        public Vector2 nearbySensorSize;
        
        protected Transform playerTransform;

        public float PlayerPositionX => playerTransform.position.x;
        public Vector2 PlayerPosition => playerTransform.position;
        public int PlayerDirection => coreManager.MoveCore.Position.x > playerTransform.position.x ? -1 : 1;
        public bool DetectPlayerNearby =>
            Physics2D.OverlapBox(nearbySensor.position, nearbySensorSize, 0f, playerLayerMask);

        protected virtual void Start()
        {
            playerTransform = GameManager.Instance.PlayerTransform;
        }

        public bool JudgeArrive(float stopDistance)
        {
            if (Mathf.Abs(coreManager.MoveCore.Position.x - playerTransform.position.x) < stopDistance)
            {
                return true;
            }

            return false;
        }

        protected override void OnDrawGizmosSelected()
        {
            base.OnDrawGizmosSelected();
            
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(nearbySensor.position,nearbySensorSize);
        }
    }
}