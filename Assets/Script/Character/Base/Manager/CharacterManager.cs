using Character.Base.Core.Core_Manger;
using Character.Base.Data;
using Character.Base.FSM.Base_State_Machine;
using UnityEngine;

namespace Character.Base.Manager
{
    public class CharacterManager : MonoBehaviour
    {
        public new string name;
        public GameObject deadCharacter;
        public CoreManager CoreManager { get; protected set; }
        public CharacterBattleManager BattleManager { get; protected set; }
        public CharacterAnimationManager AnimationManager { get; protected set; }
        public CharacterStateMachine StateMachine { get; protected set; }

        public bool IsDamaged { get; protected set; }
        public bool IsDead { get; protected set; }

        protected virtual void Awake()
        {
            InitializeComponent();
        }

        protected virtual void Start()
        {
            InitializeFSM();
        }

        protected virtual void Update()
        {
            CoreManager.OnUpdate();
            StateMachine.CurrentState.OnUpdate();
        }

        protected virtual void FixedUpdate()
        {
            StateMachine.CurrentState.OnFixedUpdate();
        }

        protected virtual void InitializeFSM()
        {
            StateMachine = new CharacterStateMachine();
        }

        protected virtual void InitializeComponent()
        {
            CoreManager = GetComponentInChildren<CoreManager>(); // CoreManager 要在最开始获取
            AnimationManager = GetComponentInChildren<CharacterAnimationManager>();
            BattleManager = GetComponentInChildren<CharacterBattleManager>();

            if (!CoreManager)
            {
                Debug.LogError("Missing Core Manager");
            }

            if (!AnimationManager)
            {
                Debug.LogError("Missing Animation Manager");
            }

            if (!BattleManager)
            {
                Debug.LogError("Missing Battle Manager");
            }
        }

        public virtual void TryToDamage(CharacterBattleManager targetBattleManager)
        {
            if (targetBattleManager.IsImmortal)
            {
                return;
            }
            
            targetBattleManager.Damaged(BattleManager.BattleData.attack);
        }
        
        public virtual void Damaged() => IsDamaged = true;

        public void ResetDamaged() => IsDamaged = false;

        public virtual void Die() => IsDead = true;

        public void ResetDead() => IsDead = false;

        public virtual void DestroyCharacter()
        {
            Destroy(gameObject);

            if (!deadCharacter) return;
            GameObject newCharacter = Instantiate(deadCharacter);
            newCharacter.transform.position = transform.position;
            newCharacter.transform.localScale = transform.localScale;
        }
    }
}