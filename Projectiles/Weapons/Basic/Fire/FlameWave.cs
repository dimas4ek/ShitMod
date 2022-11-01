using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ShitMod.Projectiles.Weapons.Basic.Fire;

public class FlameWave : ModProjectile
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Flame Wave");
        //Sets.TrailCacheLength[Projectile.type] = 10;
        //Sets.TrailCacheMode[Projectile.type] = 1;
    }

    public override void SetDefaults()
    {
        Projectile.width = 30;
        Projectile.height = 30;
        Projectile.friendly = true;
        Projectile.ignoreWater = true;
        Projectile.DamageType=DamageClass.Melee;
        Projectile.penetrate = 2;
        Projectile.alpha = 120;
        Projectile.timeLeft = 200;
        Projectile.tileCollide = false;
    }

    public override void AI()
    {
        Lighting.AddLight(Projectile.Center, 1f, 0.7f, 0f);
        Projectile.rotation = (float)Math.Atan2(Projectile.velocity.Y, Projectile.velocity.X) + 1.57f;
        //Projectile.velocity.Y += Projectile.ai[0];
        if (Main.rand.NextBool(2))
        {
            Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, 
                DustID.Firefly, Projectile.velocity.X * 0.5f, Projectile.velocity.Y * 0.5f, 0, default(Color), 1f);
        }

        
    }

    public override Color? GetAlpha(Color lightColor)
    {
        return new Color(200, 200, 200, Projectile.alpha);
    }

    public override void Kill(int timeLeft)
    {
        for (int i = 0; i < 3; i++)
        {
            Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, DustID.Firefly, 
                Projectile.velocity.X, Projectile.velocity.Y, 0, default(Color), 1f);
        }
    }

    public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
    {
        target.AddBuff(BuffID.OnFire, 100);
    }
}