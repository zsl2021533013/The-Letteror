using System;
using System.Collections;
using Character.Base.Core.Core_Component;
using Character.Player.Core.Data;
using Character.Player.Input_System;
using Unity.VisualScripting;
using UnityEngine;

namespace Character.Player.Core.Core_Component
{
    public class PlayerMoveCore : MoveCore
    {
        [Header("Player Special Dash Indicator")]
        public GameObject arrow;
        
        [SerializeField] 
        private PlayerStateMachineData playerStateMachineData;
        public PlayerStateMachineData StateMachineData => playerStateMachineData;

        public Collider2D PlayerMoveCollider { get; private set; }
        
        protected override void Awake()
        {
            base.Awake();

            PlayerMoveCollider = coreManager.CharacterTransform.GetComponent<Collider2D>();
        }

        public void CheckFlip(PlayerInputHandler input)
        {
            if (input.InputDirection == -CharacterDirection)
            {
                Flip();
            }
        }

        public void DisableOneWayPlatform(Collider2D oneWayPlatformCollider)
        {
            StartCoroutine(WaitAndDisconnectCollider(PlayerMoveCollider, 
                oneWayPlatformCollider, 0.25f));
        }
        
        IEnumerator WaitAndDisconnectCollider(Collider2D collider1, Collider2D collider2, float time)
        {
            Physics2D.IgnoreCollision(collider1, collider2);
            yield return new WaitForSeconds(time);
            Physics2D.IgnoreCollision(collider1, collider2, false);
        }
        
        public void OpenArrow()
        {
            arrow.SetActive(true);
        }

        public void CloseArrow()
        {
            arrow.SetActive(false);
        }

        public void SetArrowRotation(Vector2 direction)
        {
            float angle = Vector2.SignedAngle(Vector2.right, direction);
            arrow.transform.rotation = Quaternion.Euler(0f, 0f, angle);
            arrow.transform.localScale = CharacterDirection < 0
                ? new Vector3(-1, 1, 1)
                : new Vector3(1, 1, 1);
        }
    }
}