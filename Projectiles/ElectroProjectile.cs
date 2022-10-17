﻿using Terraria;
using Terraria.ModLoader;
using System;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow.PointsToAnalysis;
using Microsoft.Xna.Framework;
using Terraria.ID;
using ShitMod.Dusts;

namespace ShitMod.Projectiles
{
    public class ElectroProjectile : ModProjectile
    {
        private int delay = 0;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("ElectroProjectile");
        }

        public override void SetDefaults()
        {
            Projectile.width = 48;
            Projectile.height = 48;
            Projectile.timeLeft = 240;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.penetrate = 1;
            delay = 0;
        }

        public override void AI()
        {
            delay += 1;
            Projectile.velocity.Y += Projectile.ai[0];
            if (!Main.rand.NextBool(3)) return;
            var dust = Dust.NewDust(Projectile.Center, 1, 1, Mod.Find<ModDust>("ElectroDust").Type, 0f, 0f, 0, default(Color), 1f);
            Main.dust[dust].scale = 1.5f;
        }
    }
}