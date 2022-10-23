using Character.Base.FSM.Base_State;
using Character.Base.Manager;
using Character.Enemy.Boss.Colossal_Boss.Core.Core_Manager;
using Character.Enemy.Boss.Colossal_Boss.Manager;
using UnityEngine;

namespace Character.Enemy.Boss.Colossal_Boss.FSM.Base_State
{
    public class ColossalBossState : CharacterState
    {
        protected new ColossalBossManager manager;
        protected new ColossalBossCoreManager coreManager;
        
        protected ColossalBossState(CharacterManager manager, string animBoolName) : base(manager, animBoolName)
        {
            this.manager = (ColossalBossManager)manager;
            coreManager = (ColossalBossCoreManager)base.coreManager;
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