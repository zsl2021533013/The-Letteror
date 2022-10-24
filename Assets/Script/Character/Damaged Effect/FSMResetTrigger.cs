using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMResetTrigger : StateMachineBehaviour
{
    public string[] triggerNames;
    
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        foreach (var triggerName in triggerNames)
        {
            animator.ResetTrigger(triggerName);
        }
    }
    
}
