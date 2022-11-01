using ShitMod.Projectiles.Weapons.Basic.Fire;
using Terraria.ID;
using Terraria.ModLoader;

namespace ShitMod.Items.Weapons.Basic.Fire;

public class FlameScythe : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Flame Scythe");
        Tooltip.SetDefault("Releases a flame wave");
    }

    public override void SetDefaults()
    {
        Item.damage = 30;
        Item.DamageType = DamageClass.Melee;
        Item.width = 40;
        Item.height = 40;
        Item.useTime = 50;
        Item.useAnimation = 20;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.knockBack = 5;
        Item.value = 1000;
        Item.rare = ItemRarityID.Blue;
        //Item.UseSound
        Item.autoReuse = true;
        Item.shootSpeed = 10f;
        Item.shoot = ModContent.ProjectileType<FlameWave>();
    }

    public override void AddRecipes()
    {
        base.AddRecipes();
    }
}