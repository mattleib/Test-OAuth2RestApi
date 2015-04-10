# Test-OAuth2RestApi

Example: Test-OAuth2RestApi -a https://outlook.office365.com/api/v1.0/me/folders/inbox/messages -v

Test-OAuth2RestApi 1.0.0.0
Copyright c  2015

  -i, --AppId          ApplicationIdentifier or ClientId.

  -r, --RedirectUri    (Default: https://matthias.resttestapp.com) Client reply
                       address of the application as registered in AAD.

  -a, --ApiAddress     Api address of the Rest API to access. If nothing
                       specified /me is used.

  -m, --ApiMethod      (Default: get) Api Method. Supported is [Get, Post,
                       Delete, Patch].  ** Only Get is implemented right now **

  -p, --ApiPayload     Payload to pass with Api call. Required for Post and
                       Patch.

  -t, --AccessToken    Use this AccessToken for access and avoid authentication
                       prompt.

  -o, --UsePPE         (Default: False) Override to use PPE environment.

  -v, --Verbose        (Default: False) Print details.

  --help               Display this help screen.
