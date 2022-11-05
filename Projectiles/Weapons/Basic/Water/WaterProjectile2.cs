using ShitMod.Buffs;
using ShitMod.Dusts;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ShitMod.Projectiles.Weapons.Basic.Water
{
    public class WaterProjectile2 : ModProjectile
    {
        private int delay = 0;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("WaterProjectile2");
        }

        public override void SetDefaults()
        {
            Projectile.width = 12;
            Projectile.height = 12;
            Projectile.timeLeft = 100;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.ignoreWater = false;
            Projectile.tileCollide = false;
            Projectile.penetrate = 1;
            //Projectile.scale = 0.4f;
            delay = 0;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Slow, 120);
            target.AddBuff(BuffID.Wet, 120);

        }
        public override void AI()
        {
            Projectile.rotation = (float)Math.Atan2(Projectile.velocity.Y, Projectile.velocity.X) + 1.57f;

            delay += 1;
            Projectile.velocity.Y += Projectile.ai[0];
            if (!Main.rand.NextBool(3)) return;
            var dust = Dust.NewDust(Projectile.Center, 1, 1, ModContent.DustType<FireDust>(), 0f, 0f, 0, default, 1f);
            Main.dust[dust].scale = 1.5f;
        }
    }
}