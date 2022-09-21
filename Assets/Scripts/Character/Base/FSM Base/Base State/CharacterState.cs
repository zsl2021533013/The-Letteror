using Character.Base_Manager;
using Character.Base.Base_Manager;
using Character.Base.FSM_Base.Base_State_Machine;
using Character.Core;
using Character.Player.Data;
using Character.Player.Player_FSM;
using UnityEngine;

namespace Character.Base.FSM_Base.Base_State
{
    public class CharacterState
    {
        protected CharacterManager characterManager;
        protected CharacterStateMachine stateMachine;
        protected CoreManager coreManager;
        protected bool isAnimationFinish;
        protected bool isStateFinished;
        protected float startTime;

        private string _animBoolName;
        
        public CharacterState(CharacterManager characterManager, string animBoolName)
        {
            this.characterManager = characterManager;
            _animBoolName = animBoolName;
            stateMachine = characterManager.StateMachine;
            coreManager = characterManager.CoreManager;
        }

        public virtual void OnEnter()
        {
            startTime = Time.time;
            DoChecks();
            characterManager.Anim.SetBool(_animBoolName, true);
            isAnimationFinish = false;
            isStateFinished = false;
            //Debug.Log("Enter " + _animBoolName + " State");
        }

        public virtual void OnExit()
        {
            characterManager.Anim.SetBool(_animBoolName, false);
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