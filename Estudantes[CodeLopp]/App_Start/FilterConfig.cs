using System.Web;
using System.Web.Mvc;

namespace Estudantes_CodeLopp_
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
