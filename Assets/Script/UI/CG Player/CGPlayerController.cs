using Game_Manager;
using PixelCrushers;
using Script.Game_Manager;
using Tool.Generic;
using UnityEngine;

namespace Script.UI.CG_Player
{
    public class CGPlayerController : Singleton<CGPlayerController>
    {
        [SerializeField] private GameObject CG;
        [SerializeField] private Animator _animator;

        public void PlayEnterAnimation()
        {
            CG.SetActive(true);
            _animator.SetTrigger("enter");
        }

        public void PlayExitAnimation()
        {
            GameManager.Instance.PlayerManager.BattleManager.StartImmortal();
            CG.SetActive(true);
            _animator.SetTrigger("exit");
        }
        
        public void OnEnterAnimationFinish()
        {
            CG.SetActive(false);
            
            SaveManager.InitializeData();
            SaveSystem.ResetGameState();
            SaveSystem.LoadScene("City@New Game Spawn Position");
        }
        
        public void OnExitAnimationFinish()
        {
            CG.SetActive(false);
        }

    }
}