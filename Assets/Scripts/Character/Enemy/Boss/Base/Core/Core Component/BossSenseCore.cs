using System;
using Character.Base.Core.Core_Component;
using Game_Manager;
using UnityEngine;

namespace Character.Enemy.Boss.Base.Core.Core_Component
{
    public class BossSenseCore : SenseCore
    {
        protected Transform playerTransform;

        public float PlayerPositionX => playerTransform.position.x;
        
        public int PlayerDirection => coreManager.MoveCore.Position.x > playerTransform.position.x ? -1 : 1;

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
    }
}