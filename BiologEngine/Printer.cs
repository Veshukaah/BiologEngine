using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BiologEngine
{
    internal class Printer
    {
        public Graphics graphics;
        internal PublicGameSprite[] sprites = new PublicGameSprite[0];
        
        public void Initialize()
        {
            
            graphics.Clear(Color.Black);
        }
        public void Update()
        {
            graphics.Clear(Color.Black);
            for(int i = 0; i < sprites.Length; i++)
            {
                
                
                graphics.FillRectangle(sprites[i].brush, sprites[i].GetRectlange());
                
            }
        }

        internal void AddSprites(PublicGameSprite sprite)
        {
            sprites = sprites.Concat(new PublicGameSprite[] {sprite }).ToArray();
        }
        
        
    }
}
