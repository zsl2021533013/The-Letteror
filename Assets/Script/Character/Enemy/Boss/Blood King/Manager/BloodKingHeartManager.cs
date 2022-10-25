using System;
using Script.Character.Player.Manager;
using UnityEngine;

namespace Character.Enemy.Boss.Blood_King.Manager
{
    public class BloodKingHeartManager : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (!col.CompareTag("Player")) return;
            var manager = col.GetComponent<PlayerManager>().BattleManager;
            manager.Damaged(1);
        }

        public void OnAnimationFinish()
        {
            Destroy(transform.parent.gameObject);
        }
    }
}