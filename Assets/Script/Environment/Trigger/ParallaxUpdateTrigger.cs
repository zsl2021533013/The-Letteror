using System;
using System.Collections;
using Character.Player.Manager;
using Environment.Trigger.Base;
using Game_Manager;
using UnityEngine;

namespace Environment.Trigger
{
    public class ParallaxUpdateTrigger : TriggerBase
    {
        private Collider2D _collider2D;

        private void Awake()
        {
            _collider2D = GetComponent<Collider2D>();
        }

        public override void Interact(PlayerManager manager)
        {
            base.Interact(manager);
            
            GameManager.Instance.UpdateParallaxControllers();
        }

        private IEnumerator DisableInteractForSeconds()
        {
            _collider2D.enabled = false;
            yield return new WaitForSeconds(1f);
            _collider2D.enabled = true;
        }
    }
}