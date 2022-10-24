﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using static Terraria.ModLoader.PlayerDrawLayer;
using ShitMod.Players;

namespace ShitMod.Projectiles.Pets
{
    public class NagaPet : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Naga Siren");
            Main.RegisterItemAnimation(Projectile.type, new DrawAnimationVertical(10, 5));
            Main.projFrames[ModContent.ProjectileType<NagaPet>()] = 5;
        }

        public override void SetDefaults()
        {
            Projectile.width = 80;
            Projectile.height = 70;
            Projectile.aiStyle = 0;
            Projectile.penetrate = -1;
            Projectile.friendly = true;
            Projectile.ownerHitCheck = true;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
        }

        public override void AI()
        {
            Player player = Main.player[Projectile.owner];
            ShitModPlayer shitModPlayerPlayer = player.GetModPlayer<ShitModPlayer>();
            if (player.dead)
            {
                shitModPlayerPlayer.Pet = false;
            }

            if (shitModPlayerPlayer.Pet)
            {
                Projectile.timeLeft = 2;
            }
        }
    }
}