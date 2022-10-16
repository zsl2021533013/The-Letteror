using Character.Base.Manager;
using Character.Enemy.Base.FSM.Enemy_State.Super_State;
using UnityEngine;

namespace Character.Enemy.FSM.Enemy_State.Sub_State.Enemy_Ability_State
{
    public class EnemyDeathState : EnemyAbilityState
    {
        private bool _inFlipRange;

        public EnemyDeathState(CharacterManager manager, string animBoolName) : base(manager, animBoolName)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();
            
            if (_inFlipRange)
            {
                coreManager.MoveCore.Flip();
            }
        }

        public override void DoChecks()
        {
            base.DoChecks();

            _inFlipRange = coreManager.SenseCore.InFlipRange;
        }
        
        protected override void OnAnimationFinish()
        {
            
        }
    }
}