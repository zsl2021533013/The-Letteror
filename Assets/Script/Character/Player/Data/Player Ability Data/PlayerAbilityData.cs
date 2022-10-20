using UnityEngine;

namespace Character.Player.Data.Player_Ability_Data
{
    [CreateAssetMenu(fileName = "New Player Ability Data", menuName = "Data/Player Data/Player Ability Data")]
    public class PlayerAbilityData : ScriptableObject
    {
        public bool isDoubleJumpEnable;
        public bool isWallSlideEnable;
        public bool isDashEnable;
        public bool isSpecialDashEnable;
        public bool isSpecialUpwardsAttackEnable;
        public bool isSpecialHorizontalAttackEnable;
        public bool isSpecialDownwardsAttackEnable;
    }
}