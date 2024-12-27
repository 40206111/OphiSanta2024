

namespace SecretSanta.Data
{
    public class EnemyData : CreatureData
    {
        public float DamageCooldown;

        public override void SetDefultData()
        {
            Damage = 1;
            Speed = 1;
            Health = 1;
            DamageCooldown = 0.2f;
        }
    }
}