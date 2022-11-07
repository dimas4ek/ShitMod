using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ShitMod.Items.Weapons;

public class KremPaySword : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("KremPay Sword");
        Tooltip.SetDefault("This is a KremPay sword");
    }

    public override void SetDefaults()
    {
        Item.damage = 12;
        Item.DamageType = DamageClass.Melee;
        Item.width = 20;
        Item.height = 20;
        Item.useTime = 23;
        Item.useAnimation = 23;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.knockBack = 5;
        Item.value = 1000;
        Item.rare = ItemRarityID.Blue;
        Item.UseSound = SoundID.Item1;
        Item.autoReuse = true;
        Item.shootSpeed = 20f;
        Item.scale = 1f;
    }

    public override void MeleeEffects(Player player, Rectangle hitbox)
    {
        var dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Firefly, 0f, 0f, 0,
            new Color(0, 0, 255), 2f);
        Main.dust[dust].noGravity = true;
        Main.dust[dust].velocity *= 0f;
    }

    public override Vector2? HoldoutOffset()
    {
        return new Vector2(-50, -10);
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ItemID.Wood, 20)
            .Register();
    }
}