using Character.Base.Manager;
using Character.Enemy.Boss.Heart_Hoarder.FSM.Super_State;
using Game_Manager;
using UnityEngine;

namespace Character.Enemy.Boss.Heart_Hoarder
{
    public class HeartHoarderChaseState : HeartHoarderState
    {
        public HeartHoarderChaseState(CharacterManager manager, string animBoolName) : base(manager, animBoolName)
        {
        }
        
        public override void OnUpdate()
        {
            base.OnUpdate();

            coreManager.CharacterTransform.localScale = new Vector3(coreManager.MoveCore.ChaseDirection, 1, 1);
            coreManager.MoveCore.SetVelocityX(coreManager.MoveCore.moveVelocity * coreManager.MoveCore.ChaseDirection);
            
            if (coreManager.MoveCore.JudgeArrive())
            {
                stateMachine.TranslateToState(manager.Attack1StopState);
                return;
            }
        }
    }
}