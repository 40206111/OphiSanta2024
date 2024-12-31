using SecretSanta.Data;
using SecretSanta.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SecretSanta.Enemy
{
    public class Enemy : MonoBehaviour
    {
        public GameObject TargetObject;
        public EnemyData Data = new EnemyData();
        [SerializeField] GameObject _doot;
        [SerializeField] SpriteRenderer _spriteRenderer;
        public float coolDownTimer;

        private void OnEnable()
        {
            var colour = new Color
            {
                r = 0.5f + Data.Health * 0.1f,
                g = Data.Health * 0.1f,
                b = 0.5f + Data.Health * 0.1f,
                a = 100
            };
            _spriteRenderer.color = colour;
        }

        private void Update()
        {
            if (Time.time % 1f < 0.7f)
            {

            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, TargetObject.transform.position, Data.Speed * Time.deltaTime * 3f);
            }
            coolDownTimer = Mathf.Max(coolDownTimer - Time.deltaTime, 0);
        }

        public void DoDamage(int value)
        {
            var newHealth = Data.Health - value;
            Data.Health = Mathf.Max(newHealth, 0);
            if (Data.Health <= 0)
            {
                gameObject.SetActive(false);
                var doot = Instantiate(_doot);
                doot.transform.position = transform.position;
            }
            else
            {
                StartCoroutine(FlashRed());
            }
        }

        private IEnumerator<YieldInstruction> FlashRed()
        {
            _spriteRenderer.color = Color.red;

            yield return new WaitForSeconds(0.05f);

            var colour = new Color
            {
                r = 0.5f + Data.Health * 0.1f,
                g = Data.Health * 0.1f,
                b = 0.5f + Data.Health * 0.1f,
                a = 100
            };
            _spriteRenderer.color = colour;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (coolDownTimer > 0)
            {
                return;
            }
            if (collision.CompareTag("Player"))
            {
                var player = collision.GetComponent<PlayerController>();
                if (player == null)
                {
                    return;
                }
                player.DoDamage(Data.Damage);
                coolDownTimer = Data.DamageCooldown;
            }

        }
    }
}