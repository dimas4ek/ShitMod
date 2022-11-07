using Microsoft.Xna.Framework;
using ShitMod.Projectiles.Weapons.Basic.Water;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ShitMod.Items.Weapons.Basic.Water
{
    public class WaterStaff : ModItem
    {
        private int[] projArr =
        {
            ModContent.ProjectileType<WaterProjectile1>(), 
            ModContent.ProjectileType<WaterProjectile2>(),
            ModContent.ProjectileType<WaterProjectile3>()
        };

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Water Staff");
            Tooltip.SetDefault("Shoots small water drops");
            Item.staff[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.damage = 20;
            Item.mana = 7;
            Item.width = 28;
            Item.height = 30;
            Item.useTime = 10;
            Item.useAnimation = 10;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true;
            Item.knockBack = 1;
            Item.value = 10000;
            Item.rare = ItemRarityID.Orange;
            Item.UseSound = SoundID.Item33;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<WaterProjectile1>();
            Item.shootSpeed = 8f;
            Item.scale = 1f;
        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage,
            ref float knockback)
        {
            type = Main.rand.Next(projArr);
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 offset = new Vector2(velocity.X * 10, velocity.Y * 10);
            position += offset;

            Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI);

            return false;
        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            var dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Water, 0f, 0f, 0, new Color(255, 0, 0), 1f);
            Main.dust[dust].noGravity = true;
            Main.dust[dust].velocity *= 0f;

            if (player.ZoneRain)
            {
                Item.damage = 40;
            }
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-20, 4);
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Wood, 10)
                .Register();
        }
    }
}