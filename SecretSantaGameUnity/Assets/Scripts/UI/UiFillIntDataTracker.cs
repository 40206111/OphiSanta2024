using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SecretSanta.UI
{
    public class UiFillIntDataTracker : UiIntDataTracker
    {
        Image FillImage;
        protected int _fullAmount;

        protected override void Awake()
        {
            FillImage = GetComponent<Image>();

            base.Awake();
        }

        protected override void DoTracking()
        {
            FillImage.fillAmount = (float)_trackedData / (float)_fullAmount;
        }
    }
}