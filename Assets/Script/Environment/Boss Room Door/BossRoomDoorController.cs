using System;
using UnityEngine;

namespace Script.Environment.Boss_Room_Door
{
    public class BossRoomDoorController : MonoBehaviour
    {
        private Animator _animator;
        private BoxCollider2D _boxCollider;
        
        private static readonly int IsDoorOpen = Animator.StringToHash("isDoorOpen");

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _boxCollider = GetComponent<BoxCollider2D>();

            OpenDoor();
        }

        public void OpenDoor()
        {
            _animator.SetBool(IsDoorOpen, true);
            _boxCollider.enabled = false;
        }

        public void CloseDoor()
        {
            _animator.SetBool(IsDoorOpen, false);
            _boxCollider.enabled = true;
        }
    }
}