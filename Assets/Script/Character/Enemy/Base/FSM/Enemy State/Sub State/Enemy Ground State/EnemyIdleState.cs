using Character.Base.Manager;
using Character.Enemy.Base.FSM.Enemy_State.Super_State;
using UnityEngine;

namespace Character.Enemy.FSM.Enemy_State.Sub_State.Enemy_Ground_State
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
            
            if (Time.time > startTime + coreManager.MoveCore.waitTime)
            {
                stateMachine.TranslateToState(manager.PatrolState);
                return;
            }
        }
    }
}