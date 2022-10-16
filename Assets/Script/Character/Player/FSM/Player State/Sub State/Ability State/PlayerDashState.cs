using Character.Base.Manager;
using Character.Player.FSM.Player_State.Super_State;
using Environment.Trigger;
using Environment.Trigger.Base;
using UnityEngine;

namespace Character.Player.FSM.Player_State.Sub_State.Ability_State
{
    public class PlayerDashState : PlayerAbilityState
    {
        private int _amountOfDashLeft;
        private Vector2 _startPosition;
        private Vector2 _currentPosition;
        private TriggerBase _frontTrigger;

        public PlayerDashState(CharacterManager manager, string animBoolName) : base(manager,
            animBoolName)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();

            manager.BattleManager.StartImmortal();
            
            _startPosition = coreManager.MoveCore.Position;
            DecreaseAmountOfDash();
            coreManager.MoveCore.SetVelocityX(coreManager.MoveCore.StateMachineData.dashVelocity * coreManager.MoveCore.CharacterDirection);
            coreManager.MoveCore.FreezeY(_startPosition);
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            coreManager.MoveCore.FreezeY(_startPosition);

            if (coreManager.SenseCore.DetectTriggerAhead)
            {
                _frontTrigger = coreManager.SenseCore.GetTriggerAhead();
                if (_frontTrigger is DashDoorTrigger)
                {
                    _frontTrigger.Interact(manager);
                }
            }
        }

        public override void OnExit()
        {
            base.OnExit();
            
            manager.BattleManager.EndImmortal();
        }

        public bool CheckAmountOfDash() => _amountOfDashLeft > 0;

        public void ResetAmountOfDash() => _amountOfDashLeft = coreManager.MoveCore.StateMachineData.amountOfDash;

        public void DecreaseAmountOfDash() => --_amountOfDashLeft;
    }
}