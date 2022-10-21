using IL.Terraria.Modules;
using Microsoft.Xna.Framework;
using ShitMod.Items.Placeable;
using Terraria.ModLoader;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using ShitMod.Projectiles;
using ShitMod.Projectiles.Elements.Void;

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
        Item.shoot = ModContent.ProjectileType<FireArrow>();
        Item.shootSpeed = 16f;
        Item.useAmmo = AmmoID.Arrow;
    }

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type,
        int damage, float knockback)
    {
        Projectile.NewProjectile(source, position, velocity, ModContent.ProjectileType<FireArrow>(), damage, knockback, player.whoAmI);
        return false;
    }

    public override void AddRecipes()
    {
        Recipe recipe = CreateRecipe()
            .AddIngredient(ItemID.Wood, 25)
            .AddIngredient(ModContent.ItemType<FireRubyItem>(), 10)
            .AddIngredient(ItemID.GoldBow)
            .AddIngredient(ItemID.HellstoneBar, 10)
            .AddTile(TileID.WorkBenches)
            .Register();
    }
}