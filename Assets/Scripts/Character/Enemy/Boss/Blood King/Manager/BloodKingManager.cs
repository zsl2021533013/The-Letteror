using Character.Base.Manager;
using Character.Enemy.Boss.Blood_King.FSM.Sub_State.Ability_State;
using Character.Enemy.Boss.Blood_King.FSM.Sub_State.Ability_State.Attack_State;
using Character.Enemy.Boss.Blood_King.FSM.Sub_State.Ability_State.Teleport_State;
using Character.Enemy.Boss.Blood_King.FSM.Sub_State.Ground_State;
using UnityEngine;

namespace Character.Enemy.Boss.Blood_King.Manager
{
    public class BloodKingManager : CharacterManager
    {
        public int CurrentState { get; private set; }
        
        #region FSM Component
        
        public BloodKingIdleState IdleState { get; private set; }
        public BloodKingChargeState ChargeState { get; private set; }
        public BloodKingAppearCloserState AppearCloserState { get; private set; }
        public BloodKingAppearFartherState AppearFartherState { get; private set; }
        public BloodKingDisappearCloserState DisappearCloserState { get; private set; }
        public BloodKingDisappearFartherState DisappearFartherState { get; private set; }
        public BloodKingBlueChargeState BlueChargeState { get; private set; }
        public BloodKingBlueChaseState BlueChaseState { get; private set; }

        #region Attack State

        public BloodKingAttack1State Attack1State { get; private set; }
        public BloodKingAttack2State Attack2State { get; private set; }
        public BloodKingAttack3_1State Attack3_1State { get; private set; }
        public BloodKingAttack3_2State Attack3_2State { get; private set; }
        public BloodKingAttack3_3State Attack3_3State { get; private set; }
        public BloodKingAttack3_4State Attack3_4State { get; private set; }
        public BloodKingAttack4_1State Attack4_1State { get; private set; }
        public BloodKingAttack4_2State Attack4_2State { get; private set; }
        public BloodKingJumpAttackState JumpAttackState { get; private set; }
        public BloodKingBlueAttackState BlueAttackState { get; private set; }

        #endregion
        
        #endregion
    }
}