using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace LiveSwitch.TextHelper
{
    public static unsafe class TextBoxtHelper
    {

        private const int EM_GETLINE = 0xc4;

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hwnd, int wMsg, int wParam, sbyte* lParam);

        public static string GetTextBoxLine(TextBoxBase text_box, int line)
        {
            const int BUFFER_SIZE = 4086;
            sbyte[] buffer = new sbyte[BUFFER_SIZE];
            fixed (sbyte* p_buffer = buffer)
            {
                // первым word-ом ставим длину буфера, так требует протокол работы сообщения
                *((short*)p_buffer) = (short)BUFFER_SIZE;

                if (0 == SendMessage(text_box.Handle, EM_GETLINE, line, p_buffer))
                    return string.Empty;

                return new string(p_buffer);
            }
        }

    }
}
