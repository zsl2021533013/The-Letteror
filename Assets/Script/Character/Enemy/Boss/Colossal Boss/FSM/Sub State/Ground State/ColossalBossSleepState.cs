using Character.Base.Manager;
using Character.Enemy.Boss.Colossal_Boss.FSM.Base_State;
using UnityEngine;

namespace Character.Enemy.Boss.Colossal_Boss.FSM.Sub_State.Ground_State
{
    public class ColossalBossSleepState : ColossalBossState
    {
        private bool _isPlayerNearby;
        
        public ColossalBossSleepState(CharacterManager manager, string animBoolName) : base(manager, animBoolName)
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