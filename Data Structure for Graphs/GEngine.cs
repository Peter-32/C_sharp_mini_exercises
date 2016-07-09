using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;

namespace Data_Structure_for_Graphs
{
    class GEngine
    {
        /*----Members---------------*/
        private Graphics drawHandle;
        private Thread renderThread;

        // load assets here


        /*----Functions-------------*/
        public GEngine (Graphics g)
        {
            drawHandle = g;
        }

        // Takes care of initializing all important things
        public void init()
        {
            // Starts the render thread
            renderThread = new Thread(new ThreadStart(render));
            renderThread.Start();
        }

        public void stop()
        {
            renderThread.Abort();
        }

        private void render()
        {
            // Objects used for constructing the individual frames of the game
            Bitmap frame = new Bitmap(GraphicManager.CANVAS_WIDTH, GraphicManager.CANVAS_HEIGHT);
            Graphics frameGraphics = Graphics.FromImage(frame);

            TextureID[,] textures = Room.Blocks;

            while (true)
            {
                // Background Color
                frameGraphics.FillRectangle(new SolidBrush(Color.Aqua), 0, 0, GraphicManager.CANVAS_WIDTH, GraphicManager.CANVAS_HEIGHT);

                // Draw node or blank
                for (int x = 0; x < GraphicManager.ROOM_TILE_WIDTH; x++)
                {
                    for (int y = 0; y < GraphicManager.ROOM_TILE_HEIGHT; y++)
                    {
                        switch(textures[x,y])
                        {
                            case TextureID.blank:
                                break;
                            case TextureID.node:
                                frameGraphics.FillRectangle(new SolidBrush(Color.White), x * GraphicManager.TILE_SIDE_LENGTH, y * GraphicManager.TILE_SIDE_LENGTH, GraphicManager.TILE_SIDE_LENGTH, GraphicManager.TILE_SIDE_LENGTH);
                                break;
                        }
                    }
                }
            }
        }
    }
}
