using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;

namespace ShitMod.Items.Weapons.Basic.Fire;

public class FireBow : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Fire Bow");
        Tooltip.SetDefault("Shoots fire arrows");
    }

    public override void SetDefaults()
    {
        Item.damage = 10;
        Item.DamageType = DamageClass.Ranged;
        Item.width = 20;
        Item.height = 20;
        Item.useTime = 20;
        Item.useAnimation = 20;
        Item.useStyle = ItemUseStyleID.Shoot;
        Item.noMelee = true;
        Item.knockBack = 4;
        Item.value = 10000;
        Item.rare = ItemRarityID.Blue;
        Item.UseSound = SoundID.Item5;
        Item.autoReuse = true;
        Item.shoot = ProjectileID.PurificationPowder;
        Item.shootSpeed = 16f;
        Item.useAmmo = AmmoID.Arrow;
    }

    public override void AddRecipes()
    {
        Recipe recipe = CreateRecipe()
            .AddIngredient(ItemID.Wood, 25)
            .AddIngredient(Mod.Find<ModItem>("FireRubyItem").Type, 10)
            .AddIngredient(ItemID.GoldBow)
            .AddIngredient(ItemID.HellstoneBar, 10)
            .AddTile(TileID.WorkBenches)
            .Register();
    }
}