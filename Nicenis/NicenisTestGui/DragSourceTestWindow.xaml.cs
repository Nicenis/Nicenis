/*
 * Author	JO Hyeong-Ryeol
 * Since	2013.06.29
 * Version	$Id$
 * 
 * Copyright (C) 2013 JO Hyeong-Ryeol. All rights reserved.
 */

using Nicenis.Windows;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace NicenisTestGui
{
    /// <summary>
    /// The window to test the DragSource.
    /// </summary>
    public partial class DragSourceTestWindow : Window
    {
        #region Constructors

        public DragSourceTestWindow()
        {
            InitializeComponent();
        }

        #endregion


        #region ListBoxItemData

        /// <summary>
        /// A class for the ListBox item's DataContext.
        /// </summary>
        public class ListBoxItemData : IDataObjectProvider
        {
            #region Constructors

            /// <summary>
            /// Initializes a new instance of the ListBoxItemData class.
            /// </summary>
            /// <param name="text">The text to display</param>
            /// <param name="isCustomVisualFeedback">A value indicating whether it is requested to use the custom visual feedback.</param>
            public ListBoxItemData(string text, bool isCustomVisualFeedback)
            {
                if (string.IsNullOrWhiteSpace(text))
                    throw new ArgumentException("The text can not be null or white space.");

                Text = text;
                IsCustomVisualFeedback = isCustomVisualFeedback;
            }

            #endregion


            #region Properties

            /// <summary>
            /// The text to display.
            /// </summary>
            public string Text { get; private set; }

            /// <summary>
            /// Gets a value indicating whether it is requested to use the custom visual feedback.
            /// </summary>
            public bool IsCustomVisualFeedback { get; private set; }

            #endregion


            #region IDataObjectProvider implementation

            string _dataObject;

            /// <summary>
            /// Gets a data object that contains the data being dragged.
            /// </summary>
            /// <returns>A data object that contains the data being dragged.</returns>
            public object GetDataObject()
            {
                return _dataObject ?? (_dataObject = Text + " data object");
            }

            #endregion
        }

        #endregion


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Initializes a list for the ListBox.
            List<ListBoxItemData> itemsSource = new List<ListBoxItemData>();

            for (int i = 0; i < 10000; i++)
                itemsSource.Add(new ListBoxItemData("No. " + (i + 1).ToString(), i % 4 == 0));

            _listBox.ItemsSource = itemsSource;
        }
    }
}
