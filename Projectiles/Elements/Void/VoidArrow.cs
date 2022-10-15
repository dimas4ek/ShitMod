 using Microsoft.Xna.Framework;
using Terraria.Audio;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ShitMod.Projectiles.Elements.Void;

public class VoidArrow : ModProjectile
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Void Portal");
    }

    public override void SetDefaults()
    {
        Projectile.width = 60;
        Projectile.height = 60;
        Projectile.aiStyle = 0;
        Projectile.scale = 1f;
        Projectile.friendly = true;
        Projectile.DamageType = DamageClass.Ranged;
        Projectile.penetrate = -1;
        Projectile.timeLeft = 600;
        Projectile.tileCollide = false;
        AIType = ProjectileID.Bullet;
        Main.projFrames[Projectile.type] = 10;
    }

    public override bool PreDraw(ref Color lightColor)
    {
        Projectile.frameCounter++; //Making the timer go up.
        if (Projectile.frameCounter < 4) return true; //Change the 4 to how fast you want the animation to be

        Projectile.frame++; //Making the frame go up...
        Projectile.frameCounter = 0; //Resetting the timer.
        if (Projectile.frame > 9) //Change the 3 to the amount of frames your projectile has.
            Projectile.frame = 0;

        return true;
    }

    public override void Kill(int timeLeft)
    {
        //SoundEngine.PlaySound(SoundID.Item, (int)Projectile.position.X, (int)Projectile.position.Y, 34);
        //SoundEngine.PlaySound(SoundID.Item.WithVolumeScale(.5f).WithPitchOffset(.8f), Projectile.position);
        int dustId = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y + 2f), 
            Projectile.width + 5, Projectile.height + 5, DustID.PurpleTorch, Projectile.velocity.X * 0.2f,
            Projectile.velocity.Y * 0.2f, 100, default(Color), 0.8f);

        Main.dust[dustId].noGravity = true;
    }
}