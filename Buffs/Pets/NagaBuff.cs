using Microsoft.Xna.Framework;
using ShitMod.Players;
using ShitMod.Projectiles.Pets;
using Terraria;
using Terraria.ModLoader;

namespace ShitMod.Buffs.Pets
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

            int projType = ModContent.ProjectileType<NagaPet>();

            player.GetModPlayer<ShitModPlayer>().NagaPet = true;

            if (player.whoAmI == Main.myPlayer && player.ownedProjectileCounts[projType] <= 0)
            {
                var entitySource = player.GetSource_Buff(buffIndex);

                Projectile.NewProjectile(entitySource, player.Center, Vector2.Zero, projType, 0, 0f, player.whoAmI);
            }
        }
    }
}