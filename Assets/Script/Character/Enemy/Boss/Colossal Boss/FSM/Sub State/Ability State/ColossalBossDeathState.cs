using Character.Base.Manager;
using Character.Enemy.Boss.Colossal_Boss.FSM.Super_State;
using UnityEngine;

namespace Character.Enemy.Boss.Colossal_Boss.FSM.Sub_State.Ability_State
{
    public class ColossalBossDeathState : ColossalBossAbilityState
    {
        public ColossalBossDeathState(CharacterManager manager, string animBoolName) : base(manager, animBoolName)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();
            
            manager.OpenDoors();
        }

        protected override void OnAnimationFinish()
        {
            manager.DestroyCharacter();
        }
    }
}