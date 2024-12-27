using Microsoft.AspNetCore.Razor.TagHelpers;
namespace MVCCoreTagHelpers.TagHelpers
{
    public class EmailTagHelper : TagHelper
    {
        public string MailTo { get; set; }
        public string DomainName { get; set; }
        public string TargetAddress { get; set; }
        public string InnerHtml { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            //Mentioin Target Tag
            output.TagName = "a";

            //Point to Target Attribute
            if (!String.IsNullOrEmpty(TargetAddress))
                output.Attributes.SetAttribute("href", $"mailto:{TargetAddress}");
            else
                output.Attributes.SetAttribute("href", $"mailto:{MailTo}@{DomainName}");

            //Mention the Contents
            if (!String.IsNullOrEmpty(InnerHtml))
                output.Content.SetContent(InnerHtml);
            else if (!String.IsNullOrEmpty(TargetAddress))
                output.Content.SetContent(TargetAddress);
            else
                output.Content.SetContent($"{MailTo}@{DomainName}");
        }
    }
}
