using Microsoft.Xna.Framework;
using ShitMod.Buffs;
using ShitMod.Dusts;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ShitMod.Projectiles
{
    public class PoisonProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 24;
            Projectile.height = 24;
            Projectile.friendly = true;
            Projectile.aiStyle = 0;
            Projectile.penetrate = 3;
            Projectile.extraUpdates = 1;
            Projectile.hostile = false;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(ModContent.BuffType<PoisonPuls>(), 300);
            target.AddBuff(BuffID.Slow, 60);
        }

        public override void AI()
        {
            Projectile.velocity.X *= .99f;
            Projectile.velocity.Y += .2f;
            if (Projectile.velocity.X < 0)
                Projectile.spriteDirection = -1;
            Projectile.rotation += Projectile.velocity.X / 32;

            Projectile.velocity.Y += Projectile.ai[0];
            if (!Main.rand.NextBool(3)) return;
            var dust = Dust.NewDust(Projectile.Center, 1, 1, ModContent.DustType<PoisonDust>(), 0f, 0f, 0, default(Color), 3.5f);
            Main.dust[dust].scale = 1.5f;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Projectile.Kill();
            return false;
        }

        
    }
}