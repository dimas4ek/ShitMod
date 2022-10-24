using ShitMod.Players;
using ShitMod.Projectiles.Pets;
using Terraria;
using Terraria.ModLoader;

namespace ShitMod.Buffs
{
    public class NagaBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Modded Naga");
            Description.SetDefault("Our own cool Naga!");
            Main.buffNoTimeDisplay[Type] = true;
            Main.vanityPet[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<ShitModPlayer>();
            bool petProjectileNotSpawned = player.ownedProjectileCounts[ModContent.ProjectileType<NagaPet>()] <= 0;
        }
    }
}