using System;
using Character.Base.Data;
using UnityEngine;

namespace Character.Base.Manager
{
    public class CharacterBattleManager : MonoBehaviour
    {
        public CharacterBattleData battleData;
        public bool isImmortal;
        
        protected CharacterBattleManager targetBattleManager;
        protected CharacterManager manager;
        
        protected virtual void Awake()
        {
            manager = GetComponentInParent<CharacterManager>();
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Player") || col.CompareTag("Enemy"))
            {
                targetBattleManager = col.GetComponent<CharacterManager>().BattleManager;
                TryToDamage(targetBattleManager);
            }
        }

        public void TryToDamage(CharacterBattleManager targetBattleManager)
        {
            if (targetBattleManager.isImmortal)
            {
                return;
            }
            
            targetBattleManager.GetHit(battleData);
        }

        public void GetHit(CharacterBattleData targetBattleData)
        {
            battleData.currentHealth -= targetBattleData.attack;
            if (battleData.currentHealth <= 0)
            {
                battleData.currentHealth = 0;
                manager.Die();
            }
            else
            {
                manager.GetHit();
            }
        }
    }
}