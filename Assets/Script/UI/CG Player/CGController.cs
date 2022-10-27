using System.Collections;
using System.Collections.Generic;
using Script.UI.CG_Player;
using UnityEngine;

public class CGController : MonoBehaviour
{
    [SerializeField] private CGPlayerController _CGPlayerController;
    
    public void OnEnterAnimationFinish()
    {
        _CGPlayerController.OnEnterAnimationFinish();
    }
        
    public void OnExitAnimationFinish()
    {
        _CGPlayerController.OnExitAnimationFinish();
    }
}
