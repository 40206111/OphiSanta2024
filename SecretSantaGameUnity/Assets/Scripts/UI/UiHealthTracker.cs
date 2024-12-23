using SecretSanta.GameManagment;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SecretSanta.UI
{
    public class UiHealthTracker : UiHalfIntToPrefabTracker
    {
        protected override void Update()
        {
            _trackedData = SecretSantaGame.Instance.CurPlayerData.Health;
            base.Update();
        }

    }
}