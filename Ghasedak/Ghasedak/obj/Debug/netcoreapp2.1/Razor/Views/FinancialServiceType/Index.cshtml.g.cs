#pragma checksum "E:\Atrin\GhasedakFromGit2\Ghasedak\Ghasedak\Ghasedak\Views\FinancialServiceType\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "dbe57f2c378c875817527f05a4353bcffd9f8edf"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_FinancialServiceType_Index), @"mvc.1.0.view", @"/Views/FinancialServiceType/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/FinancialServiceType/Index.cshtml", typeof(AspNetCore.Views_FinancialServiceType_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dbe57f2c378c875817527f05a4353bcffd9f8edf", @"/Views/FinancialServiceType/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0a3adc42566847921abf5afd6f81e3a1773c1a92", @"/Views/_ViewImports.cshtml")]
    public class Views_FinancialServiceType_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PagedList.Core.IPagedList<Ghasedak.Models.FinancialServiceType>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "FinancialServiceType", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("register"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::PagedList.Core.Mvc.PagerTagHelper __PagedList_Core_Mvc_PagerTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(72, 229, true);
            WriteLiteral("\r\n<div class=\"row\">\r\n    <div class=\"col-xs-12\">\r\n        <div class=\"box\">\r\n            <div class=\"box-header\">\r\n                <h3 class=\"box-title\">نوع خدمت</h3>\r\n                <br />\r\n                <p style=\"color:red\">");
            EndContext();
            BeginContext(302, 15, false);
#line 9 "E:\Atrin\GhasedakFromGit2\Ghasedak\Ghasedak\Ghasedak\Views\FinancialServiceType\Index.cshtml"
                                Write(ViewBag.success);

#line default
#line hidden
            EndContext();
            BeginContext(317, 73, true);
            WriteLiteral("</p>\r\n            </div>\r\n            <div class=\"row\">\r\n                ");
            EndContext();
            BeginContext(390, 882, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "64832c4bcde74e798637cd23451a6ee9", async() => {
                BeginContext(396, 869, true);
                WriteLiteral(@"
                    <div class=""box-body"">
                        <div class=""col-md-4 form-group"">
                            <input type=""text"" name=""filtertitle"" id=""filtertitle"" class=""form-control"" placeholder=""عنوان"" />
                        </div>
                        <div class=""col-md-4 form-group"">
                            <button type=""submit"" class=""btn btn-default"">جستجو</button>
                        </div>
                        <div class=""col-md-2 form-group"">
                            <a href=""/FinancialServiceType/Index"" class=""btn btn-default"">مشاهده همه</a>
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
            BeginContext(1272, 1837, true);
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
                        فایل آپلودی به ترتیب از راست به چپ دارای فیلدهای title از نوع حروف
                    </div>
                </div>
            </div>
            <div class=""row"">
                <div class=""box-body"">

                    <div class=""col-md-12"">
                        <a class=""btn btn-success openmodal"" style=""margin-right: 10px;"" href=""#"" data-toggle=""modal"" data-target=""#myModal""> نوع خدمت جدید</a>

                        <a class=""btn btn-default deleteAll"">حذف موارد انتخابی</a>
    ");
            WriteLiteral(@"                </div>
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
                            <th>عنوان</th>

                            <th>امکانات</th>
                        </tr>
                    </thead>
                    <tbody>
");
            EndContext();
#line 74 "E:\Atrin\GhasedakFromGit2\Ghasedak\Ghasedak\Ghasedak\Views\FinancialServiceType\Index.cshtml"
                         foreach (var item in Model)
                        {

#line default
#line hidden
            BeginContext(3190, 229, true);
            WriteLiteral("                            <tr>\r\n                                <td>\r\n                                    <div class=\"chkRow\">\r\n                                        <label>\r\n                                            <input");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 3419, "\"", 3435, 1);
#line 80 "E:\Atrin\GhasedakFromGit2\Ghasedak\Ghasedak\Ghasedak\Views\FinancialServiceType\Index.cshtml"
WriteAttributeValue("", 3427, item.id, 3427, 8, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3436, 188, true);
            WriteLiteral(" type=\"checkbox\">\r\n                                        </label>\r\n                                    </div>\r\n                                </td>\r\n                                <td>");
            EndContext();
            BeginContext(3625, 10, false);
#line 84 "E:\Atrin\GhasedakFromGit2\Ghasedak\Ghasedak\Ghasedak\Views\FinancialServiceType\Index.cshtml"
                               Write(item.title);

#line default
#line hidden
            EndContext();
            BeginContext(3635, 205, true);
            WriteLiteral("</td>\r\n                                \r\n                                <td>\r\n                                    <button type=\"button\" class=\"btn btn-warning\" data-toggle=\"modal\" data-target=\"#EditModal\"");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 3840, "\"", 3853, 1);
#line 87 "E:\Atrin\GhasedakFromGit2\Ghasedak\Ghasedak\Ghasedak\Views\FinancialServiceType\Index.cshtml"
WriteAttributeValue("", 3845, item.id, 3845, 8, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3854, 186, true);
            WriteLiteral("> ویرایش</button>\r\n\r\n                                    <a class=\"btn btn-danger\" data-toggle=\"modal\" data-target=\"#QuestionModal\" onclick=\"AssignButtonClicked(this)\" data-assigned-id=\"");
            EndContext();
            BeginContext(4041, 7, false);
#line 89 "E:\Atrin\GhasedakFromGit2\Ghasedak\Ghasedak\Ghasedak\Views\FinancialServiceType\Index.cshtml"
                                                                                                                                                                Write(item.id);

#line default
#line hidden
            EndContext();
            BeginContext(4048, 23, true);
            WriteLiteral("\" data-assigned-title=\"");
            EndContext();
            BeginContext(4072, 10, false);
#line 89 "E:\Atrin\GhasedakFromGit2\Ghasedak\Ghasedak\Ghasedak\Views\FinancialServiceType\Index.cshtml"
                                                                                                                                                                                               Write(item.title);

#line default
#line hidden
            EndContext();
            BeginContext(4082, 88, true);
            WriteLiteral("\"> حذف</a>\r\n\r\n                                </td>\r\n                            </tr>\r\n");
            EndContext();
#line 93 "E:\Atrin\GhasedakFromGit2\Ghasedak\Ghasedak\Ghasedak\Views\FinancialServiceType\Index.cshtml"
                        }

#line default
#line hidden
            BeginContext(4197, 452, true);
            WriteLiteral(@"                    </tbody>
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
            BeginContext(5079, 66, true);
            WriteLiteral("                            <li>\r\n                                ");
            EndContext();
            BeginContext(5145, 80, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("pager", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "7b1b689a58994669b61f178e625d450e", async() => {
            }
            );
            __PagedList_Core_Mvc_PagerTagHelper = CreateTagHelper<global::PagedList.Core.Mvc.PagerTagHelper>();
            __tagHelperExecutionContext.Add(__PagedList_Core_Mvc_PagerTagHelper);
#line 113 "E:\Atrin\GhasedakFromGit2\Ghasedak\Ghasedak\Ghasedak\Views\FinancialServiceType\Index.cshtml"
__PagedList_Core_Mvc_PagerTagHelper.List = Model;

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("list", __PagedList_Core_Mvc_PagerTagHelper.List, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __PagedList_Core_Mvc_PagerTagHelper.AspController = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __PagedList_Core_Mvc_PagerTagHelper.AspAction = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(5225, 682, true);
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
<div class=""modal fade"" id=""myModal"" role=""dialog"" style=""height:auto;overflow-y:visible"">
    <div class=""modal-dialog modal-sm"" style=""width:400px"">
        <div class=""modal-content"">
            <div class=""modal-header text-center"">
                <button type=""button"" class=""close"" data-dismiss=""modal"">&times;</button>
                <h4 class=""modal-title"">نوع تاج گل</h4>
            </div>
            <div class=""modal-body"" style=""height:auto"">
                ");
            EndContext();
            BeginContext(5907, 936, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "20e603cf655d43e98231d77054bb588f", async() => {
                BeginContext(5927, 909, true);
                WriteLiteral(@"
                    <div class=""box-body"">
                        <input type=""hidden"" id=""FinancialServiceTypeId"" name=""FinancialServiceTypeId"" />
                        <input type=""hidden"" id=""charityId"" name=""charityId"" />

                        <div class=""col-md-12"">
                            <div class=""form-group"">
                                <label class=""control-label"">عنوان</label>
                                <input class=""form-control"" type=""text"" data-val=""true"" data-val-maxlength=""عنوان  نمی تواند بیشتر از 50 کاراکتر باشد ."" data-val-maxlength-max=""50"" id=""title"" name=""title"" value="""">
                                <span class=""text-danger field-validation-valid"" data-valmsg-for=""title"" data-valmsg-replace=""true""></span>
                            </div>
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
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(6843, 400, true);
            WriteLiteral(@"
            </div>
            <div class=""modal-footer"">
                <button type=""button"" class=""btn btn-danger"" data-dismiss=""modal"">انصراف</button>
                <button type=""button"" class=""btn btn-success"" onclick=""Save();"">ثبت</button>
            </div>
        </div>
    </div>
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
                BeginContext(7266, 5026, true);
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
                    url: ""/FinancialServiceType/OnPostImport"",
              ");
                WriteLiteral(@"      beforeSend: function (xhr) {
                        xhr.setRequestHeader(""XSRF-TOKEN"",
                            $('input:hidden[name=""__RequestVerificationToken""]').val());
                    },
                    data: fdata,
                    contentType: false,
                    processData: false,
                    success: function (response) {
                        if (response == ""Success"")
                            window.location.href = ""/FinancialServiceType/Index"";
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
            $('#exampl");
                WriteLiteral(@"e2 tr:has(td)').find(""input[type='checkbox']:checked"").each(function () {
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
                    url: ""/FinancialServiceType/DeleteAll"",
                    data: { ids: array },
                    success: function (response) {
                        if (response == ""Success"")
                            window.location.href = ""/FinancialServiceType/Index"";
                        else
         ");
                WriteLiteral(@"                   window.location.href = ""/FinancialServiceType/Index?isSuccess=true"";

                    }
                });
            });
        })
        $(""#export"").on('click', function () {
            var filtertitle = $(""#filtertitle"").val();
            window.location.href = '/FinancialServiceType/ExportToExcel?filtertitle=' + filtertitle;
        });
    </script>

    <script>


        $('#modal-default').on('hidden.bs.modal', function () {
            $('#modal-default').find('input,textarea,select').each(function (key) {
                if ($(this).attr('id') == ""id"") {
                    $(this).val(0);
                }
                else
                    if ($(this).attr('name') != '__RequestVerificationToken')
                        $(this).val('');
            })
        })
    </script>
    <script>
        window.onload = Load;
        function Load() {
            CreateAllModals();
            $("".openmodal"").click(function () {
          ");
                WriteLiteral(@"      clear('register', [""input""]);
                clear('register', [""textarea""]);

            });
            $("".btn-warning"").click(function () {
                EditAjax(""../FinancialServiceType/FinancialServiceTypeInfo"", this.id);
                var bodyStyle = document.body.style;
                bodyStyle.removeProperty('padding-right');
            });
        }
        function Save() {
            if (checkvalidity('register') === 0) {
                return;
            }
            else {
                $(""#myModal"").modal('toggle');
                var Parameters = [{ id: ""id"", htmlname: ""FinancialServiceTypeId"", special: """" },
                    { id: ""title"", htmlname: ""title"", special: """" },

                { id: ""charityId"", htmlname: ""charityId"", special: """" }];
                PostAjax('../FinancialServiceType/Register', Parameters, ""../FinancialServiceType/Index?page=""+");
                EndContext();
                BeginContext(12293, 16, false);
#line 289 "E:\Atrin\GhasedakFromGit2\Ghasedak\Ghasedak\Ghasedak\Views\FinancialServiceType\Index.cshtml"
                                                                                                          Write(Model.PageNumber);

#line default
#line hidden
                EndContext();
                BeginContext(12309, 544, true);
                WriteLiteral(@"+"""");
            }
        }
        function AssignButtonClicked(elem) {
            $('#FinancialServiceTypeId').val($(elem).data('assigned-id'));
            var title = $(elem).data('assigned-title');
            $('#QuestionModal').find(""h4"").html(title);
        }
        function Remove() {

            var Parameters = [{ id: ""id"", htmlname: ""FinancialServiceTypeId"", special: """" }];

            PostAjax('../FinancialServiceType/Delete', Parameters, ""../FinancialServiceType/Index"");

        }


    </script>

");
                EndContext();
            }
            );
            BeginContext(12856, 2, true);
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PagedList.Core.IPagedList<Ghasedak.Models.FinancialServiceType>> Html { get; private set; }
    }
}
#pragma warning restore 1591