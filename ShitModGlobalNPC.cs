using Microsoft.Xna.Framework;
using Mono.Cecil;
using ShitMod.Dusts;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ShitMod;

public class ShitModGlobalNPC : GlobalNPC
{
    public override bool InstancePerEntity => true;


    public bool BetterOnFire = false;

    public override void SetDefaults(NPC npc)
    {
        BetterOnFire = false;
    }

    public override void ResetEffects(NPC npc)
    {
        BetterOnFire = false;
    }

    public override void UpdateLifeRegen(NPC npc, ref int damage)
    {
        if(BetterOnFire)
        {
            if (npc.lifeRegen > 0)
            {
                npc.lifeRegen = 0;
            }
            npc.lifeRegen -= 30;
            if(damage < 3)
            {
                damage = 3;
            }
        }
    }

    public override void DrawEffects(NPC npc, ref Color drawColor)
    {
        if (BetterOnFire)
        {
            if (Main.rand.Next(4) < 3)
            {
                int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, ModContent.DustType<FireDust>(), npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default(Color), 3.5f);
                Main.dust[dust].noGravity = true;
                Main.dust[dust].velocity *= 1.8f;
                Main.dust[dust].velocity.Y -= 0.5f;
                if (Main.rand.NextBool(4))
                {
                    Main.dust[dust].noGravity = false;
                    Main.dust[dust].scale *= 0.5f;
                }
            }
            Lighting.AddLight(npc.position, 1f, 0.8f, 0.7f);
        }
        if(npc.HasBuff(BuffID.Stoned))
        {
            if (Main.rand.Next(4) < 3)
            {
                int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, ModContent.DustType<ElectroDust>(), npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default(Color), 3.5f);
                Main.dust[dust].noGravity = true;
                Main.dust[dust].velocity *= 1.8f;
                Main.dust[dust].velocity.Y -= 0.5f;
                if (Main.rand.NextBool(4))
                {
                    Main.dust[dust].noGravity = false;
                    Main.dust[dust].scale *= 0.2f;
                }
            }
            Lighting.AddLight(npc.position, 1f, 0.8f, 0.7f);
        }
    }

}
