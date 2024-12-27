using SecretSanta.Data;
using SecretSanta.Enemy;
using System.Collections.Generic;
using UnityEngine;

namespace SecretSanta.Player
{
    public class Weapon : MonoBehaviour
    {
        WeaponData Data = new WeaponData();

        bool _swinging = false;
        bool _isClockwise = true;
        float _timeCooling = 0;

        private void Awake()
        {
            Data.SetDefultData();
        }

        private void Update()
        {
            if (_swinging)
            {
                return;
            }

            if (_timeCooling >= Data.Cooldown)
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
                float rotateAmount = multiplier * Time.deltaTime * 100 * Data.Speed;
                transform.Rotate(new Vector3(0, 0, rotateAmount));
                totRotateAmount += rotateAmount * multiplier;
                yield return null;
            }

            transform.SetLocalPositionAndRotation(transform.localPosition, Quaternion.identity);

            _swinging = false;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Enemy"))
            {
                var enemy = other.GetComponent<SecretSanta.Enemy.Enemy>();
                if ( enemy == null )
                {
                    return;
                }
                enemy.DoDamage(Data.Damage);
            }
        }
    }
}
