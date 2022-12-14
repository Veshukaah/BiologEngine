using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Diagnostics;
using System.Windows.Forms;
using System.Drawing;
using BiologEngine;

namespace BiologeEngine
{
    /// <summary>
    /// 
    /// </summary>
    public class Engine
    {
        /// <summary>
        /// 
        /// </summary>
        public delegate void Updates();
        /// <summary>
        /// 
        /// </summary>
        public event Updates UpdatingTheFrame;
        /// <summary>
        /// 
        /// </summary>
        public Timer UpdatesTimer = new Timer();

        /// <summary>
        /// 
        /// </summary>
        public int onePixselSize = 10;
        /// <summary>
        /// 
        /// </summary>
        public int Height;
        /// <summary>
        /// 
        /// </summary>
        public int Width;

        /// <summary>
        /// 
        /// </summary>
        public Form1 form1;
        /// <summary>
        /// 
        /// </summary>
        public Graphics graphics;

        /// <summary>
        /// 
        /// </summary>
        public Sprite[] sprites = new Sprite[1] {new Sprite(new SolidBrush(Color.White))};

        /// <summary>
        /// 
        /// </summary>
        public GameObject[] gameObjects;

        /// <summary>
        /// 
        /// </summary>
        public GameFied gameFied = new GameFied();

        internal Printer printer = new Printer();

        /// <summary>
        /// 
        /// </summary>
        public static void StartEngine()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        public void InitializeEngine()
        {

            gameObjects = PreIntiliaze.GameObjects;
            
            Width = form1.pictureBox2.Size.Width;
            Height = form1.pictureBox2.Size.Height;

            if (gameObjects == null) throw new ArgumentNullException();
            //Initialize sprites
            for(int i = 0; i < sprites.Length; i++)
            {
                sprites[i].engine = this;
            }
            //In
            for(int i = 0; i < gameObjects.Length; i++)
            {
                MessageBox.Show(gameObjects[i].GetAllComponents().Length.ToString());
                gameObjects[i].engine = this;
                for (int j = 0; j < gameObjects[i].GetAllComponents().Length; j++)
                {
                    
                    if (gameObjects[i].GetAllComponents()[j].GetType().GetMethod("Update") != null)
                    {
                        UpdatingTheFrame += (Updates)Delegate.CreateDelegate(typeof(Updates), gameObjects[i].GetAllComponents()[j], gameObjects[i].GetAllComponents()[j].GetType().GetMethod("Update"));
                    }
                }
                gameObjects[i].Initialize();
            }


            //Initialize printer
            printer.graphics = graphics;
            
            UpdatingTheFrame += new Updates(printer.Update);
            printer.Initialize();


            gameFied.gameObject = new GameObject[Height, Width];

            //Initialize UpdatesTimer
            UpdatesTimer.Tick += UpdatingTheFrames;
            UpdatesTimer.Interval = 100;
            UpdatesTimer.Start();
            
            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="e"></param>
        public void UpdatingTheFrames(object obj,EventArgs e)
        {
            UpdatingTheFrame.Invoke();
        }
    }
}
