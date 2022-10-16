using Microsoft.Xna.Framework;
using IL.Terraria.DataStructures;
using Microsoft.Xna.Framework;
using ShitMod.Projectiles.xuy;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using EntitySource_ItemUse_WithAmmo = Terraria.DataStructures.EntitySource_ItemUse_WithAmmo;

namespace ShitMod.Items.Weapons.Basic.Fire
{
    public class FirePistol : ModItem
{
    public override void SetStaticDefaults()
    {
        Tooltip.SetDefault("'For Fury'");
    }
    public int numShots = 1;
    public override void SetDefaults()
    {
        numShots = 2;
        Item.damage = 10;
        Item.width = 80;
        Item.height = 44;
        Item.useTime = Item.useAnimation = 15;
        Item.useAnimation = 15;
        Item.useStyle = ItemUseStyleID.Shoot; ;
        Item.noMelee = true;
        Item.knockBack = 8;
        Item.value = 10000;
        Item.rare = ItemRarityID.Green;
        Item.UseSound = SoundID.Item11;
        Item.autoReuse = true;
        Item.shootSpeed = 14f;
        Item.shoot = ProjectileID.Bullet;
        Item.useAmmo = AmmoID.Bullet;
        Item.DamageType = DamageClass.Ranged;
        Item.autoReuse = false;
    }

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity,
        int type,
        int damage, float knockback)
    {
        Vector2 offset = new Vector2(velocity.X * 5, velocity.Y * 5);
        position += offset;

        if (type == ProjectileID.Bullet)
        {
            type = ModContent.ProjectileType<GelBulletProjectile>();

        }

        return true;
    }

    public override Vector2? HoldoutOffset()
    {
        return new Vector2(-26, 4);
    }


    public override void AddRecipes()
    {
    }
}
}