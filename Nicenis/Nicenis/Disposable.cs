/*
 * Author   JO Hyeong-Ryeol
 * Since    2012.12.25
 * 
 * This file is a part of the Nicenis project.
 * https://nicenis.codeplex.com
 * 
 * Copyright (C) 2012 JO Hyeong-Ryeol. All rights reserved.
 */

using System;

namespace Nicenis
{
    /// <summary>
    /// Provides base implementation of the IDisposable interface.
    /// </summary>
    public class Disposable : IDisposable
    {
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// Derived classes should override this method.
        /// If this method is called, it is not called again.
        /// </summary>
        /// <param name="disposing">If this method is called by a user's code.</param>
        protected virtual void DisposeOverride(bool disposing) { }


        #region Properties & Methods

        /// <summary>
        /// Returns true if it is already disposed.
        /// </summary>
        public bool IsDisposed { get; private set; }


        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <param name="disposing">If this method is called by a user's code.</param>
        private void Dispose(bool disposing)
        {
            // If it is already disposed...
            if (IsDisposed)
                return;

            IsDisposed = true;

            // Cleans up resources.
            DisposeOverride(disposing);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion


        #region Destructors

        /// <summary>
        /// The standard dispose destructor.
        /// </summary>
        ~Disposable()
        {
            Dispose(false);
        }

        #endregion
    }
}
