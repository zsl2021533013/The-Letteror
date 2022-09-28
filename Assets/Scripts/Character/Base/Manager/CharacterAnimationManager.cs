using UnityEngine;

namespace Character.Base.Manager
{
    public class CharacterAnimationManager : MonoBehaviour
    {
        protected CharacterManager manager;
        protected Animator animator;
        
        protected virtual void Awake()
        {
            manager = GetComponentInParent<CharacterManager>();
            animator = GetComponent<Animator>();
        }

        public void SetBool(string name, bool value) => animator.SetBool(name, value);
        
        public void SetFloat(string name, float value) => animator.SetFloat(name, value);

        public void AnimationFinish() => manager.StateMachine.CurrentState.AnimationFinish();
    }
}