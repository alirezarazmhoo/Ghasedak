#pragma checksum "E:\Atrin\GhasedakFromGit2\Ghasedak\Ghasedak\Ghasedak\Views\BoxIncome\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "173098d3ca53618b47e353e042af1742d5329b31"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_BoxIncome_Index), @"mvc.1.0.view", @"/Views/BoxIncome/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/BoxIncome/Index.cshtml", typeof(AspNetCore.Views_BoxIncome_Index))]
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
#line 1 "E:\Atrin\GhasedakFromGit2\Ghasedak\Ghasedak\Ghasedak\Views\_ViewImports.cshtml"
using Ghasedak;

#line default
#line hidden
#line 2 "E:\Atrin\GhasedakFromGit2\Ghasedak\Ghasedak\Ghasedak\Views\_ViewImports.cshtml"
using Ghasedak.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"173098d3ca53618b47e353e042af1742d5329b31", @"/Views/BoxIncome/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0a3adc42566847921abf5afd6f81e3a1773c1a92", @"/Views/_ViewImports.cshtml")]
    public class Views_BoxIncome_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PagedList.Core.IPagedList<Ghasedak.Models.BoxIncome>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-default"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "BoxIncome", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::PagedList.Core.Mvc.PagerTagHelper __PagedList_Core_Mvc_PagerTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(61, 233, true);
            WriteLiteral("<div class=\"row\">\r\n    <div class=\"col-xs-12\">\r\n        <div class=\"box\">\r\n            <div class=\"box-header\">\r\n                <h3 class=\"box-title\">درآمد ها</h3>\r\n            </div>\r\n            <div class=\"row\">\r\n                ");
            EndContext();
            BeginContext(294, 283, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "190f909004c54afd9c29537944da8332", async() => {
                BeginContext(300, 270, true);
                WriteLiteral(@"
                    <div class=""box-body"">
                        <div class=""col-md-2 form-group"">

                            <div class=""btn btn-default"" id=""export"">خروجی اکسل</div>
                        </div>
                    </div>
                ");
                EndContext();
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
            EndContext();
            BeginContext(577, 1844, true);
            WriteLiteral(@"

            </div>
            <div class=""row"">
                <div class=""box-body"">

                    <div class=""col-md-4"">
                        <input type=""file"" id=""fUpload"" name=""files"" class=""form-control"" />
                    </div>
                    <div class=""col-md-2"">
                        <input type=""button"" class=""btn btn-default"" id=""btnUpload"" value=""آپلود فایل اکسل"" />
                    </div>
                    <div class=""col-md-6"">
                        فایل آپلودی به ترتیب از راست به چپ دارای فیلدهای CashCode از نوع عدد،OfficeCode از نوع عدد،Price از نوع عدد،StatusIncome از نوع عدد
                    </div>
                </div>
            </div>
            <div class=""row"">
                <div class=""box-body"">
                    <div class=""col-md-12"">
                        <a class=""btn btn-default deleteAll"">حذف موارد انتخابی</a>
                    </div>
                </div>
            </div>
            <!-- /.box-header --");
            WriteLiteral(@">
            <div class=""box-body table-responsive"">
                <table id=""example2"" class=""table table-bordered table-hover "">
                    <thead>
                        <tr>
                            <th>
                                <div class=""checkbox"">
                                    <label>
                                        <input type=""checkbox"" id=""checkbox1"">
                                    </label>
                                </div>
                            </th>
                            <th>کد شخص ثبت کننده</th>
                            <th>نام مالک صندوق</th>
                            <th>وضعیت</th>
                            <th>امکانات</th>
                        </tr>
                    </thead>
                    <tbody>
");
            EndContext();
#line 59 "E:\Atrin\GhasedakFromGit2\Ghasedak\Ghasedak\Ghasedak\Views\BoxIncome\Index.cshtml"
                         foreach (var item in Model)
                        {

#line default
#line hidden
            BeginContext(2502, 229, true);
            WriteLiteral("                            <tr>\r\n                                <td>\r\n                                    <div class=\"chkRow\">\r\n                                        <label>\r\n                                            <input");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 2731, "\"", 2747, 1);
#line 65 "E:\Atrin\GhasedakFromGit2\Ghasedak\Ghasedak\Ghasedak\Views\BoxIncome\Index.cshtml"
WriteAttributeValue("", 2739, item.id, 2739, 8, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2748, 188, true);
            WriteLiteral(" type=\"checkbox\">\r\n                                        </label>\r\n                                    </div>\r\n                                </td>\r\n                                <td>");
            EndContext();
            BeginContext(2937, 17, false);
#line 69 "E:\Atrin\GhasedakFromGit2\Ghasedak\Ghasedak\Ghasedak\Views\BoxIncome\Index.cshtml"
                               Write(item.oprator.code);

#line default
#line hidden
            EndContext();
            BeginContext(2954, 43, true);
            WriteLiteral("</td>\r\n                                <td>");
            EndContext();
            BeginContext(2998, 17, false);
#line 70 "E:\Atrin\GhasedakFromGit2\Ghasedak\Ghasedak\Ghasedak\Views\BoxIncome\Index.cshtml"
                               Write(item.box.fullName);

#line default
#line hidden
            EndContext();
            BeginContext(3015, 9, true);
            WriteLiteral("</td>\r\n\r\n");
            EndContext();
#line 72 "E:\Atrin\GhasedakFromGit2\Ghasedak\Ghasedak\Ghasedak\Views\BoxIncome\Index.cshtml"
                                 if (item.status == EnumStatus.Other)
                                {

#line default
#line hidden
            BeginContext(3130, 87, true);
            WriteLiteral("                                    <td style=\"background-color:green\">تخلیه شده</td>\r\n");
            EndContext();
#line 75 "E:\Atrin\GhasedakFromGit2\Ghasedak\Ghasedak\Ghasedak\Views\BoxIncome\Index.cshtml"
                                }

#line default
#line hidden
            BeginContext(3252, 32, true);
            WriteLiteral("                                ");
            EndContext();
#line 76 "E:\Atrin\GhasedakFromGit2\Ghasedak\Ghasedak\Ghasedak\Views\BoxIncome\Index.cshtml"
                                 if (item.status == EnumStatus.LackOfInventory)
                                {

#line default
#line hidden
            BeginContext(3368, 89, true);
            WriteLiteral("                                    <td style=\"background-color:yellow\">عدم موجودی</td>\r\n");
            EndContext();
#line 79 "E:\Atrin\GhasedakFromGit2\Ghasedak\Ghasedak\Ghasedak\Views\BoxIncome\Index.cshtml"
                                }

#line default
#line hidden
            BeginContext(3492, 32, true);
            WriteLiteral("                                ");
            EndContext();
#line 80 "E:\Atrin\GhasedakFromGit2\Ghasedak\Ghasedak\Ghasedak\Views\BoxIncome\Index.cshtml"
                                 if (item.status == EnumStatus.Absence)
                                {

#line default
#line hidden
            BeginContext(3600, 90, true);
            WriteLiteral("                                    <td style=\"background-color:lightblue\">عدم حضور</td>\r\n");
            EndContext();
#line 83 "E:\Atrin\GhasedakFromGit2\Ghasedak\Ghasedak\Ghasedak\Views\BoxIncome\Index.cshtml"
                                }

#line default
#line hidden
            BeginContext(3725, 68, true);
            WriteLiteral("\r\n                            <td>\r\n                                ");
            EndContext();
            BeginContext(3793, 79, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2b8af1c86cf74571bd445a29871a1f54", async() => {
                BeginContext(3862, 6, true);
                WriteLiteral("مشاهده");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 86 "E:\Atrin\GhasedakFromGit2\Ghasedak\Ghasedak\Ghasedak\Views\BoxIncome\Index.cshtml"
                                                       WriteLiteral(item.id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3872, 163, true);
            WriteLiteral("\r\n                                <a class=\"btn btn-danger\" data-toggle=\"modal\" data-target=\"#QuestionModal\" onclick=\"AssignButtonClicked(this)\" data-assigned-id=\"");
            EndContext();
            BeginContext(4036, 7, false);
#line 87 "E:\Atrin\GhasedakFromGit2\Ghasedak\Ghasedak\Ghasedak\Views\BoxIncome\Index.cshtml"
                                                                                                                                                            Write(item.id);

#line default
#line hidden
            EndContext();
            BeginContext(4043, 85, true);
            WriteLiteral("\" > حذف</a>\r\n\r\n                            </td>\r\n                            </tr>\r\n");
            EndContext();
#line 91 "E:\Atrin\GhasedakFromGit2\Ghasedak\Ghasedak\Ghasedak\Views\BoxIncome\Index.cshtml"
                        }

#line default
#line hidden
            BeginContext(4155, 524, true);
            WriteLiteral(@"

                    </tbody>
                    <tfoot>

                    </tfoot>
                </table>
            </div>
            <!-- /.box-body -->
            <div class=""row"">
                <div class=""col-sm-5"">
                </div>
                <div class=""col-sm-7"">
                    <div class=""dataTables_paginate paging_simple_numbers"" id=""example1_paginate"">
                        <ul class=""pagination"">
                            <li>
                                ");
            EndContext();
            BeginContext(4679, 69, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("pager", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "f050eba9884746da8be598840cb98329", async() => {
            }
            );
            __PagedList_Core_Mvc_PagerTagHelper = CreateTagHelper<global::PagedList.Core.Mvc.PagerTagHelper>();
            __tagHelperExecutionContext.Add(__PagedList_Core_Mvc_PagerTagHelper);
#line 108 "E:\Atrin\GhasedakFromGit2\Ghasedak\Ghasedak\Ghasedak\Views\BoxIncome\Index.cshtml"
__PagedList_Core_Mvc_PagerTagHelper.List = Model;

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("list", __PagedList_Core_Mvc_PagerTagHelper.List, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __PagedList_Core_Mvc_PagerTagHelper.AspController = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __PagedList_Core_Mvc_PagerTagHelper.AspAction = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(4748, 321, true);
            WriteLiteral(@"
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>

    </div>
    <!-- /.col -->
</div>
<div id=""BoxIncomeId"">

</div>
<div id=""Error"">

</div>
<div id=""Success"">

</div>
<div id=""Question"">

</div>
");
            EndContext();
            DefineSection("scripts", async() => {
                BeginContext(5092, 4046, true);
                WriteLiteral(@"
    <script>
        $(document).ready(function () {
            $('#btnUpload').on('click', function () {
                var fileExtension = ['xls', 'xlsx'];
                var filename = $('#fUpload').val();
                if (filename.length == 0) {
                    alert(""Please select a file."");
                    return false;
                }
                else {
                    var extension = filename.replace(/^.*\./, '');
                    if ($.inArray(extension, fileExtension) == -1) {
                        alert(""Please select only excel files."");
                        return false;
                    }
                }
                var fdata = new FormData();
                var fileUpload = $(""#fUpload"").get(0);
                var files = fileUpload.files;
                fdata.append(files[0].name, files[0]);
                $.ajax({
                    type: ""POST"",
                    url: ""/BoxIncome/OnPostImport"",
                    befor");
                WriteLiteral(@"eSend: function (xhr) {
                        xhr.setRequestHeader(""XSRF-TOKEN"",
                            $('input:hidden[name=""__RequestVerificationToken""]').val());
                    },
                    data: fdata,
                    contentType: false,
                    processData: false,
                    success: function (response) {
                        if (response == ""Success"")
                            window.location.href = ""/BoxIncome/Index"";
                    },
                    error: function (e) {

                    }
                });
            })
        });
        $('#checkbox1').change(function () {
            if (this.checked) {
                var isChecked = $(this).prop(""checked"");
                $('#example2 tr:has(td)').find('input[type=""checkbox""]').prop('checked', isChecked);
            }
        });
        $('.deleteAll').on('click', function () {
            var array = [];
            $('#example2 tr:has(td)').find(""");
                WriteLiteral(@"input[type='checkbox']:checked"").each(function () {
                array.push(parseInt($(this).val()));
            });

            swal({
                title: ' مطمئن هستید؟',
                text: 'آیا از حذف رکورد انتخابی اطمینان دارید؟!',
                type: 'warning',
                showCancelButton: true,
                buttonsStyling: false,
                confirmButtonClass: 'btn btn-danger',
                confirmButtonText: '! بله ',
                cancelButtonClass: 'btn btn-light',
                background: 'rgba(0, 0, 0, 0.96)'
            }).then(function () {

                $.ajax({
                    type: ""POST"",
                    url: ""/BoxIncome/DeleteAll"",
                    data: { ids: array },
                    success: function (response) {
                        if (response == ""Success"")
                            window.location.href = ""/BoxIncome/Index"";
                        else
                            window.location.href = ""/");
                WriteLiteral(@"BoxIncome/Index?isSuccess=true"";

                    }
                });
            });
        })
        $(""#export"").on('click', function () {
            window.location.href = '/BoxIncome/ExportToExcel';
        });
        window.onload = Load;
        function Load() {
            CreateAllModals();
            $("".openmodal"").click(function () {
                clear('register', [""input""]);
                clear('register', [""textarea""]);

            });

        }
        function AssignButtonClicked(elem) {
            debugger
            $('#BoxIncomeId').val($(elem).data('assigned-id'));
            var id = $(elem).data('assigned-id');
            $('#QuestionModal').find(""h4"").html(id);
        }
        function Remove() {

            var Parameters = [{ id: ""id"", htmlname: ""BoxIncomeId"", special: """" }];
            PostAjax('../BoxIncome/Delete', Parameters, ""../BoxIncome/Index"");

        }
    </script>
");
                EndContext();
            }
            );
            BeginContext(9141, 6, true);
            WriteLiteral("\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PagedList.Core.IPagedList<Ghasedak.Models.BoxIncome>> Html { get; private set; }
    }
}
#pragma warning restore 1591
