using Character.Base_Manager;
using Character.Base.Base_Manager;
using Character.Base.FSM_Base.Base_State;
using Character.Core;
using Character.Enemy.Data;
using Character.Enemy.Manager;
using UnityEngine;

namespace Character.Enemy.Enemy_FSM
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
    }
}
