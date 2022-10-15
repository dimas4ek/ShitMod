using Microsoft.Xna.Framework;
using ShitMod.Projectiles.xuy;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ShitMod.Items.Weapons.xuy;

public class GelPistol : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Gel Pistol");
        Tooltip.SetDefault("This is a modded pistol.");
    }

    public override void SetDefaults()
    {
        //Item.damage = 8;
        //Item.DamageType = DamageClass.Ranged;
        //Item.width = 40;
        //Item.height = 40;
        //Item.useTime = 20;
        //Item.useAnimation = 20;
        //Item.useStyle = ItemUseStyleID.Shoot;
        //Item.knockBack = 0.1f;
        //Item.value = 2500;
        //Item.rare = ItemRarityID.Blue;
        //Item.UseSound = SoundID.Item11;
        //Item.autoReuse = true;
        //Item.shoot = ProjectileID.Bullet; //Mod.Find<ModProjectile>("GelBulletProjectile").Type
        //Item.useAmmo = AmmoID.Bullet;
        //Item.shootSpeed = 6.5f;
        //Item.noMelee = true;
        Item.DamageType = DamageClass.Ranged;
        Item.noMelee = true;
        Item.autoReuse = false;

        Item.damage = 20;

        Item.useTime = Item.useAnimation = 20;
        Item.useStyle = ItemUseStyleID.Shoot;


        Item.useAmmo = AmmoID.Bullet;
        Item.shoot = ProjectileID.Bullet;
        Item.shootSpeed = 10f;

        Item.rare = ItemRarityID.Green;

        Item.UseSound = SoundID.Item5;
    }

    //public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type,
    //    int damage, float knockback)
    //{
    //    //Vector2 offset = new Vector2(velocity.X * 5, velocity.Y * 5);
    //    //position += offset;

    //    if (type == ProjectileID.Bullet)
    //    {
    //        type = ModContent.ProjectileType<GelBulletProjectile>();

    //    }

    //    return true;
    //}

    public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage,
        ref float knockback)
    {
        if (type == ProjectileID.Bullet)
        {
            type = ModContent.ProjectileType<GelBulletProjectile>();

        }
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