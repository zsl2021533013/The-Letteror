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

        private float DistanceFromSubject => _startZ;

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
    }
}
