using ShitMod.Items.Placeable.Ores;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ShitMod.Tiles.Ores
{
    public class ElectroBar : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Floran Bar");
            Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(2, 8));
        }


        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 24;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.value = 550;
            Item.rare = ItemRarityID.Blue;
            Item.createTile = ModContent.TileType<ElectroOreTile>();
            Item.maxStack = 999;
            Item.autoReuse = true;
            Item.consumable = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<ElectroOre>(), 4)
                .AddTile(TileID.Furnaces)
                .Register();
        }
    }
}