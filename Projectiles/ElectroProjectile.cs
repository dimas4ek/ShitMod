using Terraria;
using Terraria.ModLoader;
using System;
using Microsoft.Xna.Framework;
using Terraria.ID;
using ShitMod.Dusts;
using ShitMod.Buffs;

namespace ShitMod.Projectiles
{
    public class ElectroProjectile : ModProjectile
    {
        private int delay = 0;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("ElectroProjectile");
        }

        public override void SetDefaults()
        {
            Projectile.width = 48;
            Projectile.height = 48;
            Projectile.timeLeft = 240;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.penetrate = 1;
            delay = 0;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(ModContent.BuffType<Paralysis>(), 60);
        }
        public override void AI()
        {
            delay += 1;
            Projectile.velocity.Y += Projectile.ai[0];
            if (!Main.rand.NextBool(3)) return;
            var dust = Dust.NewDust(Projectile.Center, 1, 1, ModContent.DustType<ElectroDust>(), 0f, 0f, 0, default(Color), 1f);
            Main.dust[dust].scale = 1.5f;
        }
    }
}