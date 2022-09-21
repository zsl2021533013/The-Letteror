using Character.Base.Base_Manager;
using UnityEngine;

namespace Character.Base_Manager
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