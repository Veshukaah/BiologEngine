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
        /// Ссылка на движок.
        /// </summary>
        public Engine engine;
        /// <summary>
        /// Ссылка на влодельца компонента.
        /// </summary>
        public GameObject gameObject;

        /// <summary>
        /// Метод интилизации.
        /// </summary>
        public virtual void Initialize()
        {
            
        }
    }
}
