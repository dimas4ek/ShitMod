using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ShitMod.Items.Weapons.xuy;

public class GelStaff : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Gel Staff");
        Tooltip.SetDefault("This is a modded staff.");
        Item.staff[Item.type] = true;
    }

    public override void SetDefaults()
    {
        Item.damage = 20;
        Item.DamageType = DamageClass.Magic;
        Item.width = 20;
        Item.height = 20;
        Item.useTime = 30;
        Item.useAnimation = 30;
        Item.useStyle = ItemUseStyleID.Shoot;
        Item.knockBack = 6;
        Item.value = 10000;
        Item.rare = ItemRarityID.Green;
        Item.UseSound = SoundID.Item8;
        Item.autoReuse = true;
        Item.shoot = Mod.Find<ModProjectile>("TestProjectile").Type;
        Item.shootSpeed = 6f;
        Item.mana = 10;
        Item.noMelee = true;
    }

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type,
        int damage, float knockback)
    {
        Vector2 offset = new Vector2(velocity.X * 5, velocity.Y * 5);
        position += offset;

        Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI);

        return false;
    }


    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ItemID.Gel, 20)
            .AddIngredient(ItemID.Wood, 15)
            .AddTile(TileID.Anvils)
            .Register();
    }
}