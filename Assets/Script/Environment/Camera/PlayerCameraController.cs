using System;
using Cinemachine;
using Tool.Generic;
using UnityEngine;

namespace Script.Environment.Camera
{
    public class PlayerCameraController : Singleton<PlayerCameraController>
    {
        private float _shakeTimer;
        
        private CinemachineVirtualCamera _virtualCamera;
        private CinemachineBasicMultiChannelPerlin _multiChannelPerlin;

        protected override void Awake()
        {
            base.Awake();

            _virtualCamera = GetComponent<CinemachineVirtualCamera>();
            _multiChannelPerlin = _virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        }

        public void ShakeCamera(float intensity, float time)
        {
            _multiChannelPerlin.m_AmplitudeGain = intensity;
            _shakeTimer = time;
        }

        private void Update()
        {
            _shakeTimer -= Time.deltaTime;
            if (_shakeTimer < 0f)
            {
                float currentIntensity = _multiChannelPerlin.m_AmplitudeGain;
                float targetIntensity = Mathf.Lerp(currentIntensity, 0f, 0.1f);
                _multiChannelPerlin.m_AmplitudeGain = targetIntensity;
            }
        }
    }
}