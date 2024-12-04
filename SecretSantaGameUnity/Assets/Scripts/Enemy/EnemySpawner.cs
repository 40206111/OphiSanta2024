using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SecretSanta.Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] GameObject _player;
        [SerializeField] Enemy _enemyPrefab;
        [SerializeField] float _spawnRadius = 5;
        [SerializeField] float _spawnCooldown = 2;
        [SerializeField] float _deadZone = 2;

        float _coolDownTimer = 0;

        List<Enemy> _activeEnemies = new List<Enemy>();
        List<Enemy> _enemyPool = new List<Enemy>();

        private void Update()
        {
            if (_coolDownTimer >= _spawnCooldown)
            {
                Enemy enemy;
                if (_enemyPool.Count > 0)
                {
                    enemy = _enemyPool[^1];
                    _enemyPool.RemoveAt(_enemyPool.Count - 1);
                }
                else
                {
                    enemy = Instantiate(_enemyPrefab, transform);
                }
                var randX = Random.Range(-_spawnRadius, _spawnRadius);
                randX = randX > 0 ? Mathf.Max(randX, _deadZone) : Mathf.Min(randX, -_deadZone);
                var randY = Random.Range(-_spawnRadius, _spawnRadius);
                randY = randY > 0 ? Mathf.Max(randY, _deadZone) : Mathf.Min(randY, -_deadZone);
                var spawnPos = _player.transform.position;
                spawnPos.x += randX;
                spawnPos.y += randY;
                enemy.transform.position = spawnPos;

                enemy.TargetObject = _player;

                _activeEnemies.Add(enemy);
                _coolDownTimer = 0;
                return;
            }

            _coolDownTimer += Time.deltaTime;
        }
    }
}