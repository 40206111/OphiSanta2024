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

        public void SetColour()
        {
            float c = 5;
            float percentage = c / (float)(c + (Data.Health-1));
            percentage *= percentage;
            Debug.Log($"{Data.Health}, {percentage}");
            Color noHealth = new Color(0.4f, 0f, 0.4f, 1f);
            for (int i = 0; i < 3; ++i)
            {
                noHealth[i] += (percentage * Mathf.Min(1f - noHealth[i], 0.9f));
            }
            _spriteRenderer.color = noHealth;
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

            SetColour();
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