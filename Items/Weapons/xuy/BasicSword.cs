using Microsoft.Xna.Framework;
using ShitMod.Projectiles.xuy;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ShitMod.Items.Weapons.xuy
{
    public class BasicSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cool sword");
            Tooltip.SetDefault("this can be terrifying");
        }

        public override void SetDefaults()
        {
            Item.damage = 123;
            Item.DamageType = DamageClass.Melee;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 23;
            Item.useAnimation = 23;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 5;
            Item.value = 1000;
            Item.scale = 0.3f;
            Item.rare = ItemRarityID.Blue;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            //Item.shoot = ModContent.ProjectileType<TestProjectile>();
            Item.shootSpeed = 2f;

        }

        //public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        //{
        //    target.AddBuff(BuffID.OnFire, 120);
        //}

        //public override void MeleeEffects(Player player, Rectangle hitbox)
        //{
        //    var dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Torch, 0f, 0f, 0, new Color(255, 255, 0), 2f);
        //    Main.dust[dust].noGravity = true;
        //    Main.dust[dust].velocity *= 0f;
        //}

        //public override void AddRecipes()
        //{
        //    var recipe = CreateRecipe();
        //    recipe
        //        .AddIngredient(ItemID.Diamond, 10)
        //        .AddTile(TileID.LunarCraftingStation)
        //        .Register();
        //    //recipe.AddTile(TileID.WorkBenches);
        //    //recipe.Register();
        //}
    }
}