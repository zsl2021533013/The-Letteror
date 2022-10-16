using Character.Base.Manager;
using Character.Enemy.Boss.Colossal_Boss.FSM.Super_State;
using UnityEngine;

namespace Character.Enemy.Boss.Colossal_Boss.FSM.Sub_State.Ability_State
{
    public class ColossalBossAttack1State : ColossalBossAbilityState
    {
        public ColossalBossAttack1State(CharacterManager manager, string animBoolName) : base(manager, animBoolName)
        {
        }
    }
}