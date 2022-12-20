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
    /// <summary>
    /// класс отоброжения.
    /// </summary>
    public class Renderer : Component
    {
        /// <summary>
        /// Поле для изоброжения.
        /// </summary>
        public Sprite sprite;

        internal PublicGameSprite PublicGAmesprite;
            
        
        /// <inheritdoc/>
        /// <exception cref="ArgumentNullException">Отствуе ссылки на объект.</exception>
        public override void Initialize()
        {
            
            if (gameObject == null) throw new ArgumentNullException("aaaaaaaaaaaaaaa");
            sprite = engine.sprites[0];

            

            PublicGAmesprite = new PublicGameSprite
            {
                gameObject = gameObject,
                renderer = this,
                engine = engine,                
                brush = sprite.brush
            };
            PublicGAmesprite.Initiliaze();
        }
        /// <inheritdoc/>
        public override void Destroy()
        {
            
            engine.form1.graphics.FillRectangle(new SolidBrush(Color.Black), PublicGAmesprite.GetRectlange());
            
            for(int i = 0; i < engine.printer.sprites.Length;i++)
            {
                if (engine.printer.sprites[i] == PublicGAmesprite)
                {
                    
                    List<PublicGameSprite> sprites = engine.printer.sprites.ToList();
                    sprites.RemoveAt(i);
                    engine.printer.sprites = sprites.ToArray();
                    

                }
            }
            
        }
    }
}
