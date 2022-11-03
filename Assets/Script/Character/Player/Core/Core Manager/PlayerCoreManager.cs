using Character.Base.Core.Core_Manger;
using Character.Player.Core.Core_Component;
using UnityEngine;

namespace Character.Player.Core.Core_Manager
{
    public class PlayerCoreManager : CoreManager
    {
        public new PlayerMoveCore MoveCore { get; private set; } 
        public new PlayerSenseCore SenseCore { get; private set; } 
        public new PlayerBattleEffectCore BattleEffectCore { get; private set; } 
        
        protected override void Awake()
        {
            base.Awake();

            BattleEffectCore = GetComponentInChildren<PlayerBattleEffectCore>();
            
            if (!(base.MoveCore is PlayerMoveCore))
            {
                Debug.LogError("Missing Player Move Core");
            }
            if (!(base.SenseCore is PlayerSenseCore))
            {
                Debug.LogError("Missing Player Sense Core");
            }
            if (!BattleEffectCore)
            {
                Debug.LogError("Missing Player Battle Effect Core");
            }
            
            MoveCore = (PlayerMoveCore)base.MoveCore;
            SenseCore = (PlayerSenseCore)base.SenseCore;
        }
    }
}