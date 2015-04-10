//Copyright (c) Microsoft. All rights reserved. Licensed under the MIT license. See full license at the bottom of this file.
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_OAuth2RestApi
{
    class Constants
    {
        public const string ClientIdPROD = "f13cf679-0bde-4915-9b44-20377eaa425d";
        public const string ClientIdPPE = "5860233e-1e71-4fbd-940b-84823fb71303";
        public const string DefaultInstalledClientRedirectUri = "https://matthias.resttestapp.com";

        public const string AuthorityPPE = "https://login.windows-ppe.net/common/authorize";
        public const string AuthorityProd = "https://login.windows.net/common/authorize";

        public const string ResourceProd = "https://outlook.office365.com";
        public const string RestApiEndpointProd = Constants.ResourceProd + "/api/v1.0";
        public const string MeApiEndpointProd = Constants.ResourceProd + "/api/v1.0/me";

        public const string ResourcePPE = "https://sdfpilot.outlook.com";
        public const string RestApiEndpointPPE = Constants.ResourcePPE + "/api/v1.0";
        public const string MeApiEndpointPPE = Constants.ResourcePPE + "/api/v1.0/me";

        public const string DefaultApiMethod = "get";

        public const string UserAgent = "Test-OAuth2RestApi/1.0";
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