/*
 * Author	JO Hyeong-Ryeol
 * Since	2013.03.27
 * Version	$Id$
 * 
 * This file is a part of the Nicenis project.
 * https://nicenis.codeplex.com
 * 
 * Copyright (C) 2013 JO Hyeong-Ryeol. All rights reserved.
 */

using Nicenis.Interop;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Nicenis.Windows
{
    #region DragSource Event Arguments Related

    /// <summary>
    /// Internal Use Only.
    /// The base class for DragSource related event argument classes.
    /// </summary>
    public abstract class DragSourceEventArgsBase : RoutedEventArgs
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the DragResizerEventArgsBase class.
        /// </summary>
        /// <param name="routedEvent">The routed event identifier for this instance of the RoutedEventArgs class.</param>
        /// <param name="source">An alternate source that will be reported when the event is handled. This pre-populates the Source property.</param>
        /// <param name="initiator">The drag initiator.</param>
        /// <param name="contactPosition">The contact position in the dragged source.</param>
        /// <param name="draggedPosition">The dragged position in the dragged source.</param>
        internal DragSourceEventArgsBase(RoutedEvent routedEvent, object source, DragInitiator initiator, Point contactPosition, Point draggedPosition)
            : base(routedEvent, source)
        {
            Initiator = initiator;
            ContactPosition = contactPosition;
            DraggedPosition = draggedPosition;
        }

        #endregion


        #region Properties

        /// <summary>
        /// Gets a value that initiates the dragging.
        /// </summary>
        public DragInitiator Initiator { get; private set; }

        /// <summary>
        /// Gets the contact position in the dragged source.
        /// </summary>
        /// <remarks>
        /// This value indicates the coordiate of the click or any other contact in the dragged source.
        /// It is in the dragged source cooridates.
        /// </remarks>
        public Point ContactPosition { get; private set; }

        /// <summary>
        /// Gets the dragged position in the dragged source.
        /// </summary>
        /// <remarks>
        /// This value indicates the coordiate that the dragging is started.
        /// MinimumHorizontalDragDistance and MinimumVerticalDragDistance are used to calculate this value.
        /// It is in the dragged source cooridates.
        /// </remarks>
        /// <seealso cref="DragSource.MinimumHorizontalDragDistanceProperty"/>
        /// <seealso cref="DragSource.MinimumVerticalDragDistanceProperty"/>
        public Point DraggedPosition { get; private set; }

        #endregion
    }


    /// <summary>
    /// Contains arguments for the DragSensing event.
    /// </summary>
    public class DragSourceDragSensingEventArgs : DragSourceEventArgsBase
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the DragSourceDragSensingEventArgs class.
        /// </summary>
        /// <param name="routedEvent">The routed event identifier for this instance of the RoutedEventArgs class.</param>
        /// <param name="source">An alternate source that will be reported when the event is handled. This pre-populates the Source property.</param>
        /// <param name="initiator">The drag initiator.</param>
        /// <param name="contactPosition">The contact position in the dragged source.</param>
        /// <param name="draggedPosition">The dragged position in the dragged source.</param>
        internal DragSourceDragSensingEventArgs(RoutedEvent routedEvent, object source, DragInitiator initiator, Point contactPosition, Point draggedPosition)
            : base(routedEvent, source, initiator, contactPosition, draggedPosition)
        {
        }

        #endregion


        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether the drag should be canceled.
        /// </summary>
        public bool Cancel { get; set; }

        #endregion
    }


    /// <summary>
    /// Defines required infomation for the Dragging event.
    /// </summary>
    internal interface IDragSourceDraggingEventArgsContext
    {
        DragDropEffects AllowedEffects { get; set; }
        object Data { get; set; }
        bool IsAutoVisualFeedbackAllowed { get; set; }
        object VisualFeedback { get; set; }
        DataTemplate VisualFeedbackTemplate { get; set; }
        DataTemplateSelector VisualFeedbackTemplateSelector { get; set; }
        object VisualFeedbackDataContext { get; set; }
        Point VisualFeedbackOffset { get; set; }
        double VisualFeedbackOpacity { get; set; }
        Visibility VisualFeedbackVisibility { get; set; }
        double VisualFeedbackWidth { get; set; }
        double VisualFeedbackHeight { get; set; }
        double VisualFeedbackMinWidth { get; set; }
        double VisualFeedbackMinHeight { get; set; }
        double VisualFeedbackMaxWidth { get; set; }
        double VisualFeedbackMaxHeight { get; set; }
    }

    /// <summary>
    /// Contains arguments for the Dragging event.
    /// </summary>
    public class DragSourceDraggingEventArgs : DragSourceEventArgsBase
    {
        IDragSourceDraggingEventArgsContext _context;


        #region Constructors

        /// <summary>
        /// Initializes a new instance of the DragSourceDraggingEventArgs class.
        /// </summary>
        /// <param name="routedEvent">The routed event identifier for this instance of the RoutedEventArgs class.</param>
        /// <param name="source">An alternate source that will be reported when the event is handled. This pre-populates the Source property.</param>
        /// <param name="initiator">The drag initiator.</param>
        /// <param name="contactPosition">The contact position in the dragged source.</param>
        /// <param name="draggedPosition">The dragged position in the dragged source.</param>
        /// <param name="context">The context that contains required information for the Dragging event. Null is not allowed.</param>
        internal DragSourceDraggingEventArgs(RoutedEvent routedEvent, object source, DragInitiator initiator, Point contactPosition, Point draggedPosition, IDragSourceDraggingEventArgsContext context)
            : base(routedEvent, source, initiator, contactPosition, draggedPosition)
        {
            Debug.Assert(context != null);
            _context = context;
        }

        #endregion


        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether the drag should be canceled.
        /// </summary>
        public bool Cancel { get; set; }

        /// <summary>
        /// Gets or sets a value indicating permitted effects of the drag-and-drop operation.
        /// </summary>
        public DragDropEffects AllowedEffects
        {
            get { return _context.AllowedEffects; }
            set { _context.AllowedEffects = value; }
        }

        /// <summary>
        /// Gets or sets a data object that contains the data being dragged.
        /// If IDataObjectProvider is implemented by the set value, it is used right before DragDrop.DoDragDrop call.
        /// </summary>
        public object Data
        {
            get { return _context.Data; }
            set { _context.Data = value; }
        }

        /// <summary>
        /// Gets or sets a value that indicates whether the auto generated visual feedback is allowed or not.
        /// </summary>
        public bool IsAutoVisualFeedbackAllowed
        {
            get { return _context.IsAutoVisualFeedbackAllowed; }
            set { _context.IsAutoVisualFeedbackAllowed = value; }
        }

        /// <summary>
        /// Gets or sets an object that is set to the content of the visual drag feedback.
        /// If this value is not null, the auto generated visual drag feedback is not displayed.
        /// </summary>
        public object VisualFeedback
        {
            get { return _context.VisualFeedback; }
            set { _context.VisualFeedback = value; }
        }

        /// <summary>
        /// Gets or sets a data template used to display the content of the visual drag feedback.
        /// If this value is not null, the auto generated visual drag feedback is not displayed.
        /// </summary>
        public DataTemplate VisualFeedbackTemplate
        {
            get { return _context.VisualFeedbackTemplate; }
            set { _context.VisualFeedbackTemplate = value; }
        }

        /// <summary>
        /// Gets or sets a template selector that enables an application writer to provide custom template-selection logic for visual drag feedback.
        /// If this value is not null, the auto generated visual drag feedback is not displayed.
        /// </summary>
        public DataTemplateSelector VisualFeedbackTemplateSelector
        {
            get { return _context.VisualFeedbackTemplateSelector; }
            set { _context.VisualFeedbackTemplateSelector = value; }
        }

        /// <summary>
        /// Gets or sets an object that is set to the data context of the visual drag feedback.
        /// If this value is null, the drag source's data context is set.
        /// </summary>
        public object VisualFeedbackDataContext
        {
            get { return _context.VisualFeedbackDataContext; }
            set { _context.VisualFeedbackDataContext = value; }
        }

        /// <summary>
        /// Gets or sets an offset that is pointed by a pointing device in the visual drag feedback.
        /// The origin is the upper-left corner of the visual drag feedback.
        /// The x-coordinates increase to the right. The y-coordinates increase to the bottom.
        /// </summary>
        public Point VisualFeedbackOffset
        {
            get { return _context.VisualFeedbackOffset; }
            set { _context.VisualFeedbackOffset = value; }
        }

        /// <summary>
        /// Gets or sets the opacity of the visual drag feedback.
        /// </summary>
        public double VisualFeedbackOpacity
        {
            get { return _context.VisualFeedbackOpacity; }
            set { _context.VisualFeedbackOpacity = value; }
        }

        /// <summary>
        /// Gets or sets the visual drag feedback visibility.
        /// </summary>
        public Visibility VisualFeedbackVisibility
        {
            get { return _context.VisualFeedbackVisibility; }
            set { _context.VisualFeedbackVisibility = value; }
        }

        /// <summary>
        /// Gets or sets the width of the visual drag feedback.
        /// </summary>
        public double VisualFeedbackWidth
        {
            get { return _context.VisualFeedbackWidth; }
            set { _context.VisualFeedbackWidth = value; }
        }

        /// <summary>
        /// Gets or sets the height of the visual drag feedback.
        /// </summary>
        public double VisualFeedbackHeight
        {
            get { return _context.VisualFeedbackHeight; }
            set { _context.VisualFeedbackHeight = value; }
        }

        /// <summary>
        /// Gets or sets the minimum width of the visual drag feedback.
        /// </summary>
        public double VisualFeedbackMinWidth
        {
            get { return _context.VisualFeedbackMinWidth; }
            set { _context.VisualFeedbackMinWidth = value; }
        }

        /// <summary>
        /// Gets or sets the minimum height of the visual drag feedback.
        /// </summary>
        public double VisualFeedbackMinHeight
        {
            get { return _context.VisualFeedbackMinHeight; }
            set { _context.VisualFeedbackMinHeight = value; }
        }

        /// <summary>
        /// Gets or sets the maximum width of the visual drag feedback.
        /// </summary>
        public double VisualFeedbackMaxWidth
        {
            get { return _context.VisualFeedbackMaxWidth; }
            set { _context.VisualFeedbackMaxWidth = value; }
        }

        /// <summary>
        /// Gets or sets the maximum height of the visual drag feedback.
        /// </summary>
        public double VisualFeedbackMaxHeight
        {
            get { return _context.VisualFeedbackMaxHeight; }
            set { _context.VisualFeedbackMaxHeight = value; }
        }

        #endregion
    }


    /// <summary>
    /// Defines required infomation for the GiveFeedback event.
    /// </summary>
    internal interface IDragSourceGiveFeedbackEventArgsContext
    {
        DragDropEffects AllowedEffects { get; }
        object Data { get; }
        bool IsAutoVisualFeedbackAllowed { get; set; }
        object VisualFeedback { get; set; }
        DataTemplate VisualFeedbackTemplate { get; set; }
        DataTemplateSelector VisualFeedbackTemplateSelector { get; set; }
        object VisualFeedbackDataContext { get; set; }
        Point VisualFeedbackOffset { get; set; }
        double VisualFeedbackOpacity { get; set; }
        Visibility VisualFeedbackVisibility { get; set; }
        double VisualFeedbackWidth { get; set; }
        double VisualFeedbackHeight { get; set; }
        double VisualFeedbackMinWidth { get; set; }
        double VisualFeedbackMinHeight { get; set; }
        double VisualFeedbackMaxWidth { get; set; }
        double VisualFeedbackMaxHeight { get; set; }
        void UpdateVisualFeedbackHost();
    }

    /// <summary>
    /// Contains arguments for the GiveFeedback event.
    /// </summary>
    public class DragSourceGiveFeedbackEventArgs : DragSourceEventArgsBase
    {
        IDragSourceGiveFeedbackEventArgsContext _context;
        GiveFeedbackEventArgs _giveFeedbackEventArgs;


        #region Constructors

        /// <summary>
        /// Initializes a new instance of the DragSourceGiveFeedbackEventArgs class.
        /// </summary>
        /// <param name="routedEvent">The routed event identifier for this instance of the RoutedEventArgs class.</param>
        /// <param name="source">An alternate source that will be reported when the event is handled. This pre-populates the Source property.</param>
        /// <param name="initiator">The drag initiator.</param>
        /// <param name="contactPosition">The contact position in the dragged source.</param>
        /// <param name="draggedPosition">The dragged position in the dragged source.</param>
        /// <param name="context">The context that contains required information for the GiveFeedback event. Null is not allowed.</param>
        /// <param name="giveFeedbackEventArgs">The GiveFeedbackEventArgs.</param>
        internal DragSourceGiveFeedbackEventArgs(RoutedEvent routedEvent, object source, DragInitiator initiator, Point contactPosition, Point draggedPosition,
                    IDragSourceGiveFeedbackEventArgsContext context, GiveFeedbackEventArgs giveFeedbackEventArgs)
            : base(routedEvent, source, initiator, contactPosition, draggedPosition)
        {
            Debug.Assert(context != null);
            Debug.Assert(giveFeedbackEventArgs != null);

            _context = context;
            _giveFeedbackEventArgs = giveFeedbackEventArgs;
        }

        #endregion


        #region Properties

        /// <summary>
        /// Gets a value indicating permitted effects of the drag-and-drop operation.
        /// </summary>
        public DragDropEffects AllowedEffects { get { return _context.AllowedEffects; } }

        /// <summary>
        /// Gets a data object that contains the data being dragged.
        /// This value is always not null.
        /// </summary>
        public object Data { get { return _context.Data; } }

        /// <summary>
        /// Gets a value that indicates the effects of drag-and-drop operation.
        /// </summary>
        public DragDropEffects Effects { get { return _giveFeedbackEventArgs.Effects; } }

        /// <summary>
        /// Gets or sets a Boolean value indicating whether default cursor feedback behavior should be used for the associated drag-and-drop operation.
        /// </summary>
        public bool UseDefaultCursors
        {
            get { return _giveFeedbackEventArgs.UseDefaultCursors; }
            set { _giveFeedbackEventArgs.UseDefaultCursors = value; }
        }

        /// <summary>
        /// Gets or sets a value that indicates whether the auto generated visual feedback is allowed or not.
        /// </summary>
        public bool IsAutoVisualFeedbackAllowed
        {
            get { return _context.IsAutoVisualFeedbackAllowed; }
            set { _context.IsAutoVisualFeedbackAllowed = value; }
        }

        /// <summary>
        /// Gets or sets an object that is set to the content of the visual drag feedback.
        /// If this value is not null, the auto generated visual drag feedback is not displayed.
        /// </summary>
        public object VisualFeedback
        {
            get { return _context.VisualFeedback; }
            set { _context.VisualFeedback = value; }
        }

        /// <summary>
        /// Gets or sets a data template used to display the content of the visual drag feedback.
        /// If this value is not null, the auto generated visual drag feedback is not displayed.
        /// </summary>
        public DataTemplate VisualFeedbackTemplate
        {
            get { return _context.VisualFeedbackTemplate; }
            set { _context.VisualFeedbackTemplate = value; }
        }

        /// <summary>
        /// Gets or sets a template selector that enables an application writer to provide custom template-selection logic for visual drag feedback.
        /// If this value is not null, the auto generated visual drag feedback is not displayed.
        /// </summary>
        public DataTemplateSelector VisualFeedbackTemplateSelector
        {
            get { return _context.VisualFeedbackTemplateSelector; }
            set { _context.VisualFeedbackTemplateSelector = value; }
        }

        /// <summary>
        /// Gets or sets an object that is set to the data context of the visual drag feedback.
        /// If this value is null, the drag source's data context is set.
        /// </summary>
        public object VisualFeedbackDataContext
        {
            get { return _context.VisualFeedbackDataContext; }
            set { _context.VisualFeedbackDataContext = value; }
        }

        /// <summary>
        /// Gets or sets an offset that is pointed by a pointing device in the visual drag feedback.
        /// The origin is the upper-left corner of the visual drag feedback.
        /// The x-coordinates increase to the right. The y-coordinates increase to the bottom.
        /// </summary>
        public Point VisualFeedbackOffset
        {
            get { return _context.VisualFeedbackOffset; }
            set { _context.VisualFeedbackOffset = value; }
        }

        /// <summary>
        /// Gets or sets the opacity of the visual drag feedback.
        /// </summary>
        public double VisualFeedbackOpacity
        {
            get { return _context.VisualFeedbackOpacity; }
            set { _context.VisualFeedbackOpacity = value; }
        }

        /// <summary>
        /// Gets or sets the visual drag feedback visibility.
        /// </summary>
        public Visibility VisualFeedbackVisibility
        {
            get { return _context.VisualFeedbackVisibility; }
            set { _context.VisualFeedbackVisibility = value; }
        }

        /// <summary>
        /// Gets or sets the width of the visual drag feedback.
        /// </summary>
        public double VisualFeedbackWidth
        {
            get { return _context.VisualFeedbackWidth; }
            set { _context.VisualFeedbackWidth = value; }
        }

        /// <summary>
        /// Gets or sets the height of the visual drag feedback.
        /// </summary>
        public double VisualFeedbackHeight
        {
            get { return _context.VisualFeedbackHeight; }
            set { _context.VisualFeedbackHeight = value; }
        }

        /// <summary>
        /// Gets or sets the minimum width of the visual drag feedback.
        /// </summary>
        public double VisualFeedbackMinWidth
        {
            get { return _context.VisualFeedbackMinWidth; }
            set { _context.VisualFeedbackMinWidth = value; }
        }

        /// <summary>
        /// Gets or sets the minimum height of the visual drag feedback.
        /// </summary>
        public double VisualFeedbackMinHeight
        {
            get { return _context.VisualFeedbackMinHeight; }
            set { _context.VisualFeedbackMinHeight = value; }
        }

        /// <summary>
        /// Gets or sets the maximum width of the visual drag feedback.
        /// </summary>
        public double VisualFeedbackMaxWidth
        {
            get { return _context.VisualFeedbackMaxWidth; }
            set { _context.VisualFeedbackMaxWidth = value; }
        }

        /// <summary>
        /// Gets or sets the maximum height of the visual drag feedback.
        /// </summary>
        public double VisualFeedbackMaxHeight
        {
            get { return _context.VisualFeedbackMaxHeight; }
            set { _context.VisualFeedbackMaxHeight = value; }
        }

        #endregion
    }


    /// <summary>
    /// Defines required infomation for the QueryContinueDrag event.
    /// </summary>
    internal interface IDragSourceQueryContinueDragEventArgsContext
    {
        DragDropEffects AllowedEffects { get; }
        object Data { get; }
        bool IsAutoVisualFeedbackAllowed { get; set; }
        object VisualFeedback { get; set; }
        DataTemplate VisualFeedbackTemplate { get; set; }
        DataTemplateSelector VisualFeedbackTemplateSelector { get; set; }
        object VisualFeedbackDataContext { get; set; }
        Point VisualFeedbackOffset { get; set; }
        double VisualFeedbackOpacity { get; set; }
        Visibility VisualFeedbackVisibility { get; set; }
        double VisualFeedbackWidth { get; set; }
        double VisualFeedbackHeight { get; set; }
        double VisualFeedbackMinWidth { get; set; }
        double VisualFeedbackMinHeight { get; set; }
        double VisualFeedbackMaxWidth { get; set; }
        double VisualFeedbackMaxHeight { get; set; }
    }

    /// <summary>
    /// Contains arguments for the QueryContinueDrag event.
    /// </summary>
    public class DragSourceQueryContinueDragEventArgs : DragSourceEventArgsBase
    {
        IDragSourceQueryContinueDragEventArgsContext _context;
        QueryContinueDragEventArgs _queryContinueDragEventArgs;


        #region Constructors

        /// <summary>
        /// Initializes a new instance of the DragSourceQueryContinueDragEventArgs class.
        /// </summary>
        /// <param name="routedEvent">The routed event identifier for this instance of the RoutedEventArgs class.</param>
        /// <param name="source">An alternate source that will be reported when the event is handled. This pre-populates the Source property.</param>
        /// <param name="initiator">The drag initiator.</param>
        /// <param name="contactPosition">The contact position in the dragged source.</param>
        /// <param name="draggedPosition">The dragged position in the dragged source.</param>
        /// <param name="context">The context that contains required information for the QueryContinueDrag event. Null is not allowed.</param>
        /// <param name="queryContinueDragEventArgs">The QueryContinueDragEventArgs.</param>
        internal DragSourceQueryContinueDragEventArgs(RoutedEvent routedEvent, object source, DragInitiator initiator, Point contactPosition, Point draggedPosition,
                    IDragSourceQueryContinueDragEventArgsContext context, QueryContinueDragEventArgs queryContinueDragEventArgs)
            : base(routedEvent, source, initiator, contactPosition, draggedPosition)
        {
            Debug.Assert(context != null);
            Debug.Assert(queryContinueDragEventArgs != null);

            _context = context;
            _queryContinueDragEventArgs = queryContinueDragEventArgs;
        }

        #endregion


        #region Properties

        /// <summary>
        /// Gets a value indicating permitted effects of the drag-and-drop operation.
        /// </summary>
        public DragDropEffects AllowedEffects { get { return _context.AllowedEffects; } }

        /// <summary>
        /// Gets a data object that contains the data being dragged.
        /// This value is always not null.
        /// </summary>
        public object Data { get { return _context.Data; } }

        /// <summary>
        /// Gets or sets the current status of the associated drag-and-drop operation.
        /// </summary>
        public DragAction Action
        {
            get { return _queryContinueDragEventArgs.Action; }
            set { _queryContinueDragEventArgs.Action = value; }
        }

        /// <summary>
        /// Gets a Boolean value indicating whether the ESC key has been pressed.
        /// </summary>
        public bool EscapePressed { get { return _queryContinueDragEventArgs.EscapePressed; } }

        /// <summary>
        /// Gets a Boolean value indicating whether the ESC key has been pressed.
        /// </summary>
        public DragDropKeyStates KeyStates { get { return _queryContinueDragEventArgs.KeyStates; } }

        /// <summary>
        /// Gets or sets a value that indicates whether the auto generated visual feedback is allowed or not.
        /// </summary>
        public bool IsAutoVisualFeedbackAllowed
        {
            get { return _context.IsAutoVisualFeedbackAllowed; }
            set { _context.IsAutoVisualFeedbackAllowed = value; }
        }

        /// <summary>
        /// Gets or sets an object that is set to the content of the visual drag feedback.
        /// If this value is not null, the auto generated visual drag feedback is not displayed.
        /// </summary>
        public object VisualFeedback
        {
            get { return _context.VisualFeedback; }
            set { _context.VisualFeedback = value; }
        }

        /// <summary>
        /// Gets or sets a data template used to display the content of the visual drag feedback.
        /// If this value is not null, the auto generated visual drag feedback is not displayed.
        /// </summary>
        public DataTemplate VisualFeedbackTemplate
        {
            get { return _context.VisualFeedbackTemplate; }
            set { _context.VisualFeedbackTemplate = value; }
        }

        /// <summary>
        /// Gets or sets a template selector that enables an application writer to provide custom template-selection logic for visual drag feedback.
        /// If this value is not null, the auto generated visual drag feedback is not displayed.
        /// </summary>
        public DataTemplateSelector VisualFeedbackTemplateSelector
        {
            get { return _context.VisualFeedbackTemplateSelector; }
            set { _context.VisualFeedbackTemplateSelector = value; }
        }

        /// <summary>
        /// Gets or sets an object that is set to the data context of the visual drag feedback.
        /// If this value is null, the drag source's data context is set.
        /// </summary>
        public object VisualFeedbackDataContext
        {
            get { return _context.VisualFeedbackDataContext; }
            set { _context.VisualFeedbackDataContext = value; }
        }

        /// <summary>
        /// Gets or sets an offset that is pointed by a pointing device in the visual drag feedback.
        /// The origin is the upper-left corner of the visual drag feedback.
        /// The x-coordinates increase to the right. The y-coordinates increase to the bottom.
        /// </summary>
        public Point VisualFeedbackOffset
        {
            get { return _context.VisualFeedbackOffset; }
            set { _context.VisualFeedbackOffset = value; }
        }

        /// <summary>
        /// Gets or sets the opacity of the visual drag feedback.
        /// </summary>
        public double VisualFeedbackOpacity
        {
            get { return _context.VisualFeedbackOpacity; }
            set { _context.VisualFeedbackOpacity = value; }
        }

        /// <summary>
        /// Gets or sets the visual drag feedback visibility.
        /// </summary>
        public Visibility VisualFeedbackVisibility
        {
            get { return _context.VisualFeedbackVisibility; }
            set { _context.VisualFeedbackVisibility = value; }
        }

        /// <summary>
        /// Gets or sets the width of the visual drag feedback.
        /// </summary>
        public double VisualFeedbackWidth
        {
            get { return _context.VisualFeedbackWidth; }
            set { _context.VisualFeedbackWidth = value; }
        }

        /// <summary>
        /// Gets or sets the height of the visual drag feedback.
        /// </summary>
        public double VisualFeedbackHeight
        {
            get { return _context.VisualFeedbackHeight; }
            set { _context.VisualFeedbackHeight = value; }
        }

        /// <summary>
        /// Gets or sets the minimum width of the visual drag feedback.
        /// </summary>
        public double VisualFeedbackMinWidth
        {
            get { return _context.VisualFeedbackMinWidth; }
            set { _context.VisualFeedbackMinWidth = value; }
        }

        /// <summary>
        /// Gets or sets the minimum height of the visual drag feedback.
        /// </summary>
        public double VisualFeedbackMinHeight
        {
            get { return _context.VisualFeedbackMinHeight; }
            set { _context.VisualFeedbackMinHeight = value; }
        }

        /// <summary>
        /// Gets or sets the maximum width of the visual drag feedback.
        /// </summary>
        public double VisualFeedbackMaxWidth
        {
            get { return _context.VisualFeedbackMaxWidth; }
            set { _context.VisualFeedbackMaxWidth = value; }
        }

        /// <summary>
        /// Gets or sets the maximum height of the visual drag feedback.
        /// </summary>
        public double VisualFeedbackMaxHeight
        {
            get { return _context.VisualFeedbackMaxHeight; }
            set { _context.VisualFeedbackMaxHeight = value; }
        }

        #endregion
    }


    /// <summary>
    /// Defines required infomation for the Dragged event.
    /// </summary>
    internal interface IDragSourceDraggedEventArgsContext
    {
        DragDropEffects AllowedEffects { get; }
        object Data { get; }
        bool IsAutoVisualFeedbackAllowed { get; }
        object VisualFeedback { get; }
        DataTemplate VisualFeedbackTemplate { get; }
        DataTemplateSelector VisualFeedbackTemplateSelector { get; }
        object VisualFeedbackDataContext { get; }
        Point VisualFeedbackOffset { get; }
        double VisualFeedbackOpacity { get; }
        Visibility VisualFeedbackVisibility { get; }
        double VisualFeedbackWidth { get; }
        double VisualFeedbackHeight { get; }
        double VisualFeedbackMinWidth { get; }
        double VisualFeedbackMinHeight { get; }
        double VisualFeedbackMaxWidth { get; }
        double VisualFeedbackMaxHeight { get; }
    }

    /// <summary>
    /// Contains arguments for the Dragged event.
    /// </summary>
    public class DragSourceDraggedEventArgs : DragSourceEventArgsBase
    {
        IDragSourceDraggedEventArgsContext _context;


        #region Constructors

        /// <summary>
        /// Initializes a new instance of the DragSourceDraggedEventArgs class.
        /// </summary>
        /// <param name="routedEvent">The routed event identifier for this instance of the RoutedEventArgs class.</param>
        /// <param name="source">An alternate source that will be reported when the event is handled. This pre-populates the Source property.</param>
        /// <param name="initiator">The drag initiator.</param>
        /// <param name="contactPosition">The contact position in the dragged source.</param>
        /// <param name="draggedPosition">The dragged position in the dragged source.</param>
        /// <param name="context">The context that contains required information for the Dropped event. Null is not allowed.</param>
        /// <param name="finalEffects">One of the DragDropEffects values that specifies the final effect that was performed during the drag-and-drop operation.</param>
        internal DragSourceDraggedEventArgs(RoutedEvent routedEvent, object source, DragInitiator initiator, Point contactPosition, Point draggedPosition,
                    IDragSourceDraggedEventArgsContext context, DragDropEffects finalEffects)
            : base(routedEvent, source, initiator, contactPosition, draggedPosition)
        {
            Debug.Assert(context != null);

            _context = context;
            FinalEffects = finalEffects;
        }

        #endregion


        #region Properties

        /// <summary>
        /// Gets a value indicating permitted effects of the drag-and-drop operation.
        /// </summary>
        public DragDropEffects AllowedEffects { get { return _context.AllowedEffects; } }

        /// <summary>
        /// Gets a data object that contains the data being dragged.
        /// This value is always not null.
        /// </summary>
        public object Data { get { return _context.Data; } }

        /// <summary>
        /// Gets a value that indicates whether the auto generated visual feedback is allowed or not.
        /// </summary>
        public bool IsAutoVisualFeedbackAllowed { get { return _context.IsAutoVisualFeedbackAllowed; } }

        /// <summary>
        /// Gets an object that is set to the content of the visual drag feedback.
        /// </summary>
        public object VisualFeedback { get { return _context.VisualFeedback; } }

        /// <summary>
        /// Gets a data template used to display the content of the visual drag feedback.
        /// </summary>
        public DataTemplate VisualFeedbackTemplate { get { return _context.VisualFeedbackTemplate; } }

        /// <summary>
        /// Gets the template selector that enables an application writer to provide custom template-selection logic for visual drag feedback.
        /// </summary>
        public DataTemplateSelector VisualFeedbackTemplateSelector { get { return _context.VisualFeedbackTemplateSelector; } }

        /// <summary>
        /// Gets an object that is set to the data context of the visual drag feedback.
        /// </summary>
        public object VisualFeedbackDataContext { get { return _context.VisualFeedbackDataContext; } }

        /// <summary>
        /// Gets the offset that is pointed by a pointing device in the visual drag feedback.
        /// The origin is the upper-left corner of the visual drag feedback.
        /// The x-coordinates increase to the right. The y-coordinates increase to the bottom.
        /// </summary>
        public Point VisualFeedbackOffset { get { return _context.VisualFeedbackOffset; } }

        /// <summary>
        /// Gets the opacity of the visual drag feedback.
        /// </summary>
        public double VisualFeedbackOpacity { get { return _context.VisualFeedbackOpacity; } }

        /// <summary>
        /// Gets the visual feedback drag visibility.
        /// </summary>
        public Visibility VisualFeedbackVisibility { get { return _context.VisualFeedbackVisibility; } }

        /// <summary>
        /// Gets the width of the visual drag feedback.
        /// </summary>
        public double VisualFeedbackWidth { get { return _context.VisualFeedbackWidth; } }

        /// <summary>
        /// Gets the height of the visual drag feedback.
        /// </summary>
        public double VisualFeedbackHeight { get { return _context.VisualFeedbackHeight; } }

        /// <summary>
        /// Gets the minimum width of the visual drag feedback.
        /// </summary>
        public double VisualFeedbackMinWidth { get { return _context.VisualFeedbackMinWidth; } }

        /// <summary>
        /// Gets the minimum height of the visual drag feedback.
        /// </summary>
        public double VisualFeedbackMinHeight { get { return _context.VisualFeedbackMinHeight; } }

        /// <summary>
        /// Gets the maximum width of the visual drag feedback.
        /// </summary>
        public double VisualFeedbackMaxWidth { get { return _context.VisualFeedbackMaxWidth; } }

        /// <summary>
        /// Gets the maximum height of the visual drag feedback.
        /// </summary>
        public double VisualFeedbackMaxHeight { get { return _context.VisualFeedbackMaxHeight; } }

        /// <summary>
        /// Gets the final effect that was performed during the drag-and-drop operation.
        /// </summary>
        public DragDropEffects FinalEffects { get; private set; }

        #endregion
    }

    /// <summary>
    /// Contains arguments for the Dropped event.
    /// </summary>
    [Obsolete("Instead, use the Dragged event.")]
    public class DragSourceDroppedEventArgs : DragSourceDraggedEventArgs
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the DragSourceDroppedEventArgs class.
        /// </summary>
        /// <param name="routedEvent">The routed event identifier for this instance of the RoutedEventArgs class.</param>
        /// <param name="source">An alternate source that will be reported when the event is handled. This pre-populates the Source property.</param>
        /// <param name="initiator">The drag initiator.</param>
        /// <param name="contactPosition">The contact position in the dragged source.</param>
        /// <param name="draggedPosition">The dragged position in the dragged source.</param>
        /// <param name="context">The context that contains required information for the Dropped event. Null is not allowed.</param>
        /// <param name="finalEffects">One of the DragDropEffects values that specifies the final effect that was performed during the drag-and-drop operation.</param>
        internal DragSourceDroppedEventArgs(RoutedEvent routedEvent, object source, DragInitiator initiator, Point contactPosition, Point draggedPosition,
                    IDragSourceDraggedEventArgsContext context, DragDropEffects finalEffects)
            : base(routedEvent, source, initiator, contactPosition, draggedPosition, context, finalEffects) { }

        #endregion
    }

    #endregion


    /// <summary>
    /// Provides functionalities to make an element draggable.
    /// </summary>
    /// <remarks>
    /// The AllowDrag attached property is used to specify an element to drag.
    /// A data object to transfer must be set by using the Data attached property or the Data property of related event arguments.
    /// </remarks>
    public static class DragSource
    {
        #region Inner Types

        /// <summary>
        /// The storage to save context related information.
        /// </summary>
        private class Context : IDragSourceDraggingEventArgsContext,
                IDragSourceGiveFeedbackEventArgsContext, IDragSourceQueryContinueDragEventArgsContext, IDragSourceDraggedEventArgsContext
        {
            /// <summary>
            /// The target element to drag.
            /// This variable is set to non-null value in the Constructor.
            /// </summary>
            UIElement _target;


            #region Constructors

            /// <summary>
            /// Initializes a new instance of the Context class.
            /// </summary>
            /// <param name="target">The target element to drag. Null is not allowed.</param>
            public Context(UIElement target)
            {
                Debug.Assert(target != null);
                _target = target;
            }

            #endregion


            #region Members

            DispatcherTimer _processMoveForDragSensingTimer;

            /// <summary>
            /// The timer to check cursor movement for sensing drag when it is not in the target element.
            /// </summary>
            public DispatcherTimer ProcessMoveForDragSensingTimer
            {
                get
                {
                    if (_processMoveForDragSensingTimer == null)
                    {
                        _processMoveForDragSensingTimer = new DispatcherTimer();
                        _processMoveForDragSensingTimer.Interval = TimeSpan.FromMilliseconds(100);
                        _processMoveForDragSensingTimer.Tick += (_, __) => ProcessDragSensing(_target, Mouse.GetPosition(_target));
                    }

                    return _processMoveForDragSensingTimer;
                }
            }

            /// <summary>
            /// Gets or sets a value indicating permitted effects of the drag-and-drop operation.
            /// </summary>
            public DragDropEffects AllowedEffects { get; set; }

            /// <summary>
            /// Gets or sets a data object that contains the data being dragged.
            /// </summary>
            public object Data { get; set; }

            /// <summary>
            /// Gets or sets a value that indicates whether the auto generated visual feedback is allowed or not.
            /// </summary>
            public bool IsAutoVisualFeedbackAllowed { get; set; }

            /// <summary>
            /// Gets or sets an object that is set to the content of the visual drag feedback.
            /// If this value is not null, the auto generated visual drag feedback is not displayed.
            /// </summary>
            public object VisualFeedback { get; set; }

            /// <summary>
            /// Gets or sets a data template used to display the content of the visual drag feedback.
            /// If this value is not null, the auto generated visual drag feedback is not displayed.
            /// </summary>
            public DataTemplate VisualFeedbackTemplate { get; set; }

            /// <summary>
            /// Gets or sets a template selector that enables an application writer to provide custom template-selection logic for visual drag feedback.
            /// If this value is not null, the auto generated visual drag feedback is not displayed.
            /// </summary>
            public DataTemplateSelector VisualFeedbackTemplateSelector { get; set; }

            /// <summary>
            /// Gets or sets an object that is set to the data context of the visual drag feedback.
            /// If this value is null, the drag source's data context is set.
            /// </summary>
            public object VisualFeedbackDataContext { get; set; }

            /// <summary>
            /// Gets or sets an offset that is pointed by a pointing device in the visual drag feedback.
            /// The origin is the upper-left corner of the visual drag feedback.
            /// The x-coordinates increase to the right. The y-coordinates increase to the bottom.
            /// </summary>
            public Point VisualFeedbackOffset { get; set; }

            /// <summary>
            /// Gets or sets an opacity of the visual drag feedback.
            /// </summary>
            public double VisualFeedbackOpacity { get; set; }

            /// <summary>
            /// Gets or sets the visual drag feedback visibility.
            /// </summary>
            public Visibility VisualFeedbackVisibility { get; set; }

            /// <summary>
            /// Gets or sets a width of the visual drag feedback.
            /// </summary>
            public double VisualFeedbackWidth { get; set; }

            /// <summary>
            /// Gets or sets a height of the visual drag feedback.
            /// </summary>
            public double VisualFeedbackHeight { get; set; }

            /// <summary>
            /// Gets or sets a minimum width of the visual drag feedback.
            /// </summary>
            public double VisualFeedbackMinWidth { get; set; }

            /// <summary>
            /// Gets or sets a minimum height of the visual drag feedback.
            /// </summary>
            public double VisualFeedbackMinHeight { get; set; }

            /// <summary>
            /// Gets or sets a maximum width of the visual drag feedback.
            /// </summary>
            public double VisualFeedbackMaxWidth { get; set; }

            /// <summary>
            /// Gets or sets a maximum height of the visual drag feedback.
            /// </summary>
            public double VisualFeedbackMaxHeight { get; set; }

            /// <summary>
            /// The host of the visual drag feedback.
            /// </summary>
            public VisualFeedbackHost VisualFeedbackHost { get; set; }

            /// <summary>
            /// Initializes this context for events after the DragSensing event.
            /// </summary>
            /// <param name="allowedEffects">A value indicating permitted effects of the drag-and-drop operation.</param>
            /// <param name="data">A data object that contains the data being dragged.</param>
            /// <param name="isAutoVisualFeedbackAllowed">A value that indicates whether the auto generated visual feedback is allowed or not.</param>
            /// <param name="visualFeedback">An object that is set to the content of the visual drag feedback.</param>
            /// <param name="visualFeedbackTemplate">A data template used to display the content of the visual drag feedback.</param>
            /// <param name="visualFeedbackTemplateSelector">A template selector that enables an application writer to provide custom template-selection logic for visual drag feedback.</param>
            /// <param name="visualFeedbackDataContext">An object that is set to the data context of the visual drag feedback.</param>
            /// <param name="visualFeedbackOffset">An offset that is pointed by a pointing device in the visual drag feedback.</param>
            /// <param name="visualFeedbackOpacity">An opacity of the visual drag feedback.</param>
            /// <param name="visualFeedbackVisibility">A value for the visual drag feedback visibility.</param>
            /// <param name="visualFeedbackWidth">A width of the visual drag feedback.</param>
            /// <param name="visualFeedbackHeight">A height of the visual drag feedback.</param>
            /// <param name="visualFeedbackMinWidth">A minimum width of the visual drag feedback.</param>
            /// <param name="visualFeedbackMinHeight">A minimum height of the visual drag feedback.</param>
            /// <param name="visualFeedbackMaxWidth">A maximum width of the visual drag feedback.</param>
            /// <param name="visualFeedbackMaxHeight">A maximum height of the visual drag feedback.</param>
            public void InitializeForEventsAfterDragSensing(DragDropEffects allowedEffects, object data, bool isAutoVisualFeedbackAllowed,
                object visualFeedback, DataTemplate visualFeedbackTemplate, DataTemplateSelector visualFeedbackTemplateSelector,
                object visualFeedbackDataContext, Point visualFeedbackOffset, double visualFeedbackOpacity, Visibility visualFeedbackVisibility,
                double visualFeedbackWidth, double visualFeedbackHeight, double visualFeedbackMinWidth, double visualFeedbackMinHeight,
                double visualFeedbackMaxWidth, double visualFeedbackMaxHeight)
            {
                AllowedEffects = allowedEffects;
                Data = data;

                IsAutoVisualFeedbackAllowed = isAutoVisualFeedbackAllowed;

                VisualFeedback = visualFeedback;
                VisualFeedbackTemplate = visualFeedbackTemplate;
                VisualFeedbackTemplateSelector = visualFeedbackTemplateSelector;
                VisualFeedbackDataContext = visualFeedbackDataContext;
                VisualFeedbackOffset = visualFeedbackOffset;
                VisualFeedbackOpacity = visualFeedbackOpacity;
                VisualFeedbackVisibility = visualFeedbackVisibility;
                VisualFeedbackWidth = visualFeedbackWidth;
                VisualFeedbackHeight = visualFeedbackHeight;
                VisualFeedbackMinWidth = visualFeedbackMinWidth;
                VisualFeedbackMinHeight = visualFeedbackMinHeight;
                VisualFeedbackMaxWidth = visualFeedbackMaxWidth;
                VisualFeedbackMaxHeight = visualFeedbackMaxHeight;
            }

            /// <summary>
            /// Updates the VisualFeedbackHost.
            /// </summary>
            public void UpdateVisualFeedbackHost()
            {
                if (VisualFeedbackHost == null)
                    return;

                // Updates the visual feedback window.
                VisualFeedbackHost.Update
                (
                    IsAutoVisualFeedbackAllowed,
                    VisualFeedback,
                    VisualFeedbackTemplate,
                    VisualFeedbackTemplateSelector,
                    VisualFeedbackDataContext,
                    VisualFeedbackOffset,
                    VisualFeedbackOpacity,
                    VisualFeedbackVisibility,
                    VisualFeedbackWidth,
                    VisualFeedbackHeight,
                    VisualFeedbackMinWidth,
                    VisualFeedbackMinHeight,
                    VisualFeedbackMaxWidth,
                    VisualFeedbackMaxHeight
                );
            }

            /// <summary>
            /// Cleans up internal states to help the garbage collection.
            /// </summary>
            public void CleanUp()
            {
                Data = null;
                VisualFeedback = null;
                VisualFeedbackTemplate = null;
                VisualFeedbackTemplateSelector = null;
                VisualFeedbackDataContext = null;

                if (VisualFeedbackHost != null)
                {
                    VisualFeedbackHost.Dispose();
                    VisualFeedbackHost = null;
                }
            }

            #endregion
        }

        /// <summary>
        /// Represents host for the visual drag feedback.
        /// </summary>
        private class VisualFeedbackHost : Disposable
        {
            UIElement _dragSource;


            #region Constructors

            /// <summary>
            /// Initializes a new instance of the VisualFeedbackHost class.
            /// </summary>
            /// <param name="dragSource">The element to drag.</param>
            public VisualFeedbackHost(UIElement dragSource)
            {
                _dragSource = dragSource;
            }

            #endregion


            #region Static Helpers

            /// <summary>
            /// Creates a host window for the visual drag feedback.
            /// </summary>
            /// <returns>A new host window.</returns>
            private static Window CreateHostWindow()
            {
                // Creates a host window for the visual drag feedback.
                Window hostWindow = new Window()
                {
                    ShowInTaskbar = false,
                    Topmost = true,
                    IsHitTestVisible = false,
                    AllowsTransparency = true,
                    WindowStyle = WindowStyle.None,
                    Background = Brushes.Transparent,
                    SizeToContent = SizeToContent.WidthAndHeight,
                    WindowStartupLocation = WindowStartupLocation.Manual,
                };

                hostWindow.SourceInitialized += (_, __) =>
                {
                    // Gets the window handle.
                    IntPtr hWnd = new WindowInteropHelper(hostWindow).Handle;

                    // Gets the host window's long ptr.
                    IntPtr windowLongPtr = Win32.GetWindowLong(hWnd, Win32.GWL_EXSTYLE);
                    if (windowLongPtr == IntPtr.Zero)
                    {
                        Trace.WriteLine("DragSource: GetWindowLongPtr has failed. Error code " + Marshal.GetLastWin32Error());
                        return;
                    }

                    // Ors the WS_EX_TRANSPARENT.
                    if (IntPtr.Size == 4)
                        windowLongPtr = (IntPtr)(windowLongPtr.ToInt32() | Win32.WS_EX_TRANSPARENT);
                    else
                        windowLongPtr = (IntPtr)(windowLongPtr.ToInt64() | Win32.WS_EX_TRANSPARENT);

                    // Clears the last error for checking SetWindowLong error.
                    Win32.SetLastError(0);

                    // Sets the new long ptr.
                    if (Win32.SetWindowLong(hWnd, Win32.GWL_EXSTYLE, windowLongPtr) == IntPtr.Zero)
                    {
                        int lastWin32Error = Marshal.GetLastWin32Error();
                        if (lastWin32Error != 0)
                        {
                            Trace.WriteLine("DragSource: SetWindowLong has failed. Error code " + lastWin32Error);
                            return;
                        }
                    }

                }; // hostWindow.SourceInitialized

                // Displays the created window.
                hostWindow.Show();

                // Returns the created window.
                return hostWindow;
            }

            /// <summary>
            /// Returns the TransformFromDevice matrix of the specified window.
            /// </summary>
            /// <param name="window">The window.</param>
            /// <returns>The transformFromDevice matrix.</returns>
            private static Matrix GetTransformFromDevice(Window window)
            {
                Debug.Assert(window != null);

                // Gets the host window's presentation source.
                PresentationSource windowPresentationSource = PresentationSource.FromVisual(window);
                if (windowPresentationSource == null)
                {
                    Trace.WriteLine("PresentationSource.FromVisual has failed in DragSource.");
                    return Matrix.Identity;
                }

                // Returns the TransformFromDevice matrix.
                return windowPresentationSource.CompositionTarget.TransformFromDevice;
            }

            #endregion


            #region Helpers

            VisualFeedbackContentManager _visualFeedbackContentManager;

            /// <summary>
            /// The content manager of the visual drag feedback.
            /// </summary>
            private VisualFeedbackContentManager VisualFeedbackContentManager
            {
                get { return _visualFeedbackContentManager ?? (_visualFeedbackContentManager = new VisualFeedbackContentManager(_dragSource)); }
            }

            /// <summary>
            /// Disposes the VisualFeedbackContentManager and set it to null.
            /// </summary>
            private void DisposeVisualFeedbackContentManager()
            {
                if (_visualFeedbackContentManager == null)
                    return;

                _visualFeedbackContentManager.Dispose();
                _visualFeedbackContentManager = null;
            }


            Window _hostWindow;

            /// <summary>
            /// The window to host the visual drag feedback.
            /// </summary>
            private Window HostWindow
            {
                get { return _hostWindow ?? (_hostWindow = CreateHostWindow()); }
            }

            /// <summary>
            /// Disposes the host window and set it to null.
            /// </summary>
            private void DisposeHostWindow()
            {
                if (_hostWindow == null)
                    return;

                _hostWindow.Content = null;
                _hostWindow.Close();
                _hostWindow = null;
            }


            /// <summary>
            /// The data context set to the drag source element.
            /// It can be null.
            /// </summary>
            private object DragSourceDataContext
            {
                get
                {
                    FrameworkElement frameworkElement = _dragSource as FrameworkElement;
                    return frameworkElement != null ? frameworkElement.DataContext : null;
                }
            }

            /// <summary>
            /// Updates the host window location to follow the position of the dragging.
            /// </summary>
            /// <param name="offset">The offset that is pointed by a pointing device in the the host window. The origin is the upper-left corner of the host window. The x-coordinates increase to the right. The y-coordinates increase to the bottom.</param>
            private void UpdateHostWindowLocation(Point offset)
            {
                // Gets the current mouse positon.
                Win32.POINT cursorPosition;
                if (Win32.GetCursorPos(out cursorPosition) == 0)
                {
                    Trace.WriteLine("DragSource: GetCursorPos has failed. Error code " + Marshal.GetLastWin32Error());
                    return;
                }

                // Gets the mouse position in device independent coordinate.
                Point windowPosition = GetTransformFromDevice(HostWindow).Transform(new Point(cursorPosition.x, cursorPosition.y));

                // Applies the offset.
                windowPosition.X = windowPosition.X - offset.X;
                windowPosition.Y = windowPosition.Y - offset.Y;

                // Updates the host window's location.
                HostWindow.Left = windowPosition.X;
                HostWindow.Top = windowPosition.Y;
            }

            #endregion


            /// <summary>
            /// Updates the visual feedback host to display the visual drag feedback appropriately.
            /// If content or contentTemplate or contentTemplateSelector is not null,
            /// auto generated visual feedback is not displayed regardless of the isAutoVisualFeedbackAllowed.
            /// </summary>
            /// <param name="isAutoVisualFeedbackAllowed">A value that indicates whether the auto generated visual feedback is allowed or not.</param>
            /// <param name="content">The content of the visual feedback host.</param>
            /// <param name="contentTemplate">The content template of the visual feedback host.</param>
            /// <param name="contentTemplateSelector">The content template selector of the visual feedback host.</param>
            /// <param name="dataContext">The data context of the visual feedback host. If this value is null, the drag source's data context is used.</param>
            /// <param name="offset">An offset that is pointed by a pointing device in the visual feedback host. The origin is the upper-left corner of the visual feedback host. The x-coordinates increase to the right. The y-coordinates increase to the bottom.</param>
            /// <param name="opacity">An opacity of the visual feedback host.</param>
            /// <param name="visibility">The visual feedback host visibility.</param>
            /// <param name="width">A width of the visual feedback host.</param>
            /// <param name="height">A height of the visual feedback host.</param>
            /// <param name="minWidth">A minimum width of the visual feedback host.</param>
            /// <param name="minHeight">A minimum height of the visual feedback host.</param>
            /// <param name="maxWidth">A maximum width of the visual feedback host.</param>
            /// <param name="maxHeight">A maximum height of the visual feedback host.</param>
            public void Update(bool isAutoVisualFeedbackAllowed, object content, DataTemplate contentTemplate, DataTemplateSelector contentTemplateSelector,
                    object dataContext, Point offset, double opacity, Visibility visibility, double width, double height,
                    double minWidth, double minHeight, double maxWidth, double maxHeight)
            {
                // Gets the content element for the host window.
                FrameworkElement contentElement = VisualFeedbackContentManager.CreateOrGetContent(isAutoVisualFeedbackAllowed, content, contentTemplate, contentTemplateSelector);

                // If there is no content to display, disposes the host window if it exists.
                if (contentElement == null)
                {
                    DisposeHostWindow();
                    return;
                }

                // Sets the content element.
                HostWindow.Content = contentElement;

                // Updates the host window location.
                UpdateHostWindowLocation(offset);

                // Updates the host window's properties.
                HostWindow.DataContext = dataContext ?? DragSourceDataContext;
                HostWindow.Opacity = opacity;
                HostWindow.Visibility = visibility;
                HostWindow.Width = width;
                HostWindow.Height = height;

                // Updates the content element's properties.
                contentElement.MinWidth = minWidth;
                contentElement.MinHeight = minHeight;
                contentElement.MaxWidth = maxWidth;
                contentElement.MaxHeight = maxHeight;
            }


            #region DisposeOverride

            protected override void DisposeOverride(bool disposing)
            {
                base.DisposeOverride(disposing);

                if (disposing)
                {
                    DisposeVisualFeedbackContentManager();
                    DisposeHostWindow();
                }
            }

            #endregion
        }

        /// <summary>
        /// Manages content for the visual feedback.
        /// </summary>
        private class VisualFeedbackContentManager : Disposable
        {
            UIElement _dragSource;


            #region Constructors

            /// <summary>
            /// Initializes a new instance of the VisualFeedbackContentManager class.
            /// </summary>
            /// <param name="dragSource">The element to drag.</param>
            public VisualFeedbackContentManager(UIElement dragSource)
            {
                _dragSource = dragSource;
            }

            #endregion


            #region CreateGeneratedContent

            /// <summary>
            /// Generates a visual feedback based on the dragged element.
            /// </summary>
            /// <param name="dragSource">The element to drag.</param>
            /// <returns>A generated visual feedback if the dragSource is not null; otherwise null.</returns>
            private static FrameworkElement CreateGeneratedContent(UIElement dragSource)
            {
                // If the drag source is null
                if (dragSource == null)
                    return null;

                // Creates a rectangle with a visual brush.
                Rectangle rectangle = new Rectangle()
                {
                    StrokeThickness = 0d,
                    Fill = new VisualBrush(dragSource),
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                };

                // Sets the rectangle's width binding.
                Binding widthBinding = new Binding("ActualWidth");
                widthBinding.Source = dragSource;
                rectangle.SetBinding(Rectangle.WidthProperty, widthBinding);

                // Sets the rectangle's height binding.
                Binding heightBinding = new Binding("ActualHeight");
                heightBinding.Source = dragSource;
                rectangle.SetBinding(Rectangle.HeightProperty, heightBinding);

                // Returns the rectangle.
                return rectangle;
            }

            #endregion


            #region Helpers

            ContentControl _contentControl;

            /// <summary>
            /// The content control to host the visual feedback content.
            /// </summary>
            private ContentControl ContentControl
            {
                get { return _contentControl ?? (_contentControl = new ContentControl()); }
            }

            /// <summary>
            /// Disposes the content control and set it to null.
            /// </summary>
            private void DisposeContentControl()
            {
                if (_contentControl == null)
                    return;

                _contentControl.Content = null;
                _contentControl.ClearValue(ContentControl.ContentTemplateProperty);
                _contentControl.ClearValue(ContentControl.ContentTemplateSelectorProperty);
                _contentControl = null;
            }


            FrameworkElement _generatedContent;

            /// <summary>
            /// The generated visual feedback content.
            /// </summary>
            private FrameworkElement GeneratedContent
            {
                get { return _generatedContent ?? (_generatedContent = CreateGeneratedContent(_dragSource)); }
            }

            #endregion


            /// <summary>
            /// Creates or gets the FrameworkElement that can be used as a content of the visual feedback.
            /// If content or contentTemplate or contentTemplateSelector is not null,
            /// auto generated visual feedback is not returned regardless of the isAutoVisualFeedbackAllowed.
            /// It can return null if the visual feedback is not allowed or no content.
            /// </summary>
            /// <param name="isAutoVisualFeedbackAllowed">A value that indicates whether the auto generated visual feedback is allowed or not.</param>
            /// <param name="content">The content of the visual feedback.</param>
            /// <param name="contentTemplate">The content template of the visual feedback.</param>
            /// <param name="contentTemplateSelector">The content template selector of the visual feedback.</param>
            /// <returns>The visual feedback content.</returns>
            public FrameworkElement CreateOrGetContent(bool isAutoVisualFeedbackAllowed, object content, DataTemplate contentTemplate, DataTemplateSelector contentTemplateSelector)
            {
                // If any content related property is set, it means that user wants to control the content display.
                if (content != null || contentTemplate != null || contentTemplateSelector != null)
                {
                    ContentControl.Content = content;
                    ContentControl.ContentTemplate = contentTemplate;
                    ContentControl.ContentTemplateSelector = contentTemplateSelector;

                    return ContentControl;
                }

                // If auto visual feedback is not allowed or is null
                if (!isAutoVisualFeedbackAllowed || GeneratedContent == null)
                    return null;

                ContentControl.Content = GeneratedContent;
                ContentControl.ClearValue(ContentControl.ContentTemplateProperty);
                ContentControl.ClearValue(ContentControl.ContentTemplateSelectorProperty);

                return ContentControl;
            }


            #region DisposeOverride

            protected override void DisposeOverride(bool disposing)
            {
                base.DisposeOverride(disposing);

                if (disposing)
                    DisposeContentControl();
            }

            #endregion
        }

        #endregion


        #region Context Attached Property

        /// <summary>
        /// The attached property to store internal context information.
        /// </summary>
        private static readonly DependencyProperty ContextProperty = DependencyProperty.RegisterAttached
        (
            "Context",
            typeof(Context),
            typeof(DragSource)
        );

        /// <summary>
        /// Gets a value that stores internal context information.
        /// </summary>
        /// <param name="obj">A DependencyObject instance.</param>
        /// <returns>A Context instance.</returns>
        private static Context GetContext(DependencyObject obj)
        {
            return (Context)obj.GetValue(ContextProperty);
        }

        /// <summary>
        /// Sets a value that stores internal context information.
        /// </summary>
        /// <param name="obj">A DependencyObject instance.</param>
        /// <param name="value">A Context instance.</param>
        private static void SetContext(DependencyObject obj, Context value)
        {
            obj.SetValue(ContextProperty, value);
        }

        /// <summary>
        /// Gets a value that stores internal context information.
        /// If it is not set, new context is created and set.
        /// </summary>
        /// <param name="obj">A UIElement instance.</param>
        private static Context GetSafeContext(UIElement obj)
        {
            Debug.Assert(obj != null);

            Context context = GetContext(obj);

            if (context == null)
                SetContext(obj, context = new Context(obj));

            return context;
        }

        #endregion


        #region AllowDrag Attached Property

        /// <summary>
        /// The attached property to indicate whether the element is draggable.
        /// </summary>
        public static readonly DependencyProperty AllowDragProperty = DependencyProperty.RegisterAttached
        (
            "AllowDrag",
            typeof(bool),
            typeof(DragSource),
            new PropertyMetadata(false, AllowDragProperty_Changed)
        );

        /// <summary>
        /// Gets a value that indicates whether the element is draggable.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <returns>True if it is draggable; otherwise, false.</returns>
        public static bool GetAllowDrag(UIElement obj)
        {
            return (bool)obj.GetValue(AllowDragProperty);
        }

        /// <summary>
        /// Sets a value that indicates whether the element is draggable.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <param name="value">A value that indicates whether the element is draggable.</param>
        public static void SetAllowDrag(UIElement obj, bool value)
        {
            obj.SetValue(AllowDragProperty, value);
        }

        static void AllowDragProperty_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UIElement target = d as UIElement;

            // Removes the previous event handler if it exists.
            target.PreviewMouseDown -= AllowDragProperty_PropertyHost_PreviewMouseDown;

            if ((bool)e.NewValue)
                target.PreviewMouseDown += AllowDragProperty_PropertyHost_PreviewMouseDown;
        }

        static void AllowDragProperty_PropertyHost_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            UIElement target = sender as UIElement;

            // Stops previous drag sensing if it exists.
            StopDragSensing(target);

            // Starts drag sensing.
            StartDragSensing(target, e.ChangedButton.ToDragInitiator(), e.GetPosition(target));
        }

        static void StartDragSensing(UIElement target, DragInitiator initiator, Point contactPosition)
        {
            Debug.Assert(target != null);

            // Checks whether the drag initiator is allowed or not.
            if (!GetAllowedInitiators(target).HasFlag(initiator.ToDragInitiators()))
                return;


            // Saves the initiator and contactPosition.
            SetInitiator(target, initiator);
            SetContactPosition(target, contactPosition);

            // Updates the dragged position.
            SetDraggedPosition(target, contactPosition);


            // Raises the DragSensing related events.
            if (!RaiseDragSensingEvent(target, initiator, contactPosition, contactPosition))
                return;


            // Attaches event handlers for drag sensing.
            target.PreviewMouseMove += AllowDragProperty_PropertyHost_PreviewMouseMove;
            target.MouseEnter += AllowDragProperty_PropertyHost_MouseEnter;
            target.MouseLeave += AllowDragProperty_PropertyHost_MouseLeave;
        }

        static void StopDragSensing(UIElement target)
        {
            Debug.Assert(target != null);

            // Stops the process move timer.
            GetSafeContext(target).ProcessMoveForDragSensingTimer.Stop();

            // Detaches event handlers for drag sensing.
            target.PreviewMouseMove -= AllowDragProperty_PropertyHost_PreviewMouseMove;
            target.MouseEnter -= AllowDragProperty_PropertyHost_MouseEnter;
            target.MouseLeave -= AllowDragProperty_PropertyHost_MouseLeave;
        }

        static void AllowDragProperty_PropertyHost_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            // Processes drag sensing operation.
            UIElement target = sender as UIElement;
            ProcessDragSensing(target, e.GetPosition(target));
        }

        static void AllowDragProperty_PropertyHost_MouseEnter(object sender, MouseEventArgs e)
        {
            // Stops the process move timer.
            GetSafeContext(sender as UIElement).ProcessMoveForDragSensingTimer.Stop();
        }

        static void AllowDragProperty_PropertyHost_MouseLeave(object sender, MouseEventArgs e)
        {
            // Since it is not rely on the capture, MouseMove event can not be used.
            // It is required to check cursor position periodically.
            GetSafeContext(sender as UIElement).ProcessMoveForDragSensingTimer.Start();
        }

        static void ProcessDragSensing(UIElement target, Point currentPosition)
        {
            Debug.Assert(target != null);

            Context context = GetSafeContext(target);
            DragInitiator initiator = GetInitiator(target);
            Point contactPosition = GetContactPosition(target);
            bool isDragSensingFinished = true;

            try
            {
                // Checks whether the drag initiator is active.
                if (!initiator.IsActive())
                {
                    // Cleans up the context.
                    context.CleanUp();
                    return;
                }


                // Updates the dragged position.
                SetDraggedPosition(target, currentPosition);


                // Raises the dragSensing related events.
                if (!RaiseDragSensingEvent(target, initiator, contactPosition, currentPosition))
                {
                    // Cleans up the context.
                    context.CleanUp();
                    return;
                }


                // Checkes whether the move is enough to start drag.
                if (!IsEnoughToStartDrag(new Vector(GetMinimumHorizontalDragDistance(target), GetMinimumVerticalDragDistance(target)), contactPosition, currentPosition))
                {
                    // It is required to continue the drag sensing operation.
                    isDragSensingFinished = false;
                    return;
                }
            }
            finally
            {
                // If the drag sensing operation is finished
                if (isDragSensingFinished)
                    StopDragSensing(target);
            }


            // Initializes the DragSource, AllowedEffects, Data and VisualFeedback related properties in the context.
            context.InitializeForEventsAfterDragSensing
            (
                GetAllowedEffects(target),
                GetData(target),

                GetIsAutoVisualFeedbackAllowed(target),

                GetVisualFeedback(target),
                GetVisualFeedbackTemplate(target),
                GetVisualFeedbackTemplateSelector(target),
                GetVisualFeedbackDataContext(target),
                GetVisualFeedbackOffset(target),
                GetVisualFeedbackOpacity(target),
                GetVisualFeedbackVisibility(target),
                GetVisualFeedbackWidth(target),
                GetVisualFeedbackHeight(target),
                GetVisualFeedbackMinWidth(target),
                GetVisualFeedbackMinHeight(target),
                GetVisualFeedbackMaxWidth(target),
                GetVisualFeedbackMaxHeight(target)
            );

            try
            {
                // Raises the dragging event.
                if (!RaiseDraggingEvent(target, initiator, contactPosition, currentPosition, context))
                    return;


                DragDropEffects finalEffects = DragDropEffects.None;

                if (context.Data == null)
                {
                    MessageBox.Show("The data object is null. You must set DragSource.Data or DragSourceDraggingEventArgs.Data to a non-null value.", "DragSoruce");
                    context.Data = new DataObject();
                }
                else
                {
                    // Detaches event handlers for drag feedback if it exists.
                    DetachEventHandlersForDragFeedback(target);

                    // Attaches event handlers for drag feedback.
                    AttachEventHandlersForDragFeedback(target);

                    // Marks it is dragging.
                    SetIsDragging(target, true);

                    // Creates a dragging visual feedback host.
                    using (VisualFeedbackHost visualFeedbackHost = new VisualFeedbackHost(target))
                    {
                        // Sets the visual feedback host to the context.
                        context.VisualFeedbackHost = visualFeedbackHost;

                        // Starts the DragDrop operation.
                        // If the data object implements IDataObjectProvider, uses the object returned by the GetDataObject method.
                        IDataObjectProvider provider = context.Data as IDataObjectProvider;
                        finalEffects = DragDrop.DoDragDrop
                        (
                            target,
                            provider != null ? provider.GetDataObject() : context.Data,
                            context.AllowedEffects
                        );

                        // Clears the visual feedback host from the context.
                        context.VisualFeedbackHost = null;
                    }

                    // Marks that dragging is ended.
                    target.ClearValue(IsDraggingPropertyKey);

                    // Detaches event handlers for drag feedback.
                    DetachEventHandlersForDragFeedback(target);
                }

                // Raises the Dragged event.
                RaiseDraggedEvent(target, initiator, contactPosition, currentPosition, context, finalEffects);
            }
            finally
            {
                // Cleans up the context.
                context.CleanUp();
            }
        }

        static void AttachEventHandlersForDragFeedback(UIElement target)
        {
            Debug.Assert(target != null);

            // Attaches event handlers for drag feedback.
            target.PreviewGiveFeedback += DragSource_PreviewGiveFeedback;
            target.GiveFeedback += DragSource_GiveFeedback;
            target.PreviewQueryContinueDrag += DragSource_PreviewQueryContinueDrag;
            target.QueryContinueDrag += DragSource_QueryContinueDrag;
        }

        static void DetachEventHandlersForDragFeedback(UIElement target)
        {
            Debug.Assert(target != null);

            // Detaches event handlers for drag feedback.
            target.PreviewGiveFeedback -= DragSource_PreviewGiveFeedback;
            target.GiveFeedback -= DragSource_GiveFeedback;
            target.PreviewQueryContinueDrag -= DragSource_PreviewQueryContinueDrag;
            target.QueryContinueDrag -= DragSource_QueryContinueDrag;
        }

        static void DragSource_PreviewGiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            UIElement target = sender as UIElement;

            // Raises the PreviewGiveFeedback routed event.
            RaiseGiveFeedbackEvent(true, target, GetInitiator(target), GetContactPosition(target), GetDraggedPosition(target), GetSafeContext(target), e);
        }

        static void DragSource_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            UIElement target = sender as UIElement;

            // Raises the GiveFeedback routed event.
            RaiseGiveFeedbackEvent(false, target, GetInitiator(target), GetContactPosition(target), GetDraggedPosition(target), GetSafeContext(target), e);
        }

        static void DragSource_PreviewQueryContinueDrag(object sender, QueryContinueDragEventArgs e)
        {
            UIElement target = sender as UIElement;

            // Raises the PreviewQueryContinueDrag routed event.
            RaiseQueryContinueDragEvent(true, target, GetInitiator(target), GetContactPosition(target), GetDraggedPosition(target), GetSafeContext(target), e);
        }

        static void DragSource_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
        {
            UIElement target = sender as UIElement;

            // Raises the QueryContinueDrag routed event.
            RaiseQueryContinueDragEvent(false, target, GetInitiator(target), GetContactPosition(target), GetDraggedPosition(target), GetSafeContext(target), e);
        }

        #endregion


        #region AllowedInitiators Attached Property

        /// <summary>
        /// The attached property to specified allowed drag initiators.
        /// </summary>
        public static readonly DependencyProperty AllowedInitiatorsProperty = DependencyProperty.RegisterAttached
        (
            "AllowedInitiators",
            typeof(DragInitiators),
            typeof(DragSource),
            new PropertyMetadata(DragInitiators.Default)
        );

        /// <summary>
        /// Gets a value that specifies allowed drag initiators.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <returns>Allowed drag initiators.</returns>
        public static DragInitiators GetAllowedInitiators(DependencyObject obj)
        {
            return (DragInitiators)obj.GetValue(AllowedInitiatorsProperty);
        }

        /// <summary>
        /// Sets a value that specifies allowed drag initiators.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <param name="value">A value that specifies allowed drag initiators.</param>
        public static void SetAllowedInitiators(DependencyObject obj, DragInitiators value)
        {
            obj.SetValue(AllowedInitiatorsProperty, value);
        }

        #endregion


        #region Data Attached Property

        /// <summary>
        /// The attached property for a data object that contains the data being dragged.
        /// If IDataObjectProvider is implemented by the set value, it is used right before DragDrop.DoDragDrop call.
        /// </summary>
        public static readonly DependencyProperty DataProperty = DependencyProperty.RegisterAttached
        (
            "Data",
            typeof(object),
            typeof(DragSource)
        );

        /// <summary>
        /// Gets a data object that contains the data being dragged.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <returns>A data object that contains the data being dragged.</returns>
        public static object GetData(DependencyObject obj)
        {
            return (object)obj.GetValue(DataProperty);
        }

        /// <summary>
        /// Sets a data object that contains the data being dragged.
        /// If IDataObjectProvider is implemented by the set value, it is used right before DragDrop.DoDragDrop call.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <param name="value">A data object that contains the data being dragged.</param>
        public static void SetData(DependencyObject obj, object value)
        {
            obj.SetValue(DataProperty, value);
        }

        #endregion


        #region IsAutoVisualFeedbackAllowed Attached Property

        /// <summary>
        /// The attached property to indicate whether auto visual feedback is allowed or not.
        /// </summary>
        /// <remarks>
        /// DragSource displays a generated visual drag feedback if any visual feedback related property is not set.
        /// This property turns off the visual drag feedback.
        /// </remarks>
        public static readonly DependencyProperty IsAutoVisualFeedbackAllowedProperty = DependencyProperty.RegisterAttached
        (
            "IsAutoVisualFeedbackAllowed",
            typeof(bool),
            typeof(DragSource),
            new PropertyMetadata(true)
        );

        /// <summary>
        /// Gets a value that indicates whether auto visual feedback is allowed or not.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <returns>True if auto visual feedback is allowed; otherwise, false.</returns>
        public static bool GetIsAutoVisualFeedbackAllowed(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsAutoVisualFeedbackAllowedProperty);
        }

        /// <summary>
        /// Sets a value that indicates whether auto visual feedback is allowed or not.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <param name="value">A value that indicates whether auto visual feedback is allowed or not.</param>
        public static void SetIsAutoVisualFeedbackAllowed(DependencyObject obj, bool value)
        {
            obj.SetValue(IsAutoVisualFeedbackAllowedProperty, value);
        }

        #endregion


        #region VisualFeedback Attached Property

        /// <summary>
        /// The attached property for an object that is set to the content of the visual drag feedback.
        /// If this value is not null, the auto generated visual drag feedback is not displayed.
        /// </summary>
        public static readonly DependencyProperty VisualFeedbackProperty = DependencyProperty.RegisterAttached
        (
            "VisualFeedback",
            typeof(object),
            typeof(DragSource)
        );

        /// <summary>
        /// Gets an object that is set to the content of the visual drag feedback.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <returns>An object that is set to the content of the visual drag feedback.</returns>
        public static object GetVisualFeedback(DependencyObject obj)
        {
            return (object)obj.GetValue(VisualFeedbackProperty);
        }

        /// <summary>
        /// Sets an object that is set to the content of the visual drag feedback.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <param name="value">An object that is set to the content of the visual drag feedback.</param>
        public static void SetVisualFeedback(DependencyObject obj, object value)
        {
            obj.SetValue(VisualFeedbackProperty, value);
        }

        #endregion


        #region VisualFeedbackTemplate Attached Property

        /// <summary>
        /// The attached property for a data template used to display the content of the visual drag feedback.
        /// If this value is not null, the auto generated visual drag feedback is not displayed.
        /// </summary>
        public static readonly DependencyProperty VisualFeedbackTemplateProperty = DependencyProperty.RegisterAttached
        (
            "VisualFeedbackTemplate",
            typeof(DataTemplate),
            typeof(DragSource)
        );

        /// <summary>
        /// Gets a data template used to display the content of the visual drag feedback.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <returns>A data template used to display the content of the visual drag feedback.</returns>
        public static DataTemplate GetVisualFeedbackTemplate(DependencyObject obj)
        {
            return (DataTemplate)obj.GetValue(VisualFeedbackTemplateProperty);
        }

        /// <summary>
        /// Sets a data template used to display the content of the visual drag feedback.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <param name="value">A data template used to display the content of the visual drag feedback.</param>
        public static void SetVisualFeedbackTemplate(DependencyObject obj, DataTemplate value)
        {
            obj.SetValue(VisualFeedbackTemplateProperty, value);
        }

        #endregion


        #region VisualFeedbackTemplateSelector Attached Property

        /// <summary>
        /// The attached property for a template selector that enables an application writer to provide custom template-selection logic for visual drag feedback.
        /// If this value is not null, the auto generated visual drag feedback is not displayed.
        /// </summary>
        public static readonly DependencyProperty VisualFeedbackTemplateSelectorProperty = DependencyProperty.RegisterAttached
        (
            "VisualFeedbackTemplateSelector",
            typeof(DataTemplateSelector),
            typeof(DragSource)
        );

        /// <summary>
        /// Gets a template selector that enables an application writer to provide custom template-selection logic for visual drag feedback.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <returns>A template selector that enables an application writer to provide custom template-selection logic for visual drag feedback.</returns>
        public static DataTemplateSelector GetVisualFeedbackTemplateSelector(DependencyObject obj)
        {
            return (DataTemplateSelector)obj.GetValue(VisualFeedbackTemplateSelectorProperty);
        }

        /// <summary>
        /// Sets a template selector that enables an application writer to provide custom template-selection logic for visual drag feedback.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <param name="value">A template selector that enables an application writer to provide custom template-selection logic for visual drag feedback.</param>
        public static void SetVisualFeedbackTemplateSelector(DependencyObject obj, DataTemplateSelector value)
        {
            obj.SetValue(VisualFeedbackTemplateSelectorProperty, value);
        }

        #endregion


        #region VisualFeedbackDataContext Attached Property

        /// <summary>
        /// The attached property for an object that is set to the data context of the visual drag feedback.
        /// If this value is null, the drag source's data context is set.
        /// </summary>
        public static readonly DependencyProperty VisualFeedbackDataContextProperty = DependencyProperty.RegisterAttached
        (
            "VisualFeedbackDataContext",
            typeof(object),
            typeof(DragSource)
        );

        /// <summary>
        /// Gets an object that is set to the data context of the visual drag feedback.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <returns>An object that is set to the data context of the visual drag feedback.</returns>
        public static object GetVisualFeedbackDataContext(DependencyObject obj)
        {
            return (object)obj.GetValue(VisualFeedbackDataContextProperty);
        }

        /// <summary>
        /// Sets an object that is set to the data context of the visual drag feedback.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <param name="value">An object that is set to the data context of the visual drag feedback.</param>
        public static void SetVisualFeedbackDataContext(DependencyObject obj, object value)
        {
            obj.SetValue(VisualFeedbackDataContextProperty, value);
        }

        #endregion


        #region VisualFeedbackOffset Attached Property

        /// <summary>
        /// The attached property for an offset that is pointed by a pointing device in the visual drag feedback.
        /// The origin is the upper-left corner of the visual drag feedback.
        /// The x-coordinates increase to the right. The y-coordinates increase to the bottom.
        /// </summary>
        public static readonly DependencyProperty VisualFeedbackOffsetProperty = DependencyProperty.RegisterAttached
        (
            "VisualFeedbackOffset",
            typeof(Point),
            typeof(DragSource),
            new PropertyMetadata(new Point(7, 7))
        );

        /// <summary>
        /// Gets an offset that is pointed by a pointing device in the visual drag feedback.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <returns>An offset that is pointed by a pointing device in the visual drag feedback.</returns>
        public static Point GetVisualFeedbackOffset(DependencyObject obj)
        {
            return (Point)obj.GetValue(VisualFeedbackOffsetProperty);
        }

        /// <summary>
        /// Sets an offset that is pointed by a pointing device in the visual drag feedback.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <param name="value">An offset that is pointed by a pointing device in the visual drag feedback.</param>
        public static void SetVisualFeedbackOffset(DependencyObject obj, Point value)
        {
            obj.SetValue(VisualFeedbackOffsetProperty, value);
        }

        #endregion


        #region VisualFeedbackOpacity Attached Property

        /// <summary>
        /// The attached property for the opacity of the visual drag feedback.
        /// </summary>
        public static readonly DependencyProperty VisualFeedbackOpacityProperty = DependencyProperty.RegisterAttached
        (
            "VisualFeedbackOpacity",
            typeof(double),
            typeof(DragSource),
            new PropertyMetadata(0.5d)
        );

        /// <summary>
        /// Gets the opacity of the visual drag feedback.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <returns>The opacity of the visual drag feedback.</returns>
        public static double GetVisualFeedbackOpacity(DependencyObject obj)
        {
            return (double)obj.GetValue(VisualFeedbackOpacityProperty);
        }

        /// <summary>
        /// Sets the opacity of the visual drag feedback.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <param name="value">The opacity of the visual drag feedback.</param>
        public static void SetVisualFeedbackOpacity(DependencyObject obj, double value)
        {
            obj.SetValue(VisualFeedbackOpacityProperty, value);
        }

        #endregion


        #region VisualFeedbackVisibility Attached Property

        /// <summary>
        /// The attached property for the visual drag feedback visibility.
        /// </summary>
        public static readonly DependencyProperty VisualFeedbackVisibilityProperty = DependencyProperty.RegisterAttached
        (
            "VisualFeedbackVisibility",
            typeof(Visibility),
            typeof(DragSource),
            new PropertyMetadata(Visibility.Visible)
        );

        /// <summary>
        /// Gets the visual drag feedback visibility.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <returns>The visual drag feedback visibility.</returns>
        public static Visibility GetVisualFeedbackVisibility(DependencyObject obj)
        {
            return (Visibility)obj.GetValue(VisualFeedbackVisibilityProperty);
        }

        /// <summary>
        /// Sets the visual drag feedback visibility.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <param name="value">The visual drag feedback visibility.</param>
        public static void SetVisualFeedbackVisibility(DependencyObject obj, Visibility value)
        {
            obj.SetValue(VisualFeedbackVisibilityProperty, value);
        }

        #endregion


        #region VisualFeedbackWidth Attached Property

        /// <summary>
        /// The attached property for the width of the visual drag feedback.
        /// </summary>
        public static readonly DependencyProperty VisualFeedbackWidthProperty = DependencyProperty.RegisterAttached
        (
            "VisualFeedbackWidth",
            typeof(double),
            typeof(DragSource),
            new PropertyMetadata(double.NaN)
        );

        /// <summary>
        /// Gets the width of the visual drag feedback.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <returns>The width of the visual drag feedback.</returns>
        public static double GetVisualFeedbackWidth(DependencyObject obj)
        {
            return (double)obj.GetValue(VisualFeedbackWidthProperty);
        }

        /// <summary>
        /// Sets the width of the visual drag feedback.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <param name="value">The width of the visual drag feedback.</param>
        public static void SetVisualFeedbackWidth(DependencyObject obj, double value)
        {
            obj.SetValue(VisualFeedbackWidthProperty, value);
        }

        #endregion


        #region VisualFeedbackHeight Attached Property

        /// <summary>
        /// The attached property for the height of the visual drag feedback.
        /// </summary>
        public static readonly DependencyProperty VisualFeedbackHeightProperty = DependencyProperty.RegisterAttached
        (
            "VisualFeedbackHeight",
            typeof(double),
            typeof(DragSource),
            new PropertyMetadata(double.NaN)
        );

        /// <summary>
        /// Gets the height of the visual drag feedback.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <returns>The height of the visual drag feedback.</returns>
        public static double GetVisualFeedbackHeight(DependencyObject obj)
        {
            return (double)obj.GetValue(VisualFeedbackHeightProperty);
        }

        /// <summary>
        /// Sets the height of the visual drag feedback.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <param name="value">The height of the visual drag feedback.</param>
        public static void SetVisualFeedbackHeight(DependencyObject obj, double value)
        {
            obj.SetValue(VisualFeedbackHeightProperty, value);
        }

        #endregion


        #region VisualFeedbackMinWidth Attached Property

        /// <summary>
        /// The attached property for the minimum width of the visual drag feedback.
        /// </summary>
        public static readonly DependencyProperty VisualFeedbackMinWidthProperty = DependencyProperty.RegisterAttached
        (
            "VisualFeedbackMinWidth",
            typeof(double),
            typeof(DragSource),
            new PropertyMetadata(0d)
        );

        /// <summary>
        /// Gets the minimum width of the visual drag feedback.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <returns>The minimum width of the visual drag feedback.</returns>
        public static double GetVisualFeedbackMinWidth(DependencyObject obj)
        {
            return (double)obj.GetValue(VisualFeedbackMinWidthProperty);
        }

        /// <summary>
        /// Sets the minimum width of the visual drag feedback.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <param name="value">The minimum width of the visual drag feedback.</param>
        public static void SetVisualFeedbackMinWidth(DependencyObject obj, double value)
        {
            obj.SetValue(VisualFeedbackMinWidthProperty, value);
        }

        #endregion


        #region VisualFeedbackMinHeight Attached Property

        /// <summary>
        /// The attached property for the minimum height of the visual drag feedback.
        /// </summary>
        public static readonly DependencyProperty VisualFeedbackMinHeightProperty = DependencyProperty.RegisterAttached
        (
            "VisualFeedbackMinHeight",
            typeof(double),
            typeof(DragSource),
            new PropertyMetadata(0d)
        );

        /// <summary>
        /// Gets the minimum height of the visual drag feedback.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <returns>The minimum height of the visual drag feedback.</returns>
        public static double GetVisualFeedbackMinHeight(DependencyObject obj)
        {
            return (double)obj.GetValue(VisualFeedbackMinHeightProperty);
        }

        /// <summary>
        /// Sets the minimum height of the visual drag feedback.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <param name="value">The minimum height of the visual drag feedback.</param>
        public static void SetVisualFeedbackMinHeight(DependencyObject obj, double value)
        {
            obj.SetValue(VisualFeedbackMinHeightProperty, value);
        }

        #endregion


        #region VisualFeedbackMaxWidth Attached Property

        /// <summary>
        /// The attached property for the maximum width of the visual drag feedback.
        /// </summary>
        public static readonly DependencyProperty VisualFeedbackMaxWidthProperty = DependencyProperty.RegisterAttached
        (
            "VisualFeedbackMaxWidth",
            typeof(double),
            typeof(DragSource),
            new PropertyMetadata(double.PositiveInfinity)
        );

        /// <summary>
        /// Gets the maximum width of the visual drag feedback.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <returns>The maximum width of the visual drag feedback.</returns>
        public static double GetVisualFeedbackMaxWidth(DependencyObject obj)
        {
            return (double)obj.GetValue(VisualFeedbackMaxWidthProperty);
        }

        /// <summary>
        /// Sets the maximum width of the visual drag feedback.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <param name="value">The maximum width of the visual drag feedback.</param>
        public static void SetVisualFeedbackMaxWidth(DependencyObject obj, double value)
        {
            obj.SetValue(VisualFeedbackMaxWidthProperty, value);
        }

        #endregion


        #region VisualFeedbackMaxHeight Attached Property

        /// <summary>
        /// The attached property for the maximum height of the visual drag feedback.
        /// </summary>
        public static readonly DependencyProperty VisualFeedbackMaxHeightProperty = DependencyProperty.RegisterAttached
        (
            "VisualFeedbackMaxHeight",
            typeof(double),
            typeof(DragSource),
            new PropertyMetadata(double.PositiveInfinity)
        );

        /// <summary>
        /// Gets the maximum height of the visual drag feedback.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <returns>The maximum height of the visual drag feedback.</returns>
        public static double GetVisualFeedbackMaxHeight(DependencyObject obj)
        {
            return (double)obj.GetValue(VisualFeedbackMaxHeightProperty);
        }

        /// <summary>
        /// Sets the maximum height of the visual drag feedback.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <param name="value">The maximum height of the visual drag feedback.</param>
        public static void SetVisualFeedbackMaxHeight(DependencyObject obj, double value)
        {
            obj.SetValue(VisualFeedbackMaxHeightProperty, value);
        }

        #endregion


        #region Initiator ReadOnly Attached Property

        /// <summary>
        /// The readonly attached property key for a value that initiates the dragging.
        /// </summary>
        private static readonly DependencyPropertyKey InitiatorPropertyKey = DependencyProperty.RegisterAttachedReadOnly
        (
            "Initiator",
            typeof(DragInitiator),
            typeof(DragSource),
            new PropertyMetadata(DragInitiator.MouseLeftButton)
        );

        /// <summary>
        /// The readonly attached property for a value that initiates the dragging.
        /// </summary>
        public static readonly DependencyProperty InitiatorProperty = InitiatorPropertyKey.DependencyProperty;

        /// <summary>
        /// Gets a value that initiates the dragging.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <returns>A value that initiates the dragging.</returns>
        public static DragInitiator GetInitiator(DependencyObject obj)
        {
            return (DragInitiator)obj.GetValue(InitiatorProperty);
        }

        /// <summary>
        /// Sets a value that initiates the dragging.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <param name="value">A value that initiates the dragging.</param>
        private static void SetInitiator(DependencyObject obj, DragInitiator value)
        {
            obj.SetValue(InitiatorPropertyKey, value);
        }

        #endregion


        #region ContactPosition ReadOnly Attached Property

        /// <summary>
        /// The readonly attached property key for the contact position in the dragged source.
        /// </summary>
        private static readonly DependencyPropertyKey ContactPositionPropertyKey = DependencyProperty.RegisterAttachedReadOnly
        (
            "ContactPosition",
            typeof(Point),
            typeof(DragSource),
            new PropertyMetadata(new Point())
        );

        /// <summary>
        /// The readonly attached property for the contact position in the dragged source.
        /// </summary>
        public static readonly DependencyProperty ContactPositionProperty = ContactPositionPropertyKey.DependencyProperty;

        /// <summary>
        /// Gets the contact position in the dragged source.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <returns>The contact position in the dragged source.</returns>
        public static Point GetContactPosition(DependencyObject obj)
        {
            return (Point)obj.GetValue(ContactPositionProperty);
        }

        /// <summary>
        /// Sets the contact position in the dragged source.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <param name="value">The contact position in the dragged source.</param>
        private static void SetContactPosition(DependencyObject obj, Point value)
        {
            obj.SetValue(ContactPositionPropertyKey, value);
        }

        #endregion


        #region DraggedPosition ReadOnly Attached Property

        /// <summary>
        /// The readonly attached property key for the dragged position in the dragged source.
        /// </summary>
        /// <remarks>
        /// This value indicates the coordiate that the dragging is started.
        /// MinimumHorizontalDragDistance and MinimumVerticalDragDistance are used to calculate this value.
        /// It is in the dragged source cooridates.
        /// </remarks>
        /// <seealso cref="MinimumHorizontalDragDistanceProperty"/>
        /// <seealso cref="MinimumVerticalDragDistanceProperty"/>
        private static readonly DependencyPropertyKey DraggedPositionPropertyKey = DependencyProperty.RegisterAttachedReadOnly
        (
            "DraggedPosition",
            typeof(Point),
            typeof(DragSource),
            new PropertyMetadata(new Point())
        );

        /// <summary>
        /// The readonly attached property for the dragged position in the dragged source.
        /// </summary>
        public static readonly DependencyProperty DraggedPositionProperty = DraggedPositionPropertyKey.DependencyProperty;

        /// <summary>
        /// Gets the dragged position in the dragged source.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <returns>The dragged position in the dragged source.</returns>
        public static Point GetDraggedPosition(DependencyObject obj)
        {
            return (Point)obj.GetValue(DraggedPositionProperty);
        }

        /// <summary>
        /// Sets the dragged position in the dragged source.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <param name="value">The dragged position in the dragged source.</param>
        private static void SetDraggedPosition(DependencyObject obj, Point value)
        {
            obj.SetValue(DraggedPositionPropertyKey, value);
        }

        #endregion


        #region AllowedEffects Attached Property

        /// <summary>
        /// The attached property for a value indicating permitted effects of the drag-and-drop operation.
        /// </summary>
        public static readonly DependencyProperty AllowedEffectsProperty = DependencyProperty.RegisterAttached
        (
            "AllowedEffects",
            typeof(DragDropEffects),
            typeof(DragSource),
            new PropertyMetadata(DragDropEffects.Copy | DragDropEffects.Move | DragDropEffects.Scroll)
        );

        /// <summary>
        /// Gets a value indicating permitted effects of the drag-and-drop operation.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <returns>A value indicating permitted effects of the drag-and-drop operation.</returns>
        public static DragDropEffects GetAllowedEffects(DependencyObject obj)
        {
            return (DragDropEffects)obj.GetValue(AllowedEffectsProperty);
        }

        /// <summary>
        /// Sets a value indicating permitted effects of the drag-and-drop operation.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <param name="value">A value indicating permitted effects of the drag-and-drop operation.</param>
        public static void SetAllowedEffects(DependencyObject obj, DragDropEffects value)
        {
            obj.SetValue(AllowedEffectsProperty, value);
        }

        #endregion


        #region MinimumHorizontalDragDistance & MinimumVerticalDragDistance Attached Property

        /// <summary>
        /// The attached property for the width of a rectangle centered on a drag point to allow for limited movement of the pointer before a drag operation begins.
        /// </summary>
        public static readonly DependencyProperty MinimumHorizontalDragDistanceProperty = DependencyProperty.RegisterAttached
        (
            "MinimumHorizontalDragDistance",
            typeof(double),
            typeof(DragSource),
            new PropertyMetadata(SystemParameters.MinimumHorizontalDragDistance)
        );

        /// <summary>
        /// Gets the width of a rectangle centered on a drag point to allow for limited movement of the pointer before a drag operation begins.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <returns>The width of a rectangle centered on a drag point to allow for limited movement of the pointer before a drag operation begins.</returns>
        public static double GetMinimumHorizontalDragDistance(UIElement obj)
        {
            return (double)obj.GetValue(MinimumHorizontalDragDistanceProperty);
        }

        /// <summary>
        /// Sets the width of a rectangle centered on a drag point to allow for limited movement of the pointer before a drag operation begins.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <param name="value">The width of a rectangle centered on a drag point to allow for limited movement of the pointer before a drag operation begins.</param>
        public static void SetMinimumHorizontalDragDistance(UIElement obj, double value)
        {
            obj.SetValue(MinimumHorizontalDragDistanceProperty, value);
        }


        /// <summary>
        /// The attached property for the height of a rectangle centered on a drag point to allow for limited movement of the pointer before a drag operation begins.
        /// </summary>
        public static readonly DependencyProperty MinimumVerticalDragDistanceProperty = DependencyProperty.RegisterAttached
        (
            "MinimumVerticalDragDistance",
            typeof(double),
            typeof(DragSource),
            new PropertyMetadata(SystemParameters.MinimumVerticalDragDistance)
        );

        /// <summary>
        /// Gets the height of a rectangle centered on a drag point to allow for limited movement of the pointer before a drag operation begins.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <returns>The height of a rectangle centered on a drag point to allow for limited movement of the pointer before a drag operation begins.</returns>
        public static double GetMinimumVerticalDragDistance(UIElement obj)
        {
            return (double)obj.GetValue(MinimumVerticalDragDistanceProperty);
        }

        /// <summary>
        /// Sets the height of a rectangle centered on a drag point to allow for limited movement of the pointer before a drag operation begins.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <param name="value">The height of a rectangle centered on a drag point to allow for limited movement of the pointer before a drag operation begins.</param>
        public static void SetMinimumVerticalDragDistance(UIElement obj, double value)
        {
            obj.SetValue(MinimumVerticalDragDistanceProperty, value);
        }

        #endregion


        #region IsDragging ReadOnly Attached Property

        /// <summary>
        /// The readonly attached property key for a value that indicates whether the drag is in progress.
        /// </summary>
        private static readonly DependencyPropertyKey IsDraggingPropertyKey = DependencyProperty.RegisterAttachedReadOnly
        (
            "IsDragging",
            typeof(bool),
            typeof(DragSource),
            new PropertyMetadata(false)
        );

        /// <summary>
        /// The readonly attached property for a value that indicates whether the drag is in progress.
        /// </summary>
        public static readonly DependencyProperty IsDraggingProperty = IsDraggingPropertyKey.DependencyProperty;

        /// <summary>
        /// Gets a value that indicates whether the drag is in progress.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <returns>A value that indicates whether the drag is in progress.</returns>
        public static bool GetIsDragging(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsDraggingProperty);
        }

        /// <summary>
        /// Sets a value that indicates whether the drag is in progress.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <param name="value">A value that indicates whether the drag is in progress.</param>
        private static void SetIsDragging(DependencyObject obj, bool value)
        {
            obj.SetValue(IsDraggingPropertyKey, value);
        }

        #endregion


        #region DragSensing Event Related

        /// <summary>
        /// Identifies the PreviewDragSensing routed event that is raised when drag gesture recognition is in progress.
        /// </summary>
        public static readonly RoutedEvent PreviewDragSensingEvent = EventManager.RegisterRoutedEvent
        (
            "PreviewDragSensing",
            RoutingStrategy.Tunnel,
            typeof(EventHandler<DragSourceDragSensingEventArgs>),
            typeof(DragSource)
        );

        /// <summary>
        /// Adds an event handler for the PreviewDragSensing event.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <param name="handler">The event handler.</param>
        public static void AddPreviewDragSensingHandler(UIElement obj, EventHandler<DragSourceDragSensingEventArgs> handler)
        {
            obj.AddHandler(PreviewDragSensingEvent, handler);
        }

        /// <summary>
        /// Removes the event handler for the PreviewDragSensing event.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <param name="handler">The event handler.</param>
        public static void RemovePreviewDragSensingHandler(UIElement obj, EventHandler<DragSourceDragSensingEventArgs> handler)
        {
            obj.RemoveHandler(PreviewDragSensingEvent, handler);
        }


        /// <summary>
        /// Identifies the DragSensing routed event that is raised when drag gesture recognition is in progress.
        /// </summary>
        public static readonly RoutedEvent DragSensingEvent = EventManager.RegisterRoutedEvent
        (
            "DragSensing",
            RoutingStrategy.Bubble,
            typeof(EventHandler<DragSourceDragSensingEventArgs>),
            typeof(DragSource)
        );

        /// <summary>
        /// Adds an event handler for the DragSensing event.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <param name="handler">The event handler.</param>
        public static void AddDragSensingHandler(UIElement obj, EventHandler<DragSourceDragSensingEventArgs> handler)
        {
            obj.AddHandler(DragSensingEvent, handler);
        }

        /// <summary>
        /// Removes the event handler for the DragSensing event.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <param name="handler">The event handler.</param>
        public static void RemoveDragSensingHandler(UIElement obj, EventHandler<DragSourceDragSensingEventArgs> handler)
        {
            obj.RemoveHandler(DragSensingEvent, handler);
        }


        /// <summary>
        /// Raises the PreviewDragSensingEvent and DragSensingEvent.
        /// </summary>
        /// <param name="target">The target element to raise the routed event.</param>
        /// <param name="initiator">The drag initiator.</param>
        /// <param name="contactPosition">The contact position in the dragged source.</param>
        /// <param name="draggedPosition">The dragged position in the dragged source.</param>
        /// <returns>True if it is not canceled; otherwise, false.</returns>
        private static bool RaiseDragSensingEvent(UIElement target, DragInitiator initiator, Point contactPosition, Point draggedPosition)
        {
            Debug.Assert(target != null);


            // Creates an event argument.
            DragSourceDragSensingEventArgs dragSensingEventArgs = new DragSourceDragSensingEventArgs
            (
                PreviewDragSensingEvent,
                target,
                initiator,
                contactPosition,
                draggedPosition
            );


            // Raises the PreviewDragSensing routed event.
            target.RaiseEvent(dragSensingEventArgs);


            // Raises the DragSensing routed event.
            dragSensingEventArgs.RoutedEvent = DragSensingEvent;
            target.RaiseEvent(dragSensingEventArgs);


            // If user cancels the drag
            if (dragSensingEventArgs.Cancel)
                return false;


            return true;
        }

        #endregion


        #region Dragging Event Related

        /// <summary>
        /// Identifies the PreviewDragging routed event that is raised when a dragging is about to start.
        /// </summary>
        public static readonly RoutedEvent PreviewDraggingEvent = EventManager.RegisterRoutedEvent
        (
            "PreviewDragging",
            RoutingStrategy.Tunnel,
            typeof(EventHandler<DragSourceDraggingEventArgs>),
            typeof(DragSource)
        );

        /// <summary>
        /// Adds an event handler for the PreviewDragging event.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <param name="handler">The event handler.</param>
        public static void AddPreviewDraggingHandler(UIElement obj, EventHandler<DragSourceDraggingEventArgs> handler)
        {
            obj.AddHandler(PreviewDraggingEvent, handler);
        }

        /// <summary>
        /// Removes the event handler for the PreviewDragging event.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <param name="handler">The event handler.</param>
        public static void RemovePreviewDraggingHandler(UIElement obj, EventHandler<DragSourceDraggingEventArgs> handler)
        {
            obj.RemoveHandler(PreviewDraggingEvent, handler);
        }


        /// <summary>
        /// Identifies the Dragging routed event that is raised when a dragging is about to start.
        /// </summary>
        public static readonly RoutedEvent DraggingEvent = EventManager.RegisterRoutedEvent
        (
            "Dragging",
            RoutingStrategy.Bubble,
            typeof(EventHandler<DragSourceDraggingEventArgs>),
            typeof(DragSource)
        );

        /// <summary>
        /// Adds an event handler for the Dragging event.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <param name="handler">The event handler.</param>
        public static void AddDraggingHandler(UIElement obj, EventHandler<DragSourceDraggingEventArgs> handler)
        {
            obj.AddHandler(DraggingEvent, handler);
        }

        /// <summary>
        /// Removes the event handler for the Dragging event.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <param name="handler">The event handler.</param>
        public static void RemoveDraggingHandler(UIElement obj, EventHandler<DragSourceDraggingEventArgs> handler)
        {
            obj.RemoveHandler(DraggingEvent, handler);
        }


        /// <summary>
        /// Raises the PreviewDraggingEvent and DraggingEvent.
        /// The context instance must be initialized.
        /// </summary>
        /// <param name="target">The target element to raise the routed event.</param>
        /// <param name="initiator">The drag initiator.</param>
        /// <param name="contactPosition">The contact position in the dragged source.</param>
        /// <param name="draggedPosition">The dragged position in the dragged source.</param>
        /// <param name="context">The context.</param>
        /// <returns>True if it is not canceled; otherwise, false.</returns>
        private static bool RaiseDraggingEvent(UIElement target, DragInitiator initiator, Point contactPosition, Point draggedPosition, IDragSourceDraggingEventArgsContext context)
        {
            Debug.Assert(target != null);
            Debug.Assert(context != null);


            // Creates an event argument.
            DragSourceDraggingEventArgs draggingEventArgs = new DragSourceDraggingEventArgs
            (
                PreviewDraggingEvent,
                target,
                initiator,
                contactPosition,
                draggedPosition,
                context
            );


            // Raises the PreviewDragging routed event.
            target.RaiseEvent(draggingEventArgs);


            // Raises the Dragging routed event.
            draggingEventArgs.RoutedEvent = DraggingEvent;
            target.RaiseEvent(draggingEventArgs);


            // If user cancels the drag
            if (draggingEventArgs.Cancel)
                return false;


            return true;
        }

        #endregion


        #region GiveFeedback Event Related

        /// <summary>
        /// Identifies the PreviewGiveFeedback routed event that is raised when the DragDrop.PreviewGiveFeedback event is raised.
        /// </summary>
        public static readonly RoutedEvent PreviewGiveFeedbackEvent = EventManager.RegisterRoutedEvent
        (
            "PreviewGiveFeedback",
            RoutingStrategy.Tunnel,
            typeof(EventHandler<DragSourceGiveFeedbackEventArgs>),
            typeof(DragSource)
        );

        /// <summary>
        /// Adds an event handler for the PreviewGiveFeedback event.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <param name="handler">The event handler.</param>
        public static void AddPreviewGiveFeedbackHandler(UIElement obj, EventHandler<DragSourceGiveFeedbackEventArgs> handler)
        {
            obj.AddHandler(PreviewGiveFeedbackEvent, handler);
        }

        /// <summary>
        /// Removes the event handler for the PreviewGiveFeedback event.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <param name="handler">The event handler.</param>
        public static void RemovePreviewGiveFeedbackHandler(UIElement obj, EventHandler<DragSourceGiveFeedbackEventArgs> handler)
        {
            obj.RemoveHandler(PreviewGiveFeedbackEvent, handler);
        }


        /// <summary>
        /// Identifies the GiveFeedback routed event that is raised when the DragDrop.GiveFeedback event is raised.
        /// </summary>
        public static readonly RoutedEvent GiveFeedbackEvent = EventManager.RegisterRoutedEvent
        (
            "GiveFeedback",
            RoutingStrategy.Bubble,
            typeof(EventHandler<DragSourceGiveFeedbackEventArgs>),
            typeof(DragSource)
        );

        /// <summary>
        /// Adds an event handler for the GiveFeedback event.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <param name="handler">The event handler.</param>
        public static void AddGiveFeedbackHandler(UIElement obj, EventHandler<DragSourceGiveFeedbackEventArgs> handler)
        {
            obj.AddHandler(GiveFeedbackEvent, handler);
        }

        /// <summary>
        /// Removes the event handler for the GiveFeedback event.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <param name="handler">The event handler.</param>
        public static void RemoveGiveFeedbackHandler(UIElement obj, EventHandler<DragSourceGiveFeedbackEventArgs> handler)
        {
            obj.RemoveHandler(GiveFeedbackEvent, handler);
        }


        /// <summary>
        /// Raises the PreviewGiveFeedbackEvent or GiveFeedbackEvent.
        /// The context instance must be initialized.
        /// </summary>
        /// <param name="isPreview">Whether the event is the PreviewGiveFeedback.</param>
        /// <param name="target">The target element to raise the routed event.</param>
        /// <param name="initiator">The drag initiator.</param>
        /// <param name="contactPosition">The contact position in the dragged source.</param>
        /// <param name="draggedPosition">The dragged position in the dragged source.</param>
        /// <param name="context">The context.</param>
        /// <param name="giveFeedbackEventArgs">The GiveFeedbackEventArgs.</param>
        private static void RaiseGiveFeedbackEvent(bool isPreview, UIElement target, DragInitiator initiator, Point contactPosition, Point draggedPosition,
                IDragSourceGiveFeedbackEventArgsContext context, GiveFeedbackEventArgs giveFeedbackEventArgs)
        {
            Debug.Assert(target != null);
            Debug.Assert(context != null);
            Debug.Assert(giveFeedbackEventArgs != null);

            // Creates an event argument.
            DragSourceGiveFeedbackEventArgs eventArgs = new DragSourceGiveFeedbackEventArgs
            (
                isPreview ? PreviewGiveFeedbackEvent : GiveFeedbackEvent,
                target,
                initiator,
                contactPosition,
                draggedPosition,
                context,
                giveFeedbackEventArgs
            );

            // Raises the PreviewGiveFeedback or GiveFeedback routed event.
            target.RaiseEvent(eventArgs);

            // If it is handled, sets the Handled of the giveFeedbackEventArgs to true.
            if (eventArgs.Handled)
                giveFeedbackEventArgs.Handled = true;

            // Updates the VisualFeedbackHost.
            context.UpdateVisualFeedbackHost();
        }

        #endregion


        #region QueryContinueDrag Event Related

        /// <summary>
        /// Identifies the PreviewQueryContinueDrag routed event that is raised the DragDrop.PreviewQueryContinueDrag event is raised.
        /// </summary>
        public static readonly RoutedEvent PreviewQueryContinueDragEvent = EventManager.RegisterRoutedEvent
        (
            "PreviewQueryContinueDrag",
            RoutingStrategy.Tunnel,
            typeof(EventHandler<DragSourceQueryContinueDragEventArgs>),
            typeof(DragSource)
        );

        /// <summary>
        /// Adds an event handler for the PreviewQueryContinueDrag event.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <param name="handler">The event handler.</param>
        public static void AddPreviewQueryContinueDragHandler(UIElement obj, EventHandler<DragSourceQueryContinueDragEventArgs> handler)
        {
            obj.AddHandler(PreviewQueryContinueDragEvent, handler);
        }

        /// <summary>
        /// Removes the event handler for the PreviewQueryContinueDrag event.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <param name="handler">The event handler.</param>
        public static void RemovePreviewQueryContinueDragHandler(UIElement obj, EventHandler<DragSourceQueryContinueDragEventArgs> handler)
        {
            obj.RemoveHandler(PreviewQueryContinueDragEvent, handler);
        }


        /// <summary>
        /// Identifies the QueryContinueDrag routed event that is raised the DragDrop.QueryContinueDrag event is raised.
        /// </summary>
        public static readonly RoutedEvent QueryContinueDragEvent = EventManager.RegisterRoutedEvent
        (
            "QueryContinueDrag",
            RoutingStrategy.Bubble,
            typeof(EventHandler<DragSourceQueryContinueDragEventArgs>),
            typeof(DragSource)
        );

        /// <summary>
        /// Adds an event handler for the QueryContinueDrag event.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <param name="handler">The event handler.</param>
        public static void AddQueryContinueDragHandler(UIElement obj, EventHandler<DragSourceQueryContinueDragEventArgs> handler)
        {
            obj.AddHandler(QueryContinueDragEvent, handler);
        }

        /// <summary>
        /// Removes the event handler for the QueryContinueDrag event.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <param name="handler">The event handler.</param>
        public static void RemoveQueryContinueDragHandler(UIElement obj, EventHandler<DragSourceQueryContinueDragEventArgs> handler)
        {
            obj.RemoveHandler(QueryContinueDragEvent, handler);
        }


        /// <summary>
        /// Raises the PreviewQueryContinueDragEvent or QueryContinueDragEvent.
        /// The context instance must be initialized.
        /// </summary>
        /// <param name="isPreview">Whether the event is the PreviewQueryContinueDragEvent.</param>
        /// <param name="target">The target element to raise the routed event.</param>
        /// <param name="initiator">The drag initiator.</param>
        /// <param name="contactPosition">The contact position in the dragged source.</param>
        /// <param name="draggedPosition">The dragged position in the dragged source.</param>
        /// <param name="context">The context.</param>
        /// <param name="queryContinueDragEventArgs">The QueryContinueDragEventArgs.</param>
        private static void RaiseQueryContinueDragEvent(bool isPreview, UIElement target, DragInitiator initiator, Point contactPosition, Point draggedPosition,
                IDragSourceQueryContinueDragEventArgsContext context, QueryContinueDragEventArgs queryContinueDragEventArgs)
        {
            Debug.Assert(target != null);
            Debug.Assert(context != null);
            Debug.Assert(queryContinueDragEventArgs != null);

            // Creates an event argument.
            DragSourceQueryContinueDragEventArgs eventArgs = new DragSourceQueryContinueDragEventArgs
            (
                isPreview ? PreviewQueryContinueDragEvent : QueryContinueDragEvent,
                target,
                initiator,
                contactPosition,
                draggedPosition,
                context,
                queryContinueDragEventArgs
            );

            // Raises the PreviewQueryContinueDrag or QueryContinueDrag routed event.
            target.RaiseEvent(eventArgs);

            // If it is handled, sets the Handled of the queryContinueDragEventArgs to true.
            if (eventArgs.Handled)
                queryContinueDragEventArgs.Handled = true;
        }

        #endregion


        #region Dropped Event Related

#pragma warning disable 618     // Disables the obsolete warning.
        /// <summary>
        /// Identifies the PreviewDropped routed event that is raised when a drag-and-drop operation is finished.
        /// </summary>
        [Obsolete("Instead, use the Dragged event.")]
        public static readonly RoutedEvent PreviewDroppedEvent = EventManager.RegisterRoutedEvent
        (
            "PreviewDropped",
            RoutingStrategy.Tunnel,
            typeof(EventHandler<DragSourceDroppedEventArgs>),
            typeof(DragSource)
        );
#pragma warning restore 618     // Restores the obsolete warning.

        /// <summary>
        /// Adds an event handler for the PreviewDropped event.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <param name="handler">The event handler.</param>
        [Obsolete("Instead, use the Dragged event.")]
        public static void AddPreviewDroppedHandler(UIElement obj, EventHandler<DragSourceDroppedEventArgs> handler)
        {
#pragma warning disable 618     // Disables the obsolete warning.
            obj.AddHandler(PreviewDroppedEvent, handler);
#pragma warning restore 618     // Restores the obsolete warning.
        }

        /// <summary>
        /// Removes the event handler for the PreviewDropped event.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <param name="handler">The event handler.</param>
        [Obsolete("Instead, use the Dragged event.")]
        public static void RemovePreviewDroppedHandler(UIElement obj, EventHandler<DragSourceDroppedEventArgs> handler)
        {
#pragma warning disable 618     // Disables the obsolete warning.
            obj.RemoveHandler(PreviewDroppedEvent, handler);
#pragma warning restore 618     // Restores the obsolete warning.
        }


#pragma warning disable 618     // Disables the obsolete warning.
        /// <summary>
        /// Identifies the Dropped routed event that is raised when a drag-and-drop operation is finished.
        /// </summary>
        [Obsolete("Instead, use the Dragged event.")]
        public static readonly RoutedEvent DroppedEvent = EventManager.RegisterRoutedEvent
        (
            "Dropped",
            RoutingStrategy.Bubble,
            typeof(EventHandler<DragSourceDroppedEventArgs>),
            typeof(DragSource)
        );
#pragma warning restore 618     // Restores the obsolete warning.

        /// <summary>
        /// Adds an event handler for the Dropped event.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <param name="handler">The event handler.</param>
        [Obsolete("Instead, use the Dragged event.")]
        public static void AddDroppedHandler(UIElement obj, EventHandler<DragSourceDroppedEventArgs> handler)
        {
#pragma warning disable 618     // Disables the obsolete warning.
            obj.AddHandler(DroppedEvent, handler);
#pragma warning restore 618     // Restores the obsolete warning.
        }

        /// <summary>
        /// Removes the event handler for the Dropped event.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <param name="handler">The event handler.</param>
        [Obsolete("Instead, use the Dragged event.")]
        public static void RemoveDroppedHandler(UIElement obj, EventHandler<DragSourceDroppedEventArgs> handler)
        {
#pragma warning disable 618     // Disables the obsolete warning.
            obj.RemoveHandler(DroppedEvent, handler);
#pragma warning restore 618     // Restores the obsolete warning.
        }

        #endregion


        #region Dragged Event Related

        /// <summary>
        /// Identifies the PreviewDragged routed event that is raised when a drag-and-drop operation is finished.
        /// </summary>
        public static readonly RoutedEvent PreviewDraggedEvent = EventManager.RegisterRoutedEvent
        (
            "PreviewDragged",
            RoutingStrategy.Tunnel,
            typeof(EventHandler<DragSourceDraggedEventArgs>),
            typeof(DragSource)
        );

        /// <summary>
        /// Adds an event handler for the PreviewDragged event.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <param name="handler">The event handler.</param>
        public static void AddPreviewDraggedHandler(UIElement obj, EventHandler<DragSourceDraggedEventArgs> handler)
        {
            obj.AddHandler(PreviewDraggedEvent, handler);
        }

        /// <summary>
        /// Removes the event handler for the PreviewDragged event.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <param name="handler">The event handler.</param>
        public static void RemovePreviewDraggedHandler(UIElement obj, EventHandler<DragSourceDraggedEventArgs> handler)
        {
            obj.RemoveHandler(PreviewDraggedEvent, handler);
        }


        /// <summary>
        /// Identifies the Dragged routed event that is raised when a drag-and-drop operation is finished.
        /// </summary>
        public static readonly RoutedEvent DraggedEvent = EventManager.RegisterRoutedEvent
        (
            "Dragged",
            RoutingStrategy.Bubble,
            typeof(EventHandler<DragSourceDraggedEventArgs>),
            typeof(DragSource)
        );

        /// <summary>
        /// Adds an event handler for the Dragged event.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <param name="handler">The event handler.</param>
        public static void AddDraggedHandler(UIElement obj, EventHandler<DragSourceDraggedEventArgs> handler)
        {
            obj.AddHandler(DraggedEvent, handler);
        }

        /// <summary>
        /// Removes the event handler for the Dragged event.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <param name="handler">The event handler.</param>
        public static void RemoveDraggedHandler(UIElement obj, EventHandler<DragSourceDraggedEventArgs> handler)
        {
            obj.RemoveHandler(DraggedEvent, handler);
        }


        /// <summary>
        /// Raises the PreviewDraggedEvent and DraggedEvent.
        /// The context instance must be initialized.
        /// </summary>
        /// <param name="target">The target element to raise the routed event.</param>
        /// <param name="initiator">The drag initiator.</param>
        /// <param name="contactPosition">The contact position in the dragged source.</param>
        /// <param name="draggedPosition">The dragged position in the dragged source.</param>
        /// <param name="context">The context.</param>
        /// <param name="finalEffects">The value that is returned by the DragDrop.DoDragDrop method.</param>
        private static void RaiseDraggedEvent(UIElement target, DragInitiator initiator, Point contactPosition, Point draggedPosition,
                IDragSourceDraggedEventArgsContext context, DragDropEffects finalEffects)
        {
            Debug.Assert(target != null);
            Debug.Assert(context != null);

            {
                // Creates an event argument.
                DragSourceDraggedEventArgs eventArgs = new DragSourceDraggedEventArgs
                (
                    PreviewDraggedEvent,
                    target,
                    initiator,
                    contactPosition,
                    draggedPosition,
                    context,
                    finalEffects
                );

                // Raises the PreviewDragged routed event.
                target.RaiseEvent(eventArgs);

                // Raises the Dragged routed event.
                eventArgs.RoutedEvent = DraggedEvent;
                target.RaiseEvent(eventArgs);
            }

#pragma warning disable 618     // Disables the obsolete warning.
            // Raises the Dropped event for backward compatibility.
            {
                // Creates an event argument.
                DragSourceDroppedEventArgs eventArgs = new DragSourceDroppedEventArgs
                (
                    PreviewDroppedEvent,
                    target,
                    initiator,
                    contactPosition,
                    draggedPosition,
                    context,
                    finalEffects
                );

                // Raises the PreviewDropped routed event.
                target.RaiseEvent(eventArgs);

                // Raises the Dropped routed event.
                eventArgs.RoutedEvent = DroppedEvent;
                target.RaiseEvent(eventArgs);
            }
#pragma warning restore 618     // Restores the obsolete warning.
        }

        #endregion


        #region IsEnoughToStartDrag

        /// <summary>
        /// Checks whether the movement distance is enough to start a drag.
        /// </summary>
        /// <param name="minDragDistance">The size of a rectangle centered on a drag position to allow for limited movement of the pointer before a drag operation begins.</param>
        /// <param name="startPosition">The start location.</param>
        /// <param name="draggedPosition">The dragged location.</param>
        /// <returns>True if it is enough to start a drag; otherwise, false.</returns>
        public static bool IsEnoughToStartDrag(Vector minDragDistance, Point startPosition, Point draggedPosition)
        {
            return (Math.Abs(startPosition.X - draggedPosition.X) > minDragDistance.X / 2)
                || (Math.Abs(startPosition.Y - draggedPosition.Y) > minDragDistance.Y / 2);
        }

        #endregion
    }
}
