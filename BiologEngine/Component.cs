using BiologeEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiologEngine
{
    /// <summary>
    /// Класс компонента.
    /// </summary>
    public class Component 
    {
        /// <summary>
        /// Обезательная поле движка.
        /// </summary>
        public Engine engine;
        /// <summary>
        /// Ссылка на gameObject.
        /// </summary>
        public GameObject gameObject;

        /// <summary>
        /// Метод инцилизации.
        /// </summary>
        public virtual void Initialize()
        {
            
        }
    }
}
