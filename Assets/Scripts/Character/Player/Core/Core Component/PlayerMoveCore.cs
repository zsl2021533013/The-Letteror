using System.Collections;
using Character.Base.Core.Core_Component;
using Character.Player.Core.Data;
using Unity.VisualScripting;
using UnityEngine;

namespace Character.Player.Core.Core_Component
{
    public class PlayerMoveCore : MoveCore
    {
        [SerializeField] private PlayerStateMachineData playerStateMachineData;
        public PlayerStateMachineData StateMachineData => playerStateMachineData;

        public Collider2D playerMoveCollider;

        private Coroutine _tempCoroutine;

        protected override void Awake()
        {
            base.Awake();

            playerMoveCollider = coreManager.CharacterTransform.GetComponent<Collider2D>();
        }

        public void CheckFlip(float inputX)
        {
            int inputDirection = inputX > 0 ? 1 : -1;
            if (inputX == 0f)
            {
                inputDirection = 0;
            }
                
            if (inputDirection == -Direction)
            {
                tempVector3.Set(inputDirection, 1, 1);
                transform.localScale = tempVector3;
            }
        }

        public void DisableOneWayPlatform(Collider2D oneWayPlatformCollider)
        {
            _tempCoroutine = StartCoroutine(WaitAndDisconnectCollider(playerMoveCollider, 
                oneWayPlatformCollider, 0.25f));
        }
        
        IEnumerator WaitAndDisconnectCollider(Collider2D collider1, Collider2D collider2, float time)
        {
            Physics2D.IgnoreCollision(collider1, collider2);
            yield return new WaitForSeconds(time);
            Physics2D.IgnoreCollision(collider1, collider2, false);
        }
    }
}