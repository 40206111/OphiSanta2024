using SecretSanta.Data;
using SecretSanta.GameManagment;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SecretSanta.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] SpriteRenderer playerSprite;
        private PlayerControls playerControls;
        PlayerData _data;

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
            _data = SecretSantaGame.Instance.CurPlayerData;
            _data.Speed = SecretSantaGame.Instance.CurPlayerData.Speed;

            var dir = playerControls.BattleControls.Move.ReadValue<Vector2>();

            var velocity = _data.Speed * Time.deltaTime * dir;

            var pos = transform.position;
            pos += new Vector3(velocity.x, velocity.y, 0);
            transform.position = pos;
        }

        public void DoDamage( int value )
        {
            var health = _data.Health - value;
            Debug.Log($"Player health before: {_data.Health}, after not clamped {health}");
            _data.Health = Mathf.Max(health, 0);
            if (health == 0)
            {
                playerControls.Disable();
                SecretSantaGame.Instance.GameOver();
            }
            SecretSantaGame.Instance.CurPlayerData = _data;
            StartCoroutine(FlashRed());
        }

        private IEnumerator<YieldInstruction> FlashRed()
        {
            var beforeCol = playerSprite.color;

            yield return new WaitForSeconds(0.05f);

            playerSprite.color = Color.red;

            yield return new WaitForSeconds(0.05f);

            playerSprite.color = beforeCol;
        }
    }
}