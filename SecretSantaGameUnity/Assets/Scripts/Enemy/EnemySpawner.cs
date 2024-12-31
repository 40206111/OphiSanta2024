using SecretSanta.GameManagment;
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
            for (int i = 0; i < _activeEnemies.Count; ++i)
            {
                if (_activeEnemies[i].Data.Health <= 0)
                {
                    _enemyPool.Add(_activeEnemies[i]);
                    _activeEnemies.RemoveAt(i);
                    i--;
                }
            }

            if (_coolDownTimer >= _spawnCooldown)
            {
                Spawn();
                return;
            }

            _coolDownTimer += Time.deltaTime;
        }

        void Spawn(int times = 0)
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
                enemy.gameObject.SetActive(false);
            }
            var playerLevel = SecretSantaGame.Instance.CurPlayerData.Level;
            enemy.Data.SetDefultData();
            var maxRandHealth = playerLevel;
            enemy.Data.Health = Random.Range(enemy.Data.Health, playerLevel);
            var maxRandSpeed = enemy.Data.Speed + (0.05f * playerLevel);
            maxRandSpeed = Mathf.Min(maxRandSpeed, SecretSantaGame.Instance.CurPlayerData.Speed - 0.5f);
            enemy.Data.Speed = Random.Range(enemy.Data.Speed, maxRandSpeed);
            enemy.SetColour();
            enemy.gameObject.SetActive(true);
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
            var maxCoolRange = 0 + playerLevel * 0.05f;
            maxCoolRange = Mathf.Min(maxCoolRange, _spawnCooldown - 0.1f);
            _coolDownTimer = Random.Range(0, maxCoolRange);

            var spawnAgain = Random.Range(0.0f, 1.0f);
            if (spawnAgain >= 0.8f + times * 0.1f)
            {
                Spawn(times++);
            }
        }

    }
}