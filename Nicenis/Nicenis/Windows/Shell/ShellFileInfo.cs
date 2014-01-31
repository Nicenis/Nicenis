/*
 * Author   JO Hyeong-Ryeol
 * Since    2012.10.14
 * Version  $Id$
 * 
 * This file is a part of the Nicenis project.
 * https://nicenis.codeplex.com
 * 
 * Copyright (C) 2012 JO Hyeong-Ryeol. All rights reserved.
 */

using Nicenis.Diagnostics;
using Nicenis.Interop;
using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Nicenis.Windows.Shell
{
    /// <summary>
    /// Provides file information related to the Windows Shell.
    /// </summary>
    public static class ShellFileInfo
    {
        #region Helpers

        /// <summary>
        /// Returns a frozen ImageSource from the icon handle.
        /// </summary>
        /// <param name="hIcon">The icon handle to convert.</param>
        /// <returns>A frozen ImageSource.</returns>
        private static ImageSource ToImageSource(IntPtr hIcon)
        {
            ImageSource imageSource = Imaging.CreateBitmapSourceFromHIcon(hIcon, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            imageSource.Freeze();

            return imageSource;
        }

        #endregion


        #region Methods

        /// <summary>
        /// Returns a fronzen ImageSource that is the shell icon of the specified path.
        /// </summary>
        /// <param name="path">The file/folder relative/abolute path. Nonexistent path is allowed. Null is not allowed.</param>
        /// <param name="shellIconSize">The icon size.</param>
        /// <param name="includeOverlay">Whether the overlay is displayed or not. It is ignored except these icon sizes: ShellIconSize.ShellSized, ShellIconSize.Small, ShellIconSize.Large.</param>
        /// <param name="includeLinkOverlay">Whether the link overlay is displayed or not. It is ignored except these icon sizes: ShellIconSize.ShellSized, ShellIconSize.Small, ShellIconSize.Large.</param>
        /// <param name="isOpen">Whether the open icon is returned or not.</param>
        /// <param name="isSelected">Whether the selected icon is returned or not.</param>
        /// <returns>A frozen ImageSource that is the shell icon.</returns>
        public static ImageSource GetIcon(string path, ShellIconSize shellIconSize, bool includeOverlay = false, bool includeLinkOverlay = false, bool isOpen = false, bool isSelected = false)
        {
            Verifying.ParameterIsNotNull(path, "path");

            // Creates a uFlags for the SHGetFileInfo function.
            uint uFlags = Win32.SHGFI_ICON | Win32.SHGFI_USEFILEATTRIBUTES;

            if (includeOverlay)
                uFlags |= Win32.SHGFI_ADDOVERLAYS;

            if (includeLinkOverlay)
                uFlags |= Win32.SHGFI_LINKOVERLAY;

            if (isOpen)
                uFlags |= Win32.SHGFI_OPENICON;

            if (isSelected)
                uFlags |= Win32.SHGFI_SELECTED;


            // Whether the shFileInfo structure's hIcon handle can be used to make the requested sized icon.
            bool isShFileInfoEnough = false;

            if (shellIconSize == ShellIconSize.ShellSized)
            {
                uFlags |= Win32.SHGFI_SHELLICONSIZE;
                isShFileInfoEnough = true;
            }
            else if (shellIconSize == ShellIconSize.Small)
            {
                uFlags |= Win32.SHGFI_SMALLICON;
                isShFileInfoEnough = true;
            }
            else if (shellIconSize == ShellIconSize.Large)
            {
                uFlags |= Win32.SHGFI_LARGEICON;
                isShFileInfoEnough = true;
            }


            // Creates a dwFileAttributes for the SHGetFileInfo function.
            uint dwFileAttributes = Win32.FILE_ATTRIBUTE_NORMAL;
            if (Directory.Exists(path))
                dwFileAttributes |= Win32.FILE_ATTRIBUTE_DIRECTORY;


            // Calls the SHGetFileInfo function.
            Win32.SHFILEINFO shFileInfo = new Win32.SHFILEINFO();
            if (Win32.SHGetFileInfo(path, dwFileAttributes, ref shFileInfo, (uint)Win32.SizeOfSHFILEINFO, uFlags) == IntPtr.Zero)
                throw new Exception("SHGetFileInfo function has failed.");


            try
            {
                // If shFileInfo's hIcon is enough
                if (isShFileInfoEnough)
                    return ToImageSource(shFileInfo.hIcon);
            }
            finally
            {
                // Releases the icon handle.
                if (shFileInfo.hIcon != IntPtr.Zero)
                {
                    if (Win32.DestroyIcon(shFileInfo.hIcon) == 0)
                        throw new Win32Exception(Marshal.GetLastWin32Error());

                    shFileInfo.hIcon = IntPtr.Zero;
                }
            }


            // A iImageList for the SHGetImageList function.
            int iImageList;

            switch (shellIconSize)
            {
                case ShellIconSize.SystemSmall:
                    iImageList = Win32.SHIL_SYSSMALL;
                    break;

                case ShellIconSize.ExtraLarge:
                    iImageList = Win32.SHIL_EXTRALARGE;
                    break;

                case ShellIconSize.Jumbo:
                    iImageList = Win32.SHIL_JUMBO;
                    break;

                default:
                    throw new InvalidOperationException(string.Format("The ShellIconSize.{0} is unknown.", shellIconSize));
            }


            // Gets a image list.
            Guid IID_IImageList = Win32.IID_IImageList;
            IntPtr hImageList = IntPtr.Zero;
            Marshal.ThrowExceptionForHR(Win32.SHGetImageList(iImageList, ref IID_IImageList, ref hImageList));


            // Gets an icon handle from the image list.
            IntPtr hIcon = Win32.ImageList_GetIcon(hImageList, shFileInfo.iIcon, Win32.ILD_TRANSPARENT);
            if (hIcon == IntPtr.Zero)
                throw new Exception("ImageList_GetIcon function has failed.");


            // TODO: Show overlay on the image list icon.


            try
            {
                // Returns the ImageSource.
                return ToImageSource(hIcon);
            }
            finally
            {
                // Releases the icon handle.
                if (Win32.DestroyIcon(hIcon) == 0)
                    throw new Win32Exception(Marshal.GetLastWin32Error());
            }
        }


        /// <summary>
        /// Returns the shell display name of the specified path.
        /// If the path is nonexistent or it is failed, the file name returned by the Path.GetFileName method is returned.
        /// </summary>
        /// <param name="path">The path to evaluate. Null is not allowed.</param>
        /// <returns>The shell display name if it succeeds; otherwise, the file name returned by the Path.GetFileName method.</returns>
        public static string GetDisplayName(string path)
        {
            Verifying.ParameterIsNotNull(path, "path");

            // Calls the SHGetFileInfo function.
            Win32.SHFILEINFO shFileInfo = new Win32.SHFILEINFO();
            if (Win32.SHGetFileInfo(path, 0, ref shFileInfo, (uint)Win32.SizeOfSHFILEINFO, Win32.SHGFI_DISPLAYNAME) == IntPtr.Zero)
                return Path.GetFileName(path);

            // Returns the shell display name.
            return shFileInfo.szDisplayName;
        }

        #endregion
    }
}
