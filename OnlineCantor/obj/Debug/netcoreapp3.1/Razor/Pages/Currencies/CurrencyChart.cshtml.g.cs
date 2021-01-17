#pragma checksum "C:\Users\User\Desktop\praca zawodowa\nauka\wolter kluver\OnlineCantor\OnlineCantor\Pages\Currencies\CurrencyChart.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1c64d90d7c63589bf0afdc246e3f3a8f55abbfe4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(OnlineCantor.Pages.Currencies.Pages_Currencies_CurrencyChart), @"mvc.1.0.razor-page", @"/Pages/Currencies/CurrencyChart.cshtml")]
namespace OnlineCantor.Pages.Currencies
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
#line 1 "C:\Users\User\Desktop\praca zawodowa\nauka\wolter kluver\OnlineCantor\OnlineCantor\Pages\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\User\Desktop\praca zawodowa\nauka\wolter kluver\OnlineCantor\OnlineCantor\Pages\_ViewImports.cshtml"
using OnlineCantor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\User\Desktop\praca zawodowa\nauka\wolter kluver\OnlineCantor\OnlineCantor\Pages\_ViewImports.cshtml"
using OnlineCantor.Data;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1c64d90d7c63589bf0afdc246e3f3a8f55abbfe4", @"/Pages/Currencies/CurrencyChart.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d180148e04c961f4ddf5fe750e2caaaaea5e0c6a", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Currencies_CurrencyChart : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<script src=\"https://code.highcharts.com/highcharts.js\"></script>\r\n<script src=\"https://code.highcharts.com/modules/exporting.js\"></script>\r\n ");
#nullable restore
#line 7 "C:\Users\User\Desktop\praca zawodowa\nauka\wolter kluver\OnlineCantor\OnlineCantor\Pages\Currencies\CurrencyChart.cshtml"
Write(Model.tempId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n ");
#nullable restore
#line 8 "C:\Users\User\Desktop\praca zawodowa\nauka\wolter kluver\OnlineCantor\OnlineCantor\Pages\Currencies\CurrencyChart.cshtml"
Write(Model.Currency.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<figure class=""highcharts-figure"">
    <div id=""container""></div>
    <script type=""text/javascript"">

        Highcharts.chart('container', {

            title: {
                text: '3 day currency rate'
            },

            subtitle: {
                text: 'Source: NBP statistics'
            },

            yAxis: {
                title: {
                    text: 'Currency rate'
                }
            },

            xAxis: {
                type: 'datetime',
                accessibility: {
                    rangeDescription: 'Range: 3 days ago to today'
                }
            },

            legend: {
                layout: 'vertical',
                align: 'right',
                verticalAlign: 'middle'
            },

            plotOptions: {
                series: {
                    label: {
                        connectorAllowed: false
                    },
                    pointStart: Date.UTC(");
#nullable restore
#line 48 "C:\Users\User\Desktop\praca zawodowa\nauka\wolter kluver\OnlineCantor\OnlineCantor\Pages\Currencies\CurrencyChart.cshtml"
                                    Write(Model.ThreeDaysAgoCurrency.DataTime.Year);

#line default
#line hidden
#nullable disable
            WriteLiteral(", ");
#nullable restore
#line 48 "C:\Users\User\Desktop\praca zawodowa\nauka\wolter kluver\OnlineCantor\OnlineCantor\Pages\Currencies\CurrencyChart.cshtml"
                                                                                Write(Model.ThreeDaysAgoCurrency.DataTime.Month-1);

#line default
#line hidden
#nullable disable
            WriteLiteral(", ");
#nullable restore
#line 48 "C:\Users\User\Desktop\praca zawodowa\nauka\wolter kluver\OnlineCantor\OnlineCantor\Pages\Currencies\CurrencyChart.cshtml"
                                                                                                                               Write(Model.ThreeDaysAgoCurrency.DataTime.Day);

#line default
#line hidden
#nullable disable
            WriteLiteral("),\r\n                    //pointStart: Date.UTC(2020, 10, 09),\r\n                    pointInterval: 24 * 3600 * 1000\r\n                }\r\n            },\r\n\r\n            series: [{\r\n                name: \'");
#nullable restore
#line 55 "C:\Users\User\Desktop\praca zawodowa\nauka\wolter kluver\OnlineCantor\OnlineCantor\Pages\Currencies\CurrencyChart.cshtml"
                  Write(Model.Currency.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\',\r\n                data: [");
#nullable restore
#line 56 "C:\Users\User\Desktop\praca zawodowa\nauka\wolter kluver\OnlineCantor\OnlineCantor\Pages\Currencies\CurrencyChart.cshtml"
                  Write(Model.oldest);

#line default
#line hidden
#nullable disable
            WriteLiteral(", ");
#nullable restore
#line 56 "C:\Users\User\Desktop\praca zawodowa\nauka\wolter kluver\OnlineCantor\OnlineCantor\Pages\Currencies\CurrencyChart.cshtml"
                                 Write(Model.middle);

#line default
#line hidden
#nullable disable
            WriteLiteral(", ");
#nullable restore
#line 56 "C:\Users\User\Desktop\praca zawodowa\nauka\wolter kluver\OnlineCantor\OnlineCantor\Pages\Currencies\CurrencyChart.cshtml"
                                                Write(Model.newest);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"]
            }],

            responsive: {
                rules: [{
                    condition: {
                        maxWidth: 500
                    },
                    chartOptions: {
                        legend: {
                            layout: 'horizontal',
                            align: 'center',
                            verticalAlign: 'bottom'
                        }
                    }
                }]
            }

        });


    </script>
</figure>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<OnlineCantor.Pages.Currencies.CurrencyChartModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<OnlineCantor.Pages.Currencies.CurrencyChartModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<OnlineCantor.Pages.Currencies.CurrencyChartModel>)PageContext?.ViewData;
        public OnlineCantor.Pages.Currencies.CurrencyChartModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
