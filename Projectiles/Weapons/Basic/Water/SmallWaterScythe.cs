using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ShitMod.Projectiles.Weapons.Basic.Water;

public class SmallWaterScythe : ModProjectile
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Small water scythe");
    }

    public override void SetDefaults()
    {
        Projectile.width = 50;
        Projectile.height = 50;
        Projectile.aiStyle = 18;
        Projectile.alpha = 55;
        Projectile.friendly = true;
        Projectile.DamageType=DamageClass.Melee;
        Projectile.penetrate = 3;
        Projectile.timeLeft = 420;
        Projectile.ignoreWater = true;
        Projectile.tileCollide = false;
        //Projectile.ai;
    }

    public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
    {
        target.AddBuff(BuffID.Wet, 120);
    }

    public override void AI()
    {
        Lighting.AddLight(Projectile.Center, 0f, 0f, 0.5f);

        Projectile.rotation = Main.rand.NextFloat(MathHelper.TwoPi);
    }
}