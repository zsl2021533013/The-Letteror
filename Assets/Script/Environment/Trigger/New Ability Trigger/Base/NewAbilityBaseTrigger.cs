using Character.Player.Manager;
using Environment.Trigger.Base;
using Game_Manager;
using UnityEngine;

namespace Environment.Trigger.New_Ability_Trigger.Base
{
    public class NewAbilityBaseTrigger : TriggerBase
    {
        public GameObject destroyedThronePrefab;
        
        public override void Interact(PlayerManager manager)
        {
            base.Interact(manager);

            manager.Input.GainAbility();

            GameObject newObject = Instantiate(destroyedThronePrefab);
            newObject.transform.position = transform.position;
            
            Destroy(gameObject); //Destroy 将在下一帧执行，此处写法无误
        }
    }
}