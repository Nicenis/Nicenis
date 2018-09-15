/*
 * Author   JO Hyeong-Ryeol
 * Since    2018.09.01
 * 
 * This file is a part of the Nicenis project.
 * https://github.com/nicenis/nicenis
 * 
 * Copyright (C) 2018 JO Hyeong-Ryeol. All rights reserved.
 */

using System;
using System.Diagnostics;
using System.Resources;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;
using System.Xaml;

namespace Nicenis.Windows.Data
{
    /// <summary>
    /// Returns a resource string in a ResourceManager.
    /// </summary>
    [MarkupExtensionReturnType(typeof(string))]
    public class LocalStringExtension : MarkupExtension
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="name">A string that specifies the localized resource string.</param>
        public LocalStringExtension(string name)
        {
            Name = name;
        }

        #endregion


        #region Public Properties

        /// <summary>
        /// Gets or sets a string that specifies the localized resource string.
        /// </summary>
        [ConstructorArgument("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a string that specifies how to format the localized resource string.
        /// </summary>
        public string StringFormat { get; set; }

        /// <summary>
        /// Gets or sets a ResourceManager that provides resource strings.
        /// </summary>
        /// <remarks>
        /// If this property is null, TODO: write this.
        /// </remarks>
        public ResourceManager Resource { get; set; }

        #endregion


        #region Helpers

        /// <summary>
        /// Gets the ResourceManager to retrieve a resource string.
        /// </summary>
        /// <param name="serviceProvider">A service provider helper that can provide services for the markup extension.</param>
        /// <returns>A resource manager if found; otherwise null.</returns>
        private ResourceManager GetTargetResource(IServiceProvider serviceProvider)
        {
            Debug.Assert(serviceProvider != null);

            if (Resource != null)
                return Resource;

            if (Localization.MainResource != null)
                return Localization.MainResource;

            // Gets a ResourceManager specified in the root object.
            if ((serviceProvider.GetService(typeof(IRootObjectProvider)) is IRootObjectProvider rootObjectProvider))
            {
                if (rootObjectProvider.RootObject is DependencyObject rootObject)
                {
                    var resource = Localization.GetResource(rootObject);
                    if (resource != null)
                        return resource;
                }
            }

            return Localization.FallbackResource;
        }

        #endregion


        #region ProvideValue

        /// <summary>
        /// When implemented in a derived class, returns an object that is provided as the value of the target property for this markup extension.
        /// </summary>
        /// <param name="serviceProvider">A service provider helper that can provide services for the markup extension.</param>
        /// <returns>The object value to set on the property where the extension is applied.</returns>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (serviceProvider == null)
                throw new ArgumentNullException(nameof(serviceProvider));

            ResourceManager resource = GetTargetResource(serviceProvider);
            if (resource == null)
                return Name;

            var bindingSource = Localization.CreateOrGetResourceBindingSource(resource);
            if (bindingSource == null)
                return null;

            var binding = new Binding("[" + Name + "]")
            {
                StringFormat = StringFormat,
                Source = bindingSource,
                Mode = BindingMode.OneWay,
            };
            return binding.ProvideValue(serviceProvider);
        }

        #endregion
    }
}
