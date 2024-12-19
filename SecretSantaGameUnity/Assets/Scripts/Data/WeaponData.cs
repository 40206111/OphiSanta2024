

namespace SecretSanta.Data
{
    public class WeaponData : EntityData
    {
        public float Cooldown;

        public override void SetDefultData()
        {
            Damage = 1;
            Speed = 2;
            Cooldown = 0.5f;
        }
    }
}