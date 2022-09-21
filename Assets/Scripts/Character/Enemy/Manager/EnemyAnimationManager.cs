using UnityEngine;

namespace Character.Enemy.Manager
{
    public class EnemyAnimationManager : MonoBehaviour
    {
        private EnemyManager _manager;
        
        private void Awake()
        {
            _manager = GetComponentInParent<EnemyManager>();
        }

        public void AnimationFinish() => _manager.StateMachine.CurrentState.AnimationFinish();
    }
}