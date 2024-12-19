

using UnityEngine;

namespace SecretSanta.Enemy
{
    public abstract class EntityData
    {
        public int Damage;
        public int Speed;

        public virtual void SetDefultData() => Debug.Log("Default data not set up for type");

    }
}