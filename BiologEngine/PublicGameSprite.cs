using BiologeEngine;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BiologEngine
{

    /// <summary>
    /// 
    /// </summary>
    public class PublicGameSprite
    {
        /// <summary>
        /// 
        /// </summary>
        public GameObject gameObject;
        /// <summary>
        /// 
        /// </summary>
        public Renderer renderer;
        /// <summary>
        /// 
        /// </summary>
        public Rectangle rectangle;
        /// <summary>
        /// 
        /// </summary>
        public Brush brush;
        /// <summary>
        /// 
        /// </summary>
        public Engine engine;

        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        public void Initiliaze()
        {
            if (gameObject == null) throw new ArgumentNullException();
            if (rectangle == null) throw new ArgumentNullException();
            if (brush == null) throw new ArgumentNullException();
            if (engine == null) throw new ArgumentNullException();
            
            engine.printer.AddSprites(this);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Rectangle GetRectlange()
        {
            return new Rectangle(
                gameObject.transform.position.x * engine.onePixselSize,
                gameObject.transform.position.y * engine.onePixselSize,
                gameObject.transform.scale.x * engine.onePixselSize,
                gameObject.transform.scale.y * engine.onePixselSize);
        }
    }
}
