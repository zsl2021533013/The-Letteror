using Character.Base.Data;
using UnityEngine;

namespace Character.Player.Data.Player_Battle_Data
{
    [CreateAssetMenu(fileName = "New Player Battle Data",menuName = "Data/Player Data/Player Battle Data")]
    public class PlayerBattleData : CharacterBattleData
    {
        public float immortalTimeAfterDamaged;
        public float damagedPauseTime;
        public float attackPauseTime;
        public float damagedCameraShakeIntensity;
        public float attackCameraShakeIntensity;
        public float cameraShakeTime;
    }
}