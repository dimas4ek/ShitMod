using Terraria;
using Terraria.ModLoader;

namespace ShitMod.Buffs;

public class BetterOnFire : ModBuff
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Better on fire");
        Description.SetDefault("You are on fire");
        Main.debuff[Type] = true;
        Main.buffNoSave[Type] = true;
    }

    public override void Update(NPC npc, ref int buffIndex)
    {
        //int r = Main.rand.Next(0, 100);
        //if (r < 60)
        //{
        //    npc.GetGlobalNPC<ShitModGlobalNPC>().BetterOnFire = true;
        //}
        npc.GetGlobalNPC<ShitModGlobalNPC>().BetterOnFire = true;
    }
    
}