using Character.Base.FSM_Base.Base_State_Machine;
using Character.Core;
using UnityEngine;

namespace Character.Base.Base_Manager
{
    public class CharacterManager : MonoBehaviour
    {
        public CharacterStateMachine StateMachine { get; protected set; }
        public CoreManager CoreManager { get; protected set; }
        public Animator Anim { get; protected set; }

        protected virtual void Awake()
        {
            InitializeFsm();
            Anim = GetComponentInChildren<Animator>();
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
            CoreManager = GetComponentInChildren<CoreManager>(); // CoreManager 要在最开始获取
            
            StateMachine = new CharacterStateMachine();
        }
    }
}