using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.ID;

namespace ShitMod.Projectiles.xuy
{
    public class TestProjectile : ModProjectile
    {
        public override void SetStaticDefaults() => DisplayName.SetDefault("Test Projectile");

        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Magic;
            Projectile.width = 8;
            Projectile.height = 8;
            Projectile.aiStyle = 50;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.penetrate = 3;
            Projectile.timeLeft = 600;
            Projectile.light = 0.5f;
            Projectile.ignoreWater = false;
            Projectile.tileCollide = true;
            Projectile.scale = .5f;
        }

        public override void AI()
        {
            int dust = Dust.NewDust(Projectile.Center, 1, 1, DustID.MagicMirror, 0f, 0f, 0, default, 1f);
            Main.dust[dust].scale = Main.rand.Next(50, 135) * 0.013f;
            Main.dust[dust].velocity *= 0.3f;
            Main.dust[dust].noGravity = true;
            int dust2 = Dust.NewDust(Projectile.Center, 1, 1, DustID.MagicMirror, 0f, 0f, 0, default, 1f);
            Main.dust[dust2].velocity *= 0.3f;
            Main.dust[dust2].scale = Main.rand.Next(100, 135) * 0.013f;
            Main.dust[dust2].noGravity = true;
        }


    }
}
