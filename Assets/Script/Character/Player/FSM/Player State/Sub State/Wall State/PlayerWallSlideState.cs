using Character.Base.Manager;
using Character.Player.FSM.Player_State.Super_State;
using Character.Player.Input_System;

namespace Character.Player.FSM.Player_State.Sub_State.Wall_State
{
    public class PlayerWallSlideState : PlayerWallState
    {
        private PlayerInputDirectionType _inputDirectionType;
        
        public PlayerWallSlideState(CharacterManager manager, string animBoolName) : base(manager,
            animBoolName)
        {
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            if (isStateFinished)
            {
                return;
            }

            if (IsInputOpposite())
            {
                coreManager.MoveCore.SetVelocityX(-coreManager.MoveCore.CharacterDirection *
                                                  coreManager.MoveCore.moveVelocity);
                stateMachine.TranslateToState(manager.AirState);
                return;
            }

            coreManager.MoveCore.SetVelocityY(-coreManager.MoveCore.StateMachineData.wallSlideVelocity);
        }

        protected override void UpdateInput(PlayerInputHandler input)
        {
            base.UpdateInput(input);

            _inputDirectionType = manager.Input.InputDirectionType;
        }

        private bool IsInputOpposite()
        {
            return (coreManager.MoveCore.CharacterDirection == 1 &&
                    _inputDirectionType == PlayerInputDirectionType.Left)
                   || (coreManager.MoveCore.CharacterDirection == -1 &&
                       _inputDirectionType == PlayerInputDirectionType.Right);
        } 
    }
}