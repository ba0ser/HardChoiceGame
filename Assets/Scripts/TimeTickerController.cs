using System;
using UnityEngine;

namespace Timer
{
    public class TimeTickerController : MonoBehaviour
    {
        public event EventHandler<float> FrameUpdateEvent;
        public event EventHandler SecondPassedEvent;
        
        private float _currentTime;
        
        private void Update()
        {
            _currentTime += Time.deltaTime;
            if (_currentTime >= 1)
            {
                _currentTime = 0;
                SecondPassedEvent?.Invoke(this, EventArgs.Empty);
            }

            FrameUpdateEvent?.Invoke(this, Time.deltaTime);
        }
    }
}