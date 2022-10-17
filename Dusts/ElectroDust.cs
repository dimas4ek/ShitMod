using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Terraria;

namespace ShitMod.Dusts;
    public class ElectroDust : ModDust
    {
        public override void OnSpawn(Dust dust)
        {
            dust.velocity *= 0f;
            dust.noGravity = false;
            dust.noLight = true;
            dust.scale *= 3f;
        }

        public override bool Update(Dust dust)
        {
            dust.position += dust.velocity;
            dust.rotation += Main.rand.Next(5);
            dust.scale *= 0.95f;
            Lighting.AddLight(dust.position, .8f, .8f, .8f);
            if (dust.scale < 0.3f)
            {
                dust.active = false;
            }
            return false;
        }
    }   
