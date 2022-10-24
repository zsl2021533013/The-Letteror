using Character.Base.Manager;
using Character.Enemy.Base.FSM.Enemy_State.Super_State;
using UnityEngine;

namespace Character.Enemy.FSM.Enemy_State.Sub_State.Enemy_Ability_State
{
    public class EnemyDamagedState : EnemyAbilityState
    {
        private bool _inFlipRange;
        
        public EnemyDamagedState(CharacterManager manager, string animBoolName) : base(manager, animBoolName)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();
            
            if (_inFlipRange)
            {
                coreManager.MoveCore.Flip();
            }
            
            coreManager.MoveCore.SetVelocityX(-coreManager.MoveCore.damagedVelocity * coreManager.MoveCore.CharacterDirection);
        }

        public override void DoChecks()
        {
            base.DoChecks();

            _inFlipRange = coreManager.SenseCore.InFlipRange;
        }

        protected override void OnAnimationFinish()
        {
            if (manager.IsDamaged)
            {
                manager.ResetDamaged();
                return;
            }
            
            base.OnAnimationFinish();
        }

        public override void OnCharacterDamaged()
        {
        }
    }
}