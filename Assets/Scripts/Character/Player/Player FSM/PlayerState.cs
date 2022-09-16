using Character.Player.Data;
using UnityEngine;

namespace Character.Player.Player_FSM
{
    public class PlayerState
    {
        protected PlayerManager playerManager;
        protected PlayerStateMachine stateMachine;
        protected PlayerData playerData;
        protected float startTime;
        protected bool isAnimationFinished;
        protected bool isStateFinished;

        private string _animBoolName;

        public PlayerState(PlayerManager playerManager, PlayerStateMachine stateMachine, PlayerData playerData,
            string animBoolName)
        {
            this.playerManager = playerManager;
            this.stateMachine = stateMachine;
            this.playerData = playerData;
            this._animBoolName = animBoolName;
        }

        public virtual void OnEnter()
        {
            startTime = Time.time;
            DoChecks();
            playerManager.Anim.SetBool(_animBoolName, true);
            isAnimationFinished = false;
            isStateFinished = false;
            //Debug.Log("Enter " + _animBoolName + " State");
        }

        public virtual void OnExit()
        {
            playerManager.Anim.SetBool(_animBoolName, false);
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

        public virtual void AnimatonTrigger()
        {
            
        }

        public virtual void AnimationFinish() => isAnimationFinished = true;
    }
}
