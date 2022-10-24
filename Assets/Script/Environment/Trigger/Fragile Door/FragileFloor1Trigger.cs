using System.Collections;
using Character.Player.Manager;
using Environment.Trigger.Base;
using UnityEngine;

namespace Environment.Trigger
{
    public class FragileFloor1Trigger : TriggerBase
    {
        private BoxCollider2D _boxCollider2D;
        private Animator _animator;
        private static readonly int Disappear = Animator.StringToHash("disappear");

        private void Awake()
        {
            _boxCollider2D = GetComponent<BoxCollider2D>();
            _animator = GetComponent<Animator>();
        }

        public override void Interact(PlayerManager manager)
        {
            base.Interact(manager);

            _animator.SetBool(Disappear, true);
            StopAllCoroutines();
            StartCoroutine(ResetAnimation());
        }

        IEnumerator ResetAnimation()
        {
            yield return new WaitForSeconds(5f);
            _animator.SetBool(Disappear, false);
        }
    }
}