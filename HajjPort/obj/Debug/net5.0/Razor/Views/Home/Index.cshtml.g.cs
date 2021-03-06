#pragma checksum "C:\Users\iApps\Documents\GitHub\HajjPort\HajjPort\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d4de5a49def47b5d388f1e68124d3164139c9c13"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "C:\Users\iApps\Documents\GitHub\HajjPort\HajjPort\Views\_ViewImports.cshtml"
using HajjPort;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\iApps\Documents\GitHub\HajjPort\HajjPort\Views\_ViewImports.cshtml"
using HajjPort.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\iApps\Documents\GitHub\HajjPort\HajjPort\Views\_ViewImports.cshtml"
using HajjPort.ViewModel;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\iApps\Documents\GitHub\HajjPort\HajjPort\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d4de5a49def47b5d388f1e68124d3164139c9c13", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b67263aff4f3d3946db22a275b9f6a697bc48dae", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\iApps\Documents\GitHub\HajjPort\HajjPort\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";
    double totalAll = 0;
    double totalMAll = 0;
    double totalFAll = 0;

    double totalOut = 0;
    double totalMOut = 0;
    double totalFOut = 0;

    double totalIn = 0;
    double totalMIn = 0;
    double totalFIn = 0;
    foreach (var item in ViewData["PortOperations"] as IEnumerable<PortOperations>)
    {
        

                totalAll += Convert.ToInt32(item.Quantity);

                if (item.Gender == "??????")
                    totalMAll += Convert.ToInt32(item.Quantity);


                if (item.Gender != "??????")
                    totalFAll += Convert.ToInt32(item.Quantity);

                if (item.MovementType == "????????")
                {
                    totalIn += Convert.ToInt32(item.Quantity);

                    if (item.Gender == "??????")
                        totalMIn += Convert.ToInt32(item.Quantity);


                    if (item.Gender != "??????")
                        totalFIn += Convert.ToInt32(item.Quantity);
                }

                if (item.MovementType != "????????")
                {
                    totalOut += Convert.ToInt32(item.Quantity);

                    if (item.Gender == "??????")
                        totalMOut += Convert.ToInt32(item.Quantity);


                    if (item.Gender != "??????")
                        totalFOut += Convert.ToInt32(item.Quantity);
                }

            
       
    
}

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""text-center"">
    <h1 class=""display-4"">?????????????? </h1>
    <p>
        ?????? ?????? ???????????????? ??????????????
    </p>
</div>

<div class=""container p-4"">
    <h1>?????? ???????????????? ?????????????? </h1>
    <br />
    <div class=""row"">
        <div class=""col-md-2"">
            ????????????  ????????
            &nbsp;
            <i class=""fa fa-male""></i>
        </div>
        <div class=""col-md-2"">
            ");
#nullable restore
#line 74 "C:\Users\iApps\Documents\GitHub\HajjPort\HajjPort\Views\Home\Index.cshtml"
       Write(totalMAll);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <div class=\"col-md-2\">\r\n            ????????????  ????????????\r\n\r\n        </div>\r\n        <div class=\"col-md-2\">\r\n            ");
#nullable restore
#line 81 "C:\Users\iApps\Documents\GitHub\HajjPort\HajjPort\Views\Home\Index.cshtml"
       Write(totalFAll);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <div class=\"col-md-2\">\r\n            ????????????????\r\n        </div>\r\n        <div class=\"col-md-2\">\r\n            ");
#nullable restore
#line 87 "C:\Users\iApps\Documents\GitHub\HajjPort\HajjPort\Views\Home\Index.cshtml"
       Write(totalAll);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n\r\n\r\n    </div>\r\n    <hr />\r\n    <div class=\"row\">\r\n        <div class=\"col-md-2\">\r\n            ???????????? ???????????? ????????\r\n\r\n        </div>\r\n        <div class=\"col-md-2\">\r\n            ");
#nullable restore
#line 99 "C:\Users\iApps\Documents\GitHub\HajjPort\HajjPort\Views\Home\Index.cshtml"
       Write(totalMIn);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <div class=\"col-md-2\">\r\n            ???????????? ???????????? ????????????\r\n\r\n        </div>\r\n        <div class=\"col-md-2\">\r\n            ");
#nullable restore
#line 106 "C:\Users\iApps\Documents\GitHub\HajjPort\HajjPort\Views\Home\Index.cshtml"
       Write(totalFIn);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <div class=\"col-md-2\">\r\n            ????????????????\r\n        </div>\r\n        <div class=\"col-md-2\">\r\n            ");
#nullable restore
#line 112 "C:\Users\iApps\Documents\GitHub\HajjPort\HajjPort\Views\Home\Index.cshtml"
       Write(totalIn);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n\r\n\r\n    </div>\r\n    <hr />\r\n    <div class=\"row\">\r\n        <div class=\"col-md-2\">\r\n            ???????????? ???????????? ????????\r\n\r\n        </div>\r\n        <div class=\"col-md-2\">\r\n            ");
#nullable restore
#line 124 "C:\Users\iApps\Documents\GitHub\HajjPort\HajjPort\Views\Home\Index.cshtml"
       Write(totalMOut);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <div class=\"col-md-2\">\r\n            ???????????? ???????????? ????????????\r\n\r\n        </div>\r\n        <div class=\"col-md-2\">\r\n            ");
#nullable restore
#line 131 "C:\Users\iApps\Documents\GitHub\HajjPort\HajjPort\Views\Home\Index.cshtml"
       Write(totalFOut);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <div class=\"col-md-2\">\r\n            ????????????????\r\n        </div>\r\n        <div class=\"col-md-2\">\r\n            ");
#nullable restore
#line 137 "C:\Users\iApps\Documents\GitHub\HajjPort\HajjPort\Views\Home\Index.cshtml"
       Write(totalOut);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n\r\n\r\n    </div>\r\n\r\n\r\n    <br />\r\n    <br />\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d4de5a49def47b5d388f1e68124d3164139c9c139012", async() => {
                WriteLiteral(@"
        <div class=""row bg-light p-3"">
            <div class=""col-md-6"">
                <div class=""form-group"">
                    <label class=""control-label "">??????????????</label>

                    <input type=""date"" name=""from""  class=""form-control"" />
                </div>
            </div>
            <div class=""col-md-6"">
                <div class=""form-group"">
                    <label class=""control-label "">??????????????</label>

                    <input type=""date"" name=""to""   class=""form-control"" />
                </div>
            </div>
            
            <div class=""col-md-12"">
                <div class=""form-group"">
                    <input type=""submit"" value=""??????"" class=""btn btn-dark""    />
                </div>
            </div>
        </div>
       
      
    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
    <br />

    <br />
    <div class=""table-responsive"">
        <table class=""table table-striped table-sm"">
            <thead>
                <tr>
                    <th scope=""col"">????????????</th>
                    <th scope=""col"">????????????</th>
                    <th scope=""col"">?????? ?? ?????????? ??????????????</th>
                    <th scope=""col"">?????? ????????????</th>
                    <th scope=""col"">?????? ??????????????</th>
                    <th scope=""col"">??????????</th>
                    <th scope=""col"">?????? ??????????</th>
                </tr>
            </thead>
            <tbody>

");
#nullable restore
#line 190 "C:\Users\iApps\Documents\GitHub\HajjPort\HajjPort\Views\Home\Index.cshtml"
                 foreach (var item in ViewData["PortOperations"] as IEnumerable<PortOperations>)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>");
#nullable restore
#line 193 "C:\Users\iApps\Documents\GitHub\HajjPort\HajjPort\Views\Home\Index.cshtml"
                       Write(item.Port.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 194 "C:\Users\iApps\Documents\GitHub\HajjPort\HajjPort\Views\Home\Index.cshtml"
                       Write(item.Port.AppUser.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 195 "C:\Users\iApps\Documents\GitHub\HajjPort\HajjPort\Views\Home\Index.cshtml"
                       Write(item.EntryDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 196 "C:\Users\iApps\Documents\GitHub\HajjPort\HajjPort\Views\Home\Index.cshtml"
                       Write(item.MovementType);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 197 "C:\Users\iApps\Documents\GitHub\HajjPort\HajjPort\Views\Home\Index.cshtml"
                       Write(item.TransportType);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 198 "C:\Users\iApps\Documents\GitHub\HajjPort\HajjPort\Views\Home\Index.cshtml"
                       Write(item.Quantity);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 199 "C:\Users\iApps\Documents\GitHub\HajjPort\HajjPort\Views\Home\Index.cshtml"
                       Write(item.Gender);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 200 "C:\Users\iApps\Documents\GitHub\HajjPort\HajjPort\Views\Home\Index.cshtml"
                          

                            totalAll += Convert.ToInt32(item.Quantity);

                            if (item.Gender == "??????")
                                totalMAll += Convert.ToInt32(item.Quantity);


                            if (item.Gender != "??????")
                                totalFAll += Convert.ToInt32(item.Quantity);

                            if (item.MovementType == "????????")
                            {
                                totalIn += Convert.ToInt32(item.Quantity);

                                if (item.Gender == "??????")
                                    totalMIn += Convert.ToInt32(item.Quantity);


                                if (item.Gender != "??????")
                                    totalFIn += Convert.ToInt32(item.Quantity);
                            }

                            if (item.MovementType != "????????")
                            {
                                totalOut += Convert.ToInt32(item.Quantity);

                                if (item.Gender == "??????")
                                    totalMOut += Convert.ToInt32(item.Quantity);


                                if (item.Gender != "??????")
                                    totalFOut += Convert.ToInt32(item.Quantity);
                            }

                        

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </tr>\r\n");
#nullable restore
#line 237 "C:\Users\iApps\Documents\GitHub\HajjPort\HajjPort\Views\Home\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </tbody>\r\n\r\n        </table>\r\n\r\n\r\n    </div>\r\n\r\n</div>\r\n");
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
