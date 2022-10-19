using System;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow.PointsToAnalysis;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.ID;
using ShitMod.Dusts;

namespace ShitMod.Projectiles
{
    public class HoholProjectile : ModProjectile
    {
        public override void SetStaticDefaults() => DisplayName.SetDefault("Hohol Projectile");

        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Magic;
            Projectile.width = 8;
            Projectile.height = 8;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.penetrate = 3;
            Projectile.timeLeft = 600;
            Projectile.light = 0.5f;
            Projectile.ignoreWater = false;
            Projectile.tileCollide = true;
            Projectile.scale = 2f;
        }
        
        public override void AI()
        {
            Projectile.velocity.Y += Projectile.ai[0];
            if (!Main.rand.NextBool(3)) return;
            var dust = Dust.NewDust(Projectile.Center, 1, 1, ModContent.DustType<Salo>(), 0f, 0f, 0, default(Color), 1f);
            Main.dust[dust].scale = 1.5f;
        }

        
    }
}
