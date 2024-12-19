using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiIntDataTracker : MonoBehaviour
{
    protected int _trackedData;
    int lastData;

    protected virtual void Awake()
    {
        lastData = int.MaxValue;
    }

    protected virtual void Update()
    {
        if (lastData != _trackedData)
        {
            lastData = _trackedData;
            DoTracking();
        }
    }

    protected virtual void DoTracking() {}

}
