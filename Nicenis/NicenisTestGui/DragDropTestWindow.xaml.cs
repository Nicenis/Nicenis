/*
 * Author	JO Hyeong-Ryeol
 * Since	2013.03.31
 * Version	$Id$
 * 
 * Copyright (C) 2013 JO Hyeong-Ryeol. All rights reserved.
 */

using Nicenis.Windows;
using System.Diagnostics;
using System.Windows;

namespace NicenisTestGui
{
    /// <summary>
    /// The window to test Drag and Drop.
    /// </summary>
    public partial class DragDropTestWindow : Window
    {
        public DragDropTestWindow()
        {
            InitializeComponent();
        }

        private void Border_PreviewDragSensing(object sender, DragSourceDragSensingEventArgs e)
        {
            //Debug.WriteLine("Border_PreviewDragSensing: " + e.ContactPoint + " " + e.Initiator);
        }

        private void Border_DragSensing(object sender, DragSourceDragSensingEventArgs e)
        {
            //Debug.WriteLine("Border_DragSensing: " + e.ContactPoint + " " + e.Initiator);
        }

        private void Border_PreviewDragging(object sender, DragSourceDraggingEventArgs e)
        {
            //Debug.WriteLine("Border_PreviewDragging: " + e.ContactPoint + " " + e.Initiator);
        }

        private void Border_Dragging(object sender, DragSourceDraggingEventArgs e)
        {
            //Debug.WriteLine("Border_Dragging: " + e.ContactPoint + " " + e.Initiator);
        }

        private void Border_PreviewGiveFeedback(object sender, DragSourceGiveFeedbackEventArgs e)
        {
            //Debug.WriteLine("Border_PreviewGiveFeedback: " + e.UseDefaultCursors);
        }

        private void Border_GiveFeedback(object sender, DragSourceGiveFeedbackEventArgs e)
        {
            //Debug.WriteLine("Border_GiveFeedback: " + e.UseDefaultCursors);
        }

        private void Border_PreviewQueryContinueDrag(object sender, DragSourceQueryContinueDragEventArgs e)
        {
            //Debug.WriteLine("Border_PreviewQueryContinueDrag: " + e.Action);
        }

        private void Border_QueryContinueDrag(object sender, DragSourceQueryContinueDragEventArgs e)
        {
            //Debug.WriteLine("Border_QueryContinueDrag: " + e.Action);
        }

        private void Border_PreviewDropped(object sender, DragSourceDroppedEventArgs e)
        {
            //Debug.WriteLine("Border_PreviewDropped: " + e.FinalEffects);
        }

        private void Border_Dropped(object sender, DragSourceDroppedEventArgs e)
        {
            //Debug.WriteLine("Border_Dropped: " + e.FinalEffects);
        }

        private void Grid_PreviewDragSensing(object sender, DragSourceDragSensingEventArgs e)
        {
            //Debug.WriteLine("Grid_PreviewDragSensing: " + e.ContactPoint + " " + e.Initiator);
        }

        private void Grid_DragSensing(object sender, DragSourceDragSensingEventArgs e)
        {
            //Debug.WriteLine("Grid_DragSensing: " + e.ContactPoint + " " + e.Initiator);
        }

        private void Grid_PreviewDragging(object sender, DragSourceDraggingEventArgs e)
        {
            //Debug.WriteLine("Grid_PreviewDragging: " + e.ContactPoint + " " + e.Initiator);
        }

        private void Grid_Dragging(object sender, DragSourceDraggingEventArgs e)
        {
            //Debug.WriteLine("Grid_Dragging: " + e.ContactPoint + " " + e.Initiator + " " + e.DraggedPoint);
        }

        private void Grid_PreviewGiveFeedback(object sender, DragSourceGiveFeedbackEventArgs e)
        {
            //Debug.WriteLine("Grid_PreviewGiveFeedback: " + e.UseDefaultCursors);
        }

        private void Grid_GiveFeedback(object sender, DragSourceGiveFeedbackEventArgs e)
        {
            //Debug.WriteLine("Grid_GiveFeedback: " + e.UseDefaultCursors);
        }

        private void Grid_PreviewQueryContinueDrag(object sender, DragSourceQueryContinueDragEventArgs e)
        {
            //Debug.WriteLine("Grid_PreviewQueryContinueDrag: " + e.Action);
        }

        private void Grid_QueryContinueDrag(object sender, DragSourceQueryContinueDragEventArgs e)
        {
            //Debug.WriteLine("Grid_QueryContinueDrag: " + e.Action);
        }

        private void Grid_PreviewDropped(object sender, DragSourceDroppedEventArgs e)
        {
            //Debug.WriteLine("Grid_PreviewDropped: " + e.FinalEffects);
        }

        private void Grid_Dropped(object sender, DragSourceDroppedEventArgs e)
        {
            //Debug.WriteLine("Grid_Dropped: " + e.FinalEffects);
        }

        private void theBorder_PreviewDragHover(object sender, HoverEventArgs e)
        {
            Debug.WriteLine("theBorder_PreviewDragHover: " + e.BasePosition + " " + e.BaseTicks + " " + e.HoveredPosition + " " + e.HoveredTicks);
        }

        private void theBorder_DragHover(object sender, HoverEventArgs e)
        {
            Debug.WriteLine("theBorder_DragHover: " + e.OriginalSource.ToString());
        }
    }
}
