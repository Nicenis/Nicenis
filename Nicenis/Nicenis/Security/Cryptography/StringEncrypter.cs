/*
 * Author	JO Hyeong-Ryeol (http://blog.ryeol.com/30)
 * Since	2007.10.09
 * Version	$Id: StringEncrypter.cs 24043 2013-05-21 14:49:03Z unknown $
 * 
 * Copyright (C) 2012 JO Hyeong-Ryeol. All rights reserved.
 * 
 * Permission to copy, use, modify, sell and distribute this software is granted provided this
 * copyright notice appears in all copies. This software is provided "as is" without express
 * or implied warranty, and with no claim as to its suitability for any purpose.
 */

using System;
using System.Security.Cryptography;
using System.Text;

namespace Nicenis.Security.Cryptography
{
    #region StringEncrypterKeyHashAlgorithm

    /// <summary>
    /// The hash algorithm that is used to compute hash for the encryption key.
    /// </summary>
    public enum StringEncrypterKeyHashAlgorithm
    {
        /// <summary>
        /// 128 bit MD5
        /// </summary>
        MD5,

        /// <summary>
        /// 256 bit SHA2
        /// </summary>
        SHA2_256,
    }

    #endregion


    /// <summary>
    /// This class converts a string into a cipher string, and vice versa.
    /// It uses 128/256 bit AES Algorithm in the Cipher Block Chaining (CBC) mode.
    /// Key is hashed by MD5 or SHA2-256. If the key is hashed by MD5, 128 bit AES is used.
    /// If the key is hashed by SHA2-256, 256 bit AES is used. Initialization vector is hashed by MD5.
    /// PKCS7Padding is used as a padding mode and the binary output is encoded by Base64.
    /// All strings are converted into UTF-8 before encryption or hash.
    /// </summary>
    public class StringEncrypter
    {
        #region Constants

        /// <summary>
        /// The default hash algorithm that is used to compute hash for the encryption key.
        /// </summary>
        const StringEncrypterKeyHashAlgorithm DefaultKeyHashAlgorithm = StringEncrypterKeyHashAlgorithm.MD5;

        #endregion


        /// <summary>
        /// Whether the key hash algorithm or the key or the IV is modified
        /// </summary>
        bool _isTouched = true;


        #region Constructors

        /// <summary>
        /// Creates a new StringEncrypter instance.
        /// </summary>
        /// <param name="keyHashAlgorithm">The hash algorithm that is used to compute hash for the encryption key.</param>
        /// <param name="key">The secret key string. Null or an empty string is not allowed.</param>
        /// <param name="iv">The initialization vector string. If this value is NULL, IV filled with zeros is used.</param>
        public StringEncrypter(StringEncrypterKeyHashAlgorithm keyHashAlgorithm, string key, string iv = null)
        {
            KeyHashAlgorithm = keyHashAlgorithm;
            Key = key;
            IV = iv;
        }

        /// <summary>
        /// Creates a new StringEncrypter instance.
        /// </summary>
        /// <param name="key">The secret key string. Null or an empty string is not allowed.</param>
        /// <param name="iv">The initialization vector string. If this value is NULL, IV filled with zeros is used.</param>
        public StringEncrypter(string key, string iv = null) : this(DefaultKeyHashAlgorithm, key, iv) { }

        /// <summary>
        /// Creates a new StringEncrypter instance.
        /// The Key must be set before encrypting or decrypting a string.
        /// </summary>
        public StringEncrypter() { }

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


        RijndaelManaged _rijndael;

        /// <summary>
        /// An instance for AES encryption.
        /// </summary>
        private RijndaelManaged Rijndael
        {
            get
            {
                if (_rijndael == null)
                {
                    // Creates a AES algorithm.
                    _rijndael = new RijndaelManaged();

                    // Sets cipher and padding mode.
                    _rijndael.Mode = CipherMode.CBC;
                    _rijndael.Padding = PaddingMode.PKCS7;

                    // Sets the block size.
                    _rijndael.BlockSize = 128;
                }

                return _rijndael;
            }
        }


        MD5 _md5;

        /// <summary>
        /// An instance for MD5 hash.
        /// </summary>
        private MD5 MD5
        {
            get { return _md5 ?? (_md5 = new MD5CryptoServiceProvider()); }
        }


        SHA256 _sha256;

        /// <summary>
        /// An instance for SHA2-256 hash.
        /// </summary>
        private SHA256 SHA256
        {
            get { return _sha256 ?? (_sha256 = new SHA256CryptoServiceProvider()); }
        }


        /// <summary>
        /// Prepares required values.
        /// </summary>
        private void Prepare()
        {
            if (!_isTouched)
                return;

            
            // Checks the Key.
            if (Key == null || Key == "")
                throw new InvalidOperationException("The Key can not be null or an empty string.");


            // Initializes the Key.
            switch (KeyHashAlgorithm)
            {
                case StringEncrypterKeyHashAlgorithm.MD5:
                    Rijndael.KeySize = MD5.HashSize;
                    Rijndael.Key = MD5.ComputeHash(UTF8Encoding.GetBytes(Key));
                    break;

                case StringEncrypterKeyHashAlgorithm.SHA2_256:
                    Rijndael.KeySize = SHA256.HashSize;
                    Rijndael.Key = SHA256.ComputeHash(UTF8Encoding.GetBytes(Key));
                    break;

                default:
                    throw new InvalidOperationException(string.Format("The KeyHashAlgorithm {0} is unknown.", KeyHashAlgorithm));
            }


            // Initializes the IV.
            if (IV == null)
                Rijndael.IV = new byte[Rijndael.BlockSize / 8];
            else
                Rijndael.IV = MD5.ComputeHash(UTF8Encoding.GetBytes(IV));


            _isTouched = false;
        }

        #endregion


        #region Public Properties

        StringEncrypterKeyHashAlgorithm _keyHashAlgorithm = DefaultKeyHashAlgorithm;

        /// <summary>
        /// The hash algorithm that is used to compute hash for the encryption key.
        /// MD5 and SHA2-256 are supported.
        /// This value determines the AES key size.
        /// If the hash outputs 128 bit value, 128 bit AES is used.
        /// if the hash outputs 256 bit value, 256 bit AES is used.
        /// </summary>
        public StringEncrypterKeyHashAlgorithm KeyHashAlgorithm
        {
            get { return _keyHashAlgorithm; }
            set
            {
                if (_keyHashAlgorithm == value)
                    return;

                _keyHashAlgorithm = value;
                _isTouched = true;
            }
        }


        /// <summary>
        /// The encryption key size in bits.
        /// This value depends on the key hash algorithm.
        /// </summary>
        public int KeySize
        {
            get
            {
                switch (KeyHashAlgorithm)
                {
                    case StringEncrypterKeyHashAlgorithm.MD5:
                        return MD5.HashSize;

                    case StringEncrypterKeyHashAlgorithm.SHA2_256:
                        return SHA256.HashSize;

                    default:
                        throw new InvalidOperationException(string.Format("The KeyHashAlgorithm {0} is unknown.", KeyHashAlgorithm));
                }
            }
        }


        string _key;

        /// <summary>
        /// The secret key string.
        /// The key string is converted into UTF-8 and hashed by the specified key hash algorithm.
        /// Null or an empty string is not allowed.
        /// </summary>
        public string Key
        {
            get { return _key; }
            set
            {
                if (value == null || value == "")
                    throw new ArgumentException("The key can not be null or an empty string.", "key");

                if (_key == value)
                    return;

                _key = value;
                _isTouched = true;
            }
        }


        string _iv;

        /// <summary>
        /// The initialization vector string.
        /// The initialization vector string is converted into UTF-8 and hashed by MD5.
        /// If this value is NULL, IV filled with zeros is used.
        /// </summary>
        public string IV
        {
            get { return _iv; }
            set
            {
                if (_iv == value)
                    return;

                _iv = value;
                _isTouched = true;
            }
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Encrypts a string.
        /// </summary>
        /// <param name="value">A string to encrypt. It is converted into UTF-8 before being encrypted. Null is regarded as an empty string.</param>
        /// <returns>The encrypted string.</returns>
        public string Encrypt(string value)
        {
            // Prepares required values.
            Prepare();

            if (value == null)
                value = "";

            // Gets an encryptor interface.
            ICryptoTransform transform = Rijndael.CreateEncryptor();

            // Gets the UTF-8 byte array from the unicode string.
            byte[] utf8Value = UTF8Encoding.GetBytes(value);

            // Encrypts the UTF-8 byte array.
            byte[] encryptedValue = transform.TransformFinalBlock(utf8Value, 0, utf8Value.Length);

            // Returns the base64 encoded string of the encrypted byte array.
            return Convert.ToBase64String(encryptedValue);
        }


        /// <summary>
        /// Decrypts a string which is encrypted with the same key, key hash algorithm and initialization vector. 
        /// </summary>
        /// <param name="value">A string to decrypt. It must be a string encrypted with the same key, key hash algorithm and initialization vector. Null or an empty string is not allowed.</param>
        /// <returns>The decrypted string</returns>
        public string Decrypt(string value)
        {
            if (value == null || value == "")
                throw new ArgumentException("The cipher string can not be null or an empty string.");

            // Prepares required values.
            Prepare();

            // Gets an decryptor interface.
            ICryptoTransform transform = Rijndael.CreateDecryptor();

            // Gets the encrypted byte array from the base64 encoded string.
            byte[] encryptedValue = Convert.FromBase64String(value);

            // Decrypts the byte array.
            byte[] decryptedValue = transform.TransformFinalBlock(encryptedValue, 0, encryptedValue.Length);

            // Returns the string converted from the UTF-8 byte array.
            return UTF8Encoding.GetString(decryptedValue);
        }

        #endregion
    }
}
