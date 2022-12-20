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
        private Component[] components = new Component[] { new Renderer() };
        private GameObject[] childs = new GameObject[0];
        private GameObject parent;


        /// <summary>
        /// Ссылка на движок.
        /// </summary>
        public Engine engine;
        /// <summary>
        /// Сылка на трансфрм.
        /// </summary>
        public Transform transform { get; } = new Transform();

        /// <summary>
        /// Ищет компонент.
        /// </summary>
        /// <typeparam name="T">Тип компонента.</typeparam>
        /// <returns>Возвращает компонент. </returns>
        public T GetComponent<T>() where T : Component
        {
            for (int i = 0; i < components.Length; i++)
            {
                if (components[i].GetType() == typeof(T))
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
            components = components.Concat(new Component[] { component }).ToArray();
        }


        internal Component[] GetAllComponents()
        {
            return components;
        }

        /// <summary>
        /// Устонавливает родителя.
        /// </summary>
        public void SetParent(GameObject parent)
        {
            this.parent = parent;
        }
        /// <summary>
        /// Считать значение родителя.
        /// </summary>
        /// <returns>Возвращает родителя.</returns>
        public GameObject GetParent()
        {
            return parent;
        }
        /// <summary>
        /// Добавляет дочерний объект.
        /// </summary>
        /// <param name="newChild">Новый дочерний объект.</param>
        public void AddChild(GameObject newChild)
        { 
            newChild.SetParent(this);
            childs = childs.Concat(new GameObject[] { newChild }).ToArray();
        }

        /// <summary>
        /// Возвращает дочерный объект по индексу.
        /// </summary>
        /// <param name="index">Индекс дочернего объекта.</param>
        /// <returns>Дочерний объект.</returns>
        public GameObject GetChild(int index)
        {
            return childs[index];
        }

        /// <summary>
        /// Инцилизация компонента.
        /// </summary>
        public  void Initialize()
        {
            transform.engine= engine;
            transform.gameObject = this;
            transform.Initialize();
            for( int i = 0; i < components.Length; i++)
            {
                components[i].engine = engine;
                components[i].gameObject = this;
                components[i].Initialize();
            }
            
        }

        internal void IMoved()
        {
            if(parent != null)
            {
                transform.localPosition = transform.position - parent.transform.position;
            }
            for(int i = 0; i < childs.Length; i++)
            {
                childs[i].MeMoved();
            }
        }
        internal void MeMoved()
        {
            transform.Move(parent.transform.position + transform.localPosition);
        }
        public void Destroy()
        {

        }
    }
}
