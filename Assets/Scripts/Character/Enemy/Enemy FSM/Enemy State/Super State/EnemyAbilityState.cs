using Character.Base_Manager;
using Character.Base.Base_Manager;
using Character.Enemy.Data;
using Character.Enemy.Manager;
using UnityEngine;

namespace Character.Enemy.Enemy_FSM.Enemy_State.Super_State
{
    public class EnemyAbilityState : EnemyState
    {
        public EnemyAbilityState(CharacterManager characterManager, string animBoolName) : base(characterManager,
            animBoolName)
        {
        }
    }
}