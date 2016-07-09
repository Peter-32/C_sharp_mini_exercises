using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;

namespace Side_Scroller_Game_Tutorial
{
    // Engine uses the Graphics object and holds a thread used for rendering
    // The render function draws everything to the screen
    // We start and stop the thread
    class GEngine
    {
        /*------------Members---------------------*/
        private Graphics drawHandle;
        private Thread renderThread;

        // loading as asset takes a while so we save them
        private Bitmap tex_steve;
        private Bitmap tex_dirt;


        /*------------Functions---------------------*/

        public GEngine(Graphics g)
        {
            drawHandle = g;
        }

        // Takes care of initializing all important things.
        public void init()
        {
            // Load assets
            loadAssets();

            // Starts the render thread
            renderThread = new Thread(new ThreadStart(render));
            renderThread.Start();
        }

        // Loads resources
        private void loadAssets()
        {
            tex_steve = Side_Scroller_Game_Tutorial.Properties.Resources.steve;
            tex_dirt = Side_Scroller_Game_Tutorial.Properties.Resources.dirt;
        }

        // Stops a render thread in it's tracks
        public void stop()
        {
            renderThread.Abort();
        }

        // Runs indefinitely, drawing frame by frame
        private void render()
        {
            // Benchmarking info
            int framesRendered = 0;
            long startTime = Environment.TickCount;

            // Objects used for constructing the individual frames of the game
            Bitmap frame = new Bitmap(Game.CANVAS_WIDTH, Game.CANVAS_HEIGHT);
            Graphics frameGraphics = Graphics.FromImage(frame);

            TextureID[,] textures = Level.Blocks;

            while (true)
            {                                
                // Background Color                
                frameGraphics.FillRectangle(new SolidBrush(Color.Aqua), 0, 0, Game.CANVAS_WIDTH, Game.CANVAS_HEIGHT);

                // Draw air and dirt
                for (int x = 0; x < Game.LEVEL_WIDTH; x++)
                {
                    for (int y = 0; y < Game.LEVEL_HEIGHT; y++)
                    {
                        switch(textures[x,y])
                        {
                            case TextureID.air:
                                break;
                            case TextureID.dirt:
                                frameGraphics.DrawImage(tex_dirt, x * Game.TILE_SIDE_LENGTH, y * Game.TILE_SIDE_LENGTH);
                                break;
                        }
                    }
                }

                // Draw steve
                //frameGraphics.DrawImage(tex_steve, 100, 100);

                // Draw the frame on the canvas
                drawHandle.DrawImage(frame, 0, 0);

                //Benchmarking
                framesRendered++;
                if (Environment.TickCount >= startTime + 1000) // at least one second has occurred
                {
                    Console.WriteLine("GEngine: " + framesRendered + " fps");
                    framesRendered = 0;
                    startTime = Environment.TickCount;
                }
                

            }
        }

    }
}
