using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Side_Scroller_Game_Tutorial
{
    public partial class GameWind : Form
    {
        // Main game object for managing things like graphics, etc.
        private Game game = new Game();

        public GameWind()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }


        // Canvas paint function - launches paint functionality
        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            // load the graphics object, and use the game to do that
            Graphics g = canvas.CreateGraphics();
            game.startGraphics(g);
        }

        // Stops the game before the form is closed, and therefore before any exceptions can occur.
        private void GameWind_FormClosing(object sender, FormClosingEventArgs e)
        {
            game.stopGame();
        }
    }
}
