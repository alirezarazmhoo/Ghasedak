#pragma checksum "E:\Atrin\GhasedakFromGit2\Ghasedak\Ghasedak\Ghasedak\Views\Charity\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fa6040ebdea8434e2839bd47582f6157af267aaa"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Charity_Index), @"mvc.1.0.view", @"/Views/Charity/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Charity/Index.cshtml", typeof(AspNetCore.Views_Charity_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fa6040ebdea8434e2839bd47582f6157af267aaa", @"/Views/Charity/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0a3adc42566847921abf5afd6f81e3a1773c1a92", @"/Views/_ViewImports.cshtml")]
    public class Views_Charity_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PagedList.Core.IPagedList<Ghasedak.Models.Charity>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Charity", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(59, 227, true);
            WriteLiteral("<div class=\"row\">\r\n    <div class=\"col-xs-12\">\r\n        <div class=\"box\">\r\n            <div class=\"box-header\">\r\n                <h3 class=\"box-title\">خیریه ها</h3>\r\n                <br />\r\n                <p style=\"color:red\">");
            EndContext();
            BeginContext(287, 15, false);
#line 8 "E:\Atrin\GhasedakFromGit2\Ghasedak\Ghasedak\Ghasedak\Views\Charity\Index.cshtml"
                                Write(ViewBag.success);

#line default
#line hidden
            EndContext();
            BeginContext(302, 73, true);
            WriteLiteral("</p>\r\n            </div>\r\n            <div class=\"row\">\r\n                ");
            EndContext();
            BeginContext(375, 868, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "33c03b232c5e4b8abfa7039a1fedd7e6", async() => {
                BeginContext(381, 855, true);
                WriteLiteral(@"
                    <div class=""box-body"">
                        <div class=""col-md-4 form-group"">
                            <input type=""text"" id=""filterCode"" name=""filterCode"" class=""form-control"" placeholder=""کد خیریه"" />
                        </div>
                        <div class=""col-md-1 form-group"">
                            <button type=""submit"" class=""btn btn-default"">جستجو</button>
                        </div>
                        <div class=""col-md-4 form-group"">
                            <a href=""/Charity/Index"" class=""btn btn-default"">مشاهده همه</a>
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
            BeginContext(1243, 1080, true);
            WriteLiteral(@"

            </div>
            <div class=""row"">
                <div class=""col-md-12"">
                    <a class=""btn btn-success openmodal"" style=""margin-right: 10px;"" href=""#""  data-toggle=""modal"" data-target=""#myModal""> خیریه جدید</a>

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
                            <th>نام کاربری</th>
                            <th>کد<");
            WriteLiteral("/th>\r\n                            <th>شماره همراه</th>\r\n");
            EndContext();
            BeginContext(2371, 136, true);
            WriteLiteral("                            <th>امکانات</th>\r\n                        </tr>\r\n                    </thead>\r\n                    <tbody>\r\n");
            EndContext();
#line 57 "E:\Atrin\GhasedakFromGit2\Ghasedak\Ghasedak\Ghasedak\Views\Charity\Index.cshtml"
                         foreach (var item in Model)
                        {

#line default
#line hidden
            BeginContext(2588, 229, true);
            WriteLiteral("                            <tr>\r\n                                <td>\r\n                                    <div class=\"chkRow\">\r\n                                        <label>\r\n                                            <input");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 2817, "\"", 2833, 1);
#line 63 "E:\Atrin\GhasedakFromGit2\Ghasedak\Ghasedak\Ghasedak\Views\Charity\Index.cshtml"
WriteAttributeValue("", 2825, item.id, 2825, 8, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2834, 188, true);
            WriteLiteral(" type=\"checkbox\">\r\n                                        </label>\r\n                                    </div>\r\n                                </td>\r\n                                <td>");
            EndContext();
            BeginContext(3023, 13, false);
#line 67 "E:\Atrin\GhasedakFromGit2\Ghasedak\Ghasedak\Ghasedak\Views\Charity\Index.cshtml"
                               Write(item.userName);

#line default
#line hidden
            EndContext();
            BeginContext(3036, 43, true);
            WriteLiteral("</td>\r\n                                <td>");
            EndContext();
            BeginContext(3080, 9, false);
#line 68 "E:\Atrin\GhasedakFromGit2\Ghasedak\Ghasedak\Ghasedak\Views\Charity\Index.cshtml"
                               Write(item.code);

#line default
#line hidden
            EndContext();
            BeginContext(3089, 43, true);
            WriteLiteral("</td>\r\n                                <td>");
            EndContext();
            BeginContext(3133, 11, false);
#line 69 "E:\Atrin\GhasedakFromGit2\Ghasedak\Ghasedak\Ghasedak\Views\Charity\Index.cshtml"
                               Write(item.mobile);

#line default
#line hidden
            EndContext();
            BeginContext(3144, 83, true);
            WriteLiteral("</td>\r\n                                <td>\r\n                                    <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 3227, "\"", 3307, 4);
            WriteAttributeValue("", 3234, "/User/SignInAsCharity?userName=", 3234, 31, true);
#line 71 "E:\Atrin\GhasedakFromGit2\Ghasedak\Ghasedak\Ghasedak\Views\Charity\Index.cshtml"
WriteAttributeValue("", 3265, item.userName, 3265, 14, false);

#line default
#line hidden
            WriteAttributeValue("", 3279, "&password=", 3279, 10, true);
#line 71 "E:\Atrin\GhasedakFromGit2\Ghasedak\Ghasedak\Ghasedak\Views\Charity\Index.cshtml"
WriteAttributeValue("", 3289, item.passwordShow, 3289, 18, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3308, 175, true);
            WriteLiteral(" class=\"btn btn-default\"> ورود به پنل خیریه</a>\r\n                                    <button type=\"button\" class=\"btn btn-warning\" data-toggle=\"modal\" data-target=\"#EditModal\"");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 3483, "\"", 3496, 1);
#line 72 "E:\Atrin\GhasedakFromGit2\Ghasedak\Ghasedak\Ghasedak\Views\Charity\Index.cshtml"
WriteAttributeValue("", 3488, item.id, 3488, 8, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3497, 184, true);
            WriteLiteral("> ویرایش</button>\r\n                                    <a class=\"btn btn-danger\" data-toggle=\"modal\" data-target=\"#QuestionModal\" onclick=\"AssignButtonClicked(this)\" data-assigned-id=\"");
            EndContext();
            BeginContext(3682, 7, false);
#line 73 "E:\Atrin\GhasedakFromGit2\Ghasedak\Ghasedak\Ghasedak\Views\Charity\Index.cshtml"
                                                                                                                                                                Write(item.id);

#line default
#line hidden
            EndContext();
            BeginContext(3689, 29, true);
            WriteLiteral("\" data-assigned-Charityname=\"");
            EndContext();
            BeginContext(3719, 10, false);
#line 73 "E:\Atrin\GhasedakFromGit2\Ghasedak\Ghasedak\Ghasedak\Views\Charity\Index.cshtml"
                                                                                                                                                                                                     Write(item.title);

#line default
#line hidden
            EndContext();
            BeginContext(3729, 14, true);
            WriteLiteral("\"> حذف</a>\r\n\r\n");
            EndContext();
            BeginContext(4029, 74, true);
            WriteLiteral("                                </td>\r\n                            </tr>\r\n");
            EndContext();
#line 86 "E:\Atrin\GhasedakFromGit2\Ghasedak\Ghasedak\Ghasedak\Views\Charity\Index.cshtml"
                        }

#line default
#line hidden
            BeginContext(4130, 458, true);
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
");
            EndContext();
            BeginContext(5021, 66, true);
            WriteLiteral("                            <li>\r\n                                ");
            EndContext();
            BeginContext(5087, 67, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("pager", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "c7398891c2724021a61dc59f2cb6a7f7", async() => {
            }
            );
            __PagedList_Core_Mvc_PagerTagHelper = CreateTagHelper<global::PagedList.Core.Mvc.PagerTagHelper>();
            __tagHelperExecutionContext.Add(__PagedList_Core_Mvc_PagerTagHelper);
#line 109 "E:\Atrin\GhasedakFromGit2\Ghasedak\Ghasedak\Ghasedak\Views\Charity\Index.cshtml"
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
            BeginContext(5154, 665, true);
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
                <h4 class=""modal-title"">خیریه</h4>
            </div>
            <div class=""modal-body"" style=""height:auto"">

");
            EndContext();
            BeginContext(6230, 16, true);
            WriteLiteral("                ");
            EndContext();
            BeginContext(6246, 6568, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d388e7ac1cdd4547b7da65a3fbf02558", async() => {
                BeginContext(6266, 6541, true);
                WriteLiteral(@"
                    <div class=""box-body"">
                        <input type=""hidden"" id=""CharityId"" name=""CharityId"" />
                        <input type=""hidden"" id=""password"" name=""password"" />
                        <div class=""col-md-12"">
                            <div class=""form-group"">
                                <label class=""control-label"">نام خیریه</label>
                                <input class=""form-control valid"" type=""text"" data-val=""true"" data-val-maxlength=""نام خیریه نمی تواند بیشتر از 30 کاراکتر باشد ."" data-val-maxlength-max=""30"" id=""title"" name=""title"" aria-describedby=""fullName-error"" aria-invalid=""false"">
                                <span class=""text-danger field-validation-valid"" data-valmsg-for=""title"" data-valmsg-replace=""true""></span>
                            </div>
                        </div>
                        <div class=""col-md-12"">
                            <div class=""form-group"">
                                <label class=""contro");
                WriteLiteral(@"l-label"">کد</label>
                                <input class=""form-control valid"" type=""text"" data-val=""true"" data-val-maxlength=""کد نمی تواند بیشتر از 6 کاراکتر باشد ."" data-val-maxlength-max=""6"" id=""code"" name=""code"" aria-describedby=""code-error"" aria-invalid=""false"">
                                <span class=""text-danger field-validation-valid"" data-valmsg-for=""code"" data-valmsg-replace=""true""></span>
                            </div>
                        </div>
                        <div class=""col-md-12"">
                            <div class=""form-group"">
                                <label class=""control-label"">نام کاربری</label>
                                <input class=""form-control valid"" type=""text"" data-val=""true"" data-val-maxlength=""نام کاربری نمی تواند بیشتر از 20 کاراکتر باشد ."" data-val-maxlength-max=""20"" id=""userName"" name=""userName"" aria-describedby=""CharityName-error"" aria-invalid=""false"">
                                <span class=""text-danger field-validation-");
                WriteLiteral(@"valid"" data-valmsg-for=""userName"" data-valmsg-replace=""true""></span>
                            </div>
                        </div>
                        <div class=""col-md-12"">
                            <div class=""form-group"">
                                <label class=""control-label"">رمز عبور</label>
                                <input class=""form-control valid"" type=""text"" data-val=""true"" data-val-maxlength=""پسورد نمی تواند بیشتر از 20 کاراکتر باشد ."" data-val-maxlength-max=""20"" id=""passwordShow"" name=""passwordShow"" aria-describedby=""password-error"" aria-invalid=""false"">
                                <span class=""text-danger field-validation-valid"" data-valmsg-for=""passwordShow"" data-valmsg-replace=""true""></span>
                            </div>
                        </div>
                        <div class=""col-md-12"">
                            <div class=""form-group"">
                                <label class=""control-label"">شماره همراه</label>
                      ");
                WriteLiteral(@"          <input class=""form-control text-box single-line valid"" data-val=""true"" data-val-regex=""شماره همراه را به درستی وارد نمایید"" data-val-regex-pattern=""^(09\d{9})$"" data-val-required=""شماره همراه را وارد نمایید"" id=""mobile"" maxlength=""11"" name=""mobile"" onkeypress=""return validateQty(event);"" type=""text"" value="""" aria-describedby=""mobile-error"" aria-invalid=""false"">
                                <span class=""text-danger field-validation-valid"" data-valmsg-for=""mobile"" data-valmsg-replace=""true""></span>
                            </div>
                        </div>

                        <div class=""col-md-12"">
                            <div class=""form-group"">
                                <label class=""control-label"">آدرس</label>

                                <textarea class=""form-control"" data-val=""true"" data-val-maxlength=""آدرس  نمی تواند بیشتر از 500 کاراکتر باشد ."" data-val-maxlength-max=""500"" id=""address"" name=""address""></textarea>
                                <span class");
                WriteLiteral(@"=""text-danger field-validation-valid"" data-valmsg-for=""address"" data-valmsg-replace=""true""></span>
                            </div>
                        </div>
                        <div class=""col-md-12"">
                            <div class=""form-group"">
                                <label class=""control-label"">توضیحات</label>

                                <textarea class=""form-control"" data-val=""true"" data-val-maxlength=""توضیحات  نمی تواند بیشتر از 500 کاراکتر باشد ."" data-val-maxlength-max=""500"" id=""description"" name=""description""></textarea>
                                <span class=""text-danger field-validation-valid"" data-valmsg-for=""description"" data-valmsg-replace=""true""></span>
                            </div>
                        </div>
                        <div class=""col-md-12"">
                            <label>
                                <input type=""checkbox"" id=""isActive"" name=""isActive"">
                            </label>
                      ");
                WriteLiteral(@"      <label for=""isActive"" class=""control-label"">فعال</label>
                        </div>
                        <div class=""col-md-12"">
                            <label>
                                <input type=""checkbox"" id=""isAccessBox"" name=""isAccessBox"">
                            </label>
                            <label for=""isAccessBox"" class=""control-label"">دسترسی به صندوق</label>
                            <label>
                                <input type=""checkbox"" id=""isAccessSponsor"" name=""isAccessSponsor"">
                            </label>
                            <label for=""isAccessSponsor"" class=""control-label"">دسترسی به مشارکت</label>
                            <br />
                            <label>

                                <input type=""checkbox"" id=""isAccessFinancialAid"" name=""isAccessFinancialAid"">
                            </label>
                            <label for=""isAccessFinancialAid"" class=""control-label"">دسترسی به کمک نقدی</la");
                WriteLiteral(@"bel>
                            <label>
                                <input type=""checkbox"" id=""isAccessFlowerCrown"" name=""isAccessFlowerCrown"">
                            </label>
                            <label for=""isAccessFlowerCrown"" class=""control-label"">دسترسی به تاج گل</label>
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
            BeginContext(12814, 400, true);
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
                BeginContext(13237, 3720, true);
                WriteLiteral(@"
    <script>
        $('#checkbox1').change(function () {
            if (this.checked) {
                var isChecked = $(this).prop(""checked"");
                $('#example2 tr:has(td)').find('input[type=""checkbox""]').prop('checked', isChecked);
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
            }).then(function () {");
                WriteLiteral(@"

                $.ajax({
                    type: ""POST"",
                    url: ""/Charity/DeleteAll"",
                    data: { ids: array },
                    success: function (response) {
                        if (response == ""Success"")
                            window.location.href = ""/Charity/Index"";
                        else
                            window.location.href = ""/Charity/Index?isSuccess=true"";

                    }
                });
            });
        })
        $(""#export"").on('click', function () {
            var filterCharityName = $(""#filterCode"").val();
            window.location.href = '/Charity/ExportToExcel?filterCode=' + filterCode;
        });
    </script>
    
    <script>
        window.onload = Load;
        function Load() {

            CreateAllModals();
            $("".openmodal"").click(function () {
                clear('register', [""input""]);
                clear('register', [""textarea""]);
            });
     ");
                WriteLiteral(@"       $("".btn-warning"").click(function () {
                
                EditAjax(""../Charity/CharityInfo"", this.id);
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
                var Parameters = [{ id: ""id"", htmlname: ""CharityId"", special: """" },
                    { id: ""password"", htmlname: ""password"", special: """" },
                    { id: ""passwordShow"", htmlname: ""passwordShow"", special: """" },
                    { id: ""code"", htmlname: ""code"", special: """" },
                    { id: ""userName"", htmlname: ""userName"", special: """" },
                    { id: ""title"", htmlname: ""title"", special: """" },
                    { id: ""mobile"", htmlname: ""mobile"", special: """" },
                    { id: ""descripti");
                WriteLiteral(@"on"", htmlname: ""description"", special: """" },
                    { id: ""isActive"", htmlname: ""isActive"", special: """" },
                    { id: ""isAccessBox"", htmlname: ""isAccessBox"", special: """" },
                    { id: ""isAccessSponsor"", htmlname: ""isAccessSponsor"", special: """" },
                    { id: ""isAccessFinancialAid"", htmlname: ""isAccessFinancialAid"", special: """" },
                    { id: ""isAccessFlowerCrown"", htmlname: ""isAccessFlowerCrown"", special: """" },
                { id: ""address"", htmlname: ""address"", special: """" }];
                PostAjax('../Charity/Register', Parameters, ""../Charity/Index?page=""+");
                EndContext();
                BeginContext(16958, 16, false);
#line 324 "E:\Atrin\GhasedakFromGit2\Ghasedak\Ghasedak\Ghasedak\Views\Charity\Index.cshtml"
                                                                                Write(Model.PageNumber);

#line default
#line hidden
                EndContext();
                BeginContext(16974, 502, true);
                WriteLiteral(@"+"""");
            }
        }
        function AssignButtonClicked(elem) {
            $('#CharityId').val($(elem).data('assigned-id'));
            var Charityname = $(elem).data('assigned-Charityname');
            $('#QuestionModal').find(""h4"").html(Charityname);
        }
        function Remove() {
            var Parameters = [{ id: ""id"", htmlname: ""CharityId"", special: """" }];
            PostAjax('../Charity/Delete', Parameters, ""../Charity/Index"");
        }


    </script>
");
                EndContext();
            }
            );
            BeginContext(17479, 4, true);
            WriteLiteral("\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PagedList.Core.IPagedList<Ghasedak.Models.Charity>> Html { get; private set; }
    }
}
#pragma warning restore 1591
