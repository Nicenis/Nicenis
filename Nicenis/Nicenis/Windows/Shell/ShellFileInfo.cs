/*
 * Author	JO Hyeong-Ryeol
 * Since	2012.10.14
 * Version	$Id: ShellFileInfo.cs 24043 2013-05-21 14:49:03Z unknown $
 * 
 * Copyright (C) 2012 JO Hyeong-Ryeol. All rights reserved.
 */

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
    /// 쉘의 파일 관련 정보
    /// </summary>
    public static class ShellFileInfo
    {
        #region Helpers

        /// <summary>
        /// 아이콘 핸들을 Freeze 된 ImageSource 로 변환하여 반환한다.
        /// </summary>
        /// <param name="hIcon">아이콘 핸들</param>
        /// <returns>Freeze 된 변환된 ImageSource</returns>
        private static ImageSource ToImageSource(IntPtr hIcon)
        {
            ImageSource imageSource = Imaging.CreateBitmapSourceFromHIcon(hIcon, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            imageSource.Freeze();

            return imageSource;
        }

        #endregion


        #region Methods

        /// <summary>
        /// path 로 지정된 경로의 Freeze 된 쉘 아이콘을 반환한다.
        /// </summary>
        /// <param name="path">파일/폴더 절대/상태 경로. 파일/폴더가 존재하지 않아도 된다.</param>
        /// <param name="shellIconSize">아이콘 크기</param>
        /// <param name="includeOverlay">오버레이를 포함할 지 여부. ShellIconSize.ShellSized, ShellIconSize.Small, ShellIconSize.Large 이외에는 무시된다.</param>
        /// <param name="includeLinkOverlay">링크 오버레이를 포함할 지 여부. ShellIconSize.ShellSized, ShellIconSize.Small, ShellIconSize.Large 이외에는 무시된다.</param>
        /// <param name="isOpen">열려 있는 아이콘을 가져올 지 여부</param>
        /// <param name="isSelected">선택 효과를 추가할 지 여부</param>
        /// <returns>Freeze 된 파일의 쉘 아이콘</returns>
        public static ImageSource GetIcon(string path, ShellIconSize shellIconSize, bool includeOverlay = false, bool includeLinkOverlay = false, bool isOpen = false, bool isSelected = false)
        {
            if (path == null)
                throw new ArgumentNullException("path");


            // SHGetFileInfo 에 사용할 uFlags 만들기
            uint uFlags = Win32.SHGFI_ICON | Win32.SHGFI_USEFILEATTRIBUTES;

            if (includeOverlay)
                uFlags |= Win32.SHGFI_ADDOVERLAYS;

            if (includeLinkOverlay)
                uFlags |= Win32.SHGFI_LINKOVERLAY;

            if (isOpen)
                uFlags |= Win32.SHGFI_OPENICON;

            if (isSelected)
                uFlags |= Win32.SHGFI_SELECTED;


            // shFileInfo 구조체의 hIcon 핸들에서 아이콘을 구할 수 있는지 여부
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


            // SHGetFileInfo 에 사용할 dwFileAttributes 만들기
            uint dwFileAttributes = Win32.FILE_ATTRIBUTE_NORMAL;
            if (Directory.Exists(path))
                dwFileAttributes |= Win32.FILE_ATTRIBUTE_DIRECTORY;


            // SHGetFileInfo 호출하기
            Win32.SHFILEINFO shFileInfo = new Win32.SHFILEINFO();
            if (Win32.SHGetFileInfo(path, dwFileAttributes, ref shFileInfo, (uint)Win32.SizeOfSHFILEINFO, uFlags) == IntPtr.Zero)
                throw new Exception("SHGetFileInfo function has failed.");


            try
            {
                // shFileInfo 에 있는 아이콘 핸들로도 충분하다면
                if (isShFileInfoEnough)
                    return ToImageSource(shFileInfo.hIcon);
            }
            finally
            {
                // 아이콘 핸들 해제하기
                if (shFileInfo.hIcon != IntPtr.Zero)
                {
                    if (Win32.DestroyIcon(shFileInfo.hIcon) == 0)
                        throw new Win32Exception(Marshal.GetLastWin32Error());

                    shFileInfo.hIcon = IntPtr.Zero;
                }
            }


            // SHGetImageList 에 사용할 iImageList
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


            // 이미지 리스트 구하기
            Guid IID_IImageList = Win32.IID_IImageList;
            IntPtr hImageList = IntPtr.Zero;
            Marshal.ThrowExceptionForHR(Win32.SHGetImageList(iImageList, ref IID_IImageList, ref hImageList));
            
            
            // 이미지 리스트에서 아이콘 핸들 구하기
            IntPtr hIcon = Win32.ImageList_GetIcon(hImageList, shFileInfo.iIcon, Win32.ILD_TRANSPARENT);
            if (hIcon == IntPtr.Zero)
                throw new Exception("ImageList_GetIcon function has failed.");


            // TODO: 이미지 리스트 아이콘에 오버레이 표시하는 방법 연구하기

            
            try
            {
                // ImageSource 반환하기
                return ToImageSource(hIcon);
            }
            finally
            {
                // 아이콘 핸들 해제하기
                if (Win32.DestroyIcon(hIcon) == 0)
                    throw new Win32Exception(Marshal.GetLastWin32Error());
            }
        }


        /// <summary>
        /// path 로 지정된 경로의 쉘 표시 이름을 반환한다.
        /// 경로에 파일/폴더 등이 존재하지 않거나 표시 이름을 구할 수 없는 경우에는 파일 이름을 반환한다.
        /// </summary>
        /// <param name="path">경로</param>
        /// <returns>표시 이름</returns>
        public static string GetDisplayName(string path)
        {
            if (path == null)
                throw new ArgumentNullException("path");


            // SHGetFileInfo 호출하기
            Win32.SHFILEINFO shFileInfo = new Win32.SHFILEINFO();
            if (Win32.SHGetFileInfo(path, 0, ref shFileInfo, (uint)Win32.SizeOfSHFILEINFO, Win32.SHGFI_DISPLAYNAME) == IntPtr.Zero)
                return Path.GetFileName(path);

            
            // 표시 이름 반환
            return shFileInfo.szDisplayName;
        }

        #endregion
    }
}
