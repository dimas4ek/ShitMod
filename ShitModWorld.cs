using System;
using System.Collections.Generic;
using System.IO;
using ShitMod.Tiles.Ores;
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

        //Генерация в мире
        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
        {
            //Shinies - большинство ванильных руд
            int shiniesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies")); // находим по индексу
            if (shiniesIndex != -1)
            {
                tasks.Insert(shiniesIndex + 1, new PassLegacy("Electro Ore Spawn", GenerateModOre)); // вставляем нашу руду вместо ванильной
            }
        }

        private void GenerateModOre(GenerationProgress progress, GameConfiguration configuration)
        {
            progress.Message = "Spawning Mod Ores"; // ообщение пользователю

            // перебор всех блоков в мире
            for (int i = 0; i < (int)((Main.maxTilesX * Main.maxTilesY) * 6E-05); i++) // 6Е-05 = 0.00006
            {
                // выбор рандомных координат по X и Y
                int x = WorldGen.genRand.Next(200, Main.maxTilesX - 200);
                int y = WorldGen.genRand.Next((int)WorldGen.worldSurfaceLow - 100, Main.maxTilesY - 500);

                // функция для размещения руды с силой и шагом
                WorldGen.TileRunner(x, y, WorldGen.genRand.Next(4, 7), WorldGen.genRand.Next(3, 6), ModContent.TileType<ElectroOreTile>());

                // спавн происходит только в снежном биоме (снежные и ледяные блоки)
                //Tile tile = Framing.GetTileSafely(x, y);
                //if (tile.HasTile && (tile.TileType == TileID.SnowBlock || tile.TileType == TileID.IceBlock))
                //{
                //    WorldGen.TileRunner(x, y, WorldGen.genRand.Next(4, 7), WorldGen.genRand.Next(3, 6), ModContent.TileType<ElectroOreTile>());
                //}
            }
        }

        #endregion
    }
}