using Microsoft.Xna.Framework;
using ShitMod.Buffs;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ShitMod.Projectiles.Pets;
using ShitMod.Buffs.Pets;
using Terraria.GameContent.Creative;

namespace ShitMod.Items.Pets
{
    class Naga : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Modded Naga Key");
            Tooltip.SetDefault("Summon a Naga to your side");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;

        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ZephyrFish);
            Item.shoot = ModContent.ProjectileType<NagaPet>(); 
            Item.buffType = ModContent.BuffType<NagaBuff>(); 
        }

        public override void AddRecipes()
        {
        }

        public override void UseStyle(Player player, Rectangle heldItemFrame)
        {
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
            {
                player.AddBuff(Item.buffTime, 3600, true);
            }
        }

    }
}