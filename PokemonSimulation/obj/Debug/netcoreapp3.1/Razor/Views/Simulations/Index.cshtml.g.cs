#pragma checksum "C:\Users\bobby\OneDrive\Documents\GitHub\Pokemon-Simulation\PokemonSimulation\Views\Simulations\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cd1e554a6196d41f5442577d443c3f5b08a62f60"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Simulations_Index), @"mvc.1.0.view", @"/Views/Simulations/Index.cshtml")]
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
#line 1 "C:\Users\bobby\OneDrive\Documents\GitHub\Pokemon-Simulation\PokemonSimulation\Views\_ViewImports.cshtml"
using PokemonSimulation;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\bobby\OneDrive\Documents\GitHub\Pokemon-Simulation\PokemonSimulation\Views\_ViewImports.cshtml"
using PokemonSimulation.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cd1e554a6196d41f5442577d443c3f5b08a62f60", @"/Views/Simulations/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2d38fb9076c42d94e25db6411b4af915a8261ace", @"/Views/_ViewImports.cshtml")]
    public class Views_Simulations_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PokemonSimulation.Models.PokedexIndexData>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Moves", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\bobby\OneDrive\Documents\GitHub\Pokemon-Simulation\PokemonSimulation\Views\Simulations\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Index</h1>\r\n\r\n\r\n<div class=\"form-group\">\r\n    <div class=\"col-md-offset-2 col-md-10\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cd1e554a6196d41f5442577d443c3f5b08a62f604041", async() => {
                WriteLiteral("\r\n            <table>\r\n                <tr>\r\n                    <th>Select Two  Pokemon</th>\r\n");
#nullable restore
#line 16 "C:\Users\bobby\OneDrive\Documents\GitHub\Pokemon-Simulation\PokemonSimulation\Views\Simulations\Index.cshtml"
                      
                        int cnt = 0;
                        List<PokemonSimulation.Models.Pokedex> Pokemon = ViewBag.Pokemon;
                        foreach (var pokemon in Pokemon)
                        {
                            if (cnt++ % 3 == 0)
                            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                            ");
                WriteLiteral("</tr><tr>\r\n");
#nullable restore
#line 24 "C:\Users\bobby\OneDrive\Documents\GitHub\Pokemon-Simulation\PokemonSimulation\Views\Simulations\Index.cshtml"
                            }

#line default
#line hidden
#nullable disable
                WriteLiteral("                            ");
                WriteLiteral("<td>\r\n                                <input type=\"checkbox\"\r\n                                       name=\"selectedPokemon\"");
                BeginWriteAttribute("value", "\r\n                                       value=\"", 857, "\"", 923, 1);
#nullable restore
#line 28 "C:\Users\bobby\OneDrive\Documents\GitHub\Pokemon-Simulation\PokemonSimulation\Views\Simulations\Index.cshtml"
WriteAttributeValue("", 905, pokemon.PokemonId, 905, 18, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n");
#nullable restore
#line 29 "C:\Users\bobby\OneDrive\Documents\GitHub\Pokemon-Simulation\PokemonSimulation\Views\Simulations\Index.cshtml"
                           Write(pokemon.Pokemon_Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("                            ");
                WriteLiteral("</td>\r\n");
#nullable restore
#line 31 "C:\Users\bobby\OneDrive\Documents\GitHub\Pokemon-Simulation\PokemonSimulation\Views\Simulations\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
                WriteLiteral("                    ");
                WriteLiteral("</tr>\r\n");
                WriteLiteral("                </table>\r\n                \r\n            <br />\r\n                <input type=\"submit\" value=\"Moves/Ability\" class=\"btn btn-danger\" /> \r\n            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PokemonSimulation.Models.PokedexIndexData> Html { get; private set; }
    }
}
#pragma warning restore 1591
