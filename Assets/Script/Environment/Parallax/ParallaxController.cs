using System;
using UnityEngine;

namespace Environment.Parallax
{
    public class ParallaxController : MonoBehaviour
    {
        /*[Header("Constrain")]
        [SerializeField]
        private float constraintXMin;
        [SerializeField]
        private float constraintXMax;*/
    
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
            /*float targetX = Mathf.Clamp(_startX + Travel * ParallaxFactor, constraintXMin, constraintXMax);*/
            _newPosition.Set(_startX + Travel * ParallaxFactor, _startY, _startZ);
            transform.position = _newPosition;
        }

        /*private void OnDrawGizmosSelected()
        {
            Vector2 tmp = new Vector2(constraintXMin, 1);
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(tmp, 0.5f);
        }*/
    }
}
