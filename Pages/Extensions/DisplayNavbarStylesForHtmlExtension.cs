using Microsoft.AspNetCore.Mvc.Rendering;

namespace abc.Pages.Extensions
{
    public static class DisplayNavbarStylesForHtmlExtension
    {
        public static string ActiveClass(this IHtmlHelper htmlHelper, string route)
        {
            var routeData = htmlHelper.ViewContext.RouteData;

            var pageRoute = routeData.Values["page"].ToString();

            return route == pageRoute ? "active" : "";
        }
    }
}
