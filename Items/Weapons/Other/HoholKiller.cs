using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;
using ShitMod.Items.Weapons.xuy;
using ShitMod.Projectiles;

namespace ShitMod.Items.Weapons.Other;

public class HoholKiller : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Hohol Killer");
        Tooltip.SetDefault("Fire Weapon");
    }

    public override void SetDefaults()
    {
        Item.damage = 20;
        Item.DamageType = DamageClass.Magic;
        Item.width = 20;
        Item.height = 20;
        Item.useTime = 30;
        Item.useAnimation = 30;
        Item.useStyle = ItemUseStyleID.Shoot;
        Item.knockBack = 6;
        Item.value = 10000;
        Item.rare = ItemRarityID.Orange;
        Item.UseSound = SoundID.Item8;
        Item.autoReuse = true;
        Item.shoot = ModContent.ProjectileType<HoholProjectile>();
        //Item.shoot = ProjectileID.AmethystBolt;
        Item.shootSpeed = 6f;
        Item.mana = 10;
        Item.noMelee = true;
    }

    public override bool PreDrawTooltipLine(DrawableTooltipLine line, ref int yOffset)
    {
        if (line.Mod == "Terraria" && line.Name == "ItemName")
        {
            Main.spriteBatch.End(); //end and begin main.spritebatch to apply a shader
            Main.spriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, null, Main.UIScaleMatrix);
            var lineshader = GameShaders.Misc["PulseDiagonal"].UseColor(new Color(255, 0, 0)).UseSecondaryColor(new Color(255, 120, 0));
            lineshader.Apply(null);
            Utils.DrawBorderString(Main.spriteBatch, line.Text, new Vector2(line.X, line.Y), Color.White, 1); //draw the tooltip manually
            Main.spriteBatch.End(); //then end and begin again to make remaining tooltip lines draw in the default way
            Main.spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, Main.UIScaleMatrix);
            return false;
        }
        return true;
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ItemID.Wood, 10)
            .AddTile(TileID.Hellforge)
            .Register();
    }
}