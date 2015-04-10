//Copyright (c) Microsoft. All rights reserved. Licensed under the MIT license. See full license at the bottom of this file.
//
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Test_OAuth2RestApi
{
    class Program
    {
        static void Main(string[] args)
        {
            CommandLineArgs commandLineArgs = new CommandLineArgs();

            if (!CommandLine.Parser.Default.ParseArguments(args, commandLineArgs))
                return;

            var t = new Thread(Run);
            t.SetApartmentState(ApartmentState.STA);
            t.Start(commandLineArgs);
            t.Join();
        }


        static void Run(object obj)
        {
            CommandLineArgs args = obj as CommandLineArgs;

            if (string.IsNullOrEmpty(args.ApiAddress))
            {
                if (args.UsePPE)
                    args.ApiAddress = Constants.MeApiEndpointPPE;
                else
                    args.ApiAddress = Constants.MeApiEndpointProd;
            }

            if (string.IsNullOrEmpty(args.ClientAppId))
            {
                if (args.UsePPE)
                    args.ClientAppId = Constants.ClientIdPPE;
                else
                    args.ClientAppId = Constants.ClientIdPROD;
            }

            string authority = Constants.AuthorityProd;
            if (args.UsePPE)
            {
                authority = Constants.AuthorityPPE;
            }

            Console.WriteLine("");
            Console.WriteLine("Running with following parameters:");
            Console.WriteLine("=================================");
            Console.WriteLine("ClientId: " + args.ClientAppId);
            Console.WriteLine("RedirectUri: " + args.ClientRedirectUri);
            Console.WriteLine("API Endpoint: " + args.ApiAddress);
            Console.WriteLine("API Method: " + args.ApiMethod);
            Console.WriteLine("API Payload: " + args.ApiPayload);
            Console.WriteLine("Authority: " + authority);
            Console.WriteLine("Use AccessToken: " + (string.IsNullOrEmpty(args.AccessToken) ? "False" : "True"));
            Console.WriteLine("Use PPE: " + args.UsePPE.ToString());
            Console.WriteLine("Verbose: " + args.Verbose.ToString());
            Console.WriteLine("=================================");
            Console.WriteLine("");


            string accessToken = args.AccessToken;
            if (string.IsNullOrEmpty(accessToken))
            {
                // Initializing the Authorization context
                AuthenticationContext authenticationContext = new AuthenticationContext(authority, false);

                // Get Access Token for Graph
                accessToken = Helpers.GetAccessToken(
                    authenticationContext,
                    args.ApiAddress,
                    args.ClientAppId,
                    args.ClientRedirectUri,
                    args.Verbose);

                if (string.IsNullOrEmpty(accessToken))
                {
                    return;
                }

                Console.WriteLine("AccessToken for future usage (up to 60 minutes valid):");
                Console.WriteLine("======================================================");
                Console.WriteLine(accessToken);
                Console.WriteLine("======================================================");
                Console.WriteLine("");
            }

            if(args.ApiMethod.ToLower().Equals("get"))
            {
                TestGetRestApi api = new TestGetRestApi(args.ApiAddress, accessToken, args.Verbose);
                api.Start();
            }
            else if (args.ApiMethod.ToLower().Equals("post"))
            {
                Console.WriteLine(string.Format("INFO: Post not implemented."));
            }
            else if (args.ApiMethod.ToLower().Equals("patch"))
            {
                Console.WriteLine(string.Format("INFO: Patch not implemented."));
            }
            else if (args.ApiMethod.ToLower().Equals("delete"))
            {
                Console.WriteLine(string.Format("INFO: Delete not implemented."));
            }
            else 
            {
                if (string.IsNullOrEmpty(args.ApiMethod))
                {
                    Console.WriteLine(string.Format("ERROR: No Api Method specified."));
                }
                else
                {
                    Console.WriteLine(string.Format("ERROR: Api Method [{0}] not supported.", args.ApiMethod));
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