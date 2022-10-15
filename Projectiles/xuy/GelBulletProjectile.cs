using Terraria.Audio;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace ShitMod.Projectiles.xuy
{
    public class GelBulletProjectile : ModProjectile
    {
        public override void SetStaticDefaults() => DisplayName.SetDefault("Gel bullet");

        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.width = 4;
            Projectile.height = 20;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.penetrate = 2;
            Projectile.timeLeft = 600;
            Projectile.ignoreWater = false;
            Projectile.tileCollide = true;
            Projectile.scale = 0.7f;
            Projectile.extraUpdates = 1;
        }

        //private int bounces = 0;
        //private int maxBounces = 5;

        //public override void AI()
        //{
        //    Projectile.aiStyle = 0;
        //    Lighting.AddLight(Projectile.position, 0.2f, 0.2f, 0.6f);
        //    Lighting.Brightness(1, 1);
        //}

        //public override void Kill(int timeLeft)
        //{
        //    SoundEngine.PlaySound(SoundID.Dig.WithVolumeScale(.5f).WithPitchOffset(.8f), Projectile.position);
        //    for (int i = 0; i < 6; i++)
        //    {
        //        Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.WoodFurniture, 0f, 0f, 0,
        //            default(Color), 1f);

        //    }
        //}

        //public override bool OnTileCollide(Vector2 oldVelocity)
        //{
        //    bounces++;
        //    SoundEngine.PlaySound(SoundID.Dig.WithVolumeScale(.5f).WithPitchOffset(.8f), Projectile.position);
        //    for (int i = 0; i < 6; i++)
        //    {
        //        Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.WoodFurniture, 0f, 0f, 0,
        //            default(Color), 1f);

        //    }

        //    if (Projectile.velocity.X != oldVelocity.X)
        //        Projectile.velocity.X = -oldVelocity.X;
        //    if (Projectile.velocity.Y != oldVelocity.Y)
        //        Projectile.velocity.Y = -oldVelocity.Y;

        //    Projectile.aiStyle = 1;

        //    if (bounces >= maxBounces)
        //        return true;
        //    return false;
        //}
    }
}