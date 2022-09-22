using Character.Base.Core.Core_Manger;
using Character.Base.FSM.Base_State_Machine;
using Character.Base.Manager;
using UnityEngine;

namespace Character.Base.FSM.Base_State
{
    public class CharacterState
    {
        protected CharacterManager manager;
        protected CharacterStateMachine stateMachine;
        protected CoreManager coreManager;
        protected bool isAnimationFinish;
        protected bool isStateFinished;
        protected float startTime;

        private string _animBoolName;
        
        public CharacterState(CharacterManager manager, string animBoolName)
        {
            this.manager = manager;
            _animBoolName = animBoolName;
            stateMachine = manager.StateMachine;
            coreManager = manager.CoreManager;
        }

        public virtual void OnEnter()
        {
            startTime = Time.time;
            DoChecks();
            manager.Anim.SetBool(_animBoolName, true);
            isAnimationFinish = false;
            isStateFinished = false;
            //Debug.Log("Enter " + _animBoolName + " State");
        }

        public virtual void OnExit()
        {
            manager.Anim.SetBool(_animBoolName, false);
            isStateFinished = true; //必须要写，因为父类 return 子类中不会 return，需要用 bool 传递一下
            //Debug.Log("Exit " + _animBoolName + " State");
        }

        public virtual void OnUpdate()
        {
            
        }

        public virtual void OnFixedUpdate()
        {
            DoChecks();
        }

        public virtual void DoChecks()
        {
        }

        public void AnimationFinish() => isAnimationFinish = true;
    }
}