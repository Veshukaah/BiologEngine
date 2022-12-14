using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiologEngine
{
    /// <summary>
    /// 
    /// </summary>
    public static class PreIntiliaze
    {
        internal static GameObject[] GameObjects = new GameObject[0];

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gameObjects"></param>
        public static void SetGameObject(GameObject gameObjects)
        {
            GameObjects = GameObjects.Concat(new GameObject[] { gameObjects }).ToArray();
        }
    }
}
