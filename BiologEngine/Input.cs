using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BiologEngine
{
    /// <summary>
    /// Класс отвечающий за нажатие клавиш.
    /// </summary>
    public static class Input
    {
        /// <summary>
        /// Проверка нажата ли клавиша.
        /// </summary>
        /// <param name="key">Клавиша для проверки.</param>
        /// <returns>Нажата ли клавиша.</returns>
        public static bool IsKeyDown(Key key)
        {
            if(Keyboard.IsKeyDown(key)) return true;
            return false;
        }
    }
}
