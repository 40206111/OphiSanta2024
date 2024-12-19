

namespace SecretSanta.Enemy
{
    public class PlayerData : CreatureData
    {
        public int Experience;
        public int XpToNextLvl;

        public override void SetDefultData()
        {
            Damage = 1;
            Speed = 2;
            Health = 3;
            Experience = 0;
            XpToNextLvl = 5;
        }
    }
}