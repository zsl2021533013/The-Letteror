using Character.Base.FSM.Base_State;
using Character.Base.Manager;
using Character.Enemy.Boss.Blood_King.Core.Core_Manager;
using Character.Enemy.Boss.Blood_King.Manager;
using UnityEngine;

namespace Character.Enemy.Boss.Blood_King.FSM.Base
{
    public class BloodKingState : CharacterState
    {
        protected new BloodKingManager manager;
        protected new BloodKingCoreManager coreManager;
    
        protected BloodKingState(CharacterManager manager, string animBoolName) : base(manager, animBoolName)
        {
            this.manager = (BloodKingManager)manager;
            coreManager = (BloodKingCoreManager)base.coreManager;
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
            }
        }
    }
}