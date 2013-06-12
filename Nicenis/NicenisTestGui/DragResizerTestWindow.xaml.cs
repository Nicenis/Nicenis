/*
 * Author	JO Hyeong-Ryeol
 * Since	2013.06.11
 * Version	$Id$
 * 
 * Copyright (C) 2013 JO Hyeong-Ryeol. All rights reserved.
 */

using System.Windows;

namespace NicenisTestGui
{
    /// <summary>
    /// The window to test the DragResizer.
    /// </summary>
    public partial class DragResizerTestWindow : Window
    {
        public DragResizerTestWindow()
        {
            InitializeComponent();
        }

        private void DragResizer_Resizing(object sender, Nicenis.Windows.DragResizerResizingEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("DragResizer_Resizing");
        }

        private void DragResizer_PreviewResizing(object sender, Nicenis.Windows.DragResizerResizingEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("DragResizer_PreviewResizing");
            //e.DragDelta = e.DragDelta + new Vector(100, 100);
        }

        private void DragResizer_Resized(object sender, Nicenis.Windows.DragResizerResizedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("DragResizer_Resized");
        }

        private void DragResizer_PreviewResized(object sender, Nicenis.Windows.DragResizerResizedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("DragResizer_PreviewResized");
        }
    }
}
