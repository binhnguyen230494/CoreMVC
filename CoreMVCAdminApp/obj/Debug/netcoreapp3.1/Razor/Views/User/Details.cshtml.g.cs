#pragma checksum "C:\Users\rrrrr\source\repos\CoreMVC\CoreMVCAdminApp\Views\User\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "eb14c4de988358beb454f653f8f473d27c09468b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_Details), @"mvc.1.0.view", @"/Views/User/Details.cshtml")]
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
#line 1 "C:\Users\rrrrr\source\repos\CoreMVC\CoreMVCAdminApp\Views\_ViewImports.cshtml"
using CoreMVCAdminApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\rrrrr\source\repos\CoreMVC\CoreMVCAdminApp\Views\_ViewImports.cshtml"
using CoreMVCAdminApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eb14c4de988358beb454f653f8f473d27c09468b", @"/Views/User/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7b8ca9fbad4cf8d4412a72d91659b707cd205dc0", @"/Views/_ViewImports.cshtml")]
    public class Views_User_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CoreMVCViewModels.System.Users.UserVm>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "User", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 3 "C:\Users\rrrrr\source\repos\CoreMVC\CoreMVCAdminApp\Views\User\Details.cshtml"
   ViewData["Title"] = "Chi tiết";
                Layout = "~/Views/Shared/_Layout.cshtml"; 

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""container-fluid"">
    <h1 class=""mt-4"">Chi tiết</h1>
    <ol class=""breadcrumb mb-4"">
        <li class=""breadcrumb-item""><a href=""/"">Trang chủ</a></li>
        <li class=""breadcrumb-item active"">Chi tiết</li>
    </ol>
    <div class=""card mb-4"">
        <div class=""card-header"">
            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "eb14c4de988358beb454f653f8f473d27c09468b4669", async() => {
                WriteLiteral("Về danh sách");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n        </div>\n\n        <div class=\"card-body\">\n            <div class=\"col-md-12\">\n                <dl class=\"row\">\n                    <dt class=\"col-sm-2\">\n                        ");
#nullable restore
#line 21 "C:\Users\rrrrr\source\repos\CoreMVC\CoreMVCAdminApp\Views\User\Details.cshtml"
                   Write(Html.DisplayNameFor(model => model.FirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                    </dt>\n                    <dd class=\"col-sm-10\">\n                        ");
#nullable restore
#line 24 "C:\Users\rrrrr\source\repos\CoreMVC\CoreMVCAdminApp\Views\User\Details.cshtml"
                   Write(Html.DisplayFor(model => model.FirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                    </dd>\n                    <dt class=\"col-sm-2\">\n                        ");
#nullable restore
#line 27 "C:\Users\rrrrr\source\repos\CoreMVC\CoreMVCAdminApp\Views\User\Details.cshtml"
                   Write(Html.DisplayNameFor(model => model.LastName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                    </dt>\n                    <dd class=\"col-sm-10\">\n                        ");
#nullable restore
#line 30 "C:\Users\rrrrr\source\repos\CoreMVC\CoreMVCAdminApp\Views\User\Details.cshtml"
                   Write(Html.DisplayFor(model => model.LastName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                    </dd>\n                    <dt class=\"col-sm-2\">\n                        ");
#nullable restore
#line 33 "C:\Users\rrrrr\source\repos\CoreMVC\CoreMVCAdminApp\Views\User\Details.cshtml"
                   Write(Html.DisplayNameFor(model => model.PhoneNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                    </dt>\n                    <dd class=\"col-sm-10\">\n                        ");
#nullable restore
#line 36 "C:\Users\rrrrr\source\repos\CoreMVC\CoreMVCAdminApp\Views\User\Details.cshtml"
                   Write(Html.DisplayFor(model => model.PhoneNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                    </dd>\n                    <dt class=\"col-sm-2\">\n                        ");
#nullable restore
#line 39 "C:\Users\rrrrr\source\repos\CoreMVC\CoreMVCAdminApp\Views\User\Details.cshtml"
                   Write(Html.DisplayNameFor(model => model.UserName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                    </dt>\n                    <dd class=\"col-sm-10\">\n                        ");
#nullable restore
#line 42 "C:\Users\rrrrr\source\repos\CoreMVC\CoreMVCAdminApp\Views\User\Details.cshtml"
                   Write(Html.DisplayFor(model => model.UserName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                    </dd>\n                    <dt class=\"col-sm-2\">\n                        ");
#nullable restore
#line 45 "C:\Users\rrrrr\source\repos\CoreMVC\CoreMVCAdminApp\Views\User\Details.cshtml"
                   Write(Html.DisplayNameFor(model => model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                    </dt>\n                    <dd class=\"col-sm-10\">\n                        ");
#nullable restore
#line 48 "C:\Users\rrrrr\source\repos\CoreMVC\CoreMVCAdminApp\Views\User\Details.cshtml"
                   Write(Html.DisplayFor(model => model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                    </dd>\n                    <dt class=\"col-sm-2\">\n                        ");
#nullable restore
#line 51 "C:\Users\rrrrr\source\repos\CoreMVC\CoreMVCAdminApp\Views\User\Details.cshtml"
                   Write(Html.DisplayNameFor(model => model.Dob));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                    </dt>\n                    <dd class=\"col-sm-10\">\n                        ");
#nullable restore
#line 54 "C:\Users\rrrrr\source\repos\CoreMVC\CoreMVCAdminApp\Views\User\Details.cshtml"
                   Write(Html.DisplayFor(model => model.Dob));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                    </dd>\n                </dl>\n            </div>\n        </div>\n    </div>\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CoreMVCViewModels.System.Users.UserVm> Html { get; private set; }
    }
}
#pragma warning restore 1591
