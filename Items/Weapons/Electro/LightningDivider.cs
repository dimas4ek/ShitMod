using ShitMod.Items.Materials;
using Terraria.ID;
using Terraria.ModLoader;

namespace ShitMod.Items.Weapons.Electro;

public class LightningDivider : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Lightning Divider");
        Tooltip.SetDefault("Wrath of the lightnings");
    }

    public override void SetDefaults()
    {
        Item.damage = 50;
        Item.DamageType = DamageClass.Melee;
        Item.width = 40;
        Item.height = 40;
        Item.useTime = 15;
        Item.useAnimation = 20;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.knockBack = 5;
        Item.value = 1000;
        Item.rare = ItemRarityID.Purple;
        Item.UseSound = SoundID.Item1;
        Item.autoReuse = true;
        //Item.shoot = Mod.Find<ModProjectile>("TestProjectile").Type;
        Item.shootSpeed = 10f;
        Item.scale = 1.5f;
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ModContent.ItemType<ElectroBar>(), 10)
            .Register();
    }
}