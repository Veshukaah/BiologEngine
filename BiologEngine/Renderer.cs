using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BiologEngine
{
    public class Renderer : Component
    {
        public Sprite sprite;
        
        public Rectangle rectangle = new Rectangle();
        

        public override void Initialize()
        {
            
            if (gameObject == null) throw new ArgumentNullException("aaaaaaaaaaaaaaa");
            sprite = engine.sprites[0];


            var Pablicsprite = new PublicGameSprite
            {
                gameObject = gameObject,
                renderer = this,
                engine = engine,
                rectangle = rectangle,
                brush = sprite.brush
            };
            Pablicsprite.Initiliaze();
            

        }
    }
}
