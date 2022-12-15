using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiologEngine
{
    /// <summary>
    /// Класс для обьявления параметров до инцилизации.
    /// </summary>
    public static class PreIntiliaze
    {
        internal static GameObject[] GameObjects = new GameObject[0];

        /// <summary>
        /// Добовляет игровой объект.
        /// </summary>
        /// <param name="gameObjects"> Ссылка на игровой объект.</param>
        public static void AddGameObject(GameObject gameObjects)
        {
            GameObjects = GameObjects.Concat(new GameObject[] { gameObjects }).ToArray();
        }
    }
}
