using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SecretSanta.Enemy
{
    public class Enemy : MonoBehaviour
    {
        public GameObject TargetObject;
        [SerializeField] float _speed = 1;

        private void Update()
        {
            var dir = TargetObject.transform.position - transform.localPosition;
            dir = Vector3.Normalize(dir);

            var velocity = _speed * Time.deltaTime * dir;

            var pos = transform.position;
            pos += new Vector3(velocity.x, velocity.y, 0);
            transform.position = Vector3.MoveTowards( transform.position, TargetObject.transform.position, _speed  * Time.deltaTime );
        }
    }
}