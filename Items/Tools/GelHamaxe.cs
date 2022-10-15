using Terraria.ID;
using Terraria.ModLoader;

namespace ShitMod.Items.Tools;

public class GelHamaxe : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Gel Hammer");
        Tooltip.SetDefault("This is a modded pickaxe.");
    }

    public override void SetDefaults()
    {
        Item.damage = 20;
        Item.DamageType = DamageClass.Melee;
        Item.width = 20;
        Item.height = 20;
        Item.useTime = 30;
        Item.useAnimation = 30;
        Item.hammer = 45;
        Item.axe = 10;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.knockBack = 6;
        Item.value = 10000;
        Item.rare = ItemRarityID.Green;
        Item.UseSound = SoundID.Item1;
        Item.autoReuse = true;
        Item.scale = 1.2f;
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ItemID.Gel, 20)
            .AddIngredient(ItemID.Wood, 15)
            .AddTile(TileID.WorkBenches)
            .Register();
    }
}