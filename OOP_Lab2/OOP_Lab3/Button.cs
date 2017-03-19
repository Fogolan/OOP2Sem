using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPLab2_03
{
    sealed class Button
    {
        private static Button instance;

        private Button() { }
        public static Button GetInstance()
        {
            if (instance == null)
                instance = new Button();
            return instance;
        }
    }
}
