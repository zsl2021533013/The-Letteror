using Character.Base.Manager;

namespace Character.Enemy.FSM.Enemy_State.Super_State
{
    public class EnemyAbilityState : EnemyState
    {
        public EnemyAbilityState(CharacterManager manager, string animBoolName) : base(manager,
            animBoolName)
        {
        }
    }
}