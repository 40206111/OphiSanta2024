using SecretSanta.GameManagment;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SecretSanta.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        private float _speed;

        private PlayerControls playerControls;

        private void Awake()
        {
            playerControls = new PlayerControls();
        }

        private void OnEnable()
        {
            playerControls.Enable();
        }

        private void OnDisable()
        {
            playerControls.Disable();
        }

        private void Update()
        {
            _speed = SecretSantaGame.Instance.CurPlayerData.Speed;

            var dir = playerControls.BattleControls.Move.ReadValue<Vector2>();

            var velocity = _speed * Time.deltaTime * dir;

            var pos = transform.position;
            pos += new Vector3(velocity.x, velocity.y, 0);
            transform.position = pos;
        }
    }
}