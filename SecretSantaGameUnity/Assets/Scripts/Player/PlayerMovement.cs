using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SecretSanta.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        private Vector2 _startFingerPos;
        [SerializeField]
        private float _speed;

        private bool _touching;

        private void Update()
        {
            var dir = new Vector2();

            if (Input.touchCount > 0)
            {
                dir = CheckTouchControls();
            }
            else
            {
                _touching = false;
                dir = CheckKeyboardControls();
            }


            var velocity = _speed * Time.deltaTime * dir;

            var pos = transform.position;
            pos += new Vector3(velocity.x, velocity.y, 0);
            transform.position = pos;
        }

        private Vector2 CheckTouchControls()
        {
            var touch = Input.GetTouch(0);

            if (!_touching)
            {
                _startFingerPos = touch.position;
                _touching = true;
            }

            var dir = touch.position - _startFingerPos;

            return dir.normalized;
        }

        private Vector2 CheckKeyboardControls()
        {
            var dir = new Vector2();

            if (Input.GetKey(KeyCode.W))
            {
                dir.y += 1;
            }
            if (Input.GetKey(KeyCode.S))
            {
                dir.y -= 1;
            }
            if (Input.GetKey(KeyCode.A))
            {
                dir.x -= 1;
            }
            if (Input.GetKey(KeyCode.D))
            {
                dir.x += 1;
            }

            return dir;
        }
    }
}