using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace abc.Pages.Extensions
{
    public static class EditControlsForHtmlExtension
    {
        public static IHtmlContent EditControlsFor<TClassType, TPropertyType>(
            this IHtmlHelper<TClassType> htmlHelper, Expression<Func<TClassType, TPropertyType>> expression, string type)
        {
            var s = HtmlString(htmlHelper, expression);
            var d = BHtmlString(htmlHelper, expression);
            var m = CHtmlString(htmlHelper, expression);

           
            switch (type)
            {
                default:
                    return new HtmlContentBuilder(s);
                case "textarea":
                    return new HtmlContentBuilder(d);
                case "custom-date":
                    return new HtmlContentBuilder(m);
            }
        }

        internal static List<object> HtmlString<TClassType, TPropertyType>(IHtmlHelper<TClassType> htmlHelper, Expression<Func<TClassType, TPropertyType>> expression)
        {
            return new List<object>
            {
                new HtmlString("<div class=\"form-group row\">"),
                htmlHelper.LabelFor(expression, new {@class = "col-md-4 col-form-label"}),
                new HtmlString("<div class=\"col-md-7\">"),
                htmlHelper.EditorFor(expression,
                    new {htmlAttributes = new {@class = "form-control", @required = true}}),
                new HtmlString("</div>"),
                new HtmlString("</div>")
            };
        }

        internal static List<object> BHtmlString<TClassType, TPropertyType>(IHtmlHelper<TClassType> htmlHelper, Expression<Func<TClassType, TPropertyType>> expression)
        {
            return new List<object>
            {
                new HtmlString("<div class=\"form-group row\">"),
                htmlHelper.LabelFor(expression, new {@class = "col-md-4 col-form-label"}),
                new HtmlString("<div class=\"col-md-7\">"),
                htmlHelper.TextAreaFor(expression, new {@class = "form-control", @rows = 2}),
                new HtmlString("</div>"),
                new HtmlString("</div>")
            };
        }

        internal static List<object> CHtmlString<TClassType, TPropertyType>(IHtmlHelper<TClassType> htmlHelper, Expression<Func<TClassType, TPropertyType>> expression)
        {
            return new List<object>
            {
                new HtmlString("<div class=\"form-group row\">"),
                htmlHelper.LabelFor(expression, new {@class = "col-md-4 col-form-label"}),
                new HtmlString("<div class=\"col-md-7\">"),
                new HtmlString("<div class=\"form-group\">"),
                new HtmlString("<div class=\"input-group date\" id=\"datetimepicker1\">"),
                htmlHelper.EditorFor(expression,
                    new {htmlAttributes = new {@class = "form-control", @type = "text", @required = true}}),
                new HtmlString("<div class=\"input-group-prepend\">"),
                new HtmlString("<span class=\"input-group-addon\">"),
                new HtmlString("<span class=\"input-group-text fa fa-calendar\"></span></span>"),
                new HtmlString("</div>"),
                new HtmlString("</div>"),
                new HtmlString("</div>"),
                new HtmlString("</div>"),
                new HtmlString("</div>")
            };
        }
    }
}
