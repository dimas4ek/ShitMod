using ShitMod.Projectiles;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ShitMod.Items.Weapons.Basic.Poison
{
    public class PoisonFlask: ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Poison Flask");
            Tooltip.SetDefault("'Poison'");
        }

        public override void SetDefaults()
        {
            Item.damage = 5;
            Item.noMelee = true;
            Item.width = 12;
            Item.height = 12;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.useStyle = 1;
            Item.knockBack = 6;
            Item.rare = ItemRarityID.Blue;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<PoisonProjectile>();
            Item.shootSpeed = 15f;
            Item.useTurn = true;
            Item.maxStack = 1;
            Item.consumable = false;
            Item.noUseGraphic = true;
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