#pragma checksum "C:\Users\Pheng\Downloads\Compressed\AppointmentProject\AppointmentProject\Views\Shared\_PatientList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "561287ecaaf4469fdff5ec35d743df85d9dd4c5b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__PatientList), @"mvc.1.0.view", @"/Views/Shared/_PatientList.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/_PatientList.cshtml", typeof(AspNetCore.Views_Shared__PatientList))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"561287ecaaf4469fdff5ec35d743df85d9dd4c5b", @"/Views/Shared/_PatientList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e46c89ba8a6d3b76f83985b871bb18faabdb7cfc", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__PatientList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<SystemLibraryData.Patient>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(47, 915, true);
            WriteLiteral(@"
<div class=""card mb-grid"">
    <div class=""card-header d-flex justify-content-between align-items-center"">
        <div class=""card-header-title"">Patients Info</div>
        <nav class=""card-header-actions"">

            <a class=""card-header-action"" data-toggle=""collapse"" href=""#card1"" aria-expanded=""false"" aria-controls=""card1"" title=""Minimize"">
                <i data-feather=""minus-circle""></i>
            </a>
            <a title=""Create New"" class=""card-header-action"" id=""CreateNewIcon"">
                <i data-feather=""plus-circle"" title=""Add New Patient"" style=""color: royalblue""></i>
            </a>

        </nav>
    </div>
    <div class=""table-responsive-md collapse show"" id=""card1"">
        <table class=""table table-actions table-striped table-hover mb-0"" id=""patientListTable"">
            <thead>
                <tr>
                    <th>
                        ");
            EndContext();
            BeginContext(963, 39, false);
#line 22 "C:\Users\Pheng\Downloads\Compressed\AppointmentProject\AppointmentProject\Views\Shared\_PatientList.cshtml"
                   Write(Html.DisplayNameFor(model => model.PId));

#line default
#line hidden
            EndContext();
            BeginContext(1002, 79, true);
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
            EndContext();
            BeginContext(1082, 41, false);
#line 25 "C:\Users\Pheng\Downloads\Compressed\AppointmentProject\AppointmentProject\Views\Shared\_PatientList.cshtml"
                   Write(Html.DisplayNameFor(model => model.PName));

#line default
#line hidden
            EndContext();
            BeginContext(1123, 79, true);
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
            EndContext();
            BeginContext(1203, 40, false);
#line 28 "C:\Users\Pheng\Downloads\Compressed\AppointmentProject\AppointmentProject\Views\Shared\_PatientList.cshtml"
                   Write(Html.DisplayNameFor(model => model.PSex));

#line default
#line hidden
            EndContext();
            BeginContext(1243, 79, true);
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
            EndContext();
            BeginContext(1323, 40, false);
#line 31 "C:\Users\Pheng\Downloads\Compressed\AppointmentProject\AppointmentProject\Views\Shared\_PatientList.cshtml"
                   Write(Html.DisplayNameFor(model => model.PTel));

#line default
#line hidden
            EndContext();
            BeginContext(1363, 79, true);
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
            EndContext();
            BeginContext(1443, 44, false);
#line 34 "C:\Users\Pheng\Downloads\Compressed\AppointmentProject\AppointmentProject\Views\Shared\_PatientList.cshtml"
                   Write(Html.DisplayNameFor(model => model.PAddress));

#line default
#line hidden
            EndContext();
            BeginContext(1487, 79, true);
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
            EndContext();
            BeginContext(1567, 47, false);
#line 37 "C:\Users\Pheng\Downloads\Compressed\AppointmentProject\AppointmentProject\Views\Shared\_PatientList.cshtml"
                   Write(Html.DisplayNameFor(model => model.PDocumentNo));

#line default
#line hidden
            EndContext();
            BeginContext(1614, 79, true);
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
            EndContext();
            BeginContext(1694, 39, false);
#line 40 "C:\Users\Pheng\Downloads\Compressed\AppointmentProject\AppointmentProject\Views\Shared\_PatientList.cshtml"
                   Write(Html.DisplayNameFor(model => model.CNo));

#line default
#line hidden
            EndContext();
            BeginContext(1733, 207, true);
            WriteLiteral("\r\n                    </th>\r\n                    <th></th>\r\n                </tr>\r\n            </thead>\r\n            <tbody id=\"tbStudentList\">\r\n\r\n            </tbody>\r\n        </table>\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<SystemLibraryData.Patient>> Html { get; private set; }
    }
}
#pragma warning restore 1591
