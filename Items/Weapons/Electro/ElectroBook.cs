using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ShitMod.Items.Weapons.Electro
{
    public class ElectroBook : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Шокотерапия");
            Tooltip.SetDefault("'Zap them to dust'");
        }

        public override void SetDefaults()
        {
            Item.damage = 130;
            Item.mana = 20;
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
            Item.shoot = Mod.Find<ModProjectile>("ElectroProjectile").Type;
            Item.shootSpeed = 6f;
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