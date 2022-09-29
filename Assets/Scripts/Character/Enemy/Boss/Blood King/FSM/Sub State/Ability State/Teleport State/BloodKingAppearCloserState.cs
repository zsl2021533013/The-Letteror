using Character.Base.Manager;
using Character.Enemy.Boss.Blood_King.FSM.Super_State;
using UnityEngine;

namespace Character.Enemy.Boss.Blood_King.FSM.Sub_State.Ability_State.Teleport_State
{
    public class BloodKingAppearCloserState : BloodKingAbilityState
    {
        private int _appearType;

        public BloodKingAppearCloserState(CharacterManager manager, string animBoolName) : base(manager, animBoolName)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();

            _appearType = Random.Range(0, 2);

            switch (_appearType)
            {
                case 0:
                    if ((coreManager.SenseCore.PlayerPositionX - coreManager.SenseCore.attack1Range) <
                        coreManager.MoveCore.leftPointX)
                    {
                        coreManager.MoveCore.MoveTo(coreManager.SenseCore.PlayerPositionX +
                                                    coreManager.SenseCore.attack1Range);
                    }
                    else
                    {
                        coreManager.MoveCore.MoveTo(coreManager.SenseCore.PlayerPositionX -
                                                    coreManager.SenseCore.attack1Range);
                    }
                    break;
                case 1:
                    if ((coreManager.SenseCore.PlayerPositionX + coreManager.SenseCore.attack1Range) >
                        coreManager.MoveCore.rightPointX)
                    {
                        coreManager.MoveCore.MoveTo(coreManager.SenseCore.PlayerPositionX -
                                                    coreManager.SenseCore.attack1Range);
                    }
                    else
                    {
                        coreManager.MoveCore.MoveTo(coreManager.SenseCore.PlayerPositionX +
                                                    coreManager.SenseCore.attack1Range);
                    }
                    break;
            }
        }
    }
}