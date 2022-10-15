using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ShitMod.Items.Placeable
{
    public class FireRubyItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fire Ruby");
            Tooltip.SetDefault("the is fire ruby'");
        }

        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 16;
            Item.maxStack = 999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.value = 0;
            //Item.createTile = ModContent.TileType<Tiles.FireRuby>();
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Ruby)
                .AddIngredient(ItemID.Hellstone, 2)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}