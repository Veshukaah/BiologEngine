using BiologEngine;
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
    /// <summary>
    /// Форма экрана игры.
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Ссылка на graphics. 
        /// </summary>
        public Graphics graphics;
        /// <summary>
        /// Ссылка на движок.
        /// </summary>
        public Engine engine = new Engine();
        
        /// <summary>
        /// Конструктор формы.
        /// </summary>
        public Form1()
        {
            
            // InitializaComponent
            InitializeComponent();
            System.Windows.MessageBox.Show(pictureBox2.Size.Height.ToString());
            pictureBox2.Size = new Size(610, 280);
            graphics = pictureBox2.CreateGraphics();


            Input.Initialize();
            Input.form1  = label1;
            KeyDown += Input.ButtonDown;
            KeyUp+= Input.ButtonUp;

            // InitializaEngine
            engine.form1 = this;
            engine.graphics = graphics;
            
            engine.InitializeEngine();
        }
    }
}
