using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SecretSanta.UI
{
    public class UiIntDataTracker : MonoBehaviour
    {
        protected int _trackedData;
        int _lastData;

        protected virtual void Awake()
        {
            _lastData = int.MaxValue;
        }

        protected virtual void Update()
        {
            if (_lastData != _trackedData)
            {
                DoTracking();
                _lastData = _trackedData;
            }
        }

        protected virtual void DoTracking() { }

    }
}