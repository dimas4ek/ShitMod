using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ShitMod.Buffs;
using ShitMod.Items.Placeable;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace ShitMod.Items.Weapons.Basic.Fire;

public class FireSword : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Fire Sword");
        Tooltip.SetDefault("This is a fire sword");
    }

    public override void SetDefaults()
    {
        Item.damage = 30;
        Item.DamageType = DamageClass.Melee;
        Item.width = 25;
        Item.height = 25;
        Item.useTime = 23;
        Item.useAnimation = 23;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.knockBack = 5;
        Item.value = 1000;
        Item.rare = ItemRarityID.Blue;
        Item.UseSound = new SoundStyle($"{nameof(ShitMod)}/Sounds/FireSwing")
        {
            Volume = 0.9f,
            PitchVariance = 0.2f,
            MaxInstances = 3,
        };
        Item.autoReuse = true;
        Item.shootSpeed = 10f;
        Item.scale = 1.5f;
    }
    public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
    {
        target.AddBuff(ModContent.BuffType<BetterOnFire>(), 120);

    }

    public override void MeleeEffects(Player player, Rectangle hitbox)
    {
        var dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Firefly, 0f, 0f, 0,
            new Color(255, 255, 0), 2f);
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
            .AddIngredient(ModContent.ItemType<FireRubyItem>(), 5)
            .AddTile(TileID.Anvils)
            .Register();
    }
}