using Character.Base.FSM.Base_State;
using Character.Base.Manager;
using Character.Enemy.Core.Core_Manager;
using Character.Enemy.FSM.Enemy_State.Sub_State.Enemy_Ability_State;
using Character.Enemy.Manager;
using UnityEngine;

namespace Character.Enemy.FSM
{
    public class EnemyState : CharacterState
    {
        protected new EnemyManager manager;
        protected new EnemyCoreManager coreManager;

        public EnemyState(CharacterManager manager, string animBoolName) : base(manager, animBoolName)
        {
            this.manager = (EnemyManager)manager;
            coreManager = (EnemyCoreManager)manager.CoreManager;
        }

        public override void OnEnter()
        {
            base.OnEnter();
            
            Debug.Log(_animBoolName);
        }

        public override void OnCharacterDie()
        {
            if (manager.IsDead)
            {
                manager.ResetDead();
                stateMachine.TranslateToState(manager.DeathState);
                return;
            }
        }

        public override void OnCharacterDamaged()
        {
            if (manager.IsDamaged)
            {
                manager.ResetDamaged();
                stateMachine.TranslateToState(manager.DamagedState);
                return;
            }
        }
    }
}
