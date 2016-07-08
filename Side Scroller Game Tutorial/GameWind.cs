using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

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

        // Canvas paint function - launches paint functionality
        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            game.loadLevel();
            Graphics g = canvas.CreateGraphics();
            game.startGraphics(g);
        }

        // Stops the game before the form is closed, and therefore before any exceptions can occur.
        private void GameWind_FormClosing(object sender, FormClosingEventArgs e)
        {
            game.stopGame();
        }

        private void GameWind_Load(object sender, EventArgs e)
        {
            AllocConsole();
        }

        // Allows the command line to be seen during normal execution
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAsAttribute(UnmanagedType.Bool)]
        static extern bool AllocConsole();

    }
}
