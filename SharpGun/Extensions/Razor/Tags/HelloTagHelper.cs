using Microsoft.AspNetCore.Razor.TagHelpers;

namespace SharpGun.Extensions.Razor.Tags
{
    [HtmlTargetElement("hello")]
    public class HelloTagHelper : TagHelper
    {
        public string OutputContent = default;

        public override void Process(TagHelperContext context, TagHelperOutput output) {
            output.TagName = "h1";
            output.PreContent.SetContent("hello");
        }
    }
}
