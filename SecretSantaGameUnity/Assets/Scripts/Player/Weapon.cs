using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SecretSanta.Player
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] int _damage = 1;
        [SerializeField] float _speed = 2;
        [SerializeField] float _cooldown = 0.5f;
        [SerializeField] BoxCollider2D _collider;

        bool _swinging = false;
        bool _isClockwise = true;
        float _timeCooling = 0;

        private void Update()
        {
            if (_swinging)
            {
                return;
            }

            if (_timeCooling >= _cooldown)
            {
                StartCoroutine(WaitForSwing());
                _timeCooling = 0;
                return;
            }

            _timeCooling += Time.deltaTime;

        }

        private IEnumerator<YieldInstruction> WaitForSwing()
        {
            _swinging = true;

            float multiplier = _isClockwise ? 1 : -1;
            _isClockwise = !_isClockwise;
            float totRotateAmount = 0;

            while (totRotateAmount < 360)
            {
                //TODO: This should start fast and slow as it rotates
                float rotateAmount = 100 * _speed * Time.deltaTime * multiplier;
                transform.Rotate(new Vector3(0, 0, rotateAmount));
                totRotateAmount += rotateAmount * multiplier;
                yield return null;
            }

            transform.SetLocalPositionAndRotation(transform.localPosition, Quaternion.identity);

            _swinging = false;
        }

    }
}
