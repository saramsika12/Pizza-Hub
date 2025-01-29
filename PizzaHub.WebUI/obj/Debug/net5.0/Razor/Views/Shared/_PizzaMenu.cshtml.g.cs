#pragma checksum "D:\MVCPractice\Saram\PizzaHub\PizzaHub.WebUI\Views\Shared\_PizzaMenu.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "85a3e46c9e4aa5974967e255dc03c9946b7ddbe17d028858b0639611b4a33dac"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__PizzaMenu), @"mvc.1.0.view", @"/Views/Shared/_PizzaMenu.cshtml")]
namespace AspNetCore
{
    #line hidden
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Mvc;
    using global::Microsoft.AspNetCore.Mvc.Rendering;
    using global::Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\MVCPractice\Saram\PizzaHub\PizzaHub.WebUI\Views\_ViewImports.cshtml"
using PizzaHub.WebUI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\MVCPractice\Saram\PizzaHub\PizzaHub.WebUI\Views\_ViewImports.cshtml"
using PizzaHub.WebUI.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\MVCPractice\Saram\PizzaHub\PizzaHub.WebUI\Views\_ViewImports.cshtml"
using PizzaHub.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\MVCPractice\Saram\PizzaHub\PizzaHub.WebUI\Views\_ViewImports.cshtml"
using PizzaHub.WebUI.Helpers;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"85a3e46c9e4aa5974967e255dc03c9946b7ddbe17d028858b0639611b4a33dac", @"/Views/Shared/_PizzaMenu.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"8018d503d9f6291e5f8abfd647bc2bb5637979002c2282e46cda3f0cd23245f7", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Shared__PizzaMenu : PizzaHub.WebUI.Helpers.BaseViewPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div class=\"container pb-4\">\r\n    <div class=\"row pt-4\">\r\n        <h2 class=\"col-sm-12 mb-4\" id=\"heading\">Pizza, Dessert, Beverages</h2>\r\n    </div>\r\n    <div class=\"row d-flex flex-wrap\">\r\n");
#nullable restore
#line 6 "D:\MVCPractice\Saram\PizzaHub\PizzaHub.WebUI\Views\Shared\_PizzaMenu.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"col-sm-4 pb-4 d-flex\">\r\n                <div class=\"card box-shadow w-100\">\r\n                    <img class=\"card-img-top\"");
            BeginWriteAttribute("src", " src=\"", 385, "\"", 405, 1);
#nullable restore
#line 10 "D:\MVCPractice\Saram\PizzaHub\PizzaHub.WebUI\Views\Shared\_PizzaMenu.cshtml"
WriteAttributeValue("", 391, item.ImageUrl, 391, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"image\" style=\"width:100%\">\r\n                    <div class=\"card-body d-flex flex-column\">\r\n                        <h4 class=\"card-title\">\r\n                            ");
#nullable restore
#line 13 "D:\MVCPractice\Saram\PizzaHub\PizzaHub.WebUI\Views\Shared\_PizzaMenu.cshtml"
                       Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" \r\n                            <span class=\"float-right\r\n                          font-20\">Rs ");
#nullable restore
#line 15 "D:\MVCPractice\Saram\PizzaHub\PizzaHub.WebUI\Views\Shared\_PizzaMenu.cshtml"
                                 Write(item.UnitPrice.ToString("N2"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                        </h4>\r\n                        <p class=\"card-text\">");
#nullable restore
#line 17 "D:\MVCPractice\Saram\PizzaHub\PizzaHub.WebUI\Views\Shared\_PizzaMenu.cshtml"
                                        Write(item.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                        <p>
                            <span class=""pt-1 d-inline-block""> Size: Regular</span>
                            <span class=""float-right font-20"">
                                <a class=""btn btn-primary"" href=""javascript:void(0)""");
            BeginWriteAttribute("onclick", " onclick=\"", 1086, "\"", 1185, 8);
            WriteAttributeValue("", 1096, "AddToCart", 1096, 9, true);
            WriteAttributeValue("\r\n                                 ", 1105, "(\'", 1140, 37, true);
#nullable restore
#line 22 "D:\MVCPractice\Saram\PizzaHub\PizzaHub.WebUI\Views\Shared\_PizzaMenu.cshtml"
WriteAttributeValue("", 1142, item.Id, 1142, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1150, "\',\'", 1150, 3, true);
#nullable restore
#line 22 "D:\MVCPractice\Saram\PizzaHub\PizzaHub.WebUI\Views\Shared\_PizzaMenu.cshtml"
WriteAttributeValue("", 1153, item.Name, 1153, 10, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1163, "\',\'", 1163, 3, true);
#nullable restore
#line 22 "D:\MVCPractice\Saram\PizzaHub\PizzaHub.WebUI\Views\Shared\_PizzaMenu.cshtml"
WriteAttributeValue("", 1166, item.UnitPrice, 1166, 15, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1181, "\',1)", 1181, 4, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                Add To Cart\r\n                            </a>\r\n                            </span>\r\n                        </p>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 30 "D:\MVCPractice\Saram\PizzaHub\PizzaHub.WebUI\Views\Shared\_PizzaMenu.cshtml"

        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    </div>
</div>

<div class=""toast fade hide"" data-autohide=""false"" id=""toastCart"">
    <div class=""toast-header"">
        <strong class=""mr-auto text-primary"">Notification</strong>
        <button type=""button"" class=""m1-2 mb-1 close"" data-dismiss=""toast"" aria-label=""Close"">×</button>
    </div>
    <div class=""toast-body""></div>
</div>

");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
