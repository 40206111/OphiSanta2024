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
        [SerializeField] BoxCollider2D _collider;

        private void Update()
        {
            transform.position = Vector3.MoveTowards( transform.position, TargetObject.transform.position, Data.Speed  * Time.deltaTime );
        }
    }
}