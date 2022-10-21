using Terraria;
using Terraria.ModLoader;

namespace ShitMod.Buffs;

public class Paralysis : ModBuff
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Paralysis");
        Description.SetDefault("You can't move");
        Main.debuff[Type] = true;
        Main.buffNoSave[Type] = true;
    }

    public override void Update(NPC npc, ref int buffIndex)
    {
        if (!npc.boss)
        {
            npc.velocity.X = 0;
            npc.velocity.Y = 0;
            npc.frameCounter = 0;
        }

        npc.GetGlobalNPC<ShitModGlobalNPC>().Paralysis = true;
    }

    public override bool ReApply(NPC npc, int time, int buffIndex)
    {
        return time > 2;
    }
}