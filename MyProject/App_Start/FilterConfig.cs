using System.Web.Mvc;

namespace MyProject
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());

            //Registration needed to advance.
            filters.Add(new AuthorizeAttribute());
        }
    }
}
