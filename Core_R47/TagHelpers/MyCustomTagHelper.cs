using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;
namespace Core_R47.TagHelpers
{
    [HtmlTargetElement("my-first-tag-helper")]
    public class MyCustomTagHelper : TagHelper
    {
        public string Name { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "CustumTagHelper";
            output.TagMode = TagMode.StartTagAndEndTag;

            var sb = $"<span>Hi! {this.Name}</span>";
            output.PreContent.SetHtmlContent(sb.ToString());
        }
    }
}
