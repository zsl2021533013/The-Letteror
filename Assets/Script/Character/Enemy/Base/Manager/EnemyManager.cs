using Character.Base.Data;
using Character.Base.Manager;
using Character.Enemy.Core.Core_Manager;
using Character.Enemy.FSM.Enemy_State.Sub_State.Enemy_Ability_State;
using Character.Enemy.FSM.Enemy_State.Sub_State.Enemy_Ground_State;
using Script.Character.Damaged_Effect;

namespace Character.Enemy.Manager
{
    public class EnemyManager : CharacterManager
    {
        public new EnemyCoreManager CoreManager { get; private set; }

        public DamagedEffectController EffectController { get; private set; }
        
        #region FSM Attribute
        
        public EnemyIdleState IdleState { get; private set; }
        public EnemyChaseState ChaseState { get; private set; }
        public EnemyAttackState AttackState { get; private set; }
        public EnemySpecialAttackState SpecialAttackState { get; private set; }
        public EnemyPatrolState PatrolState { get; private set; }
        public EnemyDamagedState DamagedState { get; private set; }
        public EnemyDeathState DeathState { get; private set; }

        #endregion

        protected override void Awake()
        {
            base.Awake();

            CoreManager = (EnemyCoreManager)base.CoreManager;
            EffectController = GetComponentInChildren<DamagedEffectController>();
        }

        protected override void Start()
        {
            base.Start();
            
            StateMachine.Initialize(IdleState);
        }
        
        protected override void InitializeFSM()
        {
            base.InitializeFSM();
            
            IdleState = new EnemyIdleState(this, "idle");
            ChaseState = new EnemyChaseState(this, "move");
            AttackState = new EnemyAttackState(this, "attack");
            SpecialAttackState = new EnemySpecialAttackState(this, "specialAttack");
            PatrolState = new EnemyPatrolState(this, "move");
            DamagedState = new EnemyDamagedState(this, "damaged");
            DeathState = new EnemyDeathState(this, "death");
        }

        public override void Damaged()
        {
            base.Damaged();
            
            EffectController.Damaged();
        }
    }
}