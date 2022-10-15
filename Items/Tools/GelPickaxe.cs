using Terraria.ID;
using Terraria.ModLoader;

namespace ShitMod.Items.Tools;

public class GelPickaxe : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Gel Pickaxe");
        Tooltip.SetDefault("This is a modded pickaxe.");
    }

    public override void SetDefaults()
    {
        Item.damage = 20;
        Item.DamageType = DamageClass.Melee;
        Item.width = 20;
        Item.height = 20;
        Item.useTime = 15;
        Item.useAnimation = 15;
        Item.pick = 65;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.knockBack = 6;
        Item.value = 10000;
        Item.rare = ItemRarityID.Green;
        Item.UseSound = SoundID.Item1;
        Item.autoReuse = true;
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ItemID.Gel, 30)
            .AddIngredient(ItemID.Wood, 10)
            .AddTile(TileID.WorkBenches)
            .Register();
    }
}