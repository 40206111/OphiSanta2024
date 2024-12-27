using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SecretSanta.Doot
{
    public class DootMovement : MonoBehaviour
    {
        Transform TrackedPlayer;

        private void Update()
        {
            if (TrackedPlayer == null)
            {
                return;
            }

            transform.position = Vector3.MoveTowards(transform.position, TrackedPlayer.position, 5 * Time.deltaTime);

            var dir = transform.position - TrackedPlayer.position;
            if ( dir.magnitude < 0.01 )
            {
                GameManagment.SecretSantaGame.Instance.CurPlayerData.Experience++;
                Destroy(gameObject);
            }    
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("DootCollector"))
            {
                TrackedPlayer = other.transform;
            }
        }
    }
}