using Character.Base.FSM.Base_State;
using Character.Base.Manager;
using Character.Enemy.Core.Core_Manager;
using Character.Enemy.Manager;

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
    }
}
