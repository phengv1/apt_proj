#pragma checksum "C:\Users\Pheng\Downloads\Compressed\AppointmentProject\AppointmentProject\Views\Doctor\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b63eda0f20271ba5d6c7f979993ae18c45e4a979"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Doctor_Index), @"mvc.1.0.view", @"/Views/Doctor/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Doctor/Index.cshtml", typeof(AspNetCore.Views_Doctor_Index))]
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
#line 1 "C:\Users\Pheng\Downloads\Compressed\AppointmentProject\AppointmentProject\Views\_ViewImports.cshtml"
using AppointmentProject;

#line default
#line hidden
#line 2 "C:\Users\Pheng\Downloads\Compressed\AppointmentProject\AppointmentProject\Views\_ViewImports.cshtml"
using AppointmentProject.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b63eda0f20271ba5d6c7f979993ae18c45e4a979", @"/Views/Doctor/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e46c89ba8a6d3b76f83985b871bb18faabdb7cfc", @"/Views/_ViewImports.cshtml")]
    public class Views_Doctor_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_DoctorList", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "C:\Users\Pheng\Downloads\Compressed\AppointmentProject\AppointmentProject\Views\Doctor\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
            BeginContext(43, 94, true);
            WriteLiteral("\r\n\r\n<div class=\"pb-4\">\r\n    <h4 style=\"color:#808080\"><b>Doctor Dashboard</b></h4>\r\n</div>\r\n\r\n");
            EndContext();
            BeginContext(2954, 54, true);
            WriteLiteral("<div class=\"row\">\r\n\r\n    <div class=\"col\">\r\n\r\n        ");
            EndContext();
            BeginContext(3008, 30, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "938bc26d588f426fa244dc4597ca8f02", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3038, 61, true);
            WriteLiteral("\r\n    </div>\r\n\r\n    <div class=\"col-md-4\" id=\"EditDocForm\">\r\n");
            EndContext();
#line 85 "C:\Users\Pheng\Downloads\Compressed\AppointmentProject\AppointmentProject\Views\Doctor\Index.cshtml"
          Html.RenderPartial("_EditDocQueue", new AppointmentProject.Models.DoctorModel());

#line default
#line hidden
            BeginContext(3193, 122, true);
            WriteLiteral("    </div>\r\n\r\n</div>\r\n\r\n<script>\r\n    $(document).ready(() => {\r\n\r\n        LoadDoctorData();\r\n    });\r\n    \r\n</script>\r\n\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(3333, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 99 "C:\Users\Pheng\Downloads\Compressed\AppointmentProject\AppointmentProject\Views\Doctor\Index.cshtml"
      await Html.RenderPartialAsync("_ValidationScriptsPartial");

#line default
#line hidden
            }
            );
            BeginContext(3406, 2, true);
            WriteLiteral("\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
