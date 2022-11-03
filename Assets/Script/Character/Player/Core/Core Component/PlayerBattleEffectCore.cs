using Character.Base.Core.Core_Component;
using Script.Environment.Camera;
using Script.Game_Manager;
using UnityEngine;

namespace Character.Player.Core.Core_Component
{
    public class PlayerBattleEffectCore : CoreComponent
    {
        public float immortalTimeAfterDamaged;
        public float damagedPauseTime;
        public float attackPauseTime;
        public float damagedCameraShakeIntensity;
        public float attackCameraShakeIntensity;
        public float specialDownwardsAttackShakeIntensity;
        public float cameraShakeTime;
        
        public void ShakeCamera(float intensity, float time)
        {
            PlayerCameraController.Instance.ShakeCamera(intensity, time);
        }

        public void StopForSeconds(float time)
        {
            GameManager.Instance.StopForSeconds(time);
        }
    }
}