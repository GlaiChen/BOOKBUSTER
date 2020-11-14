#pragma checksum "C:\Users\97254\Documents\GitHub\Store\Views\Shared\_detailsView.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0195af908c8e246611f71be44b4aae53a7aa15e7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__detailsView), @"mvc.1.0.view", @"/Views/Shared/_detailsView.cshtml")]
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
#line 1 "C:\Users\97254\Documents\GitHub\Store\Views\_ViewImports.cshtml"
using BooksStore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\97254\Documents\GitHub\Store\Views\_ViewImports.cshtml"
using BooksStore.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0195af908c8e246611f71be44b4aae53a7aa15e7", @"/Views/Shared/_detailsView.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2c269e86a9abc6e417b650ea50037e65f98d4826", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__detailsView : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BooksStore.ViewModels.BookListViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div id=\"product-main-img\">\r\n");
#nullable restore
#line 4 "C:\Users\97254\Documents\GitHub\Store\Views\Shared\_detailsView.cshtml"
     foreach (var book in Model.Books)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"details-view\" style=\"margin-bottom: 50px;\"");
            BeginWriteAttribute("productId", " productId=\"", 184, "\"", 208, 1);
#nullable restore
#line 6 "C:\Users\97254\Documents\GitHub\Store\Views\Shared\_detailsView.cshtml"
WriteAttributeValue("", 196, book.BookId, 196, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n        <div class=\"product-preview col-md-4\" style=\"float:left\">\r\n            <img");
            BeginWriteAttribute("src", " src=\"", 295, "\"", 318, 1);
#nullable restore
#line 8 "C:\Users\97254\Documents\GitHub\Store\Views\Shared\_detailsView.cshtml"
WriteAttributeValue("", 301, book.PictureName, 301, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 319, "\"", 325, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n        </div>\r\n        <div class=\"col-md-8\" style=\"float:right\">\r\n            <h2 class=\"product-name\">");
#nullable restore
#line 11 "C:\Users\97254\Documents\GitHub\Store\Views\Shared\_detailsView.cshtml"
                                Write(book.BookName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n            <h3 class=\"product-price\">");
#nullable restore
#line 12 "C:\Users\97254\Documents\GitHub\Store\Views\Shared\_detailsView.cshtml"
                                 Write(book.Price.ToString("c"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n            <p>");
#nullable restore
#line 13 "C:\Users\97254\Documents\GitHub\Store\Views\Shared\_detailsView.cshtml"
          Write(book.Summary);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            <div class=\"add-to-cart\">\r\n                <button id=\"addProduct\"");
            BeginWriteAttribute("onclick", " onclick=\"", 637, "\"", 670, 3);
            WriteAttributeValue("", 647, "AddToCart(", 647, 10, true);
#nullable restore
#line 15 "C:\Users\97254\Documents\GitHub\Store\Views\Shared\_detailsView.cshtml"
WriteAttributeValue("", 657, book.BookId, 657, 12, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 669, ")", 669, 1, true);
            EndWriteAttribute();
            WriteLiteral(@" value=""Add to Cart"" class=""primary-btn-add-cart cta-btn"">
                    <i class=""fa fa-shopping-cart""></i> Add to Cart
                </button>
            </div>
            <hr />
        </div>
        <div style=""clear:both; margin-top:50px;""></div>
    </div>
");
#nullable restore
#line 23 "C:\Users\97254\Documents\GitHub\Store\Views\Shared\_detailsView.cshtml"
        
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BooksStore.ViewModels.BookListViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591