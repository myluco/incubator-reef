﻿/**
 * Licensed to the Apache Software Foundation (ASF) under one
 * or more contributor license agreements.  See the NOTICE file
 * distributed with this work for additional information
 * regarding copyright ownership.  The ASF licenses this file
 * to you under the Apache License, Version 2.0 (the
 * "License"); you may not use this file except in compliance
 * with the License.  You may obtain a copy of the License at
 *
 *   http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing,
 * software distributed under the License is distributed on an
 * "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
 * KIND, either express or implied.  See the License for the
 * specific language governing permissions and limitations
 * under the License.
 */

using System.Globalization;
using System.Net;
using Org.Apache.REEF.Driver.Bridge;
using Org.Apache.REEF.Tang.Annotations;
using Org.Apache.REEF.Utilities;
using Org.Apache.REEF.Utilities.Logging;

namespace Org.Apache.REEF.Examples.HelloCLRBridge.Handlers
{
    public class HelloHttpHandler : IHttpHandler
    {
        private static readonly Logger LOGGER = Logger.GetLogger(typeof(HttpServerHandler));

        [Inject]
        public HelloHttpHandler()
        {           
        }

        public string GetSpecification()
        {
            return "NRT"; //Client Example 
        }

        public void OnHttpRequest(ReefHttpRequest requet, ReefHttpResponse response)  
        {
            LOGGER.Log(Level.Info, string.Format(CultureInfo.CurrentCulture, "HelloHttpHandler OnHttpRequest: URL: {0}, QueryString: {1}, inputStream: {2}.", requet.Url, requet.Querystring, ByteUtilities.ByteArrarysToString(requet.InputStream)));
            response.Status = HttpStatusCode.OK;
            response.OutputStream =
                ByteUtilities.StringToByteArrays("Byte array returned from HelloHttpHandler in CLR!!!");
        }
    }
}
