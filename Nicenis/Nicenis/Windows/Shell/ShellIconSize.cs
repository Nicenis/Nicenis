/*
 * Author   JO Hyeong-Ryeol
 * Since    2012.10.14
 * 
 * This file is a part of the Nicenis project.
 * https://nicenis.codeplex.com
 * 
 * Copyright (C) 2012 JO Hyeong-Ryeol. All rights reserved.
 */

namespace Nicenis.Windows.Shell
{
    /// <summary>
    /// Denotes icon size in the Windows Shell.
    /// </summary>
    /// <remarks>
    /// Icon size descriptions are copied from the SHGetFileInfo function page in the MSDN.
    /// </remarks>
    public enum ShellIconSize
    {
        /// <summary>
        /// Shell-sized icon
        /// </summary>
        ShellSized,

        /// <summary>
        /// These images are the size specified by GetSystemMetrics called with SM_CXSMICON and GetSystemMetrics called with SM_CYSMICON.
        /// </summary>
        SystemSmall,

        /// <summary>
        /// These images are the Shell standard small icon size of 16x16, but the size can be customized by the user.
        /// </summary>
        Small,

        /// <summary>
        /// The image size is normally 32x32 pixels. However, if the Use large icons option is selected from the Effects section of the Appearance tab in Display Properties, the image is 48x48 pixels.
        /// </summary>
        Large,

        /// <summary>
        /// These images are the Shell standard extra-large icon size. This is typically 48x48, but the size can be customized by the user.
        /// </summary>
        ExtraLarge,

        /// <summary>
        /// Windows Vista and later. The image is normally 256x256 pixels.
        /// </summary>
        Jumbo,
    }
}
