

using UnityEngine;

namespace SecretSanta.Data
{
    public abstract class EntityData
    {
        public int Damage;
        public float Speed;

        public virtual void SetDefultData() => Debug.Log("Default data not set up for type");

    }
}