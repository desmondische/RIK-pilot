using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace abc.Pages.Extensions
{
    public static class DisplayControlsForHtmlExtension
    {
        public static IHtmlContent DisplayControlsFor<TClassType, TPropertyType>(
            this IHtmlHelper<TClassType> htmlHelper, Expression<Func<TClassType, TPropertyType>> expression)
        {
            var s = HtmlString(htmlHelper, expression);
            return new HtmlContentBuilder(s);
        }

        internal static List<object> HtmlString<TClassType, TPropertyType>(IHtmlHelper<TClassType> htmlHelper, Expression<Func<TClassType, TPropertyType>> expression)
        {
            return new List<object>
            {
                new HtmlString("<dt class=\"col-md-4\">"),
                htmlHelper.DisplayNameFor(expression),
                new HtmlString("</dt>"),
                new HtmlString("<dd class=\"col-md-8\">"),
                htmlHelper.DisplayFor(expression),
                new HtmlString("</dd>")
            };
        }
    }
}
