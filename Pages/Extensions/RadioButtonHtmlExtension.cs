using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace abc.Pages.Extensions
{
    public static class RadioButtonHtmlExtension
    {
        public static IHtmlContent CustomRadioButtons(this IHtmlHelper htmlHelper)
        {

            var htmlStrings = new List<object> {
                new HtmlString("<div class=\"form-group row col-form-label\">"),
                new HtmlString("<div class=\"col-md-4\"></div>"),
                new HtmlString("<div class=\"col-md-7\">"),

                new HtmlString("<div class=\"custom-control custom-radio custom-control-inline\">"),
                htmlHelper.RadioButton("customRadioInline1", "customRadioInline1",
                new {@class = "custom-control-input", @checked = true}),
                htmlHelper.Label("customRadioInline1", "Eraisik",
                new {@class = "custom-control-label"}),
                new HtmlString("</div>"),

                new HtmlString("<div class=\"custom-control custom-radio custom-control-inline\">"),
                htmlHelper.RadioButton("customRadioInline2", "customRadioInline2",
                new {@class = "custom-control-input"}),
                htmlHelper.Label("customRadioInline2", "Ettevõte",
                new {@class = "custom-control-label"}),
                new HtmlString("</div>"),

                new HtmlString("</div>"),
                new HtmlString("</div>")
            };

            return new HtmlContentBuilder(htmlStrings);
        }
    }
}
