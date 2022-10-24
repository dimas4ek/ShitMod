using Terraria.ModLoader;

namespace ShitMod.Players
{
    public class ShitModPlayer : ModPlayer
    {
        private const int saveVersion = 0;
        //public bool minionName = false;

        public bool NagaPet = false;

        public static bool hasProjectile;

        public override void ResetEffects()
        {
            //minionName = false;
            NagaPet = false;
        }
    }
}