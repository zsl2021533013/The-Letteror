using Character.Base.Manager;
using UnityEngine;

namespace Character.Enemy.Boss.Heart_Hoarder
{
    public class HeartHoarderSleepState : HeartHoarderState
    {
        private bool _isPlayerNearby;
        
        public HeartHoarderSleepState(CharacterManager manager, string animBoolName) : base(manager, animBoolName)
        {
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            if (_isPlayerNearby)
            {
                stateMachine.TranslateToState(manager.WakeState);
                manager.CloseDoors();
                return;
            }
        }

        public override void DoChecks()
        {
            base.DoChecks();

            _isPlayerNearby = coreManager.SenseCore.DetectPlayerNearby;
        }
    }
}