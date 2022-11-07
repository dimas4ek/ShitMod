using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ShitMod.Items.Weapons;

public class BloodGreatSword : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Долгая работа Юры");
        Tooltip.SetDefault("Этот меч Юра делал 2 недели, он старался, не флеймите его!\nНе баг, а фича");
    }

    public override void SetDefaults()
    {
        Item.damage = 90;
        Item.DamageType = DamageClass.Melee;
        Item.width = 20;
        Item.height = 20;
        Item.useTime = 50;
        Item.useAnimation = 50;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.knockBack = 5;
        Item.value = 1000;
        Item.rare = ItemRarityID.Blue;
        Item.UseSound = SoundID.Item7;
        Item.autoReuse = true;
        Item.scale = 0.5f;
    }
    public override Vector2? HoldoutOffset()
    {
        return new Vector2(-200, 40);
    }
    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ItemID.Wood, 20)
            .Register();
    }
}