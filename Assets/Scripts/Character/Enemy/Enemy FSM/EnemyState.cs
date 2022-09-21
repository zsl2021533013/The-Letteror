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
        public EnemyState(CharacterManager characterManager, string animBoolName) : base(characterManager, animBoolName)
        {
        }
    }
}
