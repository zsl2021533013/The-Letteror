using System;
using Character.Base.Core.Core_Component;
using Game_Manager;
using UnityEngine;

namespace Character.Enemy.Boss.Base.Core.Core_Component
{
    public class BossSenseCore : SenseCore
    {
        private Transform _playerTransform;

        public int ChaseDirection => coreManager.MoveCore.Position.x > _playerTransform.position.x ? -1 : 1;

        protected virtual void Start()
        {
            _playerTransform = GameManager.Instance.PlayerTransform;
        }

        public bool JudgeArrive(float stopDistance)
        {
            if (Mathf.Abs(coreManager.MoveCore.Position.x - _playerTransform.position.x) < stopDistance)
            {
                return true;
            }

            return false;
        }
    }
}