using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Side_Scroller_Game_Tutorial
{
    class Level
    {
        private static TextureID[,] blocks = new TextureID[Game.LEVEL_WIDTH,Game.LEVEL_HEIGHT];

        public static TextureID[,] Blocks
        {
            get { return blocks; }
            set { blocks = value; }
        }

        public static void initLevel()
        {
            for (int x = 0; x < Game.LEVEL_WIDTH; x++)
            {
                for (int y = 0; y < Game.LEVEL_HEIGHT; y++)
                {
                    if (y >= 11)
                    {
                        blocks[x, y] = TextureID.dirt;
                    }
                    else
                    {
                        blocks[x, y] = TextureID.air;
                    }
                }
            }
        }
    }
}
