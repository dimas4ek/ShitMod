﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ShitMod.Dusts;

public class Salo : ModDust
{
    public override void OnSpawn(Dust dust)
    {
        dust.noGravity = true;
        dust.noLight = true;
        dust.scale = 1.5f;
    }

    public override bool Update(Dust dust)
    {
        dust.position += dust.velocity;
        dust.rotation += dust.velocity.X * 0.1f;
        dust.scale -= 0.01f;
        if (dust.scale < 0.5f)
        {
            dust.active = false;
        }
        return false;
    }
}