using Character.Player.Manager;
using Environment.Trigger.Base;
using Environment.Trigger.New_Ability_Trigger.Base;
using Game_Manager;

namespace Environment.Trigger.New_Ability_Trigger.Double_Jump_Trigger
{
    public class DoubleJumpTrigger : NewAbilityBaseTrigger
    {
        public override void Interact(PlayerManager manager)
        {
            base.Interact(manager);
            
            GameManager.Instance.EnableDoubleJump();
        }
    }
}
