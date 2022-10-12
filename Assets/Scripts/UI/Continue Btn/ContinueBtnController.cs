using System;
using Character.Player.Input_System;
using UnityEngine;
using UnityEngine.Events;

namespace UI.Continue_Btn
{
    public class ContinueBtnController : MonoBehaviour
    {
        [SerializeField] private UnityEvent onContinueInput;

        private PlayerInputHandler _input;
        private bool _interactInput;

        private void Start()
        {
            _input = PlayerInputHandler.Instance;

            if (!_input)
            {
                Debug.LogError("Missing Input Handler");
            }
        }

        private void Update()
        {
            _interactInput = _input.InteractInput;
            
            if (_interactInput)
            {
                onContinueInput.Invoke();
                _interactInput = false; // TODO:转场后，无法再使用继续按钮
                PlayerInputHandler.Instance.ResetInteractInput();
            }
        }
    }
}
