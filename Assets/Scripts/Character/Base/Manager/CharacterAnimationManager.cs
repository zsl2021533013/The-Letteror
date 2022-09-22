using UnityEngine;

namespace Character.Base.Manager
{
    public class CharacterAnimationManager : MonoBehaviour
    {
        protected CharacterManager manager;
        
        private void Awake()
        {
            manager = GetComponentInParent<CharacterManager>();
        }

        public void AnimationFinish() => manager.StateMachine.CurrentState.AnimationFinish();
    }
}