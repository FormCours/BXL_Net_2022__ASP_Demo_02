using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ASP_MVC_02_Formulaire.Helpers
{
    public static class CustomHtmlHelper
    {

        public static HtmlString DisplayYesNo(this IHtmlHelper htmlHelper, bool value)
        {
            string text = value ? "Oui" : "Non";
            return new HtmlString(text);
        }

    }
}
