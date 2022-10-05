using Character.Base.Core.Core_Manger;
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
            BattleManager.TryToDamage(targetBattleManager);
        }
        
        public virtual void Damaged()
        {
        }

        public virtual void Death()
        {
        }

        public virtual void DestroyCharacter()
        {
            Destroy(gameObject);
            
            if (deadCharacter)
            {
                GameObject newCharacter = Instantiate(deadCharacter);
                newCharacter.transform.position = transform.position;
                newCharacter.transform.localScale = transform.localScale;
            }
        }
    }
}