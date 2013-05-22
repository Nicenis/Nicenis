/*
 * Author	JO Hyeong-Ryeol
 * Since	2012.10.21
 * Version	$Id: Win32.cs 24043 2013-05-21 14:49:03Z unknown $
 * 
 * Copyright (C) 2012 JO Hyeong-Ryeol. All rights reserved.
 */

using System;
using System.Runtime.InteropServices;

namespace Nicenis.Interop
{
    /// <summary>
    /// Provides Win32 API Interop related codes.
    /// </summary>
    internal static class Win32
    {
        #region Constants

        public const int MAX_PATH = 260;


        public const int GWL_EXSTYLE = -20;
        public const int GWL_HINSTANCE = -6;
        public const int GWL_ID = -12;
        public const int GWL_STYLE = -16;
        public const int GWL_USERDATA = -21;
        public const int GWL_WNDPROC = -4;


        public const int WS_EX_ACCEPTFILES = 0x00000010;
        public const int WS_EX_APPWINDOW = 0x00040000;
        public const int WS_EX_CLIENTEDGE = 0x00000200;
        public const int WS_EX_COMPOSITED = 0x02000000;
        public const int WS_EX_CONTEXTHELP = 0x00000400;
        public const int WS_EX_CONTROLPARENT = 0x00010000;
        public const int WS_EX_DLGMODALFRAME = 0x00000001;
        public const int WS_EX_LAYERED = 0x00080000;
        public const int WS_EX_LAYOUTRTL = 0x00400000;
        public const int WS_EX_LEFT = 0x00000000;
        public const int WS_EX_LEFTSCROLLBAR = 0x00004000;
        public const int WS_EX_LTRREADING = 0x00000000;
        public const int WS_EX_MDICHILD = 0x00000040;
        public const int WS_EX_NOACTIVATE = 0x08000000;
        public const int WS_EX_NOINHERITLAYOUT = 0x00100000;
        public const int WS_EX_NOPARENTNOTIFY = 0x00000004;
        public const int WS_EX_NOREDIRECTIONBITMAP = 0x00200000;
        public const int WS_EX_OVERLAPPEDWINDOW = WS_EX_WINDOWEDGE | WS_EX_CLIENTEDGE;
        public const int WS_EX_PALETTEWINDOW = WS_EX_WINDOWEDGE | WS_EX_TOOLWINDOW | WS_EX_TOPMOST;
        public const int WS_EX_RIGHT = 0x00001000;
        public const int WS_EX_RIGHTSCROLLBAR = 0x00000000;
        public const int WS_EX_RTLREADING = 0x00002000;
        public const int WS_EX_STATICEDGE = 0x00020000;
        public const int WS_EX_TOOLWINDOW = 0x00000080;
        public const int WS_EX_TOPMOST = 0x00000008;
        public const int WS_EX_TRANSPARENT = 0x00000020;
        public const int WS_EX_WINDOWEDGE = 0x00000100;


        public const uint FILE_ATTRIBUTE_ARCHIVE = 0x20;
        public const uint FILE_ATTRIBUTE_COMPRESSED = 0x800;
        public const uint FILE_ATTRIBUTE_DEVICE = 0x40;
        public const uint FILE_ATTRIBUTE_DIRECTORY = 0x10;
        public const uint FILE_ATTRIBUTE_ENCRYPTED = 0x4000;
        public const uint FILE_ATTRIBUTE_HIDDEN = 0x2;
        public const uint FILE_ATTRIBUTE_INTEGRITY_STREAM = 0x8000;
        public const uint FILE_ATTRIBUTE_NORMAL = 0x80;
        public const uint FILE_ATTRIBUTE_NOT_CONTENT_INDEXED = 0x2000;
        public const uint FILE_ATTRIBUTE_NO_SCRUB_DATA = 0x20000;
        public const uint FILE_ATTRIBUTE_OFFLINE = 0x1000;
        public const uint FILE_ATTRIBUTE_READONLY = 0x1;
        public const uint FILE_ATTRIBUTE_REPARSE_POINT = 0x400;
        public const uint FILE_ATTRIBUTE_SPARSE_FILE = 0x200;
        public const uint FILE_ATTRIBUTE_SYSTEM = 0x4;
        public const uint FILE_ATTRIBUTE_TEMPORARY = 0x100;
        public const uint FILE_ATTRIBUTE_VIRTUAL = 0x10000;


        public static readonly Guid IID_IImageList = new Guid("46EB5926-582E-4017-9FDF-E8998DAA0950");


        public const int SHIL_LARGE = 0;
        public const int SHIL_SMALL = 1;
        public const int SHIL_EXTRALARGE = 2;
        public const int SHIL_SYSSMALL = 3;
        public const int SHIL_JUMBO = 4;


        public const uint SHGFI_ADDOVERLAYS = 0x000000020;
        public const uint SHGFI_ATTR_SPECIFIED = 0x000020000;
        public const uint SHGFI_ATTRIBUTES = 0x000000800;
        public const uint SHGFI_DISPLAYNAME = 0x000000200;
        public const uint SHGFI_EXETYPE = 0x000002000;
        public const uint SHGFI_ICON = 0x000000100;
        public const uint SHGFI_ICONLOCATION = 0x000001000;
        public const uint SHGFI_LARGEICON = 0x000000000;
        public const uint SHGFI_LINKOVERLAY = 0x000008000;
        public const uint SHGFI_OPENICON = 0x000000002;
        public const uint SHGFI_OVERLAYINDEX = 0x000000040;
        public const uint SHGFI_PIDL = 0x000000008;
        public const uint SHGFI_SELECTED = 0x000010000;
        public const uint SHGFI_SHELLICONSIZE = 0x000000004;
        public const uint SHGFI_SMALLICON = 0x000000001;
        public const uint SHGFI_SYSICONINDEX = 0x000004000;
        public const uint SHGFI_TYPENAME = 0x000000400;
        public const uint SHGFI_USEFILEATTRIBUTES = 0x000000010;


        public const uint ILD_NORMAL = 0x00000000;
        public const uint ILD_TRANSPARENT = 0x00000001;
        public const uint ILD_BLEND25 = 0x00000002;
        public const uint ILD_FOCUS = 0x00000002;
        public const uint ILD_BLEND50 = 0x00000004;
        public const uint ILD_SELECTED = 0x00000004;
        public const uint ILD_BLEND = 0x00000004;
        public const uint ILD_MASK = 0x00000010;
        public const uint ILD_IMAGE = 0x00000020;
        public const uint ILD_ROP = 0x00000040;
        public const uint ILD_OVERLAYMASK = 0x00000F00;
        public const uint ILD_PRESERVEALPHA = 0x00001000;
        public const uint ILD_SCALE = 0x00002000;
        public const uint ILD_DPISCALE = 0x00004000;
        public const uint ILD_ASYNC = 0x00008000;


        public const uint MONITOR_DEFAULTTONEAREST = 0x00000002;
        public const uint MONITOR_DEFAULTTONULL = 0x00000000;
        public const uint MONITOR_DEFAULTTOPRIMARY = 0x00000001;


        public const uint TPM_CENTERALIGN = 0x0004;
        public const uint TPM_LEFTALIGN = 0x0000;
        public const uint TPM_RIGHTALIGN = 0x0008;
        public const uint TPM_BOTTOMALIGN = 0x0020;
        public const uint TPM_TOPALIGN = 0x0000;
        public const uint TPM_VCENTERALIGN = 0x0010;
        public const uint TPM_NONOTIFY = 0x0080;
        public const uint TPM_RETURNCMD = 0x0100;
        public const uint TPM_LEFTBUTTON = 0x0000;
        public const uint TPM_RIGHTBUTTON = 0x0002;
        public const uint TPM_HORNEGANIMATION = 0x0800;
        public const uint TPM_HORPOSANIMATION = 0x0400;
        public const uint TPM_NOANIMATION = 0x4000;
        public const uint TPM_VERNEGANIMATION = 0x2000;
        public const uint TPM_VERPOSANIMATION = 0x1000;
        public const uint TPM_HORIZONTAL = 0x0000;
        public const uint TPM_VERTICAL = 0x0040;


        public const int WM_GETMINMAXINFO = 0x0024;
        public const int WM_SYSCOMMAND = 0x0112;


        public static readonly IntPtr SC_CLOSE = (IntPtr)0xF060;
        public static readonly IntPtr SC_CONTEXTHELP = (IntPtr)0xF180;
        public static readonly IntPtr SC_DEFAULT = (IntPtr)0xF160;
        public static readonly IntPtr SC_HOTKEY = (IntPtr)0xF150;
        public static readonly IntPtr SC_HSCROLL = (IntPtr)0xF080;
        public static readonly IntPtr SCF_ISSECURE = (IntPtr)0x00000001;
        public static readonly IntPtr SC_KEYMENU = (IntPtr)0xF100;
        public static readonly IntPtr SC_MAXIMIZE = (IntPtr)0xF030;
        public static readonly IntPtr SC_MINIMIZE = (IntPtr)0xF020;
        public static readonly IntPtr SC_MONITORPOWER = (IntPtr)0xF170;
        public static readonly IntPtr SC_MOUSEMENU = (IntPtr)0xF090;
        public static readonly IntPtr SC_MOVE = (IntPtr)0xF010;
        public static readonly IntPtr SC_NEXTWINDOW = (IntPtr)0xF040;
        public static readonly IntPtr SC_PREVWINDOW = (IntPtr)0xF050;
        public static readonly IntPtr SC_RESTORE = (IntPtr)0xF120;
        public static readonly IntPtr SC_SCREENSAVE = (IntPtr)0xF140;
        public static readonly IntPtr SC_SIZE = (IntPtr)0xF000;
        public static readonly IntPtr SC_TASKLIST = (IntPtr)0xF130;
        public static readonly IntPtr SC_VSCROLL = (IntPtr)0xF070;

        #endregion


        #region Structures

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct SHFILEINFO
        {
            public IntPtr hIcon;
            public int iIcon;
            public uint dwAttributes;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH)]
            public string szDisplayName;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
            public string szTypeName;
        }

        static readonly Lazy<int> LazySizeOfSHFILEINFO = new Lazy<int>(() => Marshal.SizeOf(typeof(SHFILEINFO)), false);
        public static int SizeOfSHFILEINFO { get { return LazySizeOfSHFILEINFO.Value; } }


        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct POINT
        {
            public int x;
            public int y;
        }

        static readonly Lazy<int> LazySizeOfPOINT = new Lazy<int>(() => Marshal.SizeOf(typeof(POINT)), false);
        public static int SizeOfPOINT { get { return LazySizeOfPOINT.Value; } }


        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }

        static readonly Lazy<int> LazySizeOfRECT = new Lazy<int>(() => Marshal.SizeOf(typeof(RECT)), false);
        public static int SizeOfRECT { get { return LazySizeOfRECT.Value; } }


        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct MONITORINFO
        {
            public uint cbSize;
            public RECT rcMonitor;
            public RECT rcWork;
            public uint dwFlags;

            public static MONITORINFO Create()
            {
                return new MONITORINFO()
                {
                    cbSize = (uint)SizeOfMONITORINFO,
                };
            }
        }

        static readonly Lazy<int> LazySizeOfMONITORINFO = new Lazy<int>(() => Marshal.SizeOf(typeof(MONITORINFO)), false);
        public static int SizeOfMONITORINFO { get { return LazySizeOfMONITORINFO.Value; } }


        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct MINMAXINFO
        {
            public POINT ptReserved;
            public POINT ptMaxSize;
            public POINT ptMaxPosition;
            public POINT ptMinTrackSize;
            public POINT ptMaxTrackSize;
        }

        static readonly Lazy<int> LazySizeOfMINMAXINFO = new Lazy<int>(() => Marshal.SizeOf(typeof(MINMAXINFO)), false);
        public static int SizeOfMINMAXINFO { get { return LazySizeOfMINMAXINFO.Value; } }


        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct TPMPARAMS
        {
            public uint cbSize;
            public RECT rcExclude;

            public static TPMPARAMS Create()
            {
                return new TPMPARAMS()
                {
                    cbSize = (uint)SizeOfTPMPARAMS,
                };
            }
        }

        static readonly Lazy<int> LazySizeOfTPMPARAMS = new Lazy<int>(() => Marshal.SizeOf(typeof(TPMPARAMS)), false);
        public static int SizeOfTPMPARAMS { get { return LazySizeOfTPMPARAMS.Value; } }

        #endregion


        #region Functions

        [DllImport("Kernel32")]
        public static extern void SetLastError(uint dwErrCode);

        [DllImport("Shell32", EntryPoint = "#727")]
        public static extern int SHGetImageList(int iImageList, ref Guid riid, ref IntPtr ppv);

        [DllImport("Shell32", CharSet = CharSet.Unicode)]
        public static extern IntPtr SHGetFileInfo(string szPath, uint dwFileAttributes, ref SHFILEINFO psfi, uint cbFileInfo, uint uFlags);

        [DllImport("User32", SetLastError = true)]
        public static extern int DestroyIcon(IntPtr hIcon);

        [DllImport("Comctl32")]
        public static extern IntPtr ImageList_GetIcon(IntPtr himl, int i, uint flags);


        [DllImport("User32", CharSet = CharSet.Unicode)]
        public static extern int GetMonitorInfo(IntPtr hNonitor, ref MONITORINFO lpmi);


        [DllImport("User32")]
        public static extern IntPtr MonitorFromWindow(IntPtr hwnd, uint dwFlags);

        [DllImport("User32")]
        public static extern IntPtr MonitorFromPoint(POINT pt, uint dwFlags);

        [DllImport("User32")]
        public static extern IntPtr MonitorFromRect(ref RECT lprc, uint dwFlags);


        [DllImport("User32")]
        public static extern int TrackPopupMenuEx(IntPtr hmenu, uint fuFlags, int x, int y, IntPtr hwnd, ref TPMPARAMS lptpm);

        [DllImport("User32")]
        public static extern int TrackPopupMenuEx(IntPtr hmenu, uint fuFlags, int x, int y, IntPtr hwnd, IntPtr lptpm);


        [DllImport("User32")]
        public static extern IntPtr GetSystemMenu(IntPtr hwnd, bool bRevert);


        [DllImport("User32", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern bool PostMessage(IntPtr hwnd, uint msg, IntPtr wParam, IntPtr lParam);


        [DllImport("User32", SetLastError = true)]
        private static extern IntPtr GetWindowLongPtr(IntPtr hWnd, int nIndex);

        [DllImport("User32", SetLastError = true, EntryPoint = "GetWindowLong")]
        private static extern IntPtr GetWindowLongLegacy(IntPtr hWnd, int nIndex);

        public static IntPtr GetWindowLong(IntPtr hWnd, int nIndex)
        {
            if (IntPtr.Size == 4)
                return GetWindowLongLegacy(hWnd, nIndex);

            return GetWindowLongPtr(hWnd, nIndex);
        }

        [DllImport("User32", SetLastError = true)]
        private static extern IntPtr SetWindowLongPtr(IntPtr hWnd, int nIndex, IntPtr dwNewLong);

        [DllImport("User32", SetLastError = true, EntryPoint = "SetWindowLong")]
        private static extern IntPtr SetWindowLongLegacy(IntPtr hWnd, int nIndex, IntPtr dwNewLong);

        public static IntPtr SetWindowLong(IntPtr hWnd, int nIndex, IntPtr dwNewLong)
        {
            if (IntPtr.Size == 4)
                return SetWindowLongLegacy(hWnd, nIndex, dwNewLong);

            return SetWindowLongPtr(hWnd, nIndex, dwNewLong);
        }


        [DllImport("User32", SetLastError = true)]
        public static extern int GetCursorPos(out POINT lpPoint);

        #endregion
    }
}
