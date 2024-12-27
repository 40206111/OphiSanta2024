using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SecretSanta.UI
{
    public class UiHalfIntToPrefabTracker : UiIntDataTracker
    {
        [SerializeField]
        Image prefab;
        [SerializeField]
        Transform parentTransform;
        [SerializeField]
        Sprite halfSprite;
        [SerializeField]
        Sprite fullSprite;

        List<Image> _prefabs = new List<Image>();

        protected override void DoTracking()
        {
            if (_prefabs.Count < _trackedData)
            {
                var delta = _trackedData - _prefabs.Count;
                for (int i = 0; i < delta * 0.5f; ++i)
                {
                    var newObj = Instantiate(prefab, parentTransform);
                    _prefabs.Add(newObj);
                }
            }

            for (int i = 0; i < _prefabs.Count; ++i)
            {
                if (i * 2 < _trackedData)
                {
                    _prefabs[i].gameObject.SetActive(true);
                    _prefabs[i].sprite = fullSprite;
                    continue;
                }
                _prefabs[i].gameObject.SetActive(false);
            }

            if (_trackedData % 2 == 1)
            {
                var index = ((_trackedData + 1) * 0.5f) - 1;
                _prefabs[(int)index].sprite = halfSprite;
            }

        }


    }
}