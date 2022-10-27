using Character.Base.Manager;
using Character.Enemy.Boss.Blood_King.FSM.Super_State;
using Game_Manager;
using Script.UI.CG_Player;
using UnityEngine;

namespace Character.Enemy.Boss.Blood_King.FSM.Sub_State.Ability_State
{
    public class BloodKingDeathState : BloodKingAbilityState
    {
        public BloodKingDeathState(CharacterManager manager, string animBoolName) : base(manager, animBoolName)
        {
        }

        protected override void OnAnimationFinish()
        {
            PlayerUIManager.Instance.CloseHUD();
            manager.CGCamera.SetActive(true);
            CGPlayerController.Instance.PlayExitAnimation();
            manager.DestroyCharacter();
        }
    }
}