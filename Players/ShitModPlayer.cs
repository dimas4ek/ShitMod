using Terraria.ModLoader;

namespace ShitMod.Players
{
    public class ShitModPlayer : ModPlayer
    {
        private const int saveVersion = 0;
        public bool minionName = false;
        public bool Pet = false;
        public static bool hasProjectile;

        public override void ResetEffects()
        {
            minionName = false;
            Pet = false;
        }
    }
}