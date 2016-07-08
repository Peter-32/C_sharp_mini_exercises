using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Side_Scroller_Game_Tutorial
{
    // the window -> paint gave the game the graphics
    // The graphics are given to the GEngine, and the engine is started
    class Game
    {
        /*-----------Constants-----------------------*/
        public const int CANVAS_HEIGHT = 700;
        public const int CANVAS_WIDTH = 1200;
        public const int LEVEL_WIDTH = 24;
        public const int LEVEL_HEIGHT = 14;
        public const int TILE_SIDE_LENGTH = 50;

        /*-------Members---------------------*/
        private GEngine gEngine;

        // Load the level
        public void loadLevel()
        {
            Level.initLevel();
        }

        // Launches the graphics engine
        public void startGraphics(Graphics g)
        {
            gEngine = new GEngine(g);
            gEngine.init();
        }

        // responsible for ending all threads except the maina pplication thread
        // prior to the window being closed.
        public void stopGame()
        {
            gEngine.stop();
        }
    }

    public enum TextureID
    {
        air,
        dirt
    }
}
