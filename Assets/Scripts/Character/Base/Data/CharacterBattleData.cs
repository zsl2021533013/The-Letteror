using UnityEngine;

namespace Character.Base.Data
{
    [CreateAssetMenu(fileName = "New Character Battle Data",menuName = "Data/Character Data/Character Battle Data")]
    public class CharacterBattleData : ScriptableObject
    {
        public int maxHealth;
        public int currentHealth;
        public int attack;
    }
}