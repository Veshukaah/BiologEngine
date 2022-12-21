using BiologeEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BiologeEngine.Engine;

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
        /// <summary>
        /// Уничтажает объект.
        /// </summary>
        public void Destroy()
        {
            for(int i = 0; i < engine.gameObjects.Length; i++)
            {
                if (engine.gameObjects[i] == this)
                {
                    engine.gameObjects = engine.gameObjects.Except(new GameObject[] {this}).ToArray();
                    for(int j = 0; j  < GetAllComponents().Length; j++)
                    {
                        if (GetAllComponents()[j].GetType().GetMethod("Update") != null)
                        {
                            engine.UpdatingTheFrame -= (Updates)Delegate.CreateDelegate(typeof(Updates), GetAllComponents()[j], GetAllComponents()[j].GetType().GetMethod("Update")); 
                        }
                    }
                }
            }
            for(int i = 0; i < GetAllComponents().Length;i++)
            {
                GetAllComponents()[i].Destroy();
            }
            transform.Destroy();
            
        }

        /// <summary>
        /// Уництожает компонент.
        /// </summary>
        /// <param name="component"></param>
        public void Destroy(Component component)
        {
            components = components.Except(new Component[] {component}).ToArray();
            if (component.GetType().GetMethod("Update") != null)
            {
                engine.UpdatingTheFrame -= (Updates)Delegate.CreateDelegate(typeof(Updates), component, component.GetType().GetMethod("Update"));
            }
            component.Destroy();
        }


        /// <summary>
        /// Создаёт новый объект.
        /// </summary>
        /// <param name="gameObject">Префаб объекта.</param>
        /// <param name="position">Позиция копии.</param>
        public GameObject Instante(GameObject gameObject,Vector2 position)
        {
            GameObject res = CreateGameObject();

            res.transform.position = position;
            res.engine = gameObject.engine;
            res.components = new Component[gameObject.components.Length];
            
            for(int i = 0; i < gameObject.components.Length; i++)
            {
                res.components[i] = (Component)Activator.CreateInstance(gameObject.components[i].GetType());
                res.components[i].gameObject = gameObject.components[i].gameObject;
                res.components[i].engine = gameObject.components[i].engine;
                res.Initialize();
            }
            

            for (int j = 0; j < res.GetAllComponents().Length; j++)
            {
                if (res.GetAllComponents()[j].GetType().GetMethod("Update") != null)
                {
                    engine.UpdatingTheFrame += (Updates)Delegate.CreateDelegate(typeof(Updates), res.GetAllComponents()[j], res.GetAllComponents()[j].GetType().GetMethod("Update"));
                }

                engine.gameFied.gameObject[res.transform.position.y,  res.transform.position.x] = res;
            }
            engine.gameObjects = engine.gameObjects.Concat(new GameObject[] { res }).ToArray();
            res.Initialize();
            return res;
        }
        

    }
}
