using Character.Base.FSM.Base_State;
using Character.Base.Manager;
using UnityEngine;

namespace Character.Enemy.Boss.Heart_Hoarder
{
    public class HeartHoarderState : CharacterState
    {
        protected new HeartHoarderManager manager;
        protected new HeartHoarderCoreManager coreManager;
        
        public HeartHoarderState(CharacterManager manager, string animBoolName) : base(manager, animBoolName)
        {
            this.manager = (HeartHoarderManager)manager;
            coreManager = (HeartHoarderCoreManager)manager.CoreManager;   
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