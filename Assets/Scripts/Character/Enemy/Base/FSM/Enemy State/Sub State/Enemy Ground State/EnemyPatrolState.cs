using Character.Base.Manager;
using Character.Enemy.Base.FSM.Enemy_State.Super_State;
using UnityEngine;

namespace Character.Enemy.FSM.Enemy_State.Sub_State.Enemy_Ground_State
{
    public class EnemyPatrolState : EnemyGroundState
    {
        private float _startPositionX;
        private float _targetX;
        private int _moveDirection;


        public EnemyPatrolState(CharacterManager manager, string animBoolName) : base(manager,
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
            
            coreManager.MoveCore.SetVelocityX(coreManager.MoveCore.EnemyStateMachineData.moveVelocity * coreManager.MoveCore.Direction);
            
            if (coreManager.MoveCore.JudgeArrive(_targetX))
            {
                stateMachine.TranslateToState(manager.IdleState);
                return;
            }
        }

        private void SetTargetX()
        {
            _targetX = _startPositionX + Random.Range(-coreManager.MoveCore.EnemyStateMachineData.patrolRange, coreManager.MoveCore.EnemyStateMachineData.patrolRange);

            _moveDirection = _targetX > coreManager.MoveCore.Position.x ? 1 : -1;
            if (_moveDirection == -coreManager.MoveCore.Direction)
            {
                coreManager.MoveCore.Flip();
            }
        }
    }
}