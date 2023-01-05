using System;
using System.Windows.Forms;

namespace EXIN
{
    class InputHandler
    {

        public void CheckInputNum(KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9')
            {
                // number values
                e.Handled = false;
            }
            else if ((int)e.KeyChar == 8)
            {
                //backspace
                e.Handled = false;
            }
            else if (e.KeyChar == '.')
            {
                //decimal point
                e.Handled = false;
            }
            else
            {
                //any other character
                e.Handled = true;
                Console.Beep();
            }

        }

        public void CheckEnterKey(MethodInvoker evt, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
            {
                evt();
            }
        }

    }
}
