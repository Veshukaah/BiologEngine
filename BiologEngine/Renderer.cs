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
        
        
        
        /// <summary>
        /// Инциллизация объекты.
        /// </summary>
        /// <exception cref="ArgumentNullException">Отствуе ссылки на объекта</exception>
        public override void Initialize()
        {
            
            if (gameObject == null) throw new ArgumentNullException("aaaaaaaaaaaaaaa");
            sprite = engine.sprites[0];


            var Pablicsprite = new PublicGameSprite
            {
                gameObject = gameObject,
                renderer = this,
                engine = engine,                
                brush = sprite.brush
            };
            Pablicsprite.Initiliaze();
            

        }
    }
}
