using Character.Core;
using Character.Player.Data;
using Character.Player.Manager;
using UnityEngine;

namespace Character.Player.Player_FSM
{
    public class PlayerState
    {
        public bool IsStateFinished { get; private set; }
        
        protected PlayerManager playerManager;
        protected PlayerStateMachine stateMachine;
        protected PlayerData playerData;
        protected CoreManager coreManager;
        protected float startTime;
        protected bool isAnimationFinish;

        private string _animBoolName;
        
        public PlayerState(PlayerManager playerManager, PlayerData playerData, string animBoolName)
        {
            this.playerManager = playerManager;
            this.playerData = playerData;
            _animBoolName = animBoolName;
            stateMachine = playerManager.StateMachine;
            coreManager = playerManager.CoreManager;
        }

        public virtual void OnEnter()
        {
            startTime = Time.time;
            DoChecks();
            playerManager.Anim.SetBool(_animBoolName, true);
            isAnimationFinish = false;
            IsStateFinished = false;
            //Debug.Log("Enter " + _animBoolName + " State");
        }

        public virtual void OnExit()
        {
            playerManager.Anim.SetBool(_animBoolName, false);
            IsStateFinished = true; //必须要写，因为父类 return 子类中不会 return，需要用 bool 传递一下
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
