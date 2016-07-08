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

        /*------------Functions---------------------*/

        public GEngine(Graphics g)
        {
            drawHandle = g;
        }

        // Starts a render thread
        public void init()
        {
            renderThread = new Thread(new ThreadStart(render));
            renderThread.Start();
        }

        // Stops a render thread
        public void stop()
        {
            renderThread.Abort();
        }

        // this will do ALL the drawing 
        private void render()
        {
            // since this is a new thread, it will use an infinite loop that runs forever
            while (true)
            {
                // We use solid brush because we don't have assets yet
                // 0,0 & 1200,700 are x, y positions. We want to fill the entire panel
                drawHandle.FillRectangle(new SolidBrush(Color.Aqua), 0, 0, 1200, 700);
            }
        }

    }
}
