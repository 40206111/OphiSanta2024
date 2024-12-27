using SecretSanta.Data;
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

        private void Update()
        {
            transform.position = Vector3.MoveTowards( transform.position, TargetObject.transform.position, Data.Speed  * Time.deltaTime );
        }

        public void DoDamage(int value)
        {
            var newHealth = Data.Health - value;
            Data.Health = Mathf.Max(newHealth, 0);
            gameObject.SetActive(false);
            var doot = Instantiate(_doot);
            doot.transform.position = transform.position;
        }
    }
}