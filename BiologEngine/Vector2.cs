using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiologEngine
{
    /// <summary>
    /// Предстовление векторов и точек.
    /// </summary>
    public struct Vector2
    {
        /// <summary>
        /// X компонент вектора.
        /// </summary>
        public int x ;
        /// <summary>
        /// Y компонент вектора.
        /// </summary>
        public int y ;

        /// <summary>
        /// Конструктор вектора.
        /// </summary>
        /// <param name="x">X компонент вектора.</param>
        /// <param name="y">Y компонент вектора.</param>
        public Vector2(int x,int y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// Оператор сложения векторов.
        /// </summary>
        /// <param name="vector1">Первый вектор.</param>
        /// <param name="vector2">Второй вектор.</param>
        /// <returns>Сумму векторов.</returns>
        public static Vector2 operator +(Vector2 vector1,Vector2 vector2)
        {
            return new Vector2(vector1.x + vector2.x,vector1.y + vector2.y);
        }
        
        /// <summary>
        /// Оператор вычитания.
        /// </summary>
        /// <param name="vector1">Первый вектор</param>
        /// <param name="vector2">Второй вектор</param>
        /// <returns>Разницу викторов.</returns>
        public static Vector2 operator -(Vector2 vector1, Vector2 vector2)
        {
            return new Vector2(vector1.x - vector2.x, vector1.y - vector2.y);
        }
        
    }
}
