using Microsoft.Xna.Framework;
using ShitMod.Projectiles.Weapons.Other;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ShitMod.Items.Weapons.Other
{
    public class Kratos : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Kratos");
            Tooltip.SetDefault("Kratos");
        }

        public override void SetDefaults()
        {
            Item.damage = 100;
            Item.noMelee = true;
            Item.width = 20;
            Item.height = 20;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 6;
            Item.rare = ItemRarityID.Blue;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<KratosProjectile>();
            Item.shootSpeed = 15f;
            Item.useTurn = true;
            Item.consumable = false;
            Item.noUseGraphic = true;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position,
            Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 vel = velocity.RotatedBy(
                    MathHelper.Lerp(MathHelper.ToRadians(8), MathHelper.ToRadians(8), 2));
            Projectile.NewProjectileDirect(source, position, vel, type,
                    damage, knockback, player.whoAmI);

            return true;
        }

        public override bool CanUseItem(Player player)
        {
            return player.ownedProjectileCounts[Item.shoot] < Item.stack;
        }
    }
}

/*public class Kratos : ModItem
{
    public override void SetStaticDefaults()
    {
        Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        DisplayName.SetDefault("Kratos");
        Tooltip.SetDefault("'Kratos'");
    }

    public override void SetDefaults()
    {
        Item.damage = 100;
        Item.noMelee = true;
        Item.width = 20;
        Item.height = 20;
        Item.useTime = 15;
        Item.useAnimation = 15;
        Item.useStyle = 1;
        Item.knockBack = 6;
        Item.rare = ItemRarityID.Blue;
        Item.UseSound = SoundID.Item1;
        Item.autoReuse = true;
        Item.shoot = ModContent.ProjectileType<KratosProjectile>();
        Item.shootSpeed = 15f;
        Item.useTurn = true;
        Item.maxStack = 1;
        Item.consumable = false;
        Item.noUseGraphic = true;
    }

    public override bool AltFunctionUse(Player player)
    {
        return true;
    }

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        if (player.altFunctionUse == 2)
            damage = (int)(damage * 0.75);
        Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI);
        return false;
    }
}*/