//Copyright (c) Microsoft. All rights reserved. Licensed under the MIT license. See full license at the bottom of this file.
//
using CommandLine;
using CommandLine.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_OAuth2RestApi
{
    class CommandLineArgs
    {
        [Option('i', "AppId",
            HelpText = "ApplicationIdentifier or ClientId.")]
        public string ClientAppId { get; set; }

        [Option('r', "RedirectUri", DefaultValue = Constants.DefaultInstalledClientRedirectUri,
            HelpText = "Client reply address of the application as registered in AAD.")]
        public string ClientRedirectUri { get; set; }

        [Option('a', "ApiAddress",
            HelpText = "Api address of the Rest API to access. If nothing specified /me is used.")]
        public string ApiAddress { get; set; }

        [Option('m', "ApiMethod", DefaultValue = Constants.DefaultApiMethod,
            HelpText = "Api Method. Supported is [Get, Post, Delete, Patch].")]
        public string ApiMethod { get; set; }

        [Option('p', "ApiPayload",
            HelpText = "Payload to pass with Api call. Required for Post and Patch.")]
        public string ApiPayload { get; set; }

        [Option('t', "AccessToken",
            HelpText = "Use this AccessToken for access and avoid authentication prompt.")]
        public string AccessToken { get; set; }

        [Option('o', "UsePPE", DefaultValue = false,
            HelpText = "Override to use PPE environment.")]
        public bool UsePPE { get; set; }

        [Option('v', "Verbose", DefaultValue = false,
            HelpText = "Print details.")]
        public bool Verbose { get; set; }

        [ParserState]
        public IParserState LastParserState { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            return HelpText.AutoBuild(this,
                (HelpText current) => HelpText.DefaultParsingErrorsHandler(this, current));
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