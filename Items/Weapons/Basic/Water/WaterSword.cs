using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace ShitMod.Items.Weapons.Basic.Water;

public class WaterSword : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Water Sword");
        Tooltip.SetDefault("This is a water sword");
    }

    public override void SetDefaults()
    {
        Item.damage = 30;
        Item.DamageType = DamageClass.Melee;
        Item.width = 40;
        Item.height = 40;
        Item.useTime = 23;
        Item.useAnimation = 23;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.knockBack = 5;
        Item.value = 1000;
        Item.rare = ItemRarityID.Blue;
        Item.UseSound = new SoundStyle($"{nameof(ShitMod)}/Sounds/WaterSwing")
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
        target.AddBuff(BuffID.Slow, 120);
        
        
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
            .AddIngredient(ItemID.Wood, 20)
            //.AddIngredient(Mod.Find<ModItem>("WaterSapphire"), 5)
            .AddTile(TileID.Anvils)
            .Register();
    }
}