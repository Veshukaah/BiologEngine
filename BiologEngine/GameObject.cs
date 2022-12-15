using BiologeEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BiologEngine
{
    /// <summary>
    /// Класс игровой обьект.
    /// </summary>
    public class GameObject 
    {
        private Component[] components = new Component[] {new Renderer()};

        /// <summary>
        /// Ссылка на движок.
        /// </summary>
        public Engine engine;
        /// <summary>
        /// Сылка на трансфрм.
        /// </summary>
        public Transform transform { get;} = new Transform();
        
        /// <summary>
        /// Ищет компонент.
        /// </summary>
        /// <typeparam name="T">Тип компонента.</typeparam>
        /// <returns>Возвращает компонент. </returns>
        public T GetComponent<T>()where T : Component
        {
            for(int i = 0; i < components.Length;i++)
            {
                if(components[i].GetType() == typeof(T))
                {
                    return (T)components[i];
                }
            }
            return null;
        }


        /// <summary>
        /// Добавляет компанет.
        /// </summary>
        /// <typeparam name="T">Тип компенента. </typeparam>
        /// <param name="component">Объект компонента.</param>
        public void AddComponent<T>(T component) where T : Component
        {
            components = components.Concat(new Component[] {component}).ToArray();
        }

        
        internal Component[] GetAllComponents()
        {
            return components;
        }

        /// <summary>
        /// Инцилизация компонента.
        /// </summary>
        public  void Initialize()
        {
            transform.Initialize();
            for( int i = 0; i < components.Length; i++)
            {
                components[i].engine = engine;
                components[i].gameObject = this;
                components[i].Initialize();
            }
            
        }
    }
}
