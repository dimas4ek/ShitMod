using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ShitMod.Items.Tools;

public class TimeSwap : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Time Swap");
    }

    public override void SetDefaults()
    {
        Item.width = 20;
        Item.height = 20;
        Item.useTime = 30;
        Item.useAnimation = 30;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.knockBack = 6;
        Item.value = 10000;
        Item.rare = ItemRarityID.Green;
        Item.UseSound = SoundID.Item89;
        Item.autoReuse = true;
        Item.scale = 1f;
    }
    public override bool? UseItem(Player player)
        {
            Main.time = 0.0;
            Main.dayTime = !Main.dayTime;
            if (Main.dayTime && ++Main.moonPhase >= 8)
            {
                Main.moonPhase = 0;
            }
            return true;
        }
    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ItemID.Wood, 15)
            .AddTile(TileID.WorkBenches)
            .Register();
    }
}