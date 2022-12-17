using BiologeEngine;
using System.Drawing;

namespace BiologEngine
{
    /// <summary>
    /// Класс спрайта.
    /// </summary>
    public class Sprite
    {
        /// <summary>
        /// Ссылка на движок.
        /// </summary>
        public Engine engine;
        /// <summary>
        /// Экземпляр кисти.
        /// </summary>
        public Brush brush;

        /// <summary>
        /// Конструктор спрайта.
        /// </summary>
        /// <param name="brush">Экземпляр кисти.</param>
        public Sprite( Brush brush)
        {
            this.brush = brush;
        }
    }
}
