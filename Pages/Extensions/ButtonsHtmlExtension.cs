using System.Collections.Generic;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace abc.Pages.Extensions
{
    public static class ButtonsHtmlExtension
    {
        public static IHtmlContent GoBackButton(this IHtmlHelper htmlHelper, string linkToGo, string text)
        {

            var htmlStrings = new List<object>();

            htmlStrings.Add(new HtmlString("<div class=\"form-inline row\">"));
            htmlStrings.Add(new HtmlString("<div class=\"button-box col-md-12\">"));
            htmlStrings.Add(new HtmlString($"<a href=\"{linkToGo}\" class=\"btn btn-secondary-custom\" style=\"margin-right: 5px;\">{text}</a>"));
            htmlStrings.Add(new HtmlString("</div>"));
            htmlStrings.Add(new HtmlString("</div>"));

            return new HtmlContentBuilder(htmlStrings);
        }

        public static IHtmlContent GoBackAndSubmitButtons(this IHtmlHelper htmlHelper, string linkToGo, string text, string value)
        {
            var htmlStrings = new List<object> {
                new HtmlString("<div class=\"form-inline row\">"),
                new HtmlString("<div class=\"button-box col-md-12\">"),
                new HtmlString($"<a href=\"{linkToGo}\" class=\"btn btn-secondary-custom\" style=\"margin-right: 5px;\">{text}</a>"),
                new HtmlString($"<input type=\"submit\" value=\"{value}\" class=\"btn btn-primary-custom\"/>"),
                new HtmlString("</div>"),
                new HtmlString("</div>")
            };

            return new HtmlContentBuilder(htmlStrings);
        }
    }
}
