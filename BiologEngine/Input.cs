using BiologeEngine;
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

        internal static Label form1; 
        static Dictionary<Keys, bool> Button = new Dictionary<Keys, bool>();
        internal static  void ButtonDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            Button[e.KeyData] = true;   
        }
        internal static void ButtonUp(object sender,System.Windows.Forms.KeyEventArgs e)
        {
            Button[e.KeyData] = false;
        }




        /// <summary>
        /// Проверка нажата ли клавиша.
        /// </summary>
        /// <param name="k">Клавиша.</param>
        /// <returns>Нажата ли клавиша.</returns>
        public static bool GetKey(Keys k)
        {
            return Button[k];
        }
        /// <summary>
        /// 
        /// </summary>
        public static void Print(string mes)
        {
            form1.Text = mes;
        }
        internal static void Initialize()
        {
            foreach(Keys keys in Enum.GetValues(typeof(Keys)))
            {
                if (!Button.ContainsKey(keys))
                {
                    Button.Add(keys, false);
                }
            }
        }
    }
}
