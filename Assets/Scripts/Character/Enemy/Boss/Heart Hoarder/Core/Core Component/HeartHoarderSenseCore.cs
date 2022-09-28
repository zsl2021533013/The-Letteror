using Character.Base.Core.Core_Component;
using Character.Enemy.Boss.Base.Core.Core_Component;
using Game_Manager;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

namespace Character.Enemy.Boss.Heart_Hoarder.Core.Core_Component
{
    public class HeartHoarderSenseCore : BossSenseCore
    {
        [Header("Heart Hoarder Only")]
        public float attack1Range;

        public bool InAttack1Range => JudgeArrive(attack1Range);
    }
}