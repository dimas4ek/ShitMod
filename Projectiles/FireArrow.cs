using Microsoft.Xna.Framework;
using ShitMod.Buffs;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ShitMod.Projectiles
{
    public class FireArrow : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fire Arrow"); // The English name of the projectile
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5; // The length of old position to be recorded
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0; // The recording mode

        }

        public override void SetDefaults()
        {
            //Projectile.width = 60;
            //Projectile.height = 60;
            //Projectile.aiStyle = 0;
            //Projectile.scale = 1f;
            //Projectile.friendly = true;
            //Projectile.DamageType = DamageClass.Ranged;
            //Projectile.penetrate = -1;
            //Projectile.timeLeft = 600;
            //Projectile.tileCollide = false;
            //AIType = ProjectileID.Bullet;
            //Main.projFrames[Projectile.type] = 10;

            Projectile.width = 14;
            Projectile.height = 14;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.arrow = true;
            Projectile.penetrate = 1;
            Projectile.timeLeft = 240;
        }

        public override void AI()
        {
            Projectile.rotation = Utils.ToRotation(Projectile.velocity) + (float)Math.PI / 2f;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(ModContent.BuffType<BetterOnFire>(), 120);
        }

    }
}