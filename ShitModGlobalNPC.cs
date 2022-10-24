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


    public bool BetterOnFire;
    public bool Paralysis;
    public bool PoisonPuls;

    public override void SetDefaults(NPC npc)
    {
        BetterOnFire = false;
        Paralysis = false;
        PoisonPuls = false;
    }

    public override void ResetEffects(NPC npc)
    {
        BetterOnFire = false;
        Paralysis = false;
        PoisonPuls = false;
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

        if (Paralysis)
        {
            npc.AddBuff(BuffID.Electrified, 120);
        }

        if (PoisonPuls)
        {
            if (npc.lifeRegen > 0)
            {
                npc.lifeRegen = 0;
            }
            npc.lifeRegen -= 30;
            if (damage < 2)
            {
                damage = 2;
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
        if(Paralysis)
        {
            if (Main.rand.Next(4) < 3)
            {
                int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, ModContent.DustType<ElectroDust>(), npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default(Color), 0.3f);
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
        if (PoisonPuls)
        {
            if (Main.rand.Next(4) < 3)
            {
                int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, ModContent.DustType<PoisonDust>(), npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default(Color), 3.5f);
                Main.dust[dust].noGravity = true;
                Main.dust[dust].velocity *= 1.8f;
                Main.dust[dust].velocity.Y -= 0.5f;
                if (Main.rand.NextBool(4))
                {
                    Main.dust[dust].noGravity = false;
                    Main.dust[dust].scale *= 0.3f;
                }
            }
            Lighting.AddLight(npc.position, 1f, 0.8f, 0.7f);
        }
    }

}
