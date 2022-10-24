using Terraria;
using Terraria.ModLoader;

namespace ShitMod.Buffs;

public class PoisonPuls : ModBuff
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Puls on poison");
        Description.SetDefault("You are on poison");
        Main.debuff[Type] = true;
        Main.buffNoSave[Type] = true;
    }

    public override void Update(NPC npc, ref int buffIndex)
    {
        npc.GetGlobalNPC<ShitModGlobalNPC>().PoisonPuls = true;
    }

}