using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BiologEngine
{
    /// <summary>
    /// Физическое положение обьекта.
    /// </summary>
    public class Transform : Component
    {
        /// <summary>
        /// 
        /// </summary>
        public Vector2 position = new Vector2();
        /// <summary>
        /// 
        /// </summary>
        public Vector2 rotation = new Vector2();
        /// <summary>
        /// 
        /// </summary>
        public Vector2 scale = new Vector2();

        /// <summary>
        /// ОБЕЗАТЕЛЬНАЯ функция перемещения.
        /// </summary>
        /// <param name="newVector2">Позиция перемещения. </param>
        public void Move(Vector2 newVector2)
        {

        }
    }
}
