/*
 * Author	JO Hyeong-Ryeol
 * Since	2013.06.29
 * Version	$Id$
 * 
 * Copyright (C) 2013 JO Hyeong-Ryeol. All rights reserved.
 */

namespace Nicenis.Windows
{
    /// <summary>
    /// Provides a way to get a data object that contains the data being dragged.
    /// </summary>
    public interface IDataObjectProvider
    {
        /// <summary>
        /// Gets a data object that contains the data being dragged.
        /// </summary>
        /// <returns>A data object that contains the data being dragged.</returns>
        object GetDataObject();
    }
}
