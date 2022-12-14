using BiologeEngine;
using System.Drawing;

namespace BiologEngine
{
    /// <summary>
    /// 
    /// </summary>
    public class Sprite
    {
        /// <summary>
        /// 
        /// </summary>
        public Engine engine;
        /// <summary>
        /// 
        /// </summary>
        public Brush brush;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="brush"></param>
        public Sprite( Brush brush)
        {
            this.brush = brush;
        }
    }
}
