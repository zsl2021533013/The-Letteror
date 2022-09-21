using Character.Base.Base_Manager;
using Character.Base.FSM_Base.Base_State;
using Character.Core;
using Character.Player.Data;
using Character.Player.Manager;
using UnityEngine;

namespace Character.Player.Player_FSM
{
    public class PlayerState : CharacterState
    {
        public PlayerState(CharacterManager characterManager, string animBoolName) : base(characterManager, animBoolName)
        {
        }
    }
}
