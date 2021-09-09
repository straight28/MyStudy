using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CopyAndPaste
{
    public class CGlobalKeyboardHook
    {

        [DllImport("user32.dll")]
        static extern IntPtr SetWindowsHookEx(int idHook, keyboardHookProc callback, IntPtr hinstance, uint threadId);

        [DllImport("user32.dll")]
        static extern bool UnhookWinodwsHookEx(IntPtr hInstance);


        [DllImport("user32.dll")]
        static extern int CallNextHookEx(IntPtr idHook, int nCode, int wparam, ref keyboardHookStruck iParam);


        [DllImport("user32.dll")]
        static extern short GetKeyState(int nCode);


        [DllImport("kernel32.dll")]
        static extern IntPtr LoadLibrary(string IpFileName);    // 라이브러리등록


        public delegate int keyboardHookProc(int code, int wParam, ref keyboardHookStruck iParam);  // 콜백 델리게이트

        /// <summary>
        /// KeyboardHookstruck 구조체 정의
        /// </summary>
        public struct keyboardHookStruck
        {
            public int vkCode;
            public int scanCode;
            public int flags;
            public int time;
            public int dwExtrainInfo;
        }

        // 정의 되어 있는 상수 값
        const int VK_SHIFT = 0x10;
        const int VK_CONTROL = 0x11;
        const int VK_MENU = 0x12;

        const int WH_KEYBOARD_LL = 13;
        const int WM_KEYDOWN = 0x100;
        const int WM_KEYUP = 0x101;
        const int WM_SYSKEYDOWN = 0x104;
        const int WM_SYSKEYUP = 0x105;

        private keyboardHookProc khp;
        IntPtr hhook = IntPtr.Zero;

        public event KeyEventHandler KeyDown;
        public event KeyEventHandler KeyUp;


        public CGlobalKeyboardHook()
        {
            khp = new keyboardHookProc(hookproc);
            
        }


        public void hook()
        {
            IntPtr hinstance = LoadLibrary("User32");
            hhook = SetWindowsHookEx(WH_KEYBOARD_LL, khp, hinstance, 0);
        }

        
        public void unhook()
        {
            UnhookWinodwsHookEx(hhook);
        }


        private int hookproc(int code, int wParam, ref keyboardHookStruck iParam)
        {

            if (code >= 0)
            {
                Keys key = (Keys)iParam.vkCode;
                if ((GetKeyState(VK_CONTROL) & 0x80) != 0)
                {
                    key |= Keys.Control;
                }

                if ((GetKeyState(VK_MENU) & 0x80) != 0)
                {
                    key |= Keys.Alt;
                }

                if ((GetKeyState(VK_SHIFT) & 0x80) != 0)
                {
                    key |= Keys.Shift;
                }

                KeyEventArgs kea = new KeyEventArgs(key);

                if ((wParam == WM_KEYDOWN || wParam == WM_SYSKEYDOWN) && (KeyDown != null))
                {
                    KeyDown(this, kea);
                }
                else if ((wParam == WM_KEYUP || wParam == WM_SYSKEYDOWN) && (KeyUp != null))
                {
                    KeyUp(this, kea);
                }

                if (kea.Handled)
                {
                    return 1;
                }

            }

            return CallNextHookEx(hhook, code, wParam, ref iParam);
        }
    }

}
