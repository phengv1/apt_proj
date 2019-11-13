#pragma checksum "C:\Users\Pheng\source\repos\AppointmentProject\AppointmentProject\Views\Shared\_AppointmentList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d6410c403c4b048cf15c9885d97d047cecff8b46"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__AppointmentList), @"mvc.1.0.view", @"/Views/Shared/_AppointmentList.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/_AppointmentList.cshtml", typeof(AspNetCore.Views_Shared__AppointmentList))]
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
#line 1 "C:\Users\Pheng\source\repos\AppointmentProject\AppointmentProject\Views\_ViewImports.cshtml"
using AppointmentProject;

#line default
#line hidden
#line 2 "C:\Users\Pheng\source\repos\AppointmentProject\AppointmentProject\Views\_ViewImports.cshtml"
using AppointmentProject.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d6410c403c4b048cf15c9885d97d047cecff8b46", @"/Views/Shared/_AppointmentList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e46c89ba8a6d3b76f83985b871bb18faabdb7cfc", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__AppointmentList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<SystemLibraryData.Appointment>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(51, 2007, true);
            WriteLiteral(@"
<div class=""card mb-grid"">
    <div class=""card-header d-flex justify-content-between align-items-center"">
        <div class=""card-header-title"">Appointment Info</div>
        <div class=""text-center"">

        </div>
        <nav class=""card-header-actions"">
            <a class=""card-header-action dropdown"">
                <i class=""fa fa-calendar-plus-o btn text-info  dropdown-toggle"" data-toggle=""dropdown"" style=""padding:0;"" id=""chkByDate""></i>
                <ul class=""dropdown-menu"" style=""padding: 25px;min-width: 200px;"">
                    <li>
                        <div class=""row"">
                      
                            <input class=""form-control col-12"" type=""date"" placeholder=""From..."" style=""border-radius: 0; padding-top:10px"" id=""ApDate1"" />

                       
                            <input class=""form-control col-12"" type=""date"" placeholder=""Until..."" style=""border-radius: 0; padding-top:10px"" id=""ApDate2"" />

                            <button i");
            WriteLiteral(@"d=""ChkAptBtn"" style=""padding-top:10px"" onclick=""CheckAptByDate()"" class=""btn btn-block btn-outline-info"">Search</button>


                        </div>

                    </li>
                </ul>
            </a>
            <a class=""card-header-action"" data-toggle=""collapse"" href=""#ApTableContainer"" aria-expanded=""false"" aria-controls=""ApTableContainer"" title=""Minimize"">
                <i data-feather=""minus-circle""></i>
            </a>
            <a title=""Make an appointment"" class=""card-header-action"" id=""CreateApIcon"">
                <i data-feather=""plus-circle"" title=""Add New Appointment"" style=""color: royalblue""></i>
            </a>

        </nav>
    </div>
    <div class=""table-responsive-md collapse show"" id=""ApTableContainer"">
        <table class=""table table-actions table-striped table-hover mb-0"" id=""ApTable"" data-role=""table"">

            <thead>
                <tr>
                    <th>
                        ");
            EndContext();
            BeginContext(2059, 40, false);
#line 44 "C:\Users\Pheng\source\repos\AppointmentProject\AppointmentProject\Views\Shared\_AppointmentList.cshtml"
                   Write(Html.DisplayNameFor(model => model.ApId));

#line default
#line hidden
            EndContext();
            BeginContext(2099, 79, true);
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
            EndContext();
            BeginContext(2179, 39, false);
#line 47 "C:\Users\Pheng\source\repos\AppointmentProject\AppointmentProject\Views\Shared\_AppointmentList.cshtml"
                   Write(Html.DisplayNameFor(model => model.CNo));

#line default
#line hidden
            EndContext();
            BeginContext(2218, 79, true);
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
            EndContext();
            BeginContext(2298, 41, false);
#line 50 "C:\Users\Pheng\source\repos\AppointmentProject\AppointmentProject\Views\Shared\_AppointmentList.cshtml"
                   Write(Html.DisplayNameFor(model => model.ChFee));

#line default
#line hidden
            EndContext();
            BeginContext(2339, 79, true);
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
            EndContext();
            BeginContext(2419, 39, false);
#line 53 "C:\Users\Pheng\source\repos\AppointmentProject\AppointmentProject\Views\Shared\_AppointmentList.cshtml"
                   Write(Html.DisplayNameFor(model => model.DId));

#line default
#line hidden
            EndContext();
            BeginContext(2458, 79, true);
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
            EndContext();
            BeginContext(2538, 42, false);
#line 56 "C:\Users\Pheng\source\repos\AppointmentProject\AppointmentProject\Views\Shared\_AppointmentList.cshtml"
                   Write(Html.DisplayNameFor(model => model.ApDate));

#line default
#line hidden
            EndContext();
            BeginContext(2580, 81, true);
            WriteLiteral("\r\n                    </th>\r\n\r\n                    <th>\r\n                        ");
            EndContext();
            BeginContext(2662, 44, false);
#line 60 "C:\Users\Pheng\source\repos\AppointmentProject\AppointmentProject\Views\Shared\_AppointmentList.cshtml"
                   Write(Html.DisplayNameFor(model => model.ChStatus));

#line default
#line hidden
            EndContext();
            BeginContext(2706, 192, true);
            WriteLiteral("\r\n                    </th>\r\n\r\n                    <th></th>\r\n                </tr>\r\n            </thead>\r\n            <tbody id=\"tbApList\"></tbody>\r\n        </table>\r\n\r\n    </div>\r\n\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<SystemLibraryData.Appointment>> Html { get; private set; }
    }
}
#pragma warning restore 1591
