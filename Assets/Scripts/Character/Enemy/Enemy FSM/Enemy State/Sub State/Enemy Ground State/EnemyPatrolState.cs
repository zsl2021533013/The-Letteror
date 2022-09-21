﻿using Character.Base_Manager;
using Character.Base.Base_Manager;
using Character.Core;
using Character.Core.Core_Component;
using Character.Enemy.Data;
using Character.Enemy.Enemy_FSM.Enemy_State.Super_State;
using Character.Enemy.Manager;
using Unity.VisualScripting;
using UnityEngine;

namespace Character.Enemy.Enemy_FSM.Enemy_State.Sub_State.Enemy_Ground_State
{
    public class EnemyPatrolState : EnemyGroundState
    {
        private float _startPositionX;
        private float _targetX;
        private int _moveDirection;


        public EnemyPatrolState(CharacterManager characterManager, string animBoolName) : base(characterManager,
            animBoolName)
        {
            _startPositionX = coreManager.MoveCore.Position.x;
        }

        public override void OnEnter()
        {
            base.OnEnter();

            SetTargetX();
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            
            coreManager.MoveCore.SetVelocityX(((EnemyMoveCore)coreManager.MoveCore).EnemyData.moveVelocity * coreManager.MoveCore.Direction);
            
            if (((EnemyMoveCore)coreManager.MoveCore).JudgeArrive(_targetX))
            {
                stateMachine.TranslateToState(((EnemyManager)characterManager).IdleState);
                return;
            }
        }

        private void SetTargetX()
        {
            _targetX = _startPositionX + Random.Range(-((EnemyMoveCore)coreManager.MoveCore).EnemyData.patrolRange, ((EnemyMoveCore)coreManager.MoveCore).EnemyData.patrolRange);

            _moveDirection = _targetX > coreManager.MoveCore.Position.x ? 1 : -1;
            if (_moveDirection == -coreManager.MoveCore.Direction)
            {
                ((EnemyMoveCore)coreManager.MoveCore).Flip();
            }
        }
    }
}