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
        public float coolDownTimer;

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
            gameObject.SetActive(false);
            var doot = Instantiate(_doot);
            doot.transform.position = transform.position;
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