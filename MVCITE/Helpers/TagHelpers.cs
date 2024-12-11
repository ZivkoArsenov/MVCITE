using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVCITE.Helpers
{
    public static class TagHelpers
    {
        public static IHtmlContent PictureHelper(string src, string tekst)
        {
            var tagBuilder = new TagBuilder("div");
          
            tagBuilder.InnerHtml.AppendHtml($"<img src=\"{src}\" />{tekst}");

            tagBuilder.AddCssClass("plazaTag");

            return tagBuilder;
        }
    }
}
