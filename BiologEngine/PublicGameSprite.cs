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

    
    internal class PublicGameSprite
    {
        
        public GameObject gameObject;
        
        public Renderer renderer;
        
        public Rectangle rectangle;
        
        public Brush brush;
        
        public Engine engine;

        
        public void Initiliaze()
        {
            if (gameObject == null) throw new ArgumentNullException();
            if (rectangle == null) throw new ArgumentNullException();
            if (brush == null) throw new ArgumentNullException();
            if (engine == null) throw new ArgumentNullException();
            
            engine.printer.AddSprites(this);
        }
        
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
