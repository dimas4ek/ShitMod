using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.GameContent.Events;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.IO;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.WorldBuilding;

namespace ShitMod
{
    public class ShitModWorld : ModSystem
    {
        #region Generation

        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
        {
            int shiniesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));
            if (shiniesIndex != -1)
            {
                tasks.Insert(shiniesIndex + 1, new PassLegacy("Electro Ore Spawn", GenerateModOre));

            }
        }

        private void GenerateModOre(GenerationProgress progress, GameConfiguration configuration)
        {
            progress.Message = "Spawning Mod Ores";

            for (int i = 0; i < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 6E-05); i++)
            {
                int x = WorldGen.genRand.Next(200, Main.maxTilesX - 200);
                int y = WorldGen.genRand.Next((int)WorldGen.worldSurfaceLow, Main.maxTilesY - 500);

                WorldGen.TileRunner(x, y, WorldGen.genRand.Next(4, 7), WorldGen.genRand.Next(3, 6), Mod.Find<ModTile>("ElectroOreTile").Type);
            }
        }

        #endregion
    }
}