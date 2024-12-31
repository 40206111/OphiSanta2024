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
        [SerializeField] CircleCollider2D _collectionRadBox;
        private PlayerControls playerControls;
        PlayerData _data;
        float maxInvincible = 1;
        float invincibleTimer;

        private void Awake()
        {
            playerControls = new PlayerControls();
            SecretSantaGame.Instance.UpgradeAdded += UpgradeChosen;
        }

        private void OnEnable()
        {
            playerControls.Enable();
        }

        private void OnDisable()
        {
            playerControls.Disable();
        }

        private void OnDestroy()
        {
            SecretSantaGame.Instance.UpgradeAdded -= UpgradeChosen;
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
            if (invincibleTimer < maxInvincible)
            {
                invincibleTimer += Time.deltaTime;
            }
        }

        public void DoDamage( int value )
        {
            if (invincibleTimer < maxInvincible)
            {
                return;
            }
            var health = _data.Health - value;
            _data.Health = Mathf.Max(health, 0);
            if (health == 0)
            {
                playerControls.Disable();
                SecretSantaGame.Instance.GameOver();
            }
            SecretSantaGame.Instance.CurPlayerData = _data;
            StartCoroutine(FlashRed());
            invincibleTimer = 0;
        }

        private IEnumerator<YieldInstruction> FlashRed()
        {
            var beforeCol = playerSprite.color;

            yield return new WaitForSeconds(0.05f);

            playerSprite.color = Color.red;

            yield return new WaitForSeconds(0.05f);

            playerSprite.color = beforeCol;
        }

        public void UpgradeChosen(UpgradeData data)
        {
            _data.Health += data.AddHealth;
            _data.Speed += data.AddSpeed;
            _collectionRadBox.radius += data.AddCollectRadius;
            SecretSantaGame.Instance.CurPlayerData = _data;
        }
    }
}