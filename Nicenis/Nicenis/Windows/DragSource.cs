/*
 * Author	JO Hyeong-Ryeol
 * Since	2013.03.27
 * Version	$Id$
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

namespace Nicenis.Windows
{
    #region DragInitiator related

    /// <summary>
    /// Defines drag initiator.
    /// </summary>
    public enum DragInitiator
    {
        /// <summary>
        /// The left mouse button.
        /// </summary>
        MouseLeftButton = 0x00000001,

        /// <summary>
        /// The middle mouse button.
        /// </summary>
        MouseMiddleButton = 0x00000002,

        /// <summary>
        /// The right mouse button.
        /// </summary>
        MouseRightButton = 0x00000004,

        /// <summary>
        /// The first extended mouse button.
        /// </summary>
        MouseXButton1 = 0x00000008,

        /// <summary>
        /// The second extended mouse button.
        /// </summary>
        MouseXButton2 = 0x00000010,
    }

    /// <summary>
    /// Defines bitwise-ored drag initiators.
    /// </summary>
    [Flags]
    public enum DragInitiators
    {
        /// <summary>
        /// The left mouse button.
        /// </summary>
        MouseLeftButton = DragInitiator.MouseLeftButton,

        /// <summary>
        /// The middle mouse button.
        /// </summary>
        MouseMiddleButton = DragInitiator.MouseMiddleButton,

        /// <summary>
        /// The right mouse button.
        /// </summary>
        MouseRightButton = DragInitiator.MouseRightButton,

        /// <summary>
        /// The first extended mouse button.
        /// </summary>
        MouseXButton1 = DragInitiator.MouseXButton1,

        /// <summary>
        /// The second extended mouse button.
        /// </summary>
        MouseXButton2 = DragInitiator.MouseXButton2,

        /// <summary>
        /// All mouse related drag initiators.
        /// </summary>
        Mouse = MouseLeftButton
                | MouseMiddleButton
                | MouseRightButton
                | MouseXButton1
                | MouseXButton2,

        /// <summary>
        /// The default.
        /// </summary>
        Default = MouseLeftButton,

        /// <summary>
        /// All drag initiators.
        /// </summary>
        All = Mouse,
    }

    /// <summary>
    /// Provides DragInitiator related extension methods.
    /// </summary>
    public static class DragInitiatorHelper
    {
        /// <summary>
        /// Converts a MouseButton enumeration to the DragInitiator enumeration.
        /// </summary>
        /// <param name="mouseButton">The MouseButton enumeration.</param>
        /// <returns>The converted DragInitiator.</returns>
        public static DragInitiator ToDragInitiator(this MouseButton mouseButton)
        {
            switch (mouseButton)
            {
                case MouseButton.Left:
                    return DragInitiator.MouseLeftButton;

                case MouseButton.Middle:
                    return DragInitiator.MouseMiddleButton;

                case MouseButton.Right:
                    return DragInitiator.MouseRightButton;

                case MouseButton.XButton1:
                    return DragInitiator.MouseXButton1;

                case MouseButton.XButton2:
                    return DragInitiator.MouseXButton2;
            }

            throw new InvalidOperationException
            (
                string.Format("The MouseButton '{0}' is unknown.", mouseButton.ToString())
            );
        }

        /// <summary>
        /// Converts a MouseButton enumeration to the DragInitiators enumeration.
        /// </summary>
        /// <param name="mouseButton">The MouseButton enumeration.</param>
        /// <returns>The converted DragInitiators.</returns>
        public static DragInitiators ToDragInitiators(this MouseButton mouseButton)
        {
            return (DragInitiators)ToDragInitiator(mouseButton);
        }

        /// <summary>
        /// Converts a DragInitiator enumeration to the MouseButton enumeration.
        /// </summary>
        /// <param name="dragInitiator">The DragInitiator enumeration.</param>
        /// <returns>The converted MouseButton.</returns>
        public static MouseButton ToMouseButton(this DragInitiator dragInitiator)
        {
            switch (dragInitiator)
            {
                case DragInitiator.MouseLeftButton:
                    return MouseButton.Left;

                case DragInitiator.MouseMiddleButton:
                    return MouseButton.Middle;

                case DragInitiator.MouseRightButton:
                    return MouseButton.Right;

                case DragInitiator.MouseXButton1:
                    return MouseButton.XButton1;

                case DragInitiator.MouseXButton2:
                    return MouseButton.XButton2;
            }

            throw new InvalidOperationException
            (
                string.Format
                (
                    "The DragInitiator '{0}' can not be converted into MouseButton.",
                    dragInitiator.ToString()
                )
            );
        }

        /// <summary>
        /// Returns whether the mouse button specified by the dragInitiator is pressed or not.
        /// </summary>
        /// <param name="dragInitiator">The DragInitiator enumeration.</param>
        /// <param name="e">The MouseEventArgs.</param>
        /// <returns>True if it is pressed; otherwise false.</returns>
        internal static bool IsStillPressed(this DragInitiator dragInitiator, MouseEventArgs e)
        {
            Debug.Assert(e != null);

            switch (dragInitiator)
            {
                case DragInitiator.MouseLeftButton:
                    return e.LeftButton == MouseButtonState.Pressed;

                case DragInitiator.MouseMiddleButton:
                    return e.MiddleButton == MouseButtonState.Pressed;

                case DragInitiator.MouseRightButton:
                    return e.RightButton == MouseButtonState.Pressed;

                case DragInitiator.MouseXButton1:
                    return e.XButton1 == MouseButtonState.Pressed;

                case DragInitiator.MouseXButton2:
                    return e.XButton2 == MouseButtonState.Pressed;
            }

            throw new InvalidOperationException
            (
                string.Format
                (
                    "The DragInitiator '{0}' is unknown.",
                    dragInitiator.ToString()
                )
            );
        }
    }

    #endregion


    #region DragSource event arguments related

    /// <summary>
    /// Internal Use Only.
    /// The base class for DragSource related event argument classes.
    /// </summary>
    public abstract class DragSourceEventArgsBase : RoutedEventArgs
    {
        #region Constructors

        /// <summary>
        /// Initialize a new instance of the DragResizerEventArgsBase class.
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
        /// Gets a value that initiates dragging.
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
        /// It is in the dragged source cooridates.
        /// </remarks>
        /// <seealso cref="MinimumHorizontalDragDistance"/>
        /// <seealso cref="MinimumVerticalDragDistance"/>
        public Point DraggedPosition { get; private set; }

        #endregion
    }


    public class DragSourceDragSensingEventArgs : DragSourceEventArgsBase
    {
        #region Constructors

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

    public class DragSourceDraggingEventArgs : DragSourceEventArgsBase
    {
        IDragSourceDraggingEventArgsContext _context;


        #region Constructors

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
        /// One of the DragDropEffects values that specifies permitted effects of the drag-and-drop operation.
        /// </summary>
        public DragDropEffects AllowedEffects
        {
            get { return _context.AllowedEffects; }
            set { _context.AllowedEffects = value; }
        }

        /// <summary>
        /// A data object that contains the data being dragged.
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
        /// Gets or sets an object that is set to the content of the window for visual drag feedback.
        /// </summary>
        public object VisualFeedback
        {
            get { return _context.VisualFeedback; }
            set { _context.VisualFeedback = value; }
        }

        /// <summary>
        /// Gets or sets a data template used to display the content of the window for visual drag feedback.
        /// </summary>
        public DataTemplate VisualFeedbackTemplate
        {
            get { return _context.VisualFeedbackTemplate; }
            set { _context.VisualFeedbackTemplate = value; }
        }

        /// <summary>
        /// Gets or sets a template selector that enables an application writer to provide custom template-selection logic for visual drag feedback.
        /// </summary>
        public DataTemplateSelector VisualFeedbackTemplateSelector
        {
            get { return _context.VisualFeedbackTemplateSelector; }
            set { _context.VisualFeedbackTemplateSelector = value; }
        }

        /// <summary>
        /// Gets or sets an object that is set to the data context of the window for visual drag feedback.
        /// If this value is null, the drag source's data context is set.
        /// </summary>
        public object VisualFeedbackDataContext
        {
            get { return _context.VisualFeedbackDataContext; }
            set { _context.VisualFeedbackDataContext = value; }
        }

        /// <summary>
        /// Gets or sets an offset that is pointed by pointing device in the visual drag feedback.
        /// The origin is the upper-left corner of the visual drag feedback.
        /// The x-coordinates increase to the right. The y-coordinates increase to the bottom.
        /// </summary>
        public Point VisualFeedbackOffset
        {
            get { return _context.VisualFeedbackOffset; }
            set { _context.VisualFeedbackOffset = value; }
        }

        /// <summary>
        /// Gets or sets an opacity of the visual drag feedback.
        /// </summary>
        public double VisualFeedbackOpacity
        {
            get { return _context.VisualFeedbackOpacity; }
            set { _context.VisualFeedbackOpacity = value; }
        }

        /// <summary>
        /// Gets or sets the visual feedback visibility.
        /// </summary>
        public Visibility VisualFeedbackVisibility
        {
            get { return _context.VisualFeedbackVisibility; }
            set { _context.VisualFeedbackVisibility = value; }
        }

        /// <summary>
        /// Gets or sets a width of the visual drag feedback.
        /// </summary>
        public double VisualFeedbackWidth
        {
            get { return _context.VisualFeedbackWidth; }
            set { _context.VisualFeedbackWidth = value; }
        }

        /// <summary>
        /// Gets or sets a height of the visual drag feedback.
        /// </summary>
        public double VisualFeedbackHeight
        {
            get { return _context.VisualFeedbackHeight; }
            set { _context.VisualFeedbackHeight = value; }
        }

        /// <summary>
        /// Gets or sets a minimum width of the visual drag feedback.
        /// </summary>
        public double VisualFeedbackMinWidth
        {
            get { return _context.VisualFeedbackMinWidth; }
            set { _context.VisualFeedbackMinWidth = value; }
        }

        /// <summary>
        /// Gets or sets a minimum height of the visual drag feedback.
        /// </summary>
        public double VisualFeedbackMinHeight
        {
            get { return _context.VisualFeedbackMinHeight; }
            set { _context.VisualFeedbackMinHeight = value; }
        }

        /// <summary>
        /// Gets or sets a maximum width of the visual drag feedback.
        /// </summary>
        public double VisualFeedbackMaxWidth
        {
            get { return _context.VisualFeedbackMaxWidth; }
            set { _context.VisualFeedbackMaxWidth = value; }
        }

        /// <summary>
        /// Gets or sets a maximum height of the visual drag feedback.
        /// </summary>
        public double VisualFeedbackMaxHeight
        {
            get { return _context.VisualFeedbackMaxHeight; }
            set { _context.VisualFeedbackMaxHeight = value; }
        }

        #endregion
    }


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

    public class DragSourceGiveFeedbackEventArgs : DragSourceEventArgsBase
    {
        IDragSourceGiveFeedbackEventArgsContext _context;
        GiveFeedbackEventArgs _giveFeedbackEventArgs;


        #region Constructors

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
        /// One of the DragDropEffects values that specifies permitted effects of the drag-and-drop operation.
        /// </summary>
        public DragDropEffects AllowedEffects { get { return _context.AllowedEffects; } }

        /// <summary>
        /// A data object that contains the data being dragged.
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
        /// Gets or sets an object that is set to the content of the window for visual drag feedback.
        /// </summary>
        public object VisualFeedback
        {
            get { return _context.VisualFeedback; }
            set { _context.VisualFeedback = value; }
        }

        /// <summary>
        /// Gets or sets a data template used to display the content of the window for visual drag feedback.
        /// </summary>
        public DataTemplate VisualFeedbackTemplate
        {
            get { return _context.VisualFeedbackTemplate; }
            set { _context.VisualFeedbackTemplate = value; }
        }

        /// <summary>
        /// Gets or sets a template selector that enables an application writer to provide custom template-selection logic for visual drag feedback.
        /// </summary>
        public DataTemplateSelector VisualFeedbackTemplateSelector
        {
            get { return _context.VisualFeedbackTemplateSelector; }
            set { _context.VisualFeedbackTemplateSelector = value; }
        }

        /// <summary>
        /// Gets or sets an object that is set to the data context of the window for visual drag feedback.
        /// If this value is null, the drag source's data context is set.
        /// </summary>
        public object VisualFeedbackDataContext
        {
            get { return _context.VisualFeedbackDataContext; }
            set { _context.VisualFeedbackDataContext = value; }
        }

        /// <summary>
        /// Gets or sets an offset that is pointed by pointing device in the visual drag feedback.
        /// The origin is the upper-left corner of the visual drag feedback.
        /// The x-coordinates increase to the right. The y-coordinates increase to the bottom.
        /// </summary>
        public Point VisualFeedbackOffset
        {
            get { return _context.VisualFeedbackOffset; }
            set { _context.VisualFeedbackOffset = value; }
        }

        /// <summary>
        /// Gets or sets an opacity of the visual drag feedback.
        /// </summary>
        public double VisualFeedbackOpacity
        {
            get { return _context.VisualFeedbackOpacity; }
            set { _context.VisualFeedbackOpacity = value; }
        }

        /// <summary>
        /// Gets or sets the visual feedback visibility.
        /// </summary>
        public Visibility VisualFeedbackVisibility
        {
            get { return _context.VisualFeedbackVisibility; }
            set { _context.VisualFeedbackVisibility = value; }
        }

        /// <summary>
        /// Gets or sets a width of the visual drag feedback.
        /// </summary>
        public double VisualFeedbackWidth
        {
            get { return _context.VisualFeedbackWidth; }
            set { _context.VisualFeedbackWidth = value; }
        }

        /// <summary>
        /// Gets or sets a height of the visual drag feedback.
        /// </summary>
        public double VisualFeedbackHeight
        {
            get { return _context.VisualFeedbackHeight; }
            set { _context.VisualFeedbackHeight = value; }
        }

        /// <summary>
        /// Gets or sets a minimum width of the visual drag feedback.
        /// </summary>
        public double VisualFeedbackMinWidth
        {
            get { return _context.VisualFeedbackMinWidth; }
            set { _context.VisualFeedbackMinWidth = value; }
        }

        /// <summary>
        /// Gets or sets a minimum height of the visual drag feedback.
        /// </summary>
        public double VisualFeedbackMinHeight
        {
            get { return _context.VisualFeedbackMinHeight; }
            set { _context.VisualFeedbackMinHeight = value; }
        }

        /// <summary>
        /// Gets or sets a maximum width of the visual drag feedback.
        /// </summary>
        public double VisualFeedbackMaxWidth
        {
            get { return _context.VisualFeedbackMaxWidth; }
            set { _context.VisualFeedbackMaxWidth = value; }
        }

        /// <summary>
        /// Gets or sets a maximum height of the visual drag feedback.
        /// </summary>
        public double VisualFeedbackMaxHeight
        {
            get { return _context.VisualFeedbackMaxHeight; }
            set { _context.VisualFeedbackMaxHeight = value; }
        }

        #endregion
    }


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

    public class DragSourceQueryContinueDragEventArgs : DragSourceEventArgsBase
    {
        IDragSourceQueryContinueDragEventArgsContext _context;
        QueryContinueDragEventArgs _queryContinueDragEventArgs;


        #region Constructors

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
        /// One of the DragDropEffects values that specifies permitted effects of the drag-and-drop operation.
        /// </summary>
        public DragDropEffects AllowedEffects { get { return _context.AllowedEffects; } }

        /// <summary>
        /// A data object that contains the data being dragged.
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
        /// Gets or sets an object that is set to the content of the window for visual drag feedback.
        /// </summary>
        public object VisualFeedback
        {
            get { return _context.VisualFeedback; }
            set { _context.VisualFeedback = value; }
        }

        /// <summary>
        /// Gets or sets a data template used to display the content of the window for visual drag feedback.
        /// </summary>
        public DataTemplate VisualFeedbackTemplate
        {
            get { return _context.VisualFeedbackTemplate; }
            set { _context.VisualFeedbackTemplate = value; }
        }

        /// <summary>
        /// Gets or sets a template selector that enables an application writer to provide custom template-selection logic for visual drag feedback.
        /// </summary>
        public DataTemplateSelector VisualFeedbackTemplateSelector
        {
            get { return _context.VisualFeedbackTemplateSelector; }
            set { _context.VisualFeedbackTemplateSelector = value; }
        }

        /// <summary>
        /// Gets or sets an object that is set to the data context of the window for visual drag feedback.
        /// If this value is null, the drag source's data context is set.
        /// </summary>
        public object VisualFeedbackDataContext
        {
            get { return _context.VisualFeedbackDataContext; }
            set { _context.VisualFeedbackDataContext = value; }
        }

        /// <summary>
        /// Gets or sets an offset that is pointed by pointing device in the visual drag feedback.
        /// The origin is the upper-left corner of the visual drag feedback.
        /// The x-coordinates increase to the right. The y-coordinates increase to the bottom.
        /// </summary>
        public Point VisualFeedbackOffset
        {
            get { return _context.VisualFeedbackOffset; }
            set { _context.VisualFeedbackOffset = value; }
        }

        /// <summary>
        /// Gets or sets an opacity of the visual drag feedback.
        /// </summary>
        public double VisualFeedbackOpacity
        {
            get { return _context.VisualFeedbackOpacity; }
            set { _context.VisualFeedbackOpacity = value; }
        }

        /// <summary>
        /// Gets or sets the visual feedback visibility.
        /// </summary>
        public Visibility VisualFeedbackVisibility
        {
            get { return _context.VisualFeedbackVisibility; }
            set { _context.VisualFeedbackVisibility = value; }
        }

        /// <summary>
        /// Gets or sets a width of the visual drag feedback.
        /// </summary>
        public double VisualFeedbackWidth
        {
            get { return _context.VisualFeedbackWidth; }
            set { _context.VisualFeedbackWidth = value; }
        }

        /// <summary>
        /// Gets or sets a height of the visual drag feedback.
        /// </summary>
        public double VisualFeedbackHeight
        {
            get { return _context.VisualFeedbackHeight; }
            set { _context.VisualFeedbackHeight = value; }
        }

        /// <summary>
        /// Gets or sets a minimum width of the visual drag feedback.
        /// </summary>
        public double VisualFeedbackMinWidth
        {
            get { return _context.VisualFeedbackMinWidth; }
            set { _context.VisualFeedbackMinWidth = value; }
        }

        /// <summary>
        /// Gets or sets a minimum height of the visual drag feedback.
        /// </summary>
        public double VisualFeedbackMinHeight
        {
            get { return _context.VisualFeedbackMinHeight; }
            set { _context.VisualFeedbackMinHeight = value; }
        }

        /// <summary>
        /// Gets or sets a maximum width of the visual drag feedback.
        /// </summary>
        public double VisualFeedbackMaxWidth
        {
            get { return _context.VisualFeedbackMaxWidth; }
            set { _context.VisualFeedbackMaxWidth = value; }
        }

        /// <summary>
        /// Gets or sets a maximum height of the visual drag feedback.
        /// </summary>
        public double VisualFeedbackMaxHeight
        {
            get { return _context.VisualFeedbackMaxHeight; }
            set { _context.VisualFeedbackMaxHeight = value; }
        }

        #endregion
    }


    internal interface IDragSourceDroppedEventArgsContext
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

    public class DragSourceDroppedEventArgs : DragSourceEventArgsBase
    {
        IDragSourceDroppedEventArgsContext _context;


        #region Constructors

        internal DragSourceDroppedEventArgs(RoutedEvent routedEvent, object source, DragInitiator initiator, Point contactPosition, Point draggedPosition,
                    IDragSourceDroppedEventArgsContext context, DragDropEffects finalEffects)
            : base(routedEvent, source, initiator, contactPosition, draggedPosition)
        {
            Debug.Assert(context != null);

            _context = context;
            FinalEffects = finalEffects;
        }

        #endregion


        #region Properties

        /// <summary>
        /// One of the DragDropEffects values that specifies permitted effects of the drag-and-drop operation.
        /// </summary>
        public DragDropEffects AllowedEffects { get { return _context.AllowedEffects; } }

        /// <summary>
        /// The data object that contains the data being dragged.
        /// This value is always not null.
        /// </summary>
        public object Data { get { return _context.Data; } }

        /// <summary>
        /// Gets the value that indicates whether the auto generated visual feedback is allowed or not.
        /// </summary>
        public bool IsAutoVisualFeedbackAllowed { get { return _context.IsAutoVisualFeedbackAllowed; } }

        /// <summary>
        /// Gets the object that is set to the content of the window for visual drag feedback.
        /// </summary>
        public object VisualFeedback { get { return _context.VisualFeedback; } }

        /// <summary>
        /// Gets the data template used to display the content of the window for visual drag feedback.
        /// </summary>
        public DataTemplate VisualFeedbackTemplate { get { return _context.VisualFeedbackTemplate; } }

        /// <summary>
        /// Gets the template selector that enables an application writer to provide custom template-selection logic for visual drag feedback.
        /// </summary>
        public DataTemplateSelector VisualFeedbackTemplateSelector { get { return _context.VisualFeedbackTemplateSelector; } }

        /// <summary>
        /// Gets the object that is set to the data context of the window for visual drag feedback.
        /// </summary>
        public object VisualFeedbackDataContext { get { return _context.VisualFeedbackDataContext; } }

        /// <summary>
        /// Gets the offset that is pointed by pointing device in the visual drag feedback.
        /// The origin is the upper-left corner of the visual drag feedback.
        /// The x-coordinates increase to the right. The y-coordinates increase to the bottom.
        /// </summary>
        public Point VisualFeedbackOffset { get { return _context.VisualFeedbackOffset; } }

        /// <summary>
        /// Gets the opacity of the visual drag feedback.
        /// </summary>
        public double VisualFeedbackOpacity { get { return _context.VisualFeedbackOpacity; } }

        /// <summary>
        /// Gets the visual feedback visibility.
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
        /// One of the DragDropEffects values that specifies the final effect that was performed during the drag-and-drop operation.
        /// </summary>
        public DragDropEffects FinalEffects { get; private set; }

        #endregion
    }

    #endregion


    /// <summary>
    /// If VisualFeedback or VisualFeedbackTemplate or VisualFeedbackTemplateSelector is not null,
    /// auto generated visual feedback is not displayed.
    /// </summary>
    public static class DragSource
    {
        #region Inner types

        private class Context : IDragSourceDraggingEventArgsContext,
                IDragSourceGiveFeedbackEventArgsContext, IDragSourceQueryContinueDragEventArgsContext, IDragSourceDroppedEventArgsContext
        {
            #region Constructors

            public Context() { }

            #endregion


            #region Members

            /// <summary>
            /// One of the DragDropEffects values that specifies permitted effects of the drag-and-drop operation.
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
            /// Gets or sets an object that is set to the content of the window for visual drag feedback.
            /// </summary>
            public object VisualFeedback { get; set; }

            /// <summary>
            /// Gets or sets a data template used to display the content of the window for visual drag feedback.
            /// </summary>
            public DataTemplate VisualFeedbackTemplate { get; set; }

            /// <summary>
            /// Gets or sets a template selector that enables an application writer to provide custom template-selection logic for visual drag feedback.
            /// </summary>
            public DataTemplateSelector VisualFeedbackTemplateSelector { get; set; }

            /// <summary>
            /// Gets or sets an object that is set to the data context of the window for visual drag feedback.
            /// If this value is null, the drag source's data context is set.
            /// </summary>
            public object VisualFeedbackDataContext { get; set; }

            /// <summary>
            /// Gets or sets an offset that is pointed by pointing device in the visual drag feedback.
            /// The origin is the upper-left corner of the visual drag feedback.
            /// The x-coordinates increase to the right. The y-coordinates increase to the bottom.
            /// </summary>
            public Point VisualFeedbackOffset { get; set; }

            /// <summary>
            /// Gets or sets an opacity of the visual drag feedback.
            /// </summary>
            public double VisualFeedbackOpacity { get; set; }

            /// <summary>
            /// Gets or sets the visual feedback visibility.
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
            /// The host window for visual drag feedback.
            /// </summary>
            public VisualFeedbackHost VisualFeedbackHost { get; set; }

            /// <summary>
            /// Initializes this context for events after the DragSensing event.
            /// </summary>
            /// <param name="allowedEffects"></param>
            /// <param name="data"></param>
            /// <param name="visualFeedback"></param>
            /// <param name="visualFeedbackDataContext"></param>
            /// <param name="visualFeedbackOffset"></param>
            /// <param name="visualFeedbackOpacity"></param>
            /// <param name="visualFeedbackWidth"></param>
            /// <param name="visualFeedbackHeight"></param>
            /// <param name="visualFeedbackMinWidth"></param>
            /// <param name="visualFeedbackMinHeight"></param>
            /// <param name="visualFeedbackMaxWidth"></param>
            /// <param name="visualFeedbackMaxHeight"></param>
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
            /// Cleans up internal states.
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

        internal class VisualFeedbackHost : Disposable
        {
            UIElement _dragSource;


            #region Constructors

            public VisualFeedbackHost(UIElement dragSource)
            {
                _dragSource = dragSource;
            }

            #endregion


            #region Static Helpers

            private static Window CreateHostWindow()
            {
                // Creates the host window for visual drag feedback.
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

            private VisualFeedbackContentManager VisualFeedbackContentManager
            {
                get { return _visualFeedbackContentManager ?? (_visualFeedbackContentManager = new VisualFeedbackContentManager(_dragSource)); }
            }


            Window _hostWindow;

            private Window HostWindow
            {
                get { return _hostWindow ?? (_hostWindow = CreateHostWindow()); }
            }

            private void CloseHostWindow()
            {
                if (_hostWindow == null)
                    return;

                _hostWindow.Content = null;
                _hostWindow.Close();
                _hostWindow = null;
            }


            private object DragSourceDataContext
            {
                get
                {
                    FrameworkElement frameworkElement = _dragSource as FrameworkElement;
                    return frameworkElement != null ? frameworkElement.DataContext : null;
                }
            }


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


            public void Update(bool isAutoVisualFeedbackAllowed, object content, DataTemplate contentTemplate, DataTemplateSelector contentTemplateSelector,
                    object dataContext, Point offset, double opacity, Visibility visibility, double width, double height,
                    double minWidth, double minHeight, double maxWidth, double maxHeight)
            {
                // Gets the content element for the host window.
                FrameworkElement contentElement = VisualFeedbackContentManager.CreateOrGetContent(isAutoVisualFeedbackAllowed, content, contentTemplate, contentTemplateSelector);

                // If there is no content to display, closes the host window if it exists.
                if (contentElement == null)
                {
                    CloseHostWindow();
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
                    CloseHostWindow();
            }

            #endregion
        }

        internal class VisualFeedbackContentManager
        {
            UIElement _dragSource;


            #region Constructors

            public VisualFeedbackContentManager(UIElement dragSource)
            {
                _dragSource = dragSource;
            }

            #endregion


            #region CreateGeneratedContent

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

            private ContentControl ContentControl
            {
                get { return _contentControl ?? (_contentControl = new ContentControl()); }
            }

            FrameworkElement _generatedContent;

            private FrameworkElement GeneratedContent
            {
                get { return _generatedContent ?? (_generatedContent = CreateGeneratedContent(_dragSource)); }
            }

            #endregion


            /// <summary>
            /// Returns null if there is no content to display.
            /// </summary>
            /// <param name="content"></param>
            /// <returns></returns>
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
        }

        #endregion


        #region Context Attached Property

        private static readonly DependencyProperty ContextProperty = DependencyProperty.RegisterAttached
        (
            "Context",
            typeof(Context),
            typeof(DragSource)
        );

        private static Context GetContext(DependencyObject obj)
        {
            return (Context)obj.GetValue(ContextProperty);
        }

        private static void SetContext(DependencyObject obj, Context value)
        {
            obj.SetValue(ContextProperty, value);
        }

        private static Context GetSafeContext(DependencyObject obj)
        {
            Debug.Assert(obj != null);

            Context context = GetContext(obj);

            if (context == null)
                SetContext(obj, context = new Context());

            return context;
        }

        #endregion


        #region AllowDrag Attached Property

        public static readonly DependencyProperty AllowDragProperty = DependencyProperty.RegisterAttached
        (
            "AllowDrag",
            typeof(bool),
            typeof(DragSource),
            new PropertyMetadata(false, DragSource_AllowDragChanged)
        );

        public static bool GetAllowDrag(UIElement obj)
        {
            return (bool)obj.GetValue(AllowDragProperty);
        }

        public static void SetAllowDrag(UIElement obj, bool value)
        {
            obj.SetValue(AllowDragProperty, value);
        }

        static void DragSource_AllowDragChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UIElement target = d as UIElement;

            // Removes the previous event handler if it exists.
            target.PreviewMouseDown -= DragSource_PreviewMouseDown;

            if ((bool)e.NewValue)
                target.PreviewMouseDown += DragSource_PreviewMouseDown;
        }

        static void DragSource_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            UIElement target = sender as UIElement;

            // Detaches the previous mouse move event handler if it exists.
            target.PreviewMouseMove -= DragSource_PreviewMouseMove;


            // Checks whether the drag initiator is allowed or not.
            DragInitiators dragInitiators = e.ChangedButton.ToDragInitiators();
            if (!GetAllowedInitiators(target).HasFlag(dragInitiators))
                return;


            // Saves the initiator and contactPosition.
            DragInitiator initiator = e.ChangedButton.ToDragInitiator();
            Point contactPosition = e.GetPosition(target);

            SetInitiator(target, initiator);
            SetContactPosition(target, contactPosition);

            // Updates the dragged position.
            SetDraggedPosition(target, contactPosition);


            // Raises the dragSensing related events.
            if (!RaiseDragSensingEvent(target, initiator, contactPosition, contactPosition))
                return;


            // Attaches the mouse move event handler
            target.PreviewMouseMove += DragSource_PreviewMouseMove;
        }

        static void DragSource_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            UIElement target = sender as UIElement;

            // If Capture is allowed, tries to capture the mouse.
            if (GetIsCaptureAllowed(target) && !target.IsMouseCaptured)
                target.CaptureMouse();


            Context context = GetSafeContext(target);
            DragInitiator initiator = GetInitiator(target);
            Point contactPosition = GetContactPosition(target);
            Point currentPosition;
            bool keepMouseMoveEventHandler = false;

            try
            {
                // Checks whether the drag initiator is still pressed.
                if (!initiator.IsStillPressed(e))
                {
                    // Cleans up the context.
                    context.CleanUp();
                    return;
                }


                // Updates the dragged position.
                currentPosition = e.GetPosition(target);
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
                    // It is required to track the mouse.
                    keepMouseMoveEventHandler = true;
                    return;
                }
            }
            finally
            {
                // Detaches the mouse move event handler if it is not required.
                if (!keepMouseMoveEventHandler)
                    target.PreviewMouseMove -= DragSource_PreviewMouseMove;
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
                        finalEffects = DragDrop.DoDragDrop(target, context.Data, context.AllowedEffects);

                        // Clears the visual feedback host from the context.
                        context.VisualFeedbackHost = null;
                    }

                    // Marks that dragging is ended.
                    target.ClearValue(IsDraggingPropertyKey);

                    // Detaches event handlers for drag feedback.
                    DetachEventHandlersForDragFeedback(target);
                }


                // Raises the Dropped event.
                RaiseDroppedEvent(target, initiator, contactPosition, currentPosition, context, finalEffects);
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

        public static readonly DependencyProperty AllowedInitiatorsProperty = DependencyProperty.RegisterAttached
        (
            "AllowedInitiators",
            typeof(DragInitiators),
            typeof(DragSource),
            new PropertyMetadata(DragInitiators.Default)
        );

        public static DragInitiators GetAllowedInitiators(DependencyObject obj)
        {
            return (DragInitiators)obj.GetValue(AllowedInitiatorsProperty);
        }

        public static void SetAllowedInitiators(DependencyObject obj, DragInitiators value)
        {
            obj.SetValue(AllowedInitiatorsProperty, value);
        }

        #endregion


        #region Data Attached Property

        public static readonly DependencyProperty DataProperty = DependencyProperty.RegisterAttached
        (
            "Data",
            typeof(object),
            typeof(DragSource)
        );

        public static object GetData(DependencyObject obj)
        {
            return (object)obj.GetValue(DataProperty);
        }

        public static void SetData(DependencyObject obj, object value)
        {
            obj.SetValue(DataProperty, value);
        }

        #endregion


        #region IsCaptureAllowed Attached Property

        public static readonly DependencyProperty IsCaptureAllowedProperty = DependencyProperty.RegisterAttached
        (
            "IsCaptureAllowed",
            typeof(bool),
            typeof(DragSource),
            new PropertyMetadata(true)
        );

        public static bool GetIsCaptureAllowed(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsCaptureAllowedProperty);
        }

        public static void SetIsCaptureAllowed(DependencyObject obj, bool value)
        {
            obj.SetValue(IsCaptureAllowedProperty, value);
        }

        #endregion


        #region IsAutoVisualFeedbackAllowed Attached Property

        public static readonly DependencyProperty IsAutoVisualFeedbackAllowedProperty = DependencyProperty.RegisterAttached
        (
            "IsAutoVisualFeedbackAllowed",
            typeof(bool),
            typeof(DragSource),
            new PropertyMetadata(true)
        );

        public static bool GetIsAutoVisualFeedbackAllowed(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsAutoVisualFeedbackAllowedProperty);
        }

        public static void SetIsAutoVisualFeedbackAllowed(DependencyObject obj, bool value)
        {
            obj.SetValue(IsAutoVisualFeedbackAllowedProperty, value);
        }

        #endregion


        #region VisualFeedback Attached Property

        public static readonly DependencyProperty VisualFeedbackProperty = DependencyProperty.RegisterAttached
        (
            "VisualFeedback",
            typeof(object),
            typeof(DragSource)
        );

        public static object GetVisualFeedback(DependencyObject obj)
        {
            return (object)obj.GetValue(VisualFeedbackProperty);
        }

        public static void SetVisualFeedback(DependencyObject obj, object value)
        {
            obj.SetValue(VisualFeedbackProperty, value);
        }

        #endregion


        #region VisualFeedbackTemplate Attached Property

        public static readonly DependencyProperty VisualFeedbackTemplateProperty = DependencyProperty.RegisterAttached
        (
            "VisualFeedbackTemplate",
            typeof(DataTemplate),
            typeof(DragSource)
        );

        public static DataTemplate GetVisualFeedbackTemplate(DependencyObject obj)
        {
            return (DataTemplate)obj.GetValue(VisualFeedbackTemplateProperty);
        }

        public static void SetVisualFeedbackTemplate(DependencyObject obj, DataTemplate value)
        {
            obj.SetValue(VisualFeedbackTemplateProperty, value);
        }

        #endregion


        #region VisualFeedbackTemplateSelector Attached Property

        public static readonly DependencyProperty VisualFeedbackTemplateSelectorProperty = DependencyProperty.RegisterAttached
        (
            "VisualFeedbackTemplateSelector",
            typeof(DataTemplateSelector),
            typeof(DragSource)
        );

        public static DataTemplateSelector GetVisualFeedbackTemplateSelector(DependencyObject obj)
        {
            return (DataTemplateSelector)obj.GetValue(VisualFeedbackTemplateSelectorProperty);
        }

        public static void SetVisualFeedbackTemplateSelector(DependencyObject obj, DataTemplateSelector value)
        {
            obj.SetValue(VisualFeedbackTemplateSelectorProperty, value);
        }

        #endregion


        #region VisualFeedbackDataContext Attached Property

        public static readonly DependencyProperty VisualFeedbackDataContextProperty = DependencyProperty.RegisterAttached
        (
            "VisualFeedbackDataContext",
            typeof(object),
            typeof(DragSource)
        );

        public static object GetVisualFeedbackDataContext(DependencyObject obj)
        {
            return (object)obj.GetValue(VisualFeedbackDataContextProperty);
        }

        public static void SetVisualFeedbackDataContext(DependencyObject obj, object value)
        {
            obj.SetValue(VisualFeedbackDataContextProperty, value);
        }

        #endregion


        #region VisualFeedbackOffset Attached Property

        public static readonly DependencyProperty VisualFeedbackOffsetProperty = DependencyProperty.RegisterAttached
        (
            "VisualFeedbackOffset",
            typeof(Point),
            typeof(DragSource),
            new PropertyMetadata(new Point(7, 7))
        );

        public static Point GetVisualFeedbackOffset(DependencyObject obj)
        {
            return (Point)obj.GetValue(VisualFeedbackOffsetProperty);
        }

        public static void SetVisualFeedbackOffset(DependencyObject obj, Point value)
        {
            obj.SetValue(VisualFeedbackOffsetProperty, value);
        }

        #endregion


        #region VisualFeedbackOpacity Attached Property

        public static readonly DependencyProperty VisualFeedbackOpacityProperty = DependencyProperty.RegisterAttached
        (
            "VisualFeedbackOpacity",
            typeof(double),
            typeof(DragSource),
            new PropertyMetadata(0.5d)
        );

        public static double GetVisualFeedbackOpacity(DependencyObject obj)
        {
            return (double)obj.GetValue(VisualFeedbackOpacityProperty);
        }

        public static void SetVisualFeedbackOpacity(DependencyObject obj, double value)
        {
            obj.SetValue(VisualFeedbackOpacityProperty, value);
        }

        #endregion


        #region VisualFeedbackVisibility Attached Property

        public static readonly DependencyProperty VisualFeedbackVisibilityProperty = DependencyProperty.RegisterAttached
        (
            "VisualFeedbackVisibility",
            typeof(Visibility),
            typeof(DragSource),
            new PropertyMetadata(Visibility.Visible)
        );

        public static Visibility GetVisualFeedbackVisibility(DependencyObject obj)
        {
            return (Visibility)obj.GetValue(VisualFeedbackVisibilityProperty);
        }

        public static void SetVisualFeedbackVisibility(DependencyObject obj, Visibility value)
        {
            obj.SetValue(VisualFeedbackVisibilityProperty, value);
        }

        #endregion


        #region VisualFeedbackWidth Attached Property

        public static readonly DependencyProperty VisualFeedbackWidthProperty = DependencyProperty.RegisterAttached
        (
            "VisualFeedbackWidth",
            typeof(double),
            typeof(DragSource),
            new PropertyMetadata(double.NaN)
        );

        public static double GetVisualFeedbackWidth(DependencyObject obj)
        {
            return (double)obj.GetValue(VisualFeedbackWidthProperty);
        }

        public static void SetVisualFeedbackWidth(DependencyObject obj, double value)
        {
            obj.SetValue(VisualFeedbackWidthProperty, value);
        }

        #endregion


        #region VisualFeedbackHeight Attached Property

        public static readonly DependencyProperty VisualFeedbackHeightProperty = DependencyProperty.RegisterAttached
        (
            "VisualFeedbackHeight",
            typeof(double),
            typeof(DragSource),
            new PropertyMetadata(double.NaN)
        );

        public static double GetVisualFeedbackHeight(DependencyObject obj)
        {
            return (double)obj.GetValue(VisualFeedbackHeightProperty);
        }

        public static void SetVisualFeedbackHeight(DependencyObject obj, double value)
        {
            obj.SetValue(VisualFeedbackHeightProperty, value);
        }

        #endregion


        #region VisualFeedbackMinWidth Attached Property

        public static readonly DependencyProperty VisualFeedbackMinWidthProperty = DependencyProperty.RegisterAttached
        (
            "VisualFeedbackMinWidth",
            typeof(double),
            typeof(DragSource),
            new PropertyMetadata(0d)
        );

        public static double GetVisualFeedbackMinWidth(DependencyObject obj)
        {
            return (double)obj.GetValue(VisualFeedbackMinWidthProperty);
        }

        public static void SetVisualFeedbackMinWidth(DependencyObject obj, double value)
        {
            obj.SetValue(VisualFeedbackMinWidthProperty, value);
        }

        #endregion


        #region VisualFeedbackMinHeight Attached Property

        public static readonly DependencyProperty VisualFeedbackMinHeightProperty = DependencyProperty.RegisterAttached
        (
            "VisualFeedbackMinHeight",
            typeof(double),
            typeof(DragSource),
            new PropertyMetadata(0d)
        );

        public static double GetVisualFeedbackMinHeight(DependencyObject obj)
        {
            return (double)obj.GetValue(VisualFeedbackMinHeightProperty);
        }

        public static void SetVisualFeedbackMinHeight(DependencyObject obj, double value)
        {
            obj.SetValue(VisualFeedbackMinHeightProperty, value);
        }

        #endregion


        #region VisualFeedbackMaxWidth Attached Property

        public static readonly DependencyProperty VisualFeedbackMaxWidthProperty = DependencyProperty.RegisterAttached
        (
            "VisualFeedbackMaxWidth",
            typeof(double),
            typeof(DragSource),
            new PropertyMetadata(double.PositiveInfinity)
        );

        public static double GetVisualFeedbackMaxWidth(DependencyObject obj)
        {
            return (double)obj.GetValue(VisualFeedbackMaxWidthProperty);
        }

        public static void SetVisualFeedbackMaxWidth(DependencyObject obj, double value)
        {
            obj.SetValue(VisualFeedbackMaxWidthProperty, value);
        }

        #endregion


        #region VisualFeedbackMaxHeight Attached Property

        public static readonly DependencyProperty VisualFeedbackMaxHeightProperty = DependencyProperty.RegisterAttached
        (
            "VisualFeedbackMaxHeight",
            typeof(double),
            typeof(DragSource),
            new PropertyMetadata(double.PositiveInfinity)
        );

        public static double GetVisualFeedbackMaxHeight(DependencyObject obj)
        {
            return (double)obj.GetValue(VisualFeedbackMaxHeightProperty);
        }

        public static void SetVisualFeedbackMaxHeight(DependencyObject obj, double value)
        {
            obj.SetValue(VisualFeedbackMaxHeightProperty, value);
        }

        #endregion


        #region Initiator ReadOnly Attached Property

        private static readonly DependencyPropertyKey InitiatorPropertyKey = DependencyProperty.RegisterAttachedReadOnly
        (
            "Initiator",
            typeof(DragInitiator),
            typeof(DragSource),
            new PropertyMetadata(DragInitiator.MouseLeftButton)
        );

        public static readonly DependencyProperty InitiatorProperty = InitiatorPropertyKey.DependencyProperty;

        public static DragInitiator GetInitiator(DependencyObject obj)
        {
            return (DragInitiator)obj.GetValue(InitiatorProperty);
        }

        private static void SetInitiator(DependencyObject obj, DragInitiator value)
        {
            obj.SetValue(InitiatorPropertyKey, value);
        }

        #endregion


        #region ContactPosition ReadOnly Attached Property

        private static readonly DependencyPropertyKey ContactPositionPropertyKey = DependencyProperty.RegisterAttachedReadOnly
        (
            "ContactPosition",
            typeof(Point),
            typeof(DragSource),
            new PropertyMetadata(new Point())
        );

        public static readonly DependencyProperty ContactPositionProperty = ContactPositionPropertyKey.DependencyProperty;

        public static Point GetContactPosition(DependencyObject obj)
        {
            return (Point)obj.GetValue(ContactPositionProperty);
        }

        private static void SetContactPosition(DependencyObject obj, Point value)
        {
            obj.SetValue(ContactPositionPropertyKey, value);
        }

        #endregion


        #region DraggedPosition ReadOnly Attached Property

        private static readonly DependencyPropertyKey DraggedPositionPropertyKey = DependencyProperty.RegisterAttachedReadOnly
        (
            "DraggedPosition",
            typeof(Point),
            typeof(DragSource),
            new PropertyMetadata(new Point())
        );

        public static readonly DependencyProperty DraggedPositionProperty = DraggedPositionPropertyKey.DependencyProperty;

        public static Point GetDraggedPosition(DependencyObject obj)
        {
            return (Point)obj.GetValue(DraggedPositionProperty);
        }

        private static void SetDraggedPosition(DependencyObject obj, Point value)
        {
            obj.SetValue(DraggedPositionPropertyKey, value);
        }

        #endregion


        #region AllowedEffects Attached Property

        public static readonly DependencyProperty AllowedEffectsProperty = DependencyProperty.RegisterAttached
        (
            "AllowedEffects",
            typeof(DragDropEffects),
            typeof(DragSource),
            new PropertyMetadata(DragDropEffects.Copy | DragDropEffects.Move | DragDropEffects.Scroll)
        );

        public static DragDropEffects GetAllowedEffects(DependencyObject obj)
        {
            return (DragDropEffects)obj.GetValue(AllowedEffectsProperty);
        }

        public static void SetAllowedEffects(DependencyObject obj, DragDropEffects value)
        {
            obj.SetValue(AllowedEffectsProperty, value);
        }

        #endregion


        #region MinimumHorizontalDragDistance & MinimumVerticalDragDistance Attached Property

        public static readonly DependencyProperty MinimumHorizontalDragDistanceProperty = DependencyProperty.RegisterAttached
        (
            "MinimumHorizontalDragDistance",
            typeof(double),
            typeof(DragSource),
            new PropertyMetadata(SystemParameters.MinimumHorizontalDragDistance)
        );

        public static double GetMinimumHorizontalDragDistance(UIElement obj)
        {
            return (double)obj.GetValue(MinimumHorizontalDragDistanceProperty);
        }

        public static void SetMinimumHorizontalDragDistance(UIElement obj, double value)
        {
            obj.SetValue(MinimumHorizontalDragDistanceProperty, value);
        }


        public static readonly DependencyProperty MinimumVerticalDragDistanceProperty = DependencyProperty.RegisterAttached
        (
            "MinimumVerticalDragDistance",
            typeof(double),
            typeof(DragSource),
            new PropertyMetadata(SystemParameters.MinimumVerticalDragDistance)
        );

        public static double GetMinimumVerticalDragDistance(UIElement obj)
        {
            return (double)obj.GetValue(MinimumVerticalDragDistanceProperty);
        }

        public static void SetMinimumVerticalDragDistance(UIElement obj, double value)
        {
            obj.SetValue(MinimumVerticalDragDistanceProperty, value);
        }

        #endregion


        #region IsDragging ReadOnly Attached Property

        private static readonly DependencyPropertyKey IsDraggingPropertyKey = DependencyProperty.RegisterAttachedReadOnly
        (
            "IsDragging",
            typeof(bool),
            typeof(DragSource),
            new PropertyMetadata(false)
        );

        public static readonly DependencyProperty IsDraggingProperty = IsDraggingPropertyKey.DependencyProperty;

        public static bool GetIsDragging(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsDraggingProperty);
        }

        private static void SetIsDragging(DependencyObject obj, bool value)
        {
            obj.SetValue(IsDraggingPropertyKey, value);
        }

        #endregion


        #region DragSensing event related

        public static readonly RoutedEvent PreviewDragSensingEvent = EventManager.RegisterRoutedEvent
        (
            "PreviewDragSensing",
            RoutingStrategy.Tunnel,
            typeof(EventHandler<DragSourceDragSensingEventArgs>),
            typeof(DragSource)
        );

        public static void AddPreviewDragSensingHandler(UIElement obj, EventHandler<DragSourceDragSensingEventArgs> handler)
        {
            obj.AddHandler(PreviewDragSensingEvent, handler);
        }

        public static void RemovePreviewDragSensingHandler(UIElement obj, EventHandler<DragSourceDragSensingEventArgs> handler)
        {
            obj.RemoveHandler(PreviewDragSensingEvent, handler);
        }


        public static readonly RoutedEvent DragSensingEvent = EventManager.RegisterRoutedEvent
        (
            "DragSensing",
            RoutingStrategy.Bubble,
            typeof(EventHandler<DragSourceDragSensingEventArgs>),
            typeof(DragSource)
        );

        public static void AddDragSensingHandler(UIElement obj, EventHandler<DragSourceDragSensingEventArgs> handler)
        {
            obj.AddHandler(DragSensingEvent, handler);
        }

        public static void RemoveDragSensingHandler(UIElement obj, EventHandler<DragSourceDragSensingEventArgs> handler)
        {
            obj.RemoveHandler(DragSensingEvent, handler);
        }


        /// <summary>
        /// Raises PreviewDragSensingEvent and DragSensingEvent.
        /// The context instance must be initialized.
        /// </summary>
        /// <param name="target"></param>
        /// <returns>Returns true if user does not cancel, otherwise false.</returns>
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


        #region Dragging event related

        public static readonly RoutedEvent PreviewDraggingEvent = EventManager.RegisterRoutedEvent
        (
            "PreviewDragging",
            RoutingStrategy.Tunnel,
            typeof(EventHandler<DragSourceDraggingEventArgs>),
            typeof(DragSource)
        );

        public static void AddPreviewDraggingHandler(UIElement obj, EventHandler<DragSourceDraggingEventArgs> handler)
        {
            obj.AddHandler(PreviewDraggingEvent, handler);
        }

        public static void RemovePreviewDraggingHandler(UIElement obj, EventHandler<DragSourceDraggingEventArgs> handler)
        {
            obj.RemoveHandler(PreviewDraggingEvent, handler);
        }


        public static readonly RoutedEvent DraggingEvent = EventManager.RegisterRoutedEvent
        (
            "Dragging",
            RoutingStrategy.Bubble,
            typeof(EventHandler<DragSourceDraggingEventArgs>),
            typeof(DragSource)
        );

        public static void AddDraggingHandler(UIElement obj, EventHandler<DragSourceDraggingEventArgs> handler)
        {
            obj.AddHandler(DraggingEvent, handler);
        }

        public static void RemoveDraggingHandler(UIElement obj, EventHandler<DragSourceDraggingEventArgs> handler)
        {
            obj.RemoveHandler(DraggingEvent, handler);
        }


        /// <summary>
        /// Raises PreviewDraggingEvent and DragEvent.
        /// The context instance must be initialized.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="context"></param>
        /// <returns>Returns true if user does not cancel, otherwise false.</returns>
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


        #region GiveFeedback event related

        public static readonly RoutedEvent PreviewGiveFeedbackEvent = EventManager.RegisterRoutedEvent
        (
            "PreviewGiveFeedback",
            RoutingStrategy.Tunnel,
            typeof(EventHandler<DragSourceGiveFeedbackEventArgs>),
            typeof(DragSource)
        );

        public static void AddPreviewGiveFeedbackHandler(UIElement obj, EventHandler<DragSourceGiveFeedbackEventArgs> handler)
        {
            obj.AddHandler(PreviewGiveFeedbackEvent, handler);
        }

        public static void RemovePreviewGiveFeedbackHandler(UIElement obj, EventHandler<DragSourceGiveFeedbackEventArgs> handler)
        {
            obj.RemoveHandler(PreviewGiveFeedbackEvent, handler);
        }


        public static readonly RoutedEvent GiveFeedbackEvent = EventManager.RegisterRoutedEvent
        (
            "GiveFeedback",
            RoutingStrategy.Bubble,
            typeof(EventHandler<DragSourceGiveFeedbackEventArgs>),
            typeof(DragSource)
        );

        public static void AddGiveFeedbackHandler(UIElement obj, EventHandler<DragSourceGiveFeedbackEventArgs> handler)
        {
            obj.AddHandler(GiveFeedbackEvent, handler);
        }

        public static void RemoveGiveFeedbackHandler(UIElement obj, EventHandler<DragSourceGiveFeedbackEventArgs> handler)
        {
            obj.RemoveHandler(GiveFeedbackEvent, handler);
        }


        /// <summary>
        /// Raises PreviewGiveFeedbackEvent or GiveFeedbackEvent.
        /// The context instance must be initialized.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="context"></param>
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


        #region QueryContinueDrag event related

        public static readonly RoutedEvent PreviewQueryContinueDragEvent = EventManager.RegisterRoutedEvent
        (
            "PreviewQueryContinueDrag",
            RoutingStrategy.Tunnel,
            typeof(EventHandler<DragSourceQueryContinueDragEventArgs>),
            typeof(DragSource)
        );

        public static void AddPreviewQueryContinueDragHandler(UIElement obj, EventHandler<DragSourceQueryContinueDragEventArgs> handler)
        {
            obj.AddHandler(PreviewQueryContinueDragEvent, handler);
        }

        public static void RemovePreviewQueryContinueDragHandler(UIElement obj, EventHandler<DragSourceQueryContinueDragEventArgs> handler)
        {
            obj.RemoveHandler(PreviewQueryContinueDragEvent, handler);
        }


        public static readonly RoutedEvent QueryContinueDragEvent = EventManager.RegisterRoutedEvent
        (
            "QueryContinueDrag",
            RoutingStrategy.Bubble,
            typeof(EventHandler<DragSourceQueryContinueDragEventArgs>),
            typeof(DragSource)
        );

        public static void AddQueryContinueDragHandler(UIElement obj, EventHandler<DragSourceQueryContinueDragEventArgs> handler)
        {
            obj.AddHandler(QueryContinueDragEvent, handler);
        }

        public static void RemoveQueryContinueDragHandler(UIElement obj, EventHandler<DragSourceQueryContinueDragEventArgs> handler)
        {
            obj.RemoveHandler(QueryContinueDragEvent, handler);
        }


        /// <summary>
        /// Raises PreviewQueryContinueDragEvent or QueryContinueDragEvent.
        /// The context instance must be initialized.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="context"></param>
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


        #region Dropped event related

        public static readonly RoutedEvent PreviewDroppedEvent = EventManager.RegisterRoutedEvent
        (
            "PreviewDropped",
            RoutingStrategy.Tunnel,
            typeof(EventHandler<DragSourceDroppedEventArgs>),
            typeof(DragSource)
        );

        public static void AddPreviewDroppedHandler(UIElement obj, EventHandler<DragSourceDroppedEventArgs> handler)
        {
            obj.AddHandler(PreviewDroppedEvent, handler);
        }

        public static void RemovePreviewDroppedHandler(UIElement obj, EventHandler<DragSourceDroppedEventArgs> handler)
        {
            obj.RemoveHandler(PreviewDroppedEvent, handler);
        }


        public static readonly RoutedEvent DroppedEvent = EventManager.RegisterRoutedEvent
        (
            "Dropped",
            RoutingStrategy.Bubble,
            typeof(EventHandler<DragSourceDroppedEventArgs>),
            typeof(DragSource)
        );

        public static void AddDroppedHandler(UIElement obj, EventHandler<DragSourceDroppedEventArgs> handler)
        {
            obj.AddHandler(DroppedEvent, handler);
        }

        public static void RemoveDroppedHandler(UIElement obj, EventHandler<DragSourceDroppedEventArgs> handler)
        {
            obj.RemoveHandler(DroppedEvent, handler);
        }


        /// <summary>
        /// Raises PreviewDroppedEvent and DroppedEvent.
        /// The context instance must be initialized.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="context"></param>
        /// <returns>Returns true if user does not cancel, otherwise false.</returns>
        private static void RaiseDroppedEvent(UIElement target, DragInitiator initiator, Point contactPosition, Point draggedPosition,
                IDragSourceDroppedEventArgsContext context, DragDropEffects finalEffects)
        {
            Debug.Assert(target != null);
            Debug.Assert(context != null);


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

        #endregion


        #region IsEnoughToStartDrag

        /// <summary>
        /// Checks whether the movement distance is enough to start a drag.
        /// </summary>
        /// <param name="minDragDistance">The size of a rectangle centered on a drag position to allow for limited movement of the pointer before a drag operation begins.</param>
        /// <param name="startPosition">The start location.</param>
        /// <param name="draggedPosition">The dragged location.</param>
        /// <returns>True if it is enough to start a drag, otherwise false.</returns>
        public static bool IsEnoughToStartDrag(Vector minDragDistance, Point startPosition, Point draggedPosition)
        {
            return (Math.Abs(startPosition.X - draggedPosition.X) > minDragDistance.X / 2)
                || (Math.Abs(startPosition.Y - draggedPosition.Y) > minDragDistance.Y / 2);
        }

        #endregion
    }
}
