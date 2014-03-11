using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace System.Web.Mvc
{
    public static class HtmlHelperExtensions
    {
        public static string ActiveMenu(this HtmlHelper html, string viewName)
        {
            string currentView = ((RazorView)html.ViewContext.View).ViewPath??"";

            return currentView.ToLower().Trim().Contains(viewName.Trim().ToLower()) ? "class=active" : "";
        }
    }
}