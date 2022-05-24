using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ASP_MVC_02_Formulaire.Helpers
{

    [HtmlTargetElement("hello-world")]
    public class CustomTagHelper : TagHelper
    {
        public string Name { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "span";
            output.TagMode = TagMode.StartTagAndEndTag;

            output.Content.SetContent("Hello " + Name);
        }
    }
}
