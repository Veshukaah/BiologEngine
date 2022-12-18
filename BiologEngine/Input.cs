using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
        /// <param name="keys">Клавиша для проверки.</param>
        /// <returns>Нажата ли клавиша.</returns>
        public static bool IsKeyDown(Keys keys)
        {
            if(Keyboard.Modifiers.HasFlag(keys)) return true;
            return false;
        }
    }
}
