using Terraria.ID;
using Terraria.ModLoader;

namespace ShitMod.Items.Tools;

public class WaterAxe : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Water Hammer");
        Tooltip.SetDefault("This is a modded Axe.");
    }

    public override void SetDefaults()
    {
        Item.damage = 20;
        Item.DamageType = DamageClass.Melee;
        Item.width = 20;
        Item.height = 20;
        Item.useTime = 15;
        Item.useAnimation = 15;
        Item.axe = 15;
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
    }
}