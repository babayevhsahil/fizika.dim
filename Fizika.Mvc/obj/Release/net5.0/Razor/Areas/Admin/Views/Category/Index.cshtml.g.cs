#pragma checksum "C:\Users\Tural\source\repos\Fizika\Fizika.Mvc\Areas\Admin\Views\Category\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6305f677f7a2da12ac9c940ce87655b107b0688d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Category_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/Category/Index.cshtml")]
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
#line 2 "C:\Users\Tural\source\repos\Fizika\Fizika.Mvc\Areas\Admin\Views\Category\Index.cshtml"
using Fizika.Shared.Utilities.Results.ComplexTypes;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6305f677f7a2da12ac9c940ce87655b107b0688d", @"/Areas/Admin/Views/Category/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9d587d1119c7c9b37fa9ab078bbcf9a12e73b654", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Category_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Fizika.Entities.DTOs.CategoryListDto>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "Admin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/crud/category/categoryIndex.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("application/ecmascript"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\Tural\source\repos\Fizika\Fizika.Mvc\Areas\Admin\Views\Category\Index.cshtml"
   Layout = "_Layout";
    ViewBag.Title = "Categories Index"; 

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<script src=""//cdn.jsdelivr.net/npm/sweetalert2@11""></script>
<div class=""row"">
    <div class=""col-md-12  header-wrapper"">
        <h1 class=""page-header"">Admin - Kateqoriyalar</h1>
        <p class=""page-subtitle"">Buradan yeni kateqoriya yarada, editləyə və silə bilərsiniz.</p>
    </div>
    <!-- /.col-lg-12 -->
</div>
<!-- /.row -->

<ol class=""breadcrumb"">
    <li><a href=""/Admin"">Admin</a></li>
    <li class=""active"">Kateqoriya</li>
</ol>

<div id=""modalPlaceHolder"" aria-hidden=""true""></div>
<div class=""row"">
    <div class=""col-md-12 card"">
");
#nullable restore
#line 24 "C:\Users\Tural\source\repos\Fizika\Fizika.Mvc\Areas\Admin\Views\Category\Index.cshtml"
             if (Model.ResultStatus == ResultStatus.Succes)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        <table class=""table no-footer dataTable dtr-inline"" id=""dataTables"">
            <thead>
                <tr>
                    <th>ID</th>
                    <th>Adı</th>
                    <th>Açıqlama</th>
                    <th>Aktiv</th>
                    <th>Silinib</th>
                    <th>Tarix</th>
                    <th>İstifadəçi Adı</th>
                    <th>Son Edit Tarixi</th>
                    <th>Son Editləyən İstifadəçi Adı</th>
                    <th>Əməliyyatlar</th>
                </tr>
            </thead>
            <tfoot>
                <tr>
                    <th>ID</th>
                    <th>Adı</th>
                    <th>Açıqlama</th>
                    <th>Aktiv</th>
                    <th>Silinib</th>
                    <th>Tarix</th>
                    <th>İstifadəçi Adı</th>
                    <th>Son Edit Tarixi</th>
                    <th>Son Editləyən İstifadəçi Adı</th>
                    <th>Əməliyyatlar</th>
                </tr>
  ");
            WriteLiteral("          </tfoot>\n            <tbody>\n");
#nullable restore
#line 56 "C:\Users\Tural\source\repos\Fizika\Fizika.Mvc\Areas\Admin\Views\Category\Index.cshtml"
                 foreach (var category in Model.Categories)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr class=\"odd\"");
            BeginWriteAttribute("name", " name=\"", 1954, "\"", 1973, 1);
#nullable restore
#line 58 "C:\Users\Tural\source\repos\Fizika\Fizika.Mvc\Areas\Admin\Views\Category\Index.cshtml"
WriteAttributeValue("", 1961, category.Id, 1961, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n            <td>");
#nullable restore
#line 59 "C:\Users\Tural\source\repos\Fizika\Fizika.Mvc\Areas\Admin\Views\Category\Index.cshtml"
           Write(category.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n            <td>");
#nullable restore
#line 60 "C:\Users\Tural\source\repos\Fizika\Fizika.Mvc\Areas\Admin\Views\Category\Index.cshtml"
           Write(category.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n            <td>");
#nullable restore
#line 61 "C:\Users\Tural\source\repos\Fizika\Fizika.Mvc\Areas\Admin\Views\Category\Index.cshtml"
           Write(category.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n            <td class=\"center\"><span class=\"status active\">");
#nullable restore
#line 62 "C:\Users\Tural\source\repos\Fizika\Fizika.Mvc\Areas\Admin\Views\Category\Index.cshtml"
                                                       Write(category.IsActive ? "Bəli" : "Xeyr");

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></td>\n            <td class=\"center\"><span class=\"status active\">");
#nullable restore
#line 63 "C:\Users\Tural\source\repos\Fizika\Fizika.Mvc\Areas\Admin\Views\Category\Index.cshtml"
                                                       Write(category.IsDeleted ? "Bəli" : "Xeyr" );

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></td>\n            <td class=\"center\">");
#nullable restore
#line 64 "C:\Users\Tural\source\repos\Fizika\Fizika.Mvc\Areas\Admin\Views\Category\Index.cshtml"
                          Write(category.CreatedDate.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n            <td class=\"center\">");
#nullable restore
#line 65 "C:\Users\Tural\source\repos\Fizika\Fizika.Mvc\Areas\Admin\Views\Category\Index.cshtml"
                          Write(category.CreatedByName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n            <td class=\"center\">");
#nullable restore
#line 66 "C:\Users\Tural\source\repos\Fizika\Fizika.Mvc\Areas\Admin\Views\Category\Index.cshtml"
                          Write(category.ModifiedDate.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n            <td class=\"center\">");
#nullable restore
#line 67 "C:\Users\Tural\source\repos\Fizika\Fizika.Mvc\Areas\Admin\Views\Category\Index.cshtml"
                          Write(category.ModifiedByName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n            <td class=\"text-center\">\n                <button class=\"btn btn-primary btn-sm btn-block btn-update\" data-id=\"");
#nullable restore
#line 69 "C:\Users\Tural\source\repos\Fizika\Fizika.Mvc\Areas\Admin\Views\Category\Index.cshtml"
                                                                                Write(category.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\"><span class=\"fas fa-edit\"></span> </button>\n                <button class=\"btn btn-danger btn-sm btn-delete btn-block\" data-id=\"");
#nullable restore
#line 70 "C:\Users\Tural\source\repos\Fizika\Fizika.Mvc\Areas\Admin\Views\Category\Index.cshtml"
                                                                               Write(category.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\"><span class=\"fas fa-minus-circle\"></span> </button>\n            </td>\n        </tr>");
#nullable restore
#line 72 "C:\Users\Tural\source\repos\Fizika\Fizika.Mvc\Areas\Admin\Views\Category\Index.cshtml"
             }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\n        </table> ");
#nullable restore
#line 74 "C:\Users\Tural\source\repos\Fizika\Fizika.Mvc\Areas\Admin\Views\Category\Index.cshtml"
                 }
else if (Model.ResultStatus == ResultStatus.Error)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"alert alert-danger\">\n    <h3>");
#nullable restore
#line 78 "C:\Users\Tural\source\repos\Fizika\Fizika.Mvc\Areas\Admin\Views\Category\Index.cshtml"
   Write(Model.Message);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\n    <p>Dashboarda qayıtmaq üçün ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6305f677f7a2da12ac9c940ce87655b107b0688d12199", async() => {
                WriteLiteral("Tıklayın");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</p>\n</div>");
#nullable restore
#line 80 "C:\Users\Tural\source\repos\Fizika\Fizika.Mvc\Areas\Admin\Views\Category\Index.cshtml"
      }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        <button class=""btn btn-primary btnUpdate"" type=""button"" disabled style=""display:none;"">
            <span class=""spinner-border spinner-border-sm"" role=""status"" aria-hidden=""true""></span>
            Yüklənir...
        </button>
    </div>
</div>

<!-- JavaScript -->
");
            DefineSection("Scripts", async() => {
                WriteLiteral("\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6305f677f7a2da12ac9c940ce87655b107b0688d14363", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\n");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Fizika.Entities.DTOs.CategoryListDto> Html { get; private set; }
    }
}
#pragma warning restore 1591
