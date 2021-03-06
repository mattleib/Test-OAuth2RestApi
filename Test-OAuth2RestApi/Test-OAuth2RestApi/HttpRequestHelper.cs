﻿//Copyright (c) Microsoft. All rights reserved. Licensed under the MIT license. See full license at the bottom of this file.
//
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;

namespace Test_OAuth2RestApi
{
        public class HttpRequestHelper
        {
            public static string MakeHttpRequest(Func<HttpRequestMessage> requestCreator, string accessToken, string userAgent)
            {
                using (HttpClient client = new HttpClient())
                {
                    // add propper instrumentation headers
                    string clientRequestId = Guid.NewGuid().ToString();
                    client.DefaultRequestHeaders.Add("client-request-id", clientRequestId);
                    client.DefaultRequestHeaders.Add("UserAgent", userAgent);
                    client.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer {0}", accessToken));

                    using (HttpRequestMessage request = requestCreator.Invoke())
                    {
                        string responseString = string.Format("\"response\" : \"no response\"");

                        try
                        {
                            HttpResponseMessage httpResponse = client.SendAsync(request).Result;
                            if (httpResponse.StatusCode == HttpStatusCode.OK)
                            {
                                responseString = httpResponse.Content.ReadAsStringAsync().Result;
                                return responseString;
                            }

                            string error = string.Format("\"httpRequest\" : \"{0}\"", httpResponse.RequestMessage.RequestUri.ToString());
                            error = error + string.Format(", \"httpStatus\" : \"{0}\"", httpResponse.StatusCode.ToString());
                            error = error + string.Format(", \"reason\" : \"{0}\"", httpResponse.ReasonPhrase);

                            //httpResponse.Headers.Select(h => h.Key.Equals("x-ms-diagnostics")).First();
                            foreach (var header in httpResponse.Headers)
                            {
                                // x-ms-diagnostics contains details why request was unauthorized
                                if (header.Key.Equals("x-ms-diagnostics"))
                                {
                                    string e = string.Format("{0}", header.Value.ToArray());
                                    e = e.Replace("\"", "'");
                                    error = error + string.Format(", \"x-ms-diagnostics\" : \"{0}\"", e);
                                }
                                else
                                {
                                    string e = string.Format("{0}", header.Value.ToArray());
                                    error = error + string.Format(", \"{0}\" : \"{1}\"", header.Key, e);
                                }
                            }

                            responseString = string.Format("{{{0}}}", error);
                            return responseString;

                        }
                        catch (WebException webex)
                        {
                            HttpWebResponse httpWebResponse = webex.Response as HttpWebResponse;

                            if (httpWebResponse != null)
                            {
                                using (Stream serviceResponseStream = httpWebResponse.GetResponseStream())
                                {
                                    using (StreamReader reader = new StreamReader(serviceResponseStream))
                                    {
                                        JObject jsonResponse = JObject.Parse(reader.ReadToEnd());
                                        return jsonResponse.ToString();
                                    }
                                }
                            }

                            string error = string.Format("\"error\" : \"{0}\"", webex.Message);
                            responseString = string.Format("{{{0}}}", error);
                            return responseString;
                        }
                        catch (Exception ex)
                        {
                            string error = string.Format("\"error\" : \"{0}\"", ex.Message);
                            responseString = string.Format("{{{0}}}", error);
                            return responseString;
                        }
                    }
                }
            }
        }
}
// MIT License: 

// Permission is hereby granted, free of charge, to any person obtaining 
// a copy of this software and associated documentation files (the 
// ""Software""), to deal in the Software without restriction, including 
// without limitation the rights to use, copy, modify, merge, publish, 
// distribute, sublicense, and/or sell copies of the Software, and to 
// permit persons to whom the Software is furnished to do so, subject to 
// the following conditions: 

// The above copyright notice and this permission notice shall be 
// included in all copies or substantial portions of the Software. 

// THE SOFTWARE IS PROVIDED ""AS IS"", WITHOUT WARRANTY OF ANY KIND, 
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF 
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND 
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE 
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION 
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION 
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.