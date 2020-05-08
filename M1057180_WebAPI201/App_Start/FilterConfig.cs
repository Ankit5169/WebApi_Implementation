using System.Web;
using System.Web.Mvc;

namespace M1057180_WebAPI201
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
