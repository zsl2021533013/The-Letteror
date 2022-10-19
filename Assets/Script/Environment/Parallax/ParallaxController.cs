using System;
using Game_Manager;
using UnityEngine;

namespace Environment.Parallax
{
    public class ParallaxController : MonoBehaviour
    {
        public float _cameraStartPositionX;
        public float minX;
        public float maxX;

        private Camera _cam;

        private Vector3 _newPosition;
        private float _startX;
        private float _startY;
        private float _startZ;

        private float Travel => _cam.transform.position.x - _cameraStartPositionX;

        private float DistanceFromSubject => _startZ; // _startZ 为负数时仍有意义

        private float ClippingPlane =>
            (_cam.transform.position.z + (DistanceFromSubject > 0 ? _cam.farClipPlane : _cam.nearClipPlane));
        private float ParallaxFactor => DistanceFromSubject / Mathf.Abs(ClippingPlane);

        private void Awake()
        {
            _cam = Camera.main;

            Vector3 position = transform.position;
            _startX = position.x;
            _startY = position.y;
            _startZ = position.z;
        }

        private void Start()
        {
            GameManager.Instance.RegisterParallaxController(this);
        }

        private void FixedUpdate()
        {
            float targetX = Mathf.Clamp(_startX + Travel * ParallaxFactor, minX, maxX);
            _newPosition.Set(targetX, _startY, _startZ);
            transform.position = _newPosition;
        }

        public void UpdateParallaxController()
        {
            _cam = Camera.main;
            _cameraStartPositionX = _cam.transform.position.x;
        }

        private void OnDrawGizmosSelected()
        {
            Vector2 tmp = new Vector2(_cameraStartPositionX, transform.position.y);
            Gizmos.color = Color.red;
            
            Gizmos.DrawWireSphere(tmp, 1f);
            
            tmp.Set(minX, transform.position.y);
            Gizmos.DrawWireSphere(tmp, 1f);
            
            tmp.Set(maxX, transform.position.y);
            Gizmos.DrawWireSphere(tmp, 1f);
        }
    }
}
