using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace abc.Pages.Extensions
{
    public static class EditControlsForDropDownHtmlExtension
    {
        public static IHtmlContent EditControlsForDropDown<TModel, TResult>(
            this IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TResult>> expression,
            IEnumerable<SelectListItem> items)
        {

            var htmlStrings = new List<object> {
                new HtmlString("<div class=\"form-group row\">"),
                htmlHelper.LabelFor(expression, new {@class = "col-md-4 col-form-label"}),
                new HtmlString("<div class=\"col-md-7\">"),
                htmlHelper.DropDownListFor(expression, items, new {@class = "form-control"}),
                new HtmlString("</div>"),
                new HtmlString("</div>")
            };

            return new HtmlContentBuilder(htmlStrings);
        }

    }
}
