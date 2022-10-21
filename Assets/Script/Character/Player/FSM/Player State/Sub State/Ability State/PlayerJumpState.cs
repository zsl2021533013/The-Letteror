using Character.Base.Manager;
using Character.Player.FSM.Player_State.Super_State;

namespace Character.Player.FSM.Player_State.Sub_State.Ability_State
{
    public class PlayerJumpState : PlayerAbilityState
    {
        private int _amountOfJumpsLeft;

        public PlayerJumpState(CharacterManager manager, string animBoolName) : base(manager,
            animBoolName)
        {
            _amountOfJumpsLeft = coreManager.MoveCore.StateMachineData.jumpAmount;
        }

        
        public override void OnEnter()
        {
            base.OnEnter();
            
            coreManager.MoveCore.SetVelocityY(coreManager.MoveCore.StateMachineData.jumpVelocity);
            isAbilityDone = true;
            DecreaseAmountOfJumps();
            manager.AirState.StartJumping();
        }

        public bool CheckAmountOfJump() => _amountOfJumpsLeft - (manager.AbilityData.isDoubleJumpEnable ? 0 : 1) > 0;

        public void ResetAmountOfJump() => _amountOfJumpsLeft = coreManager.MoveCore.StateMachineData.jumpAmount;

        public void DecreaseAmountOfJumps() => --_amountOfJumpsLeft;

    }
}