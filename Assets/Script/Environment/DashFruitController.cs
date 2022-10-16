using System;
using UnityEngine;

namespace Script.Environment
{
    public class DashFruitController : MonoBehaviour
    {
        private Animator _animator;
        
        private readonly int _detectPlayer = Animator.StringToHash("detectPlayer");

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void PlayerEnter()
        {
            _animator.SetBool(_detectPlayer, true);
        }

        public void PlayerExit()
        {
            _animator.SetBool(_detectPlayer, false);
        }
    }
}