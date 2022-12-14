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
    /// 
    /// </summary>
    public class GameObject 
    {
        private Component[] components = new Component[] {new Transform(),new Renderer()};

        /// <summary>
        /// 
        /// </summary>
        public Engine engine;
        /// <summary>
        /// 
        /// </summary>
        public Transform transform { get { return (Transform)components[0];}}
        
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
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
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="component"></param>
        public void AddComponent<T>(T component) where T : Component
        {
            components = components.Concat(new Component[] {component}).ToArray();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Component[] GetAllComponents()
        {
            return components;
        }

        /// <summary>
        /// 
        /// </summary>
        public  void Initialize()
        {
            for( int i = 0; i < components.Length; i++)
            {
                components[i].engine = engine;
                components[i].gameObject = this;
                components[i].Initialize();
            }
            
        }
    }
}
