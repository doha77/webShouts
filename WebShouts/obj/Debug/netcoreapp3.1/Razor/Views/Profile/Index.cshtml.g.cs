#pragma checksum "C:\Users\dohak\Desktop\WebShouts DohaKHAFI\WebShouts\Views\Profile\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b17e966b40982fd59879b69fc380ba0a0b19a851"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Profile_Index), @"mvc.1.0.view", @"/Views/Profile/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\dohak\Desktop\WebShouts DohaKHAFI\WebShouts\Views\_ViewImports.cshtml"
using WebShouts;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\dohak\Desktop\WebShouts DohaKHAFI\WebShouts\Views\_ViewImports.cshtml"
using WebShouts.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b17e966b40982fd59879b69fc380ba0a0b19a851", @"/Views/Profile/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d33528e6956faa82373f2ccc2e2287b8ad39278d", @"/Views/_ViewImports.cshtml")]
    public class Views_Profile_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IList<WebShouts.Models.UserWebShoutsVM>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\dohak\Desktop\WebShouts DohaKHAFI\WebShouts\Views\Profile\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<a href=\"/Profile/Create\">Créer un cri</a>\r\n<div class=\"row\" style=\"margin-top:50px\">\r\n");
#nullable restore
#line 9 "C:\Users\dohak\Desktop\WebShouts DohaKHAFI\WebShouts\Views\Profile\Index.cshtml"
     foreach (var item in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"col-lg-10 col-md-10 col-sm-10\">\r\n          \r\n            <div class=\"message-box\">\r\n\r\n                <div class=\"shout-message\">\r\n                    <b>Message:</b> ");
#nullable restore
#line 16 "C:\Users\dohak\Desktop\WebShouts DohaKHAFI\WebShouts\Views\Profile\Index.cshtml"
                               Write(item.Content);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n\r\n        </div>\r\n        <div class=\"col-lg-2 col-md-2 col-sm-2\">\r\n            <label>\r\n                ");
#nullable restore
#line 23 "C:\Users\dohak\Desktop\WebShouts DohaKHAFI\WebShouts\Views\Profile\Index.cshtml"
           Write(Html.ActionLink("Éditer", "Edit", "Profile", new { id = item.WebShoutId }, null));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 24 "C:\Users\dohak\Desktop\WebShouts DohaKHAFI\WebShouts\Views\Profile\Index.cshtml"
           Write(Html.ActionLink("Effacer", "Delete", "Profile", new { id = item.WebShoutId }, null));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </label>\r\n        </div>\r\n");
#nullable restore
#line 27 "C:\Users\dohak\Desktop\WebShouts DohaKHAFI\WebShouts\Views\Profile\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IList<WebShouts.Models.UserWebShoutsVM>> Html { get; private set; }
    }
}
#pragma warning restore 1591