using System;
using Character.Base.Data;
using Game_Manager;
using UnityEditor.U2D.Animation;
using UnityEngine;

namespace Character.Base.Manager
{
    public class CharacterBattleManager : MonoBehaviour
    {
        public Material damagedMaterial;
        
        protected CharacterBattleManager targetBattleManager;
        protected CharacterManager manager;
        
        private bool _isImmortal;
        private CharacterBattleData _battleData;
        private SpriteRenderer _spriteRenderer;
        private Material _originMaterial;

        public CharacterBattleData BattleData => _battleData;
        public bool IsImmortal => _isImmortal;
        
        protected virtual void Awake()
        {
            manager = GetComponentInParent<CharacterManager>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Start()
        {
            _battleData = Instantiate(BattleFactoryManager.Instance.GetBattleData(manager.name));
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
            if (targetBattleManager.IsImmortal)
            {
                return;
            }
            
            targetBattleManager.Damaged(_battleData);
        }
        
        public void TryToDamage(int attack)
        {
            if (targetBattleManager.IsImmortal)
            {
                return;
            }
            
            targetBattleManager.Damaged(attack);
        }
        
        public void Damaged(CharacterBattleData targetBattleData)
        {
            _battleData.health -= targetBattleData.attack;
            if (_battleData.health <= 0)
            {
                _battleData.health = 0;
                manager.Death();
            }
            else
            {
                manager.Damaged();
            }
        }

        public void Damaged(int attack)
        {
            _battleData.health -= attack;
            if (_battleData.health <= 0)
            {
                _battleData.health = 0;
                manager.Death();
            }
            else
            {
                manager.Damaged();
            }
        }
        
        public void Flash()
        {
            _originMaterial = _spriteRenderer.material;
            _spriteRenderer.material = damagedMaterial;
            Invoke(nameof(ResetMaterial), 0.1f);
        }

        private void ResetMaterial()
        {
            _spriteRenderer.material = _originMaterial;
        }

        public void StartImmortal() => _isImmortal = true;
        public void EndImmortal() => _isImmortal = false;
    }
}