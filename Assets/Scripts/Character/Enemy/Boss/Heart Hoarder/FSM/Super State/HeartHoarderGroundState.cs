using Character.Base.Manager;
using UnityEngine;

namespace Character.Enemy.Boss.Heart_Hoarder.FSM.Super_State
{
    public class HeartHoarderGroundState : HeartHoarderState
    {
        public HeartHoarderGroundState(CharacterManager manager, string animBoolName) : base(manager,
            animBoolName)
        {
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
        }

        public override void DoChecks()
        {
            base.DoChecks();
        }
    }
}