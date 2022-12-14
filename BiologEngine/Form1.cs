using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BiologeEngine
{
    public partial class Form1 : Form
    {
        public Graphics graphics;
        public Engine engine = new Engine();
        
        public Form1()
        {
            // InitializaComponent
            InitializeComponent();
            graphics = pictureBox2.CreateGraphics();

            // InitializaEngine
            engine.form1 = this;
            engine.graphics = graphics;
            
            engine.InitializeEngine();
        }
    }
}
