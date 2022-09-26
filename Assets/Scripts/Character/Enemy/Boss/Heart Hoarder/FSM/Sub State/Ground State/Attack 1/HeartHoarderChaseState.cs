using Character.Base.Manager;
using Character.Enemy.Boss.Heart_Hoarder.FSM.Super_State;
using Game_Manager;
using UnityEngine;

namespace Character.Enemy.Boss.Heart_Hoarder
{
    public class HeartHoarderChaseState : HeartHoarderGroundState
    {
        private Transform _playerTransform;
        
        private int ChaseDirection => coreManager.MoveCore.Position.x > _playerTransform.position.x ? -1 : 1;
        private float Distance => Mathf.Abs(coreManager.MoveCore.Position.x - _playerTransform.position.x);

        public HeartHoarderChaseState(CharacterManager manager, string animBoolName) : base(manager, animBoolName)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();

            _playerTransform = GameManager.Instance.PlayerTransform;
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            coreManager.CharacterTransform.localScale = new Vector3(ChaseDirection, 1, 1);
            coreManager.MoveCore.SetVelocityX(coreManager.MoveCore.moveVelocity * ChaseDirection);
            
            if (Distance < 4f)
            {
                stateMachine.TranslateToState(manager.Attack1StopStopState);
                return;
            }
        }
    }
}