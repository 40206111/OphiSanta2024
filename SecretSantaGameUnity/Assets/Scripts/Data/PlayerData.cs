

namespace SecretSanta.Data
{
    public class PlayerData : CreatureData
    {
        public int Experience;
        public int XpToNextLvl;
        public int Level;

        public override void SetDefultData()
        {
            Damage = 1;
            Speed = 2;
            Health = 6;
            Experience = 0;
            XpToNextLvl = 5;
            Level = 0;
        }
    }
}