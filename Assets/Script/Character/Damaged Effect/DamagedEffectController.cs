using System;
using UnityEngine;

namespace Script.Character.Damaged_Effect
{
    public class DamagedEffectController : MonoBehaviour
    {
        private Animator _animator;
        
        private static readonly int DamagedTrigger = Animator.StringToHash("damaged");

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void Damaged()
        {
            _animator.SetTrigger(DamagedTrigger);
        }
    }
}
