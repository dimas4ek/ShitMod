﻿using ShitMod.Projectiles;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ShitMod.Items.Weapons.Basic.Fire
{
    public class Fire : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Огненый всплеск");
            Tooltip.SetDefault("'Fire them to dust'");
        }

        public override void SetDefaults()
        {
            Item.damage = 15;
            Item.mana = 5;
            Item.width = 28;
            Item.height = 30;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = 5;
            Item.noMelee = true;
            Item.knockBack = 5;
            Item.value = 10000;
            Item.rare = ItemRarityID.Orange;
            Item.UseSound = SoundID.Item33;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<FireProjectile>();
            Item.shootSpeed = 8f;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Wood, 10)
                .AddTile(TileID.Hellforge)
                .Register();
        }
    }
}