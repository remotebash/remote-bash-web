#pragma checksum "C:\dev\pqp\pqp3\remote-bash-web\remotebash\remotebash.web\Views\Command\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8ec1348856481d7781902e9b39672f1de984032a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Command_Index), @"mvc.1.0.view", @"/Views/Command/Index.cshtml")]
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
#line 1 "C:\dev\pqp\pqp3\remote-bash-web\remotebash\remotebash.web\Views\_ViewImports.cshtml"
using remotebash.web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\dev\pqp\pqp3\remote-bash-web\remotebash\remotebash.web\Views\_ViewImports.cshtml"
using remotebash.web.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8ec1348856481d7781902e9b39672f1de984032a", @"/Views/Command/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bf77e73f5c87caf60c8a6e71a49afda3ab6323a7", @"/Views/_ViewImports.cshtml")]
    public class Views_Command_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<remotebash.web.Models.ViewModel.UserComputer>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\dev\pqp\pqp3\remote-bash-web\remotebash\remotebash.web\Views\Command\Index.cshtml"
  
    ViewData["Title"] = "Command";
    ViewData["UserConnect"] = $"/{Model.User.Name}/laboratories/computers/{Model.Computer.OperationalSystem} - {Model.Computer.Macaddress}";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<script>   \r\n   var idUser = ");
#nullable restore
#line 8 "C:\dev\pqp\pqp3\remote-bash-web\remotebash\remotebash.web\Views\Command\Index.cshtml"
           Write(Model.User.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral(";\r\n   var idPc = ");
#nullable restore
#line 9 "C:\dev\pqp\pqp3\remote-bash-web\remotebash\remotebash.web\Views\Command\Index.cshtml"
         Write(Model.Computer.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral(";    \r\n   var idLab = ");
#nullable restore
#line 10 "C:\dev\pqp\pqp3\remote-bash-web\remotebash\remotebash.web\Views\Command\Index.cshtml"
          Write(Model.Laboratory.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral(";\r\n   var urlRest = \"");
#nullable restore
#line 11 "C:\dev\pqp\pqp3\remote-bash-web\remotebash\remotebash.web\Views\Command\Index.cshtml"
              Write(Model.UrlRest);

#line default
#line hidden
#nullable disable
            WriteLiteral(@""";
</script>

    <div class=""prompt"" id=""pc-001"">
        <div class=""container-cmd"">
            <div id=""container-return"" class=""text-white""></div>
            <div class=""container-input"">
                <div class=""user-cmd text-white"">remotebash></div>
                <input type=""text"" class=""execute-cmd"" id=""input-cmd"" autofocus />
            </div>
        </div>
    </div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<remotebash.web.Models.ViewModel.UserComputer> Html { get; private set; }
    }
}
#pragma warning restore 1591
