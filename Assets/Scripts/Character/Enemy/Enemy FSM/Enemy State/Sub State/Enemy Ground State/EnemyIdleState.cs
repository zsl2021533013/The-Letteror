using Character.Base_Manager;
using Character.Base.Base_Manager;
using Character.Core.Core_Component;
using Character.Enemy.Data;
using Character.Enemy.Enemy_FSM.Enemy_State.Super_State;
using Character.Enemy.Manager;
using UnityEngine;

namespace Character.Enemy.Enemy_FSM.Enemy_State.Sub_State.Enemy_Ground_State
{
    public class EnemyIdleState : EnemyGroundState
    {
        public EnemyIdleState(CharacterManager manager, string animBoolName) : base(manager,
            animBoolName)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();
            
            coreManager.MoveCore.SetVelocityX(0f);
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            
            if (Time.time > startTime + coreManager.MoveCore.EnemyData.waitTime)
            {
                stateMachine.TranslateToState(manager.PatrolState);
                return;
            }
        }
    }
}