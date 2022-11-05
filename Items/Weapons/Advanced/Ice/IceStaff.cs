using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ShitMod.Items.Weapons.Advanced.Ice
{
    public class IceStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ice Staff");
            Tooltip.SetDefault("Shoots small water drops");
            Item.staff[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.damage = 50;
            Item.mana = 10;
            Item.width = 28;
            Item.height = 30;
            Item.useTime = 10;
            Item.useAnimation = 10;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true;
            Item.knockBack = 1;
            Item.value = 10000;
            Item.rare = ItemRarityID.Red;
            Item.UseSound = SoundID.Item33;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<IceStar>(); //IceStar потом удалить надо
            //Item.shoot = ModContent.ProjectileType<Icicle>();
            Item.shootSpeed = 8f;
            Item.scale = 0.5f;
        }

        public override bool AltFunctionUse(Player player) => true;

        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2) //2 - ctrl или пкм, 0 - лкм
            {
                Item.staff[Item.type] = false;

                Item.damage = 40;
                //Item.shoot = ModContent.ProjectileType<FrostStorm>(); //добавить снежную бурю
                //Item.shootSpeed = 30f;
                //Item.mana = 200;

                //сделать кд как у жезла раздора

                Item.useStyle = ItemUseStyleID.HoldUp;
                //Item.holdStyle = ItemHoldStyleID.HoldFront;
                //Item.noUseGraphic = true; //хз че это
                Item.channel = true;
                Item.knockBack = 0;
            }

            return true;
        }

        //это типа буря снежная
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position,
            Vector2 velocity, int type,
            int damage, float knockback)
        {
            float shootSpeed = Item.shootSpeed;
            Vector2 val = player.RotatedRelativePoint(player.MountedCenter, true, true);
            float num = (float)Main.mouseX + Main.screenPosition.X - val.X;
            float num2 = (float)Main.mouseY + Main.screenPosition.Y - val.Y;
            if (player.gravDir == -1f)
            {
                num2 = Main.screenPosition.Y + (float)Main.screenHeight - (float)Main.mouseY - val.Y;
            }

            float num3 = (float)Math.Sqrt(num * num + num2 * num2);
            if ((float.IsNaN(num) && float.IsNaN(num2)) || (num == 0f && num2 == 0f))
            {
                num = ((Entity)player).direction;
                num2 = 0f;
                num3 = shootSpeed;
            }
            else
            {
                num3 = shootSpeed / num3;
            }

            int num4 = 3;
            for (int i = 0; i < num4; i++)
            {
                float num5 = 1f;
                float num6 = 1f;
                val = new Vector2(
                    player.Center.X + (float)((Entity)player).width * 0.5f +
                    (float)Main.rand.Next(201) * (0f - (float)((Entity)player).direction) +
                    ((float)Main.mouseX + Main.screenPosition.X - ((Entity)player).Center.X),
                    player.MountedCenter.Y - 600f);
                val.X = (val.X + player.Center.X) / 2f + (float)Main.rand.Next(-200, 201);
                val.Y -= 100 * i;
                num = (float)Main.mouseX + Main.screenPosition.X - val.X;
                num2 = (float)Main.mouseY + Main.screenPosition.Y - val.Y;
                if (num2 < 0f)
                {
                    num2 *= -1f;

                    if (num2 < 20f)
                    {
                        num2 = 20f;

                        num3 = (float)Math.Sqrt(num * num + num2 * num2);
                        num3 = shootSpeed / num3;
                        num *= num3;
                        num2 *= num3;
                        float num7 = num + (float)Main.rand.Next(-30, 31) * 0.02f;
                        float num8 = num2 + (float)Main.rand.Next(-30, 31) * 0.02f;
                        Projectile.NewProjectile((IEntitySource)(object)source, val.X, val.Y, num7, num8, type,
                            (int)((float)damage * num5), (float)(int)(knockback * num6), ((Entity)player).whoAmI, 0f,
                            (float)Main.rand.Next(15));
                    }
                }
            }
            return false;
        }
    }
}
