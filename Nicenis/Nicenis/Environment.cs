/*
 * Author	JO Hyeong-Ryeol
 * Since	2012.08.12
 * Version	$Id$
 * 
 * Copyright (C) 2012 JO Hyeong-Ryeol. All rights reserved.
 */

using System;
using System.Linq;
using System.Management;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;

namespace Nicenis
{
    /// <summary>
    /// Provides functionalities related to environment.
    /// </summary>
    internal static class Environment
    {
        #region GetId

        /// <summary>
        /// Returns true if the environment ID is cached.
        /// </summary>
        private static bool IsIdCached = false;

        /// <summary>
        /// The cached environment ID that is encoded by Base64.
        /// </summary>
        private static string CachedId = null;

        /// <summary>
        /// Returns an environment ID.
        /// This value can be used to identify a system, but it is not guaranteed.
        /// The hash algorithm used to generate ID is MD5. So the length is 24.
        /// Returns null if it fails to generate it.
        /// </summary>
        /// <returns>An environment ID.</returns>
        public static string GetId()
        {
            // If it is not cached
            if (!IsIdCached)
            {
                try
                {
                    // Gets the bios manufacturer.
                    string biosManufacturer = null;
                    foreach (ManagementObject managementObject in new ManagementClass("Win32_BIOS").GetInstances())
                    {
                        biosManufacturer = managementObject.GetPropertyValue("Manufacturer").ToString();
                        break;
                    }

                    // If it is not found
                    if (string.IsNullOrWhiteSpace(biosManufacturer))
                        return null;


                    // Finds a non-virtual nic's MAC address.
                    NetworkInterface[] networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();

                    // First, finds a wireless nic.
                    NetworkInterface foundNetworkInterface = networkInterfaces.FirstOrDefault
                    (
                        p => p.NetworkInterfaceType == NetworkInterfaceType.Wireless80211
                    );

                    // If not found, finds a Realtek nic.
                    if (foundNetworkInterface == null)
                    {
                        foundNetworkInterface = networkInterfaces.FirstOrDefault
                        (
                            p =>
                            (
                                p.NetworkInterfaceType == NetworkInterfaceType.Ethernet
                                ||
                                p.NetworkInterfaceType == NetworkInterfaceType.GigabitEthernet
                            )
                            && p.Description.StartsWith("Realtek", StringComparison.OrdinalIgnoreCase)
                        );
                    }

                    // If not found, gets the first nic.
                    if (foundNetworkInterface == null)
                    {
                        foundNetworkInterface = networkInterfaces.FirstOrDefault
                        (
                            p => p.NetworkInterfaceType == NetworkInterfaceType.Ethernet
                                || p.NetworkInterfaceType == NetworkInterfaceType.GigabitEthernet
                        );
                    }

                    // If MAC address does not exist
                    if (foundNetworkInterface == null)
                        return null;


                    // Creates a byte arrary combining the bios name with the MAC address.
                    byte[] utf8BiosManufacturer = Encoding.UTF8.GetBytes(biosManufacturer);
                    byte[] physicalAddress = foundNetworkInterface.GetPhysicalAddress().GetAddressBytes();

                    byte[] idToHash = new byte[utf8BiosManufacturer.Length + physicalAddress.Length];
                    Array.Copy(utf8BiosManufacturer, idToHash, utf8BiosManufacturer.Length);
                    Array.Copy(physicalAddress, 0, idToHash, utf8BiosManufacturer.Length, physicalAddress.Length);


                    // Hashs using MD5.
                    byte[] hashedId = new MD5CryptoServiceProvider().ComputeHash(idToHash);


                    // Encodes the generated ID using Base64.
                    CachedId = Convert.ToBase64String(hashedId);
                }
                catch { }
                finally
                {
                    // Marks it is cached.
                    IsIdCached = true;
                }

            } // if (!IsIdCached)

            // Returns the cached ID.
            return CachedId;
        }

        #endregion
    }
}
