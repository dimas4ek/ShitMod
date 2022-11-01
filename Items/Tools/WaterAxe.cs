using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ShitMod.Items.Tools;

public class WaterAxe : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Water Axe");
        Tooltip.SetDefault("This is a modded Axe.");
    }

    public override void SetDefaults()
    {
        Item.damage = 20;
        Item.DamageType = DamageClass.Melee;
        Item.width = 20;
        Item.height = 20;
        Item.useTime = 15;
        Item.useAnimation = 15;
        Item.axe = 15;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.knockBack = 6;
        Item.value = 10000;
        Item.rare = ItemRarityID.Green;
        Item.UseSound = SoundID.Item1;
        Item.autoReuse = true;
        Item.scale = 1f;
    }

    public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
    {
        target.AddBuff(BuffID.Slow, 120);
        target.AddBuff(BuffID.Wet, 120);

    }

    public override void MeleeEffects(Player player, Rectangle hitbox)
    {
        var dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Water, 0f, 0f, 0, new Color(255, 255, 0), 2f);
        Main.dust[dust].noGravity = true;
        Main.dust[dust].velocity *= 0f;

        if (player.ZoneRain)
        {
            Item.damage = 42;
        }

        // будет спавнить мелких слизней

    }
    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ItemID.Wood, 15)
            .Register();
    }
}