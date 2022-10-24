using System;
using System.Collections;
using Character.Player.Manager;
using Environment.Trigger.Base;
using Game_Manager;
using PixelCrushers;
using Script.Game_Manager;
using UnityEngine;

namespace Script.Environment.Trigger.Save_Trigger
{
    public class SaveTrigger : TriggerBase
    {
        
        
        private bool _isSaveTriggerEnable;
        private Animator _animator;
        
        private static readonly int Save = Animator.StringToHash("save");

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            StartCoroutine(EnableSaveTriggerAfterSeconds());
        }
        
        public override void Interact(PlayerManager manager)
        {
            base.Interact(manager);

            if (_isSaveTriggerEnable)
            {
                _isSaveTriggerEnable = false;
            
                _animator.SetTrigger(Save);
                
                GameManager.Instance.ResetHealth();
                GameManager.Instance.PlayerManager.UIManager.RefreshHealthUI(GameManager.Instance.BattleData.health);
                
                SaveManager.Save();
                SaveSystem.SaveToSlot(0);
            }
        }

        private IEnumerator EnableSaveTriggerAfterSeconds()
        {
            yield return new WaitForSeconds(1f);
            _isSaveTriggerEnable = true;
        }

        public void OnAnimationFinish()
        {
            _isSaveTriggerEnable = true;
        }
    }
}