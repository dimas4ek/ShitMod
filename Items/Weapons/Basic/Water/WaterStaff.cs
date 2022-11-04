﻿using Microsoft.Xna.Framework;
using ShitMod.Projectiles.Weapons.Basic.Water;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ShitMod.Items.Weapons.Basic.Water
{
    public class WaterStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Water Staff");
            Tooltip.SetDefault("'Water them to dust'");
        }

        public override void SetDefaults()
        {
            Item.damage = 1;
            Item.mana = 1;
            Item.width = 28;
            Item.height = 30;
            Item.useTime = 1;
            Item.useAnimation = 1;
            Item.useStyle = 5;
            Item.noMelee = true;
            Item.knockBack = 1;
            Item.value = 10000;
            Item.rare = ItemRarityID.Orange;
            Item.UseSound = SoundID.Item33;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<WaterProjectile1>();
            Item.shootSpeed = 8f;
            Item.scale = 0.5f;
        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            var dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Water, 0f, 0f, 0, new Color(255, 255, 0), 2f);
            Main.dust[dust].noGravity = true;
            Main.dust[dust].velocity *= 0f;

            if (player.ZoneRain)
            {
                Item.damage = 2;
            }

            //рандомные проджектайлы
            int r = Main.rand.Next(0, 100);
            if (r < 33)
            {
                Item.shoot = ModContent.ProjectileType<WaterProjectile1>();
            }
            else if (r >= 33 && r < 66)
            {
                Item.shoot = ModContent.ProjectileType<WaterProjectile2>();
            }
            else if (r >= 66)
            {
                Item.shoot = ModContent.ProjectileType<WaterProjectile3>();
            }
        }
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Wood, 10)
                .Register();
        }
    }
}