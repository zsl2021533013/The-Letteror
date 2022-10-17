using UnityEngine;

namespace Environment.Parallax
{
    public class ParallaxController : MonoBehaviour
    {
        private Camera _cam;
        private float _cameraPositionX;

        private Vector3 _newPosition;
        private float _startX;
        private float _startY;
        private float _startZ;

        private float Travel => _cam.transform.position.x - _cameraPositionX;

        private float DistanceFromSubject => _startZ; // _startZ 为负数时仍有意义

        private float ClippingPlane =>
            (_cam.transform.position.z + (DistanceFromSubject > 0 ? _cam.farClipPlane : _cam.nearClipPlane));
        private float ParallaxFactor => DistanceFromSubject / Mathf.Abs(ClippingPlane);

        private void Awake()
        {
            _cam = Camera.main;
            _cameraPositionX = _cam.transform.position.x;

            Vector3 position = transform.position;
            _startX = position.x;
            _startY = position.y;
            _startZ = position.z;
        }

        private void FixedUpdate()
        {
            _newPosition.Set(_startX + Travel * ParallaxFactor, _startY, _startZ);
            transform.position = _newPosition;
        }

        /*[Header("画布相较于相机的移动速度")] public Vector2 speed;
        [Header("纵轴循环")] public bool infiniteHorizontal;
        [Header("横轴循环")] public bool infiniteVertical;

        private Transform cameraTransform;
        private Vector3 lastCameraPosition;
        private float textureUnitSizeX;
        private float textureUnitSizeY;

        private void Awake()
        {
            cameraTransform = Camera.main.transform;
            lastCameraPosition = cameraTransform.position;
            Sprite sprite = GetComponent<SpriteRenderer>().sprite;
            Texture2D texture = sprite.texture;
            textureUnitSizeX = texture.width / sprite.pixelsPerUnit;
            textureUnitSizeY = texture.height / sprite.pixelsPerUnit;
        }

        private void FixedUpdate()
        {
            Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;
            transform.position += new Vector3(deltaMovement.x * speed.x, deltaMovement.y * speed.y, deltaMovement.z);
            lastCameraPosition = cameraTransform.position;

            if (infiniteVertical) 
            {
                if (Mathf.Abs(cameraTransform.position.x - transform.position.x) >= textureUnitSizeX)
                {
                    float offsetPositionX = (cameraTransform.position.x - transform.position.x) % textureUnitSizeX;
                    transform.position = new Vector3(cameraTransform.position.x + offsetPositionX, transform.position.y);
                }
            }
            if (infiniteHorizontal) 
            {
                if (Mathf.Abs(cameraTransform.position.y - transform.position.y) >= textureUnitSizeY)
                {
                    float offsetPositionY = (cameraTransform.position.y - transform.position.y) % textureUnitSizeY;
                    transform.position = new Vector3(transform.position.x, cameraTransform.position.y + offsetPositionY);
                }
            }

        }*/
    }
}
