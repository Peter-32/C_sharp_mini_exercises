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
        private GEngine gEngine;

        public void startGraphics(Graphics g)
        {
            gEngine = new GEngine(g);
            gEngine.init();
        }

        // Stops any threads we have running;
        // At the moment we only have one thread, inside gEngine
        public void stopGame()
        {
            gEngine.stop();
        }
    }
}
