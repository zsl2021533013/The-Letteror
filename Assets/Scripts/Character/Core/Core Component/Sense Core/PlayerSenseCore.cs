using UnityEngine;

namespace Character.Core.Core_Component
{
    public class PlayerSenseCore : SenseCore
    {
        public Vector2 GetCornerPosition() // 只有 player 会调用
        {
            RaycastHit2D hitX = Physics2D.Raycast(coreManager.SenseCore.WallSensor.position,
                Vector2.right * coreManager.MoveCore.Direction, wallCheckDistance,
                groundLayerMask);
            float distanceX = hitX.distance + 0.01f;

            Vector2 detectPosition = (Vector2)coreManager.SenseCore.LedgeSensor.position +
                                     new Vector2(distanceX * coreManager.MoveCore.Direction, 0f);
            float detectDistance = ledgeSensor.position.y - wallSensor.position.y;
            RaycastHit2D hitY = Physics2D.Raycast(detectPosition, Vector2.down,
                detectDistance, groundLayerMask);
            float distanceY = hitY.distance + 0.01f;

            return new Vector2(wallSensor.position.x + distanceX * coreManager.MoveCore.Direction,
                ledgeSensor.position.y - distanceY);
        }
    }
}