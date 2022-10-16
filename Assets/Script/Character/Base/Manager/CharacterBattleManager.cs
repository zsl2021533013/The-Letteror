using System;
using System.Collections;
using Character.Base.Data;
using Game_Manager;
using UnityEditor;
using UnityEngine;

namespace Character.Base.Manager
{
    public class CharacterBattleManager : MonoBehaviour
    {
        public Material damagedMaterial;
        public Material defaultMaterial;
        
        protected CharacterBattleManager targetBattleManager;

        private bool _isImmortal;
        private CharacterBattleData _battleData;
        private SpriteRenderer _spriteRenderer;
        private Coroutine _immortalCoroutine;

        public CharacterManager Manager { get; private set; }
        
        public CharacterBattleData BattleData => _battleData;
        public bool IsImmortal => _isImmortal;
        
        protected virtual void Awake()
        {
            Manager = GetComponentInParent<CharacterManager>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Start()
        {
            _battleData = Instantiate(BattleFactoryManager.Instance.GetBattleData(Manager.name));
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Player") || col.CompareTag("Enemy"))
            {
                targetBattleManager = col.GetComponent<CharacterManager>().BattleManager;
                Manager.TryToDamage(targetBattleManager);
            }
        }

        public void Damaged(int attack)
        {
            if (IsImmortal)
            {
                return;
            }
            
            _battleData.health -= attack;
            
            if (_battleData.health > 0)
            {
                Manager.Damaged();
            }
            else
            {
                _battleData.health = 0;
                Manager.Die();
            }
        }
        
        public void Flash()
        {
            _spriteRenderer.material = damagedMaterial;
            Invoke(nameof(ResetMaterial), 0.1f);
        }

        private void ResetMaterial()
        {
            _spriteRenderer.material = defaultMaterial;
        }

        public void StartImmortalForSeconds(float time)
        {
            StopAllCoroutines();
            _immortalCoroutine = StartCoroutine(StartImmortalForSecondsEnumerator(time));
        }

        IEnumerator StartImmortalForSecondsEnumerator(float time)
        {
            StartImmortal();
            yield return new WaitForSeconds(time);
            EndImmortal();
        }
        
        public void StartImmortal() => _isImmortal = true;
        public void EndImmortal() => _isImmortal = false;
    }
}