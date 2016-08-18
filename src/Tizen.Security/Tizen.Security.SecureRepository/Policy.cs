﻿/*
 *  Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
 *
 *  Licensed under the Apache License, Version 2.0 (the "License");
 *  you may not use this file except in compliance with the License.
 *  You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 *  Unless required by applicable law or agreed to in writing, software
 *  distributed under the License is distributed on an "AS IS" BASIS,
 *  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 *  See the License for the specific language governing permissions and
 *  limitations under the License
 */

using System;
using static Interop;

namespace Tizen.Security.SecureRepository
{
    /// <summary>
    /// A class for a policy for storing key, certificate, and binary data.
    /// </summary>
    public class Policy
    {
        /// <summary>
        /// A default constructor of Policy with default policy.
        /// </summary>
        /// <remarks>The default value for Password is null and the default value for Extractabl is false.</remarks>
        public Policy()
        {
            Password = null;
            Extractable = true;
        }

        /// <summary>
        /// A constructor of Key that takes the flag for extractable.
        /// </summary>
        /// <param name="extractable">If true key may be extracted from secure repository.</param>
        /// <remarks>The default value for Password is null.</remarks>
        public Policy(bool extractable)
        {
            Password = null;
            Extractable = extractable;
        }

        /// <summary>
        /// A constructor of Key that takes the password.
        /// </summary>
        /// <param name="password">Used to encrypt data secure repository.</param>
        /// <remarks>The default value for Extractabl is false.</remarks>
        public Policy(String password)
        {
            Password = password;
            Extractable = true;
        }

        /// <summary>
        /// A constructor of Key that takes the password and the flag for extractable.
        /// </summary>
        /// <param name="password">Used to encrypt data secure repository.</param>
        /// <param name="extractable">If true key may be extracted from secure repository.</param>
        public Policy(String password, bool extractable)
        {
            Password = password;
            Extractable = extractable;
        }

        /// <summary>
        /// Used to encrypt data secure repository. If it is not null, the data
        /// (or key, or certificate) is stored encrypted with this password inside secure repository
        /// </summary>
        public String Password
        {
            get; set;
        }

        /// <summary>
        /// If true key may be extracted from secure repository.
        /// </summary>
        public bool Extractable
        {
            get; set;
        }

        internal CkmcPolicy ToCkmcPolicy()
        {
            return new Interop.CkmcPolicy(Password, Extractable);
        }
    }
}
