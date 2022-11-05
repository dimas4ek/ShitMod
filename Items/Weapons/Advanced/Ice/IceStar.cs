using Terraria;
using Terraria.ModLoader;

namespace ShitMod.Items.Weapons.Advanced.Ice;

public class IceStar : ModProjectile
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Star");
    }

    public override void SetDefaults()
    {
        Projectile.width = 10;
        Projectile.height = 10;
        Projectile.friendly = true;
        Projectile.penetrate = -1;
        Projectile.alpha = 255;
        Projectile.DamageType = DamageClass.Magic;
        Projectile.aiStyle = 93;
        Projectile.extraUpdates = 1;
        Projectile.usesLocalNPCImmunity = true;
        Projectile.localNPCHitCooldown = 10;
    }
}