#pragma checksum "C:\Users\97254\Documents\GitHub\Bookbuster\Views\Shared\_pictureView.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8ba22ef2ebec19937ba4fe20f766f3d2b3aafcdb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__pictureView), @"mvc.1.0.view", @"/Views/Shared/_pictureView.cshtml")]
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
#line 1 "C:\Users\97254\Documents\GitHub\Bookbuster\Views\_ViewImports.cshtml"
using BooksStore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\97254\Documents\GitHub\Bookbuster\Views\_ViewImports.cshtml"
using BooksStore.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8ba22ef2ebec19937ba4fe20f766f3d2b3aafcdb", @"/Views/Shared/_pictureView.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2c269e86a9abc6e417b650ea50037e65f98d4826", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__pictureView : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BooksStore.ViewModels.BookListViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n<div id=\"product-imgs\">\r\n");
#nullable restore
#line 5 "C:\Users\97254\Documents\GitHub\Bookbuster\Views\Shared\_pictureView.cshtml"
     foreach (var book in Model.Books)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"product-preview\"");
            BeginWriteAttribute("productId", " productId=\"", 160, "\"", 185, 2);
#nullable restore
#line 7 "C:\Users\97254\Documents\GitHub\Bookbuster\Views\Shared\_pictureView.cshtml"
WriteAttributeValue("", 172, book.BookId, 172, 12, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 184, ".", 184, 1, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n            <img");
            BeginWriteAttribute("src", " src=\"", 205, "\"", 228, 1);
#nullable restore
#line 8 "C:\Users\97254\Documents\GitHub\Bookbuster\Views\Shared\_pictureView.cshtml"
WriteAttributeValue("", 211, book.PictureName, 211, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 229, "\"", 235, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n        </div>\r\n");
#nullable restore
#line 10 "C:\Users\97254\Documents\GitHub\Bookbuster\Views\Shared\_pictureView.cshtml"
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
