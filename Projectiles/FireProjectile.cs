using Terraria;
using Terraria.ModLoader;
using System;
using Microsoft.Xna.Framework;
using Terraria.ID;
using ShitMod.Dusts;
using ShitMod.Buffs;

namespace ShitMod.Projectiles
{
    public class FireProjectile : ModProjectile
    {
        private int delay = 0;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("FireProjectile");
        }

        public override void SetDefaults()
        {
            Projectile.width = 24;
            Projectile.height = 24;
            Projectile.timeLeft = 100;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.ignoreWater = false;
            Projectile.tileCollide = false;
            Projectile.penetrate = 1;
            delay = 0;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(ModContent.BuffType<BetterOnFire>(), 120);
        }
        public override void AI()
        {
            delay += 1;
            Projectile.velocity.Y += Projectile.ai[0];
            if (!Main.rand.NextBool(3)) return;
            var dust = Dust.NewDust(Projectile.Center, 1, 1, ModContent.DustType<FireDust>(), 0f, 0f, 0, default(Color), 1f);
            Main.dust[dust].scale = 1.5f;
        }
    }
}