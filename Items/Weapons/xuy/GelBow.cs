using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ShitMod.Items.Weapons.xuy;

public class GelBow : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Gel Bow");
        Tooltip.SetDefault("This is a modded bow.");
    }

    public override void SetDefaults()
    {
        Item.damage = 20;
        Item.DamageType = DamageClass.Ranged;
        Item.width = 20;
        Item.height = 20;
        Item.useTime = 20;
        Item.useAnimation = 20;
        Item.useStyle = ItemUseStyleID.Shoot;
        Item.noMelee = true;
        Item.knockBack = 6;
        Item.value = 10000;
        Item.rare = ItemRarityID.Green;
        Item.UseSound = SoundID.Item5;
        Item.autoReuse = true;
        Item.shoot = ProjectileID.PurificationPowder;
        Item.shootSpeed = 16f;
        Item.useAmmo = AmmoID.Arrow;
    }

    public override Vector2? HoldoutOffset()
    {
        return new Vector2(20, 0);
    }

    public override void AddRecipes()
    {
        Recipe recipe = CreateRecipe();
        recipe
            .AddIngredient(ItemID.Gel, 10)
            .AddIngredient(ItemID.GoldBar, 10)
            .AddTile(TileID.WorkBenches)
            .Register();
    }
}