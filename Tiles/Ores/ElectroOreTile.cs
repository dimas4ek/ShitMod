using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace ShitMod.Tiles.Ores
{
    public class ElectroOreTile : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSpelunker[Type] = true;
            Main.tileSolid[Type] = true;
            Main.tileBlockLight[Type] = true;

            TileID.Sets.Ore[Type] = true;

            ItemDrop = Mod.Find<ModItem>("ElectroOre").Type;
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Electro Ore");
            AddMapEntry(new Color(30, 200, 25), name);
            //soundType = SoundID.Tink;
            //dustType = DustID.GrassBlades;
            //minPick = 40;
        }

        public override bool CanExplode(int i, int j)
        {
            return false;
        }

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            r = 0.04f;
			g = 0.1f;
			b = 0.02f;
        }
    }
}