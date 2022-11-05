using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using EntitySource_ItemUse_WithAmmo = Terraria.DataStructures.EntitySource_ItemUse_WithAmmo;
using ShitMod.Buffs;
using ShitMod.Projectiles.xuy;
using ShitMod.Projectiles.Weapons.Basic.Fire;

namespace ShitMod.Items.Weapons.Basic.Fire
{
    public class FirePistol : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'Fire'");
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
            Item.useStyle = ItemUseStyleID.Shoot;
            ;
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


        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage,
            ref float knockback)
        {
            if (type == ProjectileID.Bullet)
            {
                type = ModContent.ProjectileType<FireBullet>();
            }
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity,
        int type,
        int damage, float knockback)
        {
            Vector2 offset = new Vector2(velocity.X * 5, velocity.Y * 5);
            position += offset;

            return true;
        }
        public override void ModifyHitNPC(Player player, NPC target, ref int damage, ref float knockBack, ref bool crit)
        {
            target.AddBuff(ModContent.BuffType<BetterOnFire>(), 120);
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