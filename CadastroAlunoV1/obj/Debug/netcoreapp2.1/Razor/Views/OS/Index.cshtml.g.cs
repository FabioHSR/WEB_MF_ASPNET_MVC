#pragma checksum "C:\Users\T-Gamer\Desktop\2BN1-1.4\WEBMF\CadastroAlunoV1\Views\OS\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "594bc786552782621952cc73a7b51fae8472cad9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_OS_Index), @"mvc.1.0.view", @"/Views/OS/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/OS/Index.cshtml", typeof(AspNetCore.Views_OS_Index))]
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
#line 1 "C:\Users\T-Gamer\Desktop\2BN1-1.4\WEBMF\CadastroAlunoV1\Views\_ViewImports.cshtml"
using WEBMF;

#line default
#line hidden
#line 2 "C:\Users\T-Gamer\Desktop\2BN1-1.4\WEBMF\CadastroAlunoV1\Views\_ViewImports.cshtml"
using WEBMF.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"594bc786552782621952cc73a7b51fae8472cad9", @"/Views/OS/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d388c064342e9c6455f6eccf7a6d5b928827c5f3", @"/Views/_ViewImports.cshtml")]
    public class Views_OS_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<OsViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/site.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\T-Gamer\Desktop\2BN1-1.4\WEBMF\CadastroAlunoV1\Views\OS\Index.cshtml"
  
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(80, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            DefineSection("styles", async() => {
                BeginContext(99, 121, true);
                WriteLiteral("\r\n    <link rel=\"stylesheet\" type=\"text/css\" href=\"https://cdn.datatables.net/1.10.16/css/jquery.dataTables.min.css\" />\r\n");
                EndContext();
            }
            );
            BeginContext(223, 382, true);
            WriteLiteral(@"
<h2>Listagem de OS</h2>

<a href=""/OS/Create"" class=""btn btn-primary"">Novo Registro</a>
<br />

<table class=""display"" id=""myTable"">
    <thead>
        <tr>
            <th>Ações</th>
            <th>Status</th>
            <th>ID</th>
            <th>Cliente</th>
            <th>Tipo</th>
            <th>Orientação</th>
        </tr>
    </thead>
    <tbody>
");
            EndContext();
#line 27 "C:\Users\T-Gamer\Desktop\2BN1-1.4\WEBMF\CadastroAlunoV1\Views\OS\Index.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
            BeginContext(654, 62, true);
            WriteLiteral("            <tr>\r\n                <td>\r\n                    <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 716, "\"", 743, 2);
            WriteAttributeValue("", 723, "/OS/Edit?id=", 723, 12, true);
#line 31 "C:\Users\T-Gamer\Desktop\2BN1-1.4\WEBMF\CadastroAlunoV1\Views\OS\Index.cshtml"
WriteAttributeValue("", 735, item.Id, 735, 8, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(744, 37, true);
            WriteLiteral(">Editar</a> |\r\n                    <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 781, "\"", 820, 3);
            WriteAttributeValue("", 788, "javascript:apagar(", 788, 18, true);
#line 32 "C:\Users\T-Gamer\Desktop\2BN1-1.4\WEBMF\CadastroAlunoV1\Views\OS\Index.cshtml"
WriteAttributeValue("", 806, item.Id, 806, 8, false);

#line default
#line hidden
            WriteAttributeValue("", 814, ",\'OS\')", 814, 6, true);
            EndWriteAttribute();
            BeginContext(821, 56, true);
            WriteLiteral(">Apagar</a>\r\n                </td>\r\n                <td>");
            EndContext();
            BeginContext(878, 11, false);
#line 34 "C:\Users\T-Gamer\Desktop\2BN1-1.4\WEBMF\CadastroAlunoV1\Views\OS\Index.cshtml"
               Write(item.Status);

#line default
#line hidden
            EndContext();
            BeginContext(889, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(917, 7, false);
#line 35 "C:\Users\T-Gamer\Desktop\2BN1-1.4\WEBMF\CadastroAlunoV1\Views\OS\Index.cshtml"
               Write(item.Id);

#line default
#line hidden
            EndContext();
            BeginContext(924, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(952, 16, false);
#line 36 "C:\Users\T-Gamer\Desktop\2BN1-1.4\WEBMF\CadastroAlunoV1\Views\OS\Index.cshtml"
               Write(item.ClienteNome);

#line default
#line hidden
            EndContext();
            BeginContext(968, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(996, 11, false);
#line 37 "C:\Users\T-Gamer\Desktop\2BN1-1.4\WEBMF\CadastroAlunoV1\Views\OS\Index.cshtml"
               Write(item.OSTipo);

#line default
#line hidden
            EndContext();
            BeginContext(1007, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(1035, 15, false);
#line 38 "C:\Users\T-Gamer\Desktop\2BN1-1.4\WEBMF\CadastroAlunoV1\Views\OS\Index.cshtml"
               Write(item.Orientacao);

#line default
#line hidden
            EndContext();
            BeginContext(1050, 26, true);
            WriteLiteral("</td>\r\n            </tr>\r\n");
            EndContext();
#line 40 "C:\Users\T-Gamer\Desktop\2BN1-1.4\WEBMF\CadastroAlunoV1\Views\OS\Index.cshtml"
        }

#line default
#line hidden
            BeginContext(1087, 28, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n\r\n\r\n");
            EndContext();
            DefineSection("scripts", async() => {
                BeginContext(1133, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(1139, 36, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9df928d01afd453f82e6506ce4b2cd30", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1175, 242, true);
                WriteLiteral("\r\n    <script type=\"text/javascript\" src=\"https://cdn.datatables.net/1.10.16/js/jquery.dataTables.min.js\"></script>\r\n\r\n    <script>\r\n        $(document).ready(function () {\r\n            $(\'#myTable\').DataTable();\r\n        });\r\n    </script>\r\n");
                EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<OsViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
