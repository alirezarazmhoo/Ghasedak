#pragma checksum "E:\Atrin\GhasedakFromGit2\Ghasedak\Ghasedak\Ghasedak\Views\Box\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ca1c4f5233e6c79523d8aa63a18dd3df7f75a7a7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Box_Index), @"mvc.1.0.view", @"/Views/Box/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Box/Index.cshtml", typeof(AspNetCore.Views_Box_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ca1c4f5233e6c79523d8aa63a18dd3df7f75a7a7", @"/Views/Box/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0a3adc42566847921abf5afd6f81e3a1773c1a92", @"/Views/_ViewImports.cshtml")]
    public class Views_Box_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PagedList.Core.IPagedList<Ghasedak.Models.Box>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-warning"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Box", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(55, 228, true);
            WriteLiteral("\r\n<div class=\"row\">\r\n    <div class=\"col-xs-12\">\r\n        <div class=\"box\">\r\n            <div class=\"box-header\">\r\n                <h3 class=\"box-title\">صندوقات</h3>\r\n                <br />\r\n                <p style=\"color:red\">");
            EndContext();
            BeginContext(284, 15, false);
#line 9 "E:\Atrin\GhasedakFromGit2\Ghasedak\Ghasedak\Ghasedak\Views\Box\Index.cshtml"
                                Write(ViewBag.success);

#line default
#line hidden
            EndContext();
            BeginContext(299, 75, true);
            WriteLiteral("</p>\r\n            </div>\r\n\r\n            <div class=\"row\">\r\n                ");
            EndContext();
            BeginContext(374, 871, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6e65b4c860d4480ba4c8649c3d517eb8", async() => {
                BeginContext(380, 858, true);
                WriteLiteral(@"
                    <div class=""box-body"">
                        <div class=""col-md-4 form-group"">
                            <input type=""text"" name=""filternumber"" id=""filternumber"" class=""form-control"" placeholder=""شماره صندوق"" />
                        </div>
                        <div class=""col-md-4 form-group"">
                            <button type=""submit"" class=""btn btn-default"">جستجو</button>
                        </div>
                        <div class=""col-md-2 form-group"">
                            <a href=""/Box/Index"" class=""btn btn-default"">مشاهده همه</a>
                        </div>
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
            BeginContext(1245, 891, true);
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
                        فایل آپلودی به ترتیب از راست به چپ دارای فیلدهای IsSendSMS از نوع عدد،PathCode از نوع عدد،Address از نوع حروف،Mobile از نوع عدد،Name از نوع حروف،Number از نوع عدد
                    </div>
                </div>
            </div>
            <div class=""row"">
                <div class=""box-body"">
                    <div class=""col-md-12"">
                        ");
            EndContext();
            BeginContext(2136, 61, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "84aa1e1eec9048a695b0fcc3e203545b", async() => {
                BeginContext(2183, 10, true);
                WriteLiteral("صندوق جدید");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2197, 1018, true);
            WriteLiteral(@"
                        <a class=""btn btn-default deleteAll"">حذف موارد انتخابی</a>
                    </div>
                </div>
                <!-- /.box-header -->
                <div class=""box-body table-responsive"">
                    <table id=""example2"" class=""table table-bordered table-hover"">
                        <thead>
                            <tr>
                                <th>
                                    <div class=""checkbox"">
                                        <label>
                                            <input type=""checkbox"" id=""checkbox1"">
                                        </label>
                                    </div>
                                </th>
                                <th>شماره صندوق</th>
                                <th>نام و نام خانوادگی</th>

                                <th>امکانات</th>
                            </tr>
                        </thead>
                        <tbody>
");
            EndContext();
#line 72 "E:\Atrin\GhasedakFromGit2\Ghasedak\Ghasedak\Ghasedak\Views\Box\Index.cshtml"
                             foreach (var item in Model)
                            {

#line default
#line hidden
            BeginContext(3304, 249, true);
            WriteLiteral("                                <tr>\r\n                                    <td>\r\n                                        <div class=\"chkRow\">\r\n                                            <label>\r\n                                                <input");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 3553, "\"", 3569, 1);
#line 78 "E:\Atrin\GhasedakFromGit2\Ghasedak\Ghasedak\Ghasedak\Views\Box\Index.cshtml"
WriteAttributeValue("", 3561, item.id, 3561, 8, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3570, 204, true);
            WriteLiteral(" type=\"checkbox\">\r\n                                            </label>\r\n                                        </div>\r\n                                    </td>\r\n                                    <td>");
            EndContext();
            BeginContext(3775, 11, false);
#line 82 "E:\Atrin\GhasedakFromGit2\Ghasedak\Ghasedak\Ghasedak\Views\Box\Index.cshtml"
                                   Write(item.number);

#line default
#line hidden
            EndContext();
            BeginContext(3786, 47, true);
            WriteLiteral("</td>\r\n                                    <td>");
            EndContext();
            BeginContext(3834, 13, false);
#line 83 "E:\Atrin\GhasedakFromGit2\Ghasedak\Ghasedak\Ghasedak\Views\Box\Index.cshtml"
                                   Write(item.fullName);

#line default
#line hidden
            EndContext();
            BeginContext(3847, 91, true);
            WriteLiteral("</td>\r\n\r\n                                    <td>\r\n                                        ");
            EndContext();
            BeginContext(3938, 79, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1aa6b409e36f44b9bc84c0cfa61a575f", async() => {
                BeginContext(4007, 6, true);
                WriteLiteral("ویرایش");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 86 "E:\Atrin\GhasedakFromGit2\Ghasedak\Ghasedak\Ghasedak\Views\Box\Index.cshtml"
                                                               WriteLiteral(item.id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(4017, 173, true);
            WriteLiteral("\r\n\r\n                                        <a class=\"btn btn-danger\" data-toggle=\"modal\" data-target=\"#QuestionModal\" onclick=\"AssignButtonClicked(this)\" data-assigned-id=\"");
            EndContext();
            BeginContext(4191, 7, false);
#line 88 "E:\Atrin\GhasedakFromGit2\Ghasedak\Ghasedak\Ghasedak\Views\Box\Index.cshtml"
                                                                                                                                                                    Write(item.id);

#line default
#line hidden
            EndContext();
            BeginContext(4198, 24, true);
            WriteLiteral("\" data-assigned-number=\"");
            EndContext();
            BeginContext(4223, 11, false);
#line 88 "E:\Atrin\GhasedakFromGit2\Ghasedak\Ghasedak\Ghasedak\Views\Box\Index.cshtml"
                                                                                                                                                                                                    Write(item.number);

#line default
#line hidden
            EndContext();
            BeginContext(4234, 96, true);
            WriteLiteral("\"> حذف</a>\r\n\r\n                                    </td>\r\n                                </tr>\r\n");
            EndContext();
#line 92 "E:\Atrin\GhasedakFromGit2\Ghasedak\Ghasedak\Ghasedak\Views\Box\Index.cshtml"
                            }

#line default
#line hidden
            BeginContext(4361, 500, true);
            WriteLiteral(@"                        </tbody>
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
");
            EndContext();
            BeginContext(5315, 74, true);
            WriteLiteral("                                <li>\r\n                                    ");
            EndContext();
            BeginContext(5389, 63, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("pager", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "ced8b8e5580946c399b9a54581399752", async() => {
            }
            );
            __PagedList_Core_Mvc_PagerTagHelper = CreateTagHelper<global::PagedList.Core.Mvc.PagerTagHelper>();
            __tagHelperExecutionContext.Add(__PagedList_Core_Mvc_PagerTagHelper);
#line 112 "E:\Atrin\GhasedakFromGit2\Ghasedak\Ghasedak\Ghasedak\Views\Box\Index.cshtml"
__PagedList_Core_Mvc_PagerTagHelper.List = Model;

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("list", __PagedList_Core_Mvc_PagerTagHelper.List, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __PagedList_Core_Mvc_PagerTagHelper.AspController = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __PagedList_Core_Mvc_PagerTagHelper.AspAction = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(5452, 383, true);
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
    <div id=""BoxId"">

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
                BeginContext(5862, 4493, true);
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
                        type:");
                WriteLiteral(@" ""POST"",
                        url: ""/Box/OnPostImport"",
                        beforeSend: function (xhr) {
                            xhr.setRequestHeader(""XSRF-TOKEN"",
                                $('input:hidden[name=""__RequestVerificationToken""]').val());
                        },
                        data: fdata,
                        contentType: false,
                        processData: false,
                        success: function (response) {
                            if (response == ""Success"")
                                window.location.href = ""/Box/Index"";
                        },
                        error: function (e) {

                        }
                    });
                })
            });
            $('#checkbox1').change(function () {
                if (this.checked) {
                    var isChecked = $(this).prop(""checked"");
                    $('#example2 tr:has(td)').find('input[type=""checkbox""]').prop('checked', isChe");
                WriteLiteral(@"cked);
                }
            });
            $('.deleteAll').on('click', function () {
                var array = [];
                $('#example2 tr:has(td)').find(""input[type='checkbox']:checked"").each(function () {
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
                        url: ""/Box/DeleteAll"",
                        data: { ids: array },
                 ");
                WriteLiteral(@"       success: function (response) {
                            if (response == ""Success"")
                                window.location.href = ""/Box/Index"";
                            else
                                window.location.href = ""/Box/Index?isSuccess=true"";

                        }
                    });
                });
            })
            $(""#export"").on('click', function () {
                var filternumber = $(""#filternumber"").val();
                window.location.href = '/Box/ExportToExcel?filternumber=' + filternumber;
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
                $('#BoxId').val($(e");
                WriteLiteral(@"lem).data('assigned-id'));
                var number = $(elem).data('assigned-number');
                $('#QuestionModal').find(""h4"").html(number);
            }
            function Remove() {

                var Parameters = [{ id: ""id"", htmlname: ""BoxId"", special: """" }];
                PostAjax('../Box/Delete', Parameters, ""../Box/Index"");

            }
        </script>
    ");
                EndContext();
            }
            );
            BeginContext(10358, 6, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PagedList.Core.IPagedList<Ghasedak.Models.Box>> Html { get; private set; }
    }
}
#pragma warning restore 1591
