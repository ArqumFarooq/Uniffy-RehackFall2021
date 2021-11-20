using System.Web;
using System.Web.Mvc;

namespace WebApplication_Rehack_Fall_2021
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
