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
    /// Параметры пространстенного положения объекта.
    /// </summary>
    public class Transform : Component
    {
        /// <summary>
        /// Позицая объекта.
        /// </summary>
        public Vector2 position = new Vector2();
        /// <summary>
        /// Поворот объекта.
        /// </summary>
        public Vector2 rotation = new Vector2();
        /// <summary>
        /// Размер объекта.
        /// </summary>
        public Vector2 scale = new Vector2();

        /// <summary>
        /// Позицая объекта относительно родителя.
        /// </summary>
        public Vector2 localPosition = new Vector2();

        /// <summary>
        /// ОБЕЗАТЕЛЬНАЯ функция перемещения.
        /// </summary>
        /// <param name="newVector2">Новая позицая. </param>
        public void Move(Vector2 newVector2)
        {
            engine.gameFied.gameObject[position.y, position.x] = null;
            if (newVector2.x >= 0 && newVector2.x < engine.Width && engine.gameFied.gameObject[position.y,newVector2.x] == null)
            {
                position.x = newVector2.x;
            }
            if(newVector2.y >= 0 && newVector2.y< engine.Height && engine.gameFied.gameObject[newVector2.y,position.x] == null)
            {
                position.y = newVector2.y;
            }
            engine.gameFied.gameObject[position.y, position.x] = gameObject;
            gameObject.IMoved();
        }
        
    }
}
