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
        /// ОБЕЗАТЕЛЬНАЯ функция перемещения.
        /// </summary>
        /// <param name="newVector2">Новая позицая. </param>
        public void Move(Vector2 newVector2)
        {
            if (newVector2.x >= 0 && newVector2.x < engine.Width - 1)
            {
                position.x = newVector2.x;
            }
            if(newVector2.y >= 0 && newVector2.y< engine.Height - 1)
            {
                position.y = newVector2.y;
            }
        }
    }
}
