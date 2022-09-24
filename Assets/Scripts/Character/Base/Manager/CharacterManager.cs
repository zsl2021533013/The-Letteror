using Character.Base.Core.Core_Manger;
using Character.Base.FSM.Base_State_Machine;
using UnityEngine;

namespace Character.Base.Manager
{
    public class CharacterManager : MonoBehaviour
    {
        public string name;
        public CoreManager CoreManager { get; protected set; }
        public CharacterBattleManager BattleManager { get; protected set; }
        public CharacterAnimationManager AnimationManager { get; protected set; }
        public CharacterStateMachine StateMachine { get; protected set; }
        
        protected virtual void Awake()
        {
            InitializeComponent();
            InitializeFsm();
        }

        protected virtual void Start()
        {
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

        protected virtual void InitializeFsm()
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

        public virtual void GetHit()
        {
        }

        public virtual void Die()
        {
        }
    }
}