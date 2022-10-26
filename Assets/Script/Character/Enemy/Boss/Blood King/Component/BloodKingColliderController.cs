using System;
using Character.Enemy.Boss.Blood_King.Manager;
using Script.Character.Enemy.Boss.Blood_King.Manager;
using UnityEngine;

namespace Script.Character.Enemy.Boss.Blood_King.Component
{
    public class BloodKingColliderController : MonoBehaviour
    {
        private BloodKingManager _manager;
        private BoxCollider2D _boxCollider;

        private void Awake()
        {
            _manager = GetComponentInParent<BloodKingManager>();
            _boxCollider = GetComponent<BoxCollider2D>();
        }

        private void Update()
        {
            _manager.SetCollider(_boxCollider.offset, _boxCollider.size);
        }
    }
}
