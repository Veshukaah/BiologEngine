﻿using System;
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
    /// Основной класс игровово движка. 
    /// </summary>
    public class Engine
    {
        /// <summary>
        /// Делегат обновлений.
        /// </summary>
        public delegate void Updates();
        /// <summary>
        /// Событие обновления.
        /// </summary>
        public event Updates UpdatingTheFrame;
        
        
        internal Timer UpdatesTimer = new Timer();

        /// <summary>
        /// Рармер одного пикселя.
        /// </summary>
        public int onePixselSize = 10;

        /// <summary>
        /// Высота экрана.
        /// </summary>
        public int Height;
        /// <summary>
        /// Ширина экрана.
        /// </summary>
        public int Width;

        /// <summary>
        /// Ссылка на форму. 
        /// </summary>
        public Form1 form1;
        /// <summary>
        /// Ссылка на отрисовочный экран.
        /// </summary>
        public Graphics graphics;

        /// <summary>
        /// Спрайты.
        /// </summary>
        public Sprite[] sprites = new Sprite[1] {new Sprite(new SolidBrush(Color.White))};

        internal GameObject[] gameObjects;

        /// <summary>
        /// Игровое поле.
        /// </summary>
        public GameFied gameFied = new GameFied();

        internal Printer printer = new Printer();

        /// <summary>
        /// Запуск движка.
        /// </summary>
        public static void StartEngine()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
        
        
        internal void InitializeEngine()
        {

            gameObjects = PreIntiliaze.GameObjects;
            
            
            Width = form1.pictureBox2.Size.Width / onePixselSize;
            Height = form1.pictureBox2.Size.Height / onePixselSize;

            gameFied.gameObject = new GameObject[Height, Width];

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
                    gameObjects[i].Initialize();
                    gameFied.gameObject[gameObjects[i].transform.position.y, gameObjects[i].transform.position.x] = gameObjects[i];
                }
                
            }


            //Initialize printer
            printer.graphics = graphics;
            
            UpdatingTheFrame += new Updates(printer.Update);
            printer.Initialize();


            

            //Initialize UpdatesTimer
            UpdatesTimer.Tick += UpdatingTheFrames;
            UpdatesTimer.Interval = 100;
            UpdatesTimer.Start();
            
            
        }
        internal void UpdatingTheFrames(object obj,EventArgs e)
        {
            UpdatingTheFrame.Invoke();
        }

        /// <summary>
        /// Создает новый GameObject.
        /// </summary>
        /// <returns>Возвращает созданный GameObject.</returns>
        public static GameObject CreateGameObject()
        {
            GameObject gameObject = new GameObject();
            gameObject.transform.position = new Vector2(0,0);
            gameObject.transform.scale= new Vector2(1,1);
            return gameObject;
        }
        /// <summary>
        /// Создает новый GameObject.
        /// </summary>
        /// <param name="position">Позицая нового объекта.</param>
        /// <returns>Возвращает созданный GameObject.</returns>
        public static GameObject CreateGameObject(Vector2 position)
        {
            GameObject gameObject = new GameObject();
            gameObject.transform.position = position;
            gameObject.transform.scale = new Vector2(1, 1);
            return gameObject;
        }
    }
}
