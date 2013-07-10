/*
 * Author	JO Hyeong-Ryeol
 * Since	2012.12.09
 * Version	$Id$
 * 
 * This file is a part of the Nicenis project.
 * https://nicenis.codeplex.com
 *
 * Copyright (C) 2012 JO Hyeong-Ryeol. All rights reserved.
 */

using System;
using System.Security.Cryptography;
using System.Text;

namespace Nicenis.Security.Cryptography
{
    #region StringHasherAlgorithm

    /// <summary>
    /// The hash algorithm that is used to compute hash for the input string.
    /// </summary>
    public enum StringHasherAlgorithm
    {
        /// <summary>
        /// 128 bit MD5
        /// </summary>
        MD5,

        /// <summary>
        /// 160 bit
        /// </summary>
        SHA1,

        /// <summary>
        /// 256 bit SHA2
        /// </summary>
        SHA2_256,

        /// <summary>
        /// 384 bit SHA2
        /// </summary>
        SHA2_384,

        /// <summary>
        /// 512 bit SHA2
        /// </summary>
        SHA2_512,
    }

    #endregion


    /// <summary>
    /// This class converts a string into a hash string.
    /// The input string is converted into UTF-8 before being hashed
    /// and the hash output is encoded by Base64.
    /// </summary>
    public class StringHasher
    {
        #region Constants

        /// <summary>
        /// The default hash algorithm that is used to compute hash for the input string.
        /// </summary>
        const StringHasherAlgorithm DefaultAlgorithm = StringHasherAlgorithm.MD5;

        #endregion


        #region Constructors

        /// <summary>
        /// Creates a new StringHasher instance.
        /// </summary>
        /// <param name="algorithm">The hash algorithm that is used to compute hash for the input string.</param>
        public StringHasher(StringHasherAlgorithm algorithm)
        {
            Algorithm = algorithm;
        }

        /// <summary>
        /// Creates a new StringHasher instance.
        /// </summary>
        public StringHasher() : this(DefaultAlgorithm) { }

        #endregion


        #region Helpers

        UTF8Encoding _utf8Encoding;

        /// <summary>
        /// An instance for UTF8Encoding.
        /// </summary>
        private UTF8Encoding UTF8Encoding
        {
            get { return _utf8Encoding ?? (_utf8Encoding = new UTF8Encoding()); }
        }


        HashAlgorithm _hashAlgorithm;

        /// <summary>
        /// An instance for HashAlgorithm.
        /// </summary>
        private HashAlgorithm HashAlgorithm
        {
            get
            {
                if (_hashAlgorithm == null)
                {
                    // Initializes the hash algorithm.
                    switch (Algorithm)
                    {
                        case StringHasherAlgorithm.MD5:
                            _hashAlgorithm = MD5.Create();
                            break;

                        case StringHasherAlgorithm.SHA1:
                            _hashAlgorithm = SHA1.Create();
                            break;

                        case StringHasherAlgorithm.SHA2_256:
                            _hashAlgorithm = SHA256.Create();
                            break;

                        case StringHasherAlgorithm.SHA2_384:
                            _hashAlgorithm = SHA384.Create();
                            break;

                        case StringHasherAlgorithm.SHA2_512:
                            _hashAlgorithm = SHA512.Create();
                            break;

                        default:
                            throw new InvalidOperationException(string.Format("The Algorithm {0} is unknown.", Algorithm));
                    }
                }

                return _hashAlgorithm;
            }
        }

        #endregion


        #region Public Properties

        StringHasherAlgorithm _algorithm = DefaultAlgorithm;

        /// <summary>
        /// The hash algorithm that is used to compute hash for the input string.
        /// </summary>
        public StringHasherAlgorithm Algorithm
        {
            get { return _algorithm; }
            set
            {
                if (_algorithm == value)
                    return;

                _algorithm = value;
                _hashAlgorithm = null;  // This variable must be recreated.
            }
        }


        /// <summary>
        /// The hash size in bits.
        /// </summary>
        public int Size
        {
            get { return HashAlgorithm.HashSize; }
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Computes the hash string.
        /// The input string is converted into UTF-8 before being hashed and the hash output is encoded by Base64.
        /// </summary>
        /// <param name="value">A string to hash. It is converted into UTF-8 before being hashed. Null is regarded as an empty string.</param>
        /// <returns>The hashed string.</returns>
        public string Compute(string value)
        {
            if (value == null)
                value = "";

            // Gets the UTF-8 byte array from the unicode string.
            byte[] utf8Value = UTF8Encoding.GetBytes(value);

            // Computes hash.
            byte[] hashedValue = HashAlgorithm.ComputeHash(utf8Value);

            // Returns the base64 encoded string of the hash byte array.
            return Convert.ToBase64String(hashedValue);
        }

        #endregion
    }
}
