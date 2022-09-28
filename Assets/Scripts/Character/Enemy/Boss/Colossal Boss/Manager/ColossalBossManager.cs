using Character.Base.Manager;
using Character.Enemy.Boss.Colossal_Boss.FSM.Sub_State.Ability_State;
using Character.Enemy.Boss.Colossal_Boss.FSM.Sub_State.Ground_State;
using UnityEngine;

namespace Character.Enemy.Boss.Colossal_Boss.Manager
{
    public class ColossalBossManager : CharacterManager
    {
        public int CurrentState { get; private set; }
        
        #region FSM State

        public ColossalBossWakeState WakeState { get; private set; }
        public ColossalBossIdleState IdleState { get; private set; }
        public ColossalBossBuffState BuffState { get; private set; }
        public ColossalBossChaseState ChaseState { get; private set; }
        public ColossalBossAttack1State Attack1State { get; private set; }
        public ColossalBossAttack2State Attack2State { get; private set; }
        public ColossalBossAttack2StopState Attack2StopState { get; private set; }
        public ColossalBossAttack3State Attack3State { get; private set; }
        public ColossalBossAttack4State Attack4State { get; private set; }
        public ColossalBossTurnLeftState TurnLeftState { get; private set; }
        public ColossalBossTurnRightState TurnRightState { get; private set; }
        public ColossalBossDeathState DeathState { get; private set; }

        #endregion
        
        protected override void Start()
        {
            base.Start();

            CurrentState = 1;
            
            StateMachine.Initialize(WakeState);
        }

        protected override void InitializeFsm()
        {
            base.InitializeFsm();
            
            WakeState = new ColossalBossWakeState(this, "wake");
            IdleState = new ColossalBossIdleState(this, "idle");
            BuffState = new ColossalBossBuffState(this, "buff");
            ChaseState = new ColossalBossChaseState(this, "move");
            Attack1State = new ColossalBossAttack1State(this, "attack1");
            Attack2State = new ColossalBossAttack2State(this, "attack2");
            Attack2StopState = new ColossalBossAttack2StopState(this, "attack2Stop");
            Attack3State = new ColossalBossAttack3State(this, "attack3");
            Attack4State = new ColossalBossAttack4State(this, "attack4");
            TurnLeftState = new ColossalBossTurnLeftState(this, "turnLeft");
            TurnRightState = new ColossalBossTurnRightState(this, "turnRight");
            DeathState = new ColossalBossDeathState(this, "death");
        }

        public override void Damaged()
        {
            base.Damaged();
            
            int health = BattleManager.BattleData.health;
            switch (health)
            {
                case > 40:
                    CurrentState = 1;
                    break;
                case > 30:
                    CurrentState = 2;
                    break;
                case < 20:
                    CurrentState = 3;
                    break;
            }
            
            BattleManager.Flash();
        }

        public override void Death()
        {
            base.Death();
            
            StateMachine.TranslateToState(DeathState);
        }
    }
}