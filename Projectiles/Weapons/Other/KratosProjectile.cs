using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace ShitMod.Projectiles.Weapons.Other
{
    public class KratosProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Kratos Projectile");
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 3;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
        }

        public override string Texture => "ShitMod/Projectiles/Weapons/Other/KratosProjectile";

        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Melee;
            Projectile.width = 40;
            Projectile.height = 40;
            Projectile.friendly = true;
            Projectile.tileCollide = true;
            Projectile.ignoreWater = true;
            Projectile.penetrate = 2;
            Projectile.timeLeft = 1050;
            Projectile.scale = 1.3f;
        }

        public override void AI()
        {
            Projectile.rotation += 0.53f * Projectile.direction;

            if (Projectile.timeLeft < 1000)
            {
                Projectile.ai[0] = 1f;
            }
            if (Projectile.ai[0] == 0f)
            {
                return;
            }

            Projectile.tileCollide = false;
            float speed = 20f;
            float distance = Projectile.Distance(Main.player[Projectile.owner].Center);
            Vector2 val = (Main.player[Projectile.owner].Center - Projectile.Center) / distance * speed;

            if (distance > 3000f)
            {
                Projectile.Kill();
            }
            if (Projectile.velocity.X < val.X)
            {
                Projectile.velocity.X += 2f;
            }
            else if (Projectile.velocity.X > val.X)
            {
                Projectile.velocity.X -= 2f;
            }
            if (Projectile.velocity.Y < val.Y)
            {
                Projectile.velocity.Y += 2f;
            }
            else if (Projectile.velocity.Y > val.Y)
            {
                Projectile.velocity.Y -= 2f;
            }
            if (Main.myPlayer == Projectile.owner)
            {
                Rectangle hitbox = Projectile.Hitbox;
                if (hitbox.Intersects(Main.player[Projectile.owner].Hitbox))
                {
                    Projectile.Kill();
                }
            }
        }

        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D value = ModContent.Request<Texture2D>("ShitMod/Projectiles/Weapons/Other/KratosChain", (AssetRequestMode)2).Value;

            Vector2 mountedCenter = Main.player[Projectile.owner].MountedCenter; //MountedCenter - центер хитбокса игрока
                                                                                 //Center - центер спрайта игрока
            Vector2 projCenter = Projectile.Center;
            Vector2 origin = new Vector2(value.Width * 0.4f, value.Height * 0.4f); //откуда выпускаются
            Vector2 distance = mountedCenter - projCenter;
            float rotation = (float)Math.Atan2(distance.Y, distance.X) - 1.57f;
            bool flag = true;

            while (flag)
            {
                if (distance.Length() < value.Height)
                {
                    flag = false;
                    continue;
                }
                distance.Normalize();                   //
                projCenter += distance * value.Height;   //удлинение расстояния цепи 
                distance = mountedCenter - projCenter;  //
                Color color = Lighting.GetColor((int)(projCenter.X / 16f), (int)(projCenter.Y / 16f));
                Main.spriteBatch.Draw(value, projCenter - Main.screenPosition, null, color, rotation, origin, 1f, 0, 0f);
            }
            return true;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            SoundEngine.PlaySound(SoundID.Dig, Projectile.Center);
            Collision.HitTiles(Projectile.position, Projectile.velocity, Projectile.width, Projectile.height);
            Projectile.ai[0] = 1f;
            return false;
        }
    }
}


/*public class KratosProjectile : ModProjectile
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("KratosProjectile");
        ProjectileID.Sets.TrailCacheLength[Projectile.type] = 6;
        ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
    }

    public override void SetDefaults()
    {
        Projectile.DamageType = DamageClass.Ranged;
        Projectile.friendly = true;
        Projectile.light = 0.4f;

        Projectile.width = 50;
        Projectile.height = 50;
        Projectile.penetrate = -1;
        Projectile.aiStyle = -1;
    }

    public override bool? CanDamage()
    {
        return false;
    }

    public override bool PreAI()
    {
        if (Projectile.ai[0] == 1)
        {
            Projectile.ai[1]++;

            //stay in place
            Projectile.position = Projectile.oldPosition;
            Projectile.velocity = Vector2.Zero;
            Projectile.rotation += Projectile.direction * -0.4f;

            if (Projectile.ai[1] > 15)
            {
                Projectile.ai[0] = 2;
            }

            return false;
        }

        return true;
    }

    public override void AI()
    {
        //вылет
        if (Projectile.ai[0] == 0)
        {
            Projectile.ai[1]++;

            if (Projectile.ai[1] > 30)
            {
                Projectile.ai[0] = 1;
                Projectile.ai[1] = 0;
                Projectile.netUpdate = true;
            }
        }
        //возвращение к игроку
        else if (Projectile.ai[0] == 2)
        {
            Projectile.extraUpdates = 0;
            Projectile.velocity = Vector2.Normalize(Main.player[Projectile.owner].Center - Projectile.Center) * 15;

            //убейство, когда вернется к игроку
            if (Projectile.Distance(Main.player[Projectile.owner].Center) <= 30)
                Projectile.Kill();
        }

        //вращение
        Projectile.rotation += Projectile.direction * -0.4f;

        //dust
        int dustId = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y + 2f), Projectile.width, Projectile.height + 5, 60, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f, 100, default(Color), 2f);
        Main.dust[dustId].noGravity = true;

        if (Projectile.ai[0] == 1)
        {
            Projectile.localAI[0] += 0.1f;
            Projectile.position += Projectile.DirectionTo(Main.player[Projectile.owner].Center) * Projectile.localAI[0];

            if (Projectile.Distance(Main.player[Projectile.owner].Center) <= Projectile.localAI[0])
                Projectile.Kill();
        }
    }

    public override bool OnTileCollide(Vector2 oldVelocity)
    {
        if (Projectile.ai[0] == 0)
        {
            Projectile.ai[0] = 1;
            Projectile.ai[1] = 0;
        }
        Projectile.tileCollide = false;

        return false;
    }

    public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
    {
        target.AddBuff(ModContent.BuffType<BetterOnFire>(), 200);
        target.AddBuff(BuffID.Slow, 60);
    }
    public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough, ref Vector2 hitboxCenterFrac)
    {
        //колизия
        width = 30;
        height = 30;
        return true;
    }

    public override bool PreDraw(ref Color lightColor)
    {
        Texture2D texture2D13 = TextureAssets.Projectile[Projectile.type].Value;
        int num156 = TextureAssets.Projectile[Projectile.type].Value.Height / Main.projFrames[Projectile.type];
        int y3 = num156 * Projectile.frame; 
        Rectangle rectangle = new Rectangle(0, y3, texture2D13.Width, num156);
        Vector2 origin2 = rectangle.Size() / 2f;

        Color color26 = lightColor;
        color26 = Projectile.GetAlpha(color26);

        for (int i = 0; i < ProjectileID.Sets.TrailCacheLength[Projectile.type]; i++)
        {
            Color color27 = color26;
            color27 *= (float)(ProjectileID.Sets.TrailCacheLength[Projectile.type] - i) / ProjectileID.Sets.TrailCacheLength[Projectile.type];
            Vector2 value4 = Projectile.oldPos[i];
            float num165 = Projectile.oldRot[i];
            Main.EntitySpriteDraw(texture2D13, value4 + Projectile.Size / 2f - Main.screenPosition + new Vector2(0, Projectile.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(rectangle), color27, num165, origin2, Projectile.scale, SpriteEffects.None, 0);
        }

        Main.EntitySpriteDraw(texture2D13, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(rectangle), Projectile.GetAlpha(lightColor), Projectile.rotation, origin2, Projectile.scale, SpriteEffects.None, 0);
        return false;
    }
}*/